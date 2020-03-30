using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Amazon_Price_Recorder
{
    public enum MerchantStatus : int
    {
        None, ShippingOnly, Both
    }

    static class Extensions
    {
        public static int PriceToValue(this string price)
        {
            string value = price.Trim().Replace("￥", "").Replace(",", "");
            return Convert.ToInt32(value);
        }

        
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

        public static void Save(object obj, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
        }

        public static object Read(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(fs);
            }
        }

        public static bool CheckASINValidity(string ASIN)
        {
            if (ASIN.Length != 10)
            {
                return false;
            }
            WebRequest wrGetURL;
            try
            {
                wrGetURL = WebRequest.Create("https://www.amazon.co.jp/dp/" + ASIN);
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

        public static void AddProduct(this ListView listView, Product product)
        {
            // listViewに追加する
            string[] item = new string[4];
            item[0] = product.Name;
            int[] prices = { product.Price, product.NewStockPrice, product.UsedStockPrice };
            item[1] = "￥" + prices.Where(x => x != 0).OrderByDescending(x => x).First().ToString();
            item[2] = product.NewStockCount + "/" + product.UsedStockCount;
            item[3] = product.MerchantStatus == MerchantStatus.Both ? "有り" : "無し";
            listView.Items.Add(new ListViewItem(item));
        }

        public static void UpdateForm(this Form1 form, Product product)
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
            form.pictureBox_product.ImageLocation = Environment.CurrentDirectory + "\\cache\\" + product.ASIN + ".jpg";
            form.checkBox_statusChange.Checked = product.whenStatusChanges;
            form.checkBox_newStockGoesDown.Checked = product.whenNewStockCountGoesDown;
            form.checkBox_priceGoesDown.Checked = product.whenPriceGoesDown;
            form.checkBox_usedStockGoesDown.Checked = product.whenUsedStockCountGoesDown;
            form.numericUpDown_priceThreshold.Value = product.thresholdPrice;
            form.numericUpDown_newStockCountThreshold.Value = product.thresholdNewStockCount;
            form.numericUpDown_usedStockCountThreshold.Value = product.thresholdUsedStockcount;
        }

        // DateTime dt以前の古いPriceHistoryを削除する
        public static void DeletePriceHistory(Product product, DateTime dt)
        {
            product.PriceHistory = product.PriceHistory.Where(x => x.Key > dt).ToDictionary(item => item.Key, item => item.Value);
        }
    }
}
