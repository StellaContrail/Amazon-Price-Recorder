using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using AngleSharp;

namespace Amazon_Price_Recorder
{
    static class AmazonProductInformation
    {
        public static Task<AngleSharp.Dom.IDocument> GetDocument(string ASIN)
        {
            // Create WebRequest
            WebRequest wrGetURL;
            wrGetURL = WebRequest.Create("https://www.amazon.co.jp/dp/" + ASIN);
            // Obtain a Stream object 
            Stream objStream;
            objStream = wrGetURL.GetResponse().GetResponseStream();
            string source = "";
            using (StreamReader objReader = new StreamReader(objStream))
            {
                source = objReader.ReadToEnd();
            }
            var context = BrowsingContext.New(Configuration.Default);
            return context.OpenAsync(req => req.Content(source));
        }

        public static Product NativeData(AngleSharp.Dom.IDocument document, string ASIN)
        {
            // 商品名を抜き出す
            string productName = document.QuerySelector("#productTitle").TextContent.Trim();
            // 参考価格を抜き出す(存在しない場合有り)
            var referPriceNode = document.QuerySelector("#price .priceBlockStrikePriceString");
            int referPrice = -1;
            if (referPriceNode != null)
            {
                referPrice = referPriceNode.TextContent.PriceToValue();
            }
            // 商品画像
            string filePath = Environment.CurrentDirectory + "\\cache\\" + ASIN + ".jpg";
            if (File.Exists(filePath) == false)
            {
                string imageData = document.QuerySelector("#landingImage").GetAttribute("src").Trim();
                imageData = imageData.Remove(0, imageData.IndexOf("base64") + 7);
                Byte[] bytes = Convert.FromBase64String(imageData);
                using (var imageFile = new FileStream(Environment.CurrentDirectory + "\\cache\\" + ASIN + ".jpg", FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
            }
            return new Product(ASIN, productName, referPrice);
        }

        public static Product AcquiredData(AngleSharp.Dom.IDocument document, Product product)
        {
            // 現在価格を抜き出す
            var priceblock = document.QuerySelector("#priceblock_ourprice");
            int price = 0;
            if (priceblock != null)
            {
                price = priceblock.TextContent.PriceToValue();
            }
            // 割引価格を抜き出す(存在しない場合有り)
            var priceSavingNode = document.QuerySelector("#regularprice_savings > td.priceBlockSavingsString");
            int priceSaving = 0;
            if (priceSavingNode != null)
            {
                string _priceSaving = priceSavingNode.TextContent.Trim();
                Match match = Regex.Match(_priceSaving, @"￥\d{1,3}(,\d{1,3})*\b");
                priceSaving = match.Value.Substring(1).PriceToValue();
            }
            // 新品/中古品のクエリを読み出す(存在しない場合有り)
            var stocks = document.QuerySelectorAll("#olp_feature_div > div > span");
            // 新品のクエリだけを読み出し、在庫と最低価格を抜き出す(存在しない場合有り)
            var newStock = stocks.Where(x => x.QuerySelector("a").TextContent.IndexOf("新品") > -1);
            int newStockCount = 0;
            int newStockPrice = 0;
            if (newStock.Count() > 0)
            {
                newStockCount = Convert.ToInt32(newStock.First().QuerySelector("a").TextContent.Trim().Replace("新品の出品：", ""));
                newStockPrice = newStock.First().QuerySelector(".a-color-price").TextContent.Trim().PriceToValue();
            }
            // 中古品のクエリだけを読み出し、在庫と最低価格を抜き出す(存在しない場合有り)
            var usedStock = stocks.Where(x => x.QuerySelector("a").TextContent.IndexOf("中古品") > -1);
            int usedStockCount = 0;
            int usedStockPrice = 0;
            if (usedStock.Count() > 0)
            {
                usedStockCount = Convert.ToInt32(usedStock.First().QuerySelector("a").TextContent.Trim().Replace("中古品の出品：", ""));
                usedStockPrice = usedStock.First().QuerySelector(".a-color-price").TextContent.PriceToValue();
            }
            // Amazonからの出品が使用可能かどうか調べる
            string merchantText = document.QuerySelector("#merchant-info").TextContent;
            // 総合ランキング
            var rankInfo = document.QuerySelector("#SalesRank").ChildNodes[2];
            string ranking = rankInfo.TextContent.Trim();
            ranking = ranking.Remove(ranking.Length - 1, 1);
            // 商品在庫状態
            string status = document.QuerySelector("#availability > .a-size-medium.a-color-success").TextContent.Trim();

            // Amazon出品 > 新品 > 中古の順でpriceに代入する
            if (price == 0)
            {
                if (newStockPrice == 0)
                {
                    price = usedStockPrice;
                }
                else
                {
                    price = newStockPrice;
                }
            }

            product.Price = price;
            product.PriceHistory[DateTime.Now] = price;
            product.PriceSaving = priceSaving;
            product.SetStockInfo(newStockPrice, newStockCount, usedStockPrice, usedStockCount);
            product.MerchantStatus = merchantText.Status();
            product.Ranking = ranking;
            product.Status = status;

            return product;
        }
    }
}
