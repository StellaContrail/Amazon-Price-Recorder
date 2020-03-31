using AngleSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Amazon_Price_Recorder
{
    static class AmazonProductAPI
    {
        // Amazon商品ページのbaseURL
        const string baseUrl = "https://www.amazon.co.jp/dp/";
        // 商品ページのHTMLを非同期的に取得する
        public static Task<AngleSharp.Dom.IDocument> GetDocument(string ASIN)
        {
            WebRequest wr;
            wr = WebRequest.Create(baseUrl + ASIN);
            Stream stream;
            stream = wr.GetResponse().GetResponseStream();
            string source = "";
            using (StreamReader sr = new StreamReader(stream))
            {
                source = sr.ReadToEnd();
            }
            var context = BrowsingContext.New(Configuration.Default);
            return context.OpenAsync(req => req.Content(source));
        }

        // 商品ページのHTMLから商品の初期情報を取得する
        public async static Task<Product> CreateProductData(string ASIN)
        {
            AngleSharp.Dom.IDocument document = await GetDocument(ASIN);

            // 商品名
            string productName = document.QuerySelector("#productTitle").TextContent.Trim();
            // 参考価格
            var referPriceNode = document.QuerySelector("#price .priceBlockStrikePriceString");
            int referPrice = referPriceNode == null ? -1 : referPriceNode.TextContent.PriceToValue();
            // 商品画像
            string filePath = Environment.CurrentDirectory + "\\cache\\" + ASIN + ".jpg";
            if (File.Exists(filePath) == false)
            {
                string imageDataBase64 = document.QuerySelector("#landingImage").GetAttribute("src").Trim();
                imageDataBase64 = imageDataBase64.Remove(0, imageDataBase64.IndexOf("base64") + 7);
                Byte[] imageDataBytes = Convert.FromBase64String(imageDataBase64);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    fileStream.Write(imageDataBytes, 0, imageDataBytes.Length);
                    fileStream.Flush();
                }
            }

            Product product = new Product(ASIN, productName, referPrice);
            return await UpdateProductData(product, document);
        }

        // 商品ページのHTMLから商品の更新可能性のある情報を取得、更新する
        public async static Task<Product> UpdateProductData(Product product, AngleSharp.Dom.IDocument document = null)
        {
            if (document == null)
            {
                document = await GetDocument(product.ASIN);
            }

            // 現在価格を抜き出す
            var priceblockElement = document.QuerySelector("#priceblock_ourprice");
            int price = 0;
            if (priceblockElement != null)
            {
                price = priceblockElement.TextContent.PriceToValue();
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
