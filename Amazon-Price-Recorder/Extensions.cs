using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AmazonProductAPI;

namespace Amazon_Price_Recorder
{
    static class Extensions
    {
        // データをシリアライズして保存する
        public static void Save(object obj, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
        }

        // データをデシリアライズして開く
        public static object Read(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(fs);
            }
        }

        // リストに商品を追加する
        public static void AddProduct(this ListView listView, Product product)
        {
            // 商品情報を格納する配列
            string[] item = new string[4];
            item[0] = product.Name;
            // 一番安い価格を取り出して格納する
            int?[] prices = { product.Price, product.NewStockPrice, product.UsedStockPrice };
            var validPriceNodes = prices.Where(x => x != null);
            if (validPriceNodes.Count() > 0)
            {
                item[1] = "￥" + validPriceNodes.OrderBy(x => x).First().ToString();
            }
            else
            {
                item[1] = "在庫切れ";
            }
            // 在庫情報
            if (product.NewStockCount >= 0 || product.UsedStockCount >= 0)
            {
                item[2] = product.NewStockCount + "/" + product.UsedStockCount;
            }
            else
            {
                item[2] = "取得エラー";
            }
            // Amazonからの出品の有無
            item[3] = product.MerchantStatus == MerchantStatus.Both ? "有り" : "無し";
            // リストに追加する
            listView.Items.Add(new ListViewItem(item));
        }

        // リストの商品情報を変更する
        public static void UpdateProduct(this ListView listView, int index, Product product)
        {
            // 一番安い価格を取り出して格納する
            int?[] prices = { product.Price, product.NewStockPrice, product.UsedStockPrice };
            var validPriceNodes = prices.Where(x => x != null);
            if (validPriceNodes.Count() > 0)
            {
                listView.Items[index].SubItems[1].Text = "￥" + validPriceNodes.OrderBy(x => x).First().ToString();
            }
            else
            {
                listView.Items[index].SubItems[1].Text = "在庫切れ";
            }
            // 在庫情報
            if (product.NewStockCount >= 0 || product.UsedStockCount >= 0)
            {
                listView.Items[index].SubItems[2].Text = product.NewStockCount + "/" + product.UsedStockCount;
            }
            else
            {
                listView.Items[index].SubItems[2].Text = "取得エラー";
            }
            // Amazonからの出品の有無
            listView.Items[index].SubItems[3].Text = product.MerchantStatus == MerchantStatus.Both ? "有り" : "無し";
        }

        // タイマーに間隔を秒数で設定する
        public static void SetInterval(this Timer timer, decimal seconds)
        {
            timer.Interval = (int)(seconds * 1000);
        }


        // DateTime < dt の古い PriceHistory を削除する
        public static void DeletePriceHistory(Product product, DateTime dt)
        {
            product.PriceHistory = product.PriceHistory
                .Where(x => x.Key > dt)
                .ToDictionary(item => item.Key, item => item.Value);
        }
    }
}
