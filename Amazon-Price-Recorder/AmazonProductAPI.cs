using AngleSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AmazonProductAPI
{
    // 商品のAmazonからの出荷状態を表す列挙型
    public enum MerchantStatus
    {
        None, ShippingOnly, Both
    }

    static class Tools
    {
        // Amazon商品ページのbaseURL
        const string baseUrl = "https://www.amazon.co.jp/dp/";

        // 商品ページのHTMLを非同期的に取得する
        internal static Task<AngleSharp.Dom.IDocument> GetDocument(string ASIN)
        {
            HttpWebRequest wr = WebRequest.Create(baseUrl + ASIN) as HttpWebRequest;
            wr.CookieContainer = new CookieContainer();
            if (wr.SupportsCookieContainer == false)
            {
                return null;
            }
            var response = wr.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();

            string source = "";
            using (StreamReader sr = new StreamReader(stream))
            {
                source = sr.ReadToEnd();
            }
            var context = BrowsingContext.New(Configuration.Default) as IBrowsingContext;
            return context.OpenAsync(req => req.Content(source));
        }

        // ￥XXX,XXX の表記を XXXXXX に変換する
        public static int? PriceToValue(this string priceStr)
        {
            priceStr = priceStr.Trim().Replace("￥", "").Replace(",", "");
            if (Int32.TryParse(priceStr, out int priceInt))
            {
                return priceInt;
            }
            else
            {
                return null;
            }
        }

        // 商品のASINの妥当性を調べる
        public static bool CheckASINValidity(string ASIN)
        {
            // 10桁で無いなら弾く
            if (ASIN.Length != 10)
            {
                return false;
            }
            // 商品が存在するか調べる
            try
            {
                WebRequest wrGetURL = WebRequest.Create("https://www.amazon.co.jp/dp/" + ASIN);
            }
            catch (WebException ex)
            {
                HttpWebResponse error = ex.Response as HttpWebResponse;
                if (error.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
            }
            return true;
        }

        public async static Task<bool> DownloadProductImage(string ASIN, string imageFilePath, AngleSharp.Dom.IDocument document = null, CookieContainer cookies = null)
        {
            if (document == null)
            {
                if (cookies != null)
                {
                    document = await GetDocument(ASIN);
                }
                else
                {
                    return false;
                }
            }
            if (File.Exists(imageFilePath) == false)
            {
                string imageDataBase64 = document.QuerySelector("#landingImage").GetAttribute("src").Trim();
                imageDataBase64 = imageDataBase64.Remove(0, imageDataBase64.IndexOf("base64") + 7);
                Byte[] imageDataBytes = Convert.FromBase64String(imageDataBase64);
                using (var fileStream = new FileStream(imageFilePath, FileMode.Create))
                {
                    fileStream.Write(imageDataBytes, 0, imageDataBytes.Length);
                    fileStream.Flush();
                }
                return true;
            }
            return false;
        }
    }

    class ProductData
    {
        // Create Product with latest data
        public async Task<Product> Create(string ASIN, string cacheFolderPath)
        {
            // 商品ページのドキュメント
            AngleSharp.Dom.IDocument document = await Tools.GetDocument(ASIN);
            // 商品名
            string productName = document.QuerySelector("#productTitle").TextContent.Trim();
            // 元値
            var referencePriceNode = document.QuerySelector("#priceblock_ourprice");
            int? referencePrice = null;
            if (referencePriceNode != null)
            {
                referencePrice = referencePriceNode.TextContent.PriceToValue();
            }
            // 商品画像
            string imgFilePath = cacheFolderPath + ASIN + ".jpg";
            await Tools.DownloadProductImage(ASIN, imgFilePath, document);

            // 新しいProductインスタンスを作成する
            Product product = new Product(ASIN, productName, referencePrice);
            // 未設定のデータを設定する
            product = await Update(product, document);
            return product;
        }

        // 商品ページからAmazonからの出荷状況を調べる
        private MerchantStatus Status(string merchantInfo)
        {
            if (merchantInfo.IndexOf("Amazon.co.jp が販売、発送") > -1)
            {
                return MerchantStatus.Both;
            }
            if (merchantInfo.IndexOf("Amazon.co.jp が発送") > -1)
            {
                return MerchantStatus.ShippingOnly;
            }
            else
            {
                return MerchantStatus.None;
            }
        }

        // 商品ページのHTMLから商品の更新可能性のある情報を取得、更新する
        public async Task<Product> Update(Product product, AngleSharp.Dom.IDocument document = null)
        {
            // 新品/中古品のクエリを読み出す New/Used
            int newStockCount = 0;
            int? newStockPrice = null;
            int usedStockCount = 0;
            int? usedStockPrice = null;

            // ドキュメントが指定されていない場合、新しいドキュメントを取りに行く
            if (document == null)
            {
                document = await Tools.GetDocument(product.ASIN);
            }

            var stockNodes = document.QuerySelectorAll("#olp_feature_div > div > span:not(.a-color-base)");
            if (stockNodes.Length != 0)
            {
                foreach (var stockNode in stockNodes)
                {
                    // 新品のクエリだけを読み出し、在庫と最低価格を抜き出す(存在しない場合有り)
                    if (stockNode.QuerySelector("a").TextContent.IndexOf("新品の出品：") > -1)
                    {
                        var newStock = stockNode;
                        newStockCount = Convert.ToInt32(newStock.QuerySelector("a").TextContent.Trim().Replace("新品の出品：", ""));
                        newStockPrice = newStock.QuerySelector("span.a-color-price").TextContent.PriceToValue();
                    }

                    // 中古品のクエリだけを読み出し、在庫と最低価格を抜き出す(存在しない場合有り)
                    if (stockNode.QuerySelector("a").TextContent.IndexOf("中古品の出品：") > -1)
                    {
                        var usedStock = stockNode;
                        usedStockCount = Convert.ToInt32(usedStock.QuerySelector("a").TextContent.Trim().Replace("中古品の出品：", ""));
                        usedStockPrice = usedStock.QuerySelector("span.a-color-price").TextContent.PriceToValue();
                    }
                }
            }
            else
            {
                stockNodes = document.QuerySelectorAll("#olp_feature_div > div > a");
                if (stockNodes.Length != 0)
                {
                    // 取得エラー (在庫表記がおかしい)
                    newStockCount = -1;
                    newStockPrice = null;
                    usedStockCount = -1;
                    usedStockPrice = null;
                }
                else
                {
                    // 新品/中古品表記が無い = 在庫が無い
                    newStockCount = 0;
                    newStockPrice = null;
                    usedStockCount = 0;
                    usedStockPrice = null;
                }
            }



            // 現在価格を抜き出す
            var amazonPriceNode = document.QuerySelector("#priceblock_ourprice");
            int? amazonPrice = null;
            if (amazonPriceNode != null)
            {
                amazonPrice = amazonPriceNode.TextContent.PriceToValue();
            }

            // 割引価格を抜き出す(存在しない場合有り)
            var priceSavingNode = document.QuerySelector(".priceBlockSavingsString");
            int? priceSaving = null;
            if (priceSavingNode != null)
            {
                string _priceSaving = priceSavingNode.TextContent.Trim();
                // 割引価格から値のみ抜き出す
                Match match = Regex.Match(_priceSaving, @"￥\d{1,3}(,\d{1,3})*\b");
                priceSaving = match.Value.Substring(1).PriceToValue();
            }

            // Amazonからの出品が使用可能かどうか調べる
            string merchantText = document.QuerySelector("#merchant-info").TextContent;
            // 総合ランキング
            var rankInfo = document.QuerySelector("#SalesRank > .value").FirstChild;
            string ranking = rankInfo.TextContent.Trim();
            ranking = ranking.Remove(ranking.Length - 1, 1);
            // 商品在庫状態
            string status = document.QuerySelector("#availability > span").TextContent.Trim();

            // Amazon出品 > 新品 > 中古の順で表示する価格を決定する
            int? price = amazonPrice;
            if (amazonPrice == null)
            {
                if (newStockPrice == null)
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
            product.MerchantStatus = this.Status(merchantText);
            product.Ranking = ranking;
            product.Status = status;

            return product;
        }
    }
}
