using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Amazon_Price_Recorder
{
    // 商品のAmazonからの出荷状態を表す列挙型
    public enum MerchantStatus
    {
        None, ShippingOnly, Both
    }

    static class Extensions
    {
        // ￥XXX,XXX の表記を XXXXXX に変換する
        public static int PriceToValue(this string price)
        {
            string value = price.Trim().Replace("￥", "").Replace(",", "");
            return Convert.ToInt32(value);
        }

        // 商品ページからAmazonからの出荷状況を調べる
        public static MerchantStatus Status(this string merchantInfo)
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

        // リストに商品を追加する
        public static void AddProduct(this ListView listView, Product product)
        {
            // 商品情報を格納する配列
            string[] item = new string[4];
            item[0] = product.Name;
            // 一番安い価格を取り出して格納する
            int[] prices = { product.Price, product.NewStockPrice, product.UsedStockPrice };
            item[1] = "￥" + prices.Where(x => x != 0).OrderBy(x => x).First().ToString();
            // 在庫情報
            item[2] = product.NewStockCount + "/" + product.UsedStockCount;
            // Amazonからの出品の有無
            item[3] = product.MerchantStatus == MerchantStatus.Both ? "有り" : "無し";
            // リストに追加する
            listView.Items.Add(new ListViewItem(item));
        }

        // 商品情報表示のための初期設定を行う
        public static void UpdateForm(this MainForm form, Product product)
        {
            form.label_ASIN.Text = product.ASIN;
            form.label_productName.Text = product.Name;
            form.label_Amazon_price.Text = "￥" + product.Price.ToString();
            form.label_reference_price.Text = "￥" + product.ReferencePrice.ToString();
            form.label_newStock.Text = product.NewStockCount.ToString() + "　個";
            form.label_usedStock.Text = product.UsedStockCount.ToString() + "　個";
            form.label_ranking.Text = product.Ranking;
            form.label_status.Text = product.Status;
            if (product.PriceSaving == 0)
            {
                form.label_Amazon_pricecut.Text = "割引無し";
            }
            else
            {
                form.label_Amazon_pricecut.Text = "￥" + product.PriceSaving + " OFF";
            }
            string product_image_path = Environment.CurrentDirectory + "\\cache\\" + product.ASIN + ".jpg";
            if (File.Exists(product_image_path))
            {
                form.pictureBox_product.ImageLocation = product_image_path;
            }
            form.checkBox_statusChange.Checked = product.whenStatusChanges;
            form.checkBox_newStockGoesDown.Checked = product.whenNewStockCountGoesDown;
            form.checkBox_priceGoesDown.Checked = product.whenPriceGoesDown;
            form.checkBox_usedStockGoesDown.Checked = product.whenUsedStockCountGoesDown;
            form.numericUpDown_priceThreshold.Value = product.thresholdPrice;
            form.numericUpDown_newStockCountThreshold.Value = product.thresholdNewStockCount;
            form.numericUpDown_usedStockCountThreshold.Value = product.thresholdUsedStockcount;
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
