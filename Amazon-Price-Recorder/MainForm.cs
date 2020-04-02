// TODO: リファクタリング

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Mail;
using AmazonProductAPI;
using System.Threading.Tasks;

namespace Amazon_Price_Recorder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // 商品情報を格納する配列を宣言
        Product[] products;
        // 登録してある商品の数
        int productNum = 0;
        // キャッシュデータを入れておくディレクトリの絶対パス
        string cacheFolderPath = Environment.CurrentDirectory + "\\cache\\";
        // 設定情報を格納する変数を宣言
        Setting setting = new Setting();
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // キャッシュフォルダーが存在するか確認。無かったら作成
            if (Directory.Exists(cacheFolderPath) == false)
            {
                Directory.CreateDirectory(cacheFolderPath);
            }

            products = new Product[128];
            for (int i = 0; i < 128; i++)
            {
                products[i] = new Product();
            }

            // 以前に取得した商品情報が存在するか確認
            string dataFilePath = cacheFolderPath + "\\data.dat";
            if (File.Exists(dataFilePath))
            {
                // 保存してある商品情報の読み込み
                statusLabel.Text = "保存した商品情報を読み込んでいます";
                products = Extensions.Read(dataFilePath) as Product[];
                // 登録できる上限までループを回す
                for (int i = 0; i < 128; i++)
                {
                    // 登録してないところまで行ったらループを止める
                    if (products[i].ASIN == "")
                    {
                        break;
                    }
                    // ASINデータの取得
                    string ASIN = products[i].ASIN;
                    // 更新の必要があるデータを取得、代入する
                    products[i] = await ProductData.Update(products[i]);
                    // リストに登録した商品情報を追加する
                    ProductList.AddProduct(products[i]);
                    // 追加した商品数分インクリメントしておく
                    productNum++;
                    statusLabel.Text = productNum + " 個目まで読み込み完了";
                }
                statusLabel.Text = "読み込み完了";

                // 価格推移を表示するためのChartコントロールの初期化
                PriceChart.Series.Clear();
                PriceChart.ChartAreas.Clear();
                PriceChart.Titles.Clear();
                // Chartのタイトル
                Title title = new Title("価格推移");
                // Chartの描画設定
                ChartArea area = new ChartArea();
                area.AxisX.Title = "取得順";
                area.AxisY.Title = "価格（円）";
                PriceChart.Titles.Add(title);
                PriceChart.ChartAreas.Add(area);

                // 読み込みが終わったら一番最初の商品を選択する/初期値を表示
                if (productNum > 0)
                {
                    ProductList.Items[0].Selected = true;
                    ProductList.Select();
                }
                else
                {
                    statusLabel.Text = "描画しています";
                    await DrawProductInformation(new Product(), cacheFolderPath);
                    DrawPriceHistory(new Product());
                }
            }

            // 以前に作成した設定データがあるか調べる
            string settingFilePath = cacheFolderPath + "\\setting.dat";
            int refreshRateInSeconds = 120;
            if (File.Exists(settingFilePath))
            {
                setting = Extensions.Read(settingFilePath) as Setting;
            }
            else
            {
                setting = new Setting("", "", "", refreshRateInSeconds);
                Extensions.Save(setting, settingFilePath);
            }

            // タイマーをスタートする
            Timer.Interval = Convert.ToInt32(setting.Interval * 1000);
            Timer.Start();
            statusLabel.Text = "準備完了  -  更新間隔は" + setting.Interval + " 秒です";
        }

        // フォームが閉じるときに商品情報のデータを保存する
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            statusLabel.Text = "商品情報および設定を保存しています";
            Extensions.Save(products, cacheFolderPath + "data.dat");
            statusLabel.Text = "保存終了";
        }

        // Listの選択が変わった時にプレビュー画面の情報を選択した商品のものにする
        int lastSelectedIndex = -1;
        private async void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductList.SelectedItems.Count > 0)
            {
                int selectedIndex = ProductList.SelectedItems[0].Index;
                if (selectedIndex != lastSelectedIndex)
                {
                    lastSelectedIndex = selectedIndex;
                    await DrawProductInformation(products[selectedIndex], cacheFolderPath);
                    DrawPriceHistory(products[selectedIndex]);
                }
            }
        }

        // 価格推移をChartに描画する
        private void DrawPriceHistory(Product product)
        {
            // 初期化と再設定
            PriceChart.Series.Clear();
            Series seriesLine = new Series
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,

                LegendText = "価格",
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 5
            };
            foreach (KeyValuePair<DateTime, int?> price in product.PriceHistory)
            {
                if (price.Value != null)
                {
                    seriesLine.Points.AddXY(price.Key, price.Value);
                }
            }
            var orderedPriceHistory = product.PriceHistory.Where(x => x.Value != null).OrderByDescending(x => x.Value);
            int priceRecordsCount = orderedPriceHistory.Count();
            int maximumPrice = priceRecordsCount > 0 ? (int)orderedPriceHistory.First().Value : 1000;
            int minimumPrice = priceRecordsCount > 0 ? (int)orderedPriceHistory.Last().Value : 1000;
            PriceChart.Series.Add(seriesLine);
            PriceChart.ChartAreas[0].AxisY.Maximum = maximumPrice + 1000;
            PriceChart.ChartAreas[0].AxisY.Minimum = minimumPrice - 1000;
            PriceChart.ChartAreas[0].AxisX.Title = "日付";
            PriceChart.ChartAreas[0].AxisY.Title = "価格(円)";
            PriceChart.ChartAreas[0].AxisY.Interval = 500;
            PriceChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            DateTime dt = priceRecordsCount > 0 ? product.PriceHistory.OrderBy(x => x.Key).First().Key : DateTime.Now;
            PriceChart.ChartAreas[0].AxisX.Minimum = dt.ToOADate();
            PriceChart.ChartAreas[0].AxisX.Interval = 1;
        }

        // 商品名をクリックしたら商品ページを開くようにする
        private void Label_productName_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("商品ページを開きますか？", "確認", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://www.amazon.co.jp/dp/" + Label_ASIN.Text);
                statusLabel.Text = "商品ページを開きました";
            }
        }

        // 商品を削除する
        private async void RemoveProductButton_Click(object sender, EventArgs e)
        {
            // リスト内で選択している商品があるか調べる
            if (ProductList.SelectedItems.Count > 0)
            {
                DisableAllButtons();
                statusLabel.Text = "選択された商品情報を削除しています";
                int selectedIndex = ProductList.SelectedItems[0].Index;
                // 仮のProduct配列を作り、削除する商品を飛ばして代入することで
                // 削除する商品を抜かしてキューを作る
                Product[] _products = new Product[128];
                for (int i = 0; i < 128; i++)
                {
                    _products[i] = new Product();
                }
                int j = 0;
                for (int i = 0; i < 128; i++)
                {
                    if (i != selectedIndex)
                    {
                        _products[j] = products[i];
                        j++;
                    }
                }
                // 削除する商品の画像をキャッシュから消す
                File.Delete(cacheFolderPath + products[selectedIndex].ASIN + ".jpg");
                products = _products;
                Extensions.Save(products, cacheFolderPath + "data.dat");
                // 登録してある商品数を減らす
                productNum--;
                // リストからも消す
                ProductList.Items.RemoveAt(selectedIndex);
                // 削除操作を行った後は初期状態を表示
                Product NullProduct = new Product();
                await DrawProductInformation(NullProduct, cacheFolderPath);
                DrawPriceHistory(NullProduct);
                statusLabel.Text = "選択された商品の削除を完了しました";
                EnabledAllButtons();
            }
        }

        // 通知を行う
        private async void Nortify(Product updatedProduct, string oldProductStatus)
        {
            // 通知を送るべき項目がtrueになる
            bool[] nortificateItems = new bool[4];
            if (updatedProduct.whenStatusChanges)
            {
                if (updatedProduct.Status != oldProductStatus)
                {
                    nortificateItems[0] = true;
                    updatedProduct.whenStatusChanges = false;
                }
            }
            if (updatedProduct.whenPriceGoesDown)
            {
                if (updatedProduct.Price != null && updatedProduct.thresholdPrice < updatedProduct.Price)
                {
                    nortificateItems[1] = true;
                    updatedProduct.whenPriceGoesDown = false;
                }
            }
            if (updatedProduct.whenNewStockCountGoesDown)
            {
                if (updatedProduct.thresholdNewStockCount < updatedProduct.NewStockCount)
                {
                    nortificateItems[2] = true;
                    updatedProduct.whenNewStockCountGoesDown = false;
                }
            }
            if (updatedProduct.whenUsedStockCountGoesDown)
            {
                if (updatedProduct.thresholdUsedStockCount < updatedProduct.UsedStockCount)
                {
                    nortificateItems[3] = true;
                    updatedProduct.whenUsedStockCountGoesDown = false;
                }
            }
            if (nortificateItems.Where(x => x == true).Count() > 0)
            {
                statusLabel.Text = "通知を行っています";
                // 通知を二度送らないようにトリガーがかかった通知設定をOFFにしておく
                await DrawProductInformation(updatedProduct, cacheFolderPath);
                Extensions.Save(products, cacheFolderPath + "\\data.dat");

                // ここに通知を送るシステムを書く
                MailMessage msg = new MailMessage
                {
                    From = new MailAddress(setting.Email, Text)
                };
                msg.To.Add(new MailAddress(setting.Id + "@gmail.com", setting.Id));
                msg.Subject = "商品情報に変化がありました";
                msg.Body = "変化があったのは次の項目です\n\n";
                if (nortificateItems[0])
                {
                    msg.Body += "・Amazon.co.jp の在庫状況に変化がありました\n";
                }
                if (nortificateItems[1])
                {
                    msg.Body += "・値段が設定した値を下回りました\n";
                }
                if (nortificateItems[2])
                {
                    msg.Body += "・新品の在庫が設定した値を下回りました\n";
                }
                if (nortificateItems[3])
                {
                    msg.Body += "・中古品の在庫が設定した値を下回りました\n";
                }

                SmtpClient sc = new SmtpClient();

                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.Credentials = new System.Net.NetworkCredential(setting.Email + "@gmail.com", setting.Pass);
                sc.EnableSsl = true;

                sc.Send(msg);
                msg.Dispose();

                statusLabel.Text = "通知完了";
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (productNum < 1)
            {
                return;
            }
            statusLabel.Text = "更新しています";
            // 登録してある商品情報を更新する
            for (int i = 0; i < productNum; i++)
            {
                string oldProductStatus = products[i].Status;
                // スクレピングを行って更新すべきデータのみを更新する（NativeDataはそのまま）
                products[i] = await ProductData.Update(products[i]);
                Nortify(products[i], oldProductStatus);
                // 12ヶ月前のデータは消去する
                Extensions.DeletePriceHistory(products[i], DateTime.Now.AddMonths(-12));
                statusLabel.Text = i + 1 + " 番目更新完了";
            }
            // 選択してあった商品情報のプレビュー画面を更新する
            if (ProductList.SelectedItems.Count > 0)
            {
                int selectedIndex = ProductList.SelectedItems[0].Index;
                await DrawProductInformation(products[selectedIndex], cacheFolderPath);
                DrawPriceHistory(products[selectedIndex]);
            }
            statusLabel.Text = "更新完了";
        }

        bool isRefreshHalt = false;
        private void StopRefreshButton_Click(object sender, EventArgs e)
        {
            if (isRefreshHalt)
            {
                Timer.Start();
                statusLabel.Text = "更新を再開しました";
                isRefreshHalt = false;
                StopRefreshButton.Text = "更新を停止する";
            }
            else
            {
                Timer.Stop();
                statusLabel.Text = "更新を停止しています";
                isRefreshHalt = true;
                StopRefreshButton.Text = "更新を再開する";
            }
        }

        private void ChangeRefreshRateButton_Click(object sender, EventArgs e)
        {
            decimal tickSeconds = Timer.Interval / 1000;
            RefreshRate_InputForm form = new RefreshRate_InputForm(tickSeconds);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Timer.Stop();
                Timer.Interval = Convert.ToInt32(form.value * 1000);
                setting.Interval = form.value;
                Extensions.Save(setting, cacheFolderPath + "\\setting.dat");
                Timer.Start();
                statusLabel.Text = "更新間隔を" + Timer.Interval + " 秒に変更しました";
            }
        }

        private async void AddProductButton_Click(object sender, EventArgs e)
        {
            // ASINを入力させるモーダルフォームを立ち上げる
            string ASIN = "";
            ASIN_InputForm form = new ASIN_InputForm();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                ASIN = form.value.Trim();
                // 有効なASINか調べる
                if (Tools.CheckASINValidity(ASIN))
                {
                    DisableAllButtons();
                    statusLabel.Text = "商品情報を取得しています";
                    // 商品データを取得する
                    products[productNum] = await ProductData.Create(ASIN, cacheFolderPath);

                    // リストに追加する
                    ProductList.AddProduct(products[productNum]);
                    // 登録したので登録している商品数をインクリメントする
                    productNum++;

                    // 登録した商品にリスト中で選択する
                    ProductList.Items[productNum - 1].Selected = true;
                    ProductList.Select();
                    if (productNum == 1)
                    {
                        await DrawProductInformation(products[productNum - 1], cacheFolderPath);
                        DrawPriceHistory(products[productNum - 1]);
                    }
                    statusLabel.Text = "商品情報登録完了";
                    EnabledAllButtons();
                }
                else
                {
                    MessageBox.Show("有効なASINではありません");
                }
            }
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            // 更新を一時的に停止する
            Timer.Stop();
            statusLabel.Text = "更新しています";
            // 登録してある商品情報を更新する
            for (int i = 0; i < productNum; i++)
            {
                products[i] = await ProductData.Update(products[i]);
                // 一ヶ月前のデータは消去する
                Extensions.DeletePriceHistory(products[i], DateTime.Now.AddMonths(-1));
                statusLabel.Text = i + 1 + " 番目更新完了";
            }
            statusLabel.Text = "更新完了";
            Timer.Start();
            // 選択してあった商品情報のプレビュー画面を更新する
            if (ProductList.SelectedItems.Count > 0)
            {
                int selectedIndex = ProductList.SelectedItems[0].Index;
                await DrawProductInformation(products[selectedIndex], cacheFolderPath);
                DrawPriceHistory(products[selectedIndex]);
            }
        }

        private void SettingButton_Click(object sender, EventArgs e)
        {
            Setting_InputForm form = new Setting_InputForm(setting);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK && form.newSetting != null)
            {
                decimal interval = setting.Interval;
                setting = form.newSetting;
                setting.Interval = interval;
                Extensions.Save(setting, cacheFolderPath + "\\setting.dat");
            }
        }

        private void SaveSettingButton_Click(object sender, EventArgs e)
        {
            if (setting.Email == "" || setting.Id == "" || setting.Pass == "")
            {
                MessageBox.Show("通知設定が設定されていません。メニューバーから設定してください。");
                return;
            }
            int selectedIndex = ProductList.SelectedItems[0].Index;
            Product product = products[selectedIndex];
            product.whenStatusChanges = CheckBox_statusChange.Checked;
            product.whenNewStockCountGoesDown = CheckBox_newStockGoesDown.Checked;
            product.whenPriceGoesDown = CheckBox_priceGoesDown.Checked;
            product.whenUsedStockCountGoesDown = CheckBox_usedStockGoesDown.Checked;
            product.thresholdPrice = NumericUpDown_priceThreshold.Value;
            product.thresholdNewStockCount = NumericUpDown_newStockCountThreshold.Value;
            product.thresholdUsedStockCount = NumericUpDown_usedStockCountThreshold.Value;
            // 通知設定はProductクラス内にあるためフォームを閉じる時と同じようにシリアライズ化して保存する
            Extensions.Save(products, cacheFolderPath + "\\data.dat");
            MessageBox.Show("保存しました");
            statusLabel.Text = "通知設定の保存終了";

        }

        // 商品情報表示のための初期設定を行う
        private async Task<bool> DrawProductInformation(Product product, string cacheFolderPath)
        {
            Label_ASIN.Text = product.ASIN;
            Label_productName.Text = product.Name;
            int? price = product.Price;
            Label_Amazon_price.Text = price == null ? "在庫切れ" : "￥" + price.ToString();
            int? referencePrice = product.ReferencePrice;
            Label_reference_price.Text = referencePrice == null ? "未設定" : "￥" + referencePrice.ToString();
            int newStockCount = product.NewStockCount;
            Label_newStock.Text = newStockCount < 1 ? "無し" : newStockCount.ToString() + "　個";
            int usedStockCount = product.UsedStockCount;
            Label_usedStock.Text = usedStockCount < 1 ? "無し" : product.UsedStockCount.ToString() + "　個";
            Label_ranking.Text = product.Ranking;
            Label_status.Text = product.Status;
            int? priceSaving = product.PriceSaving;
            Label_Amazon_pricecut.Text = priceSaving == null ? "割引なし" : priceSaving.ToString() + " OFF";
            string productImageFilePath = cacheFolderPath + product.ASIN + ".jpg";
            PictureBox_product.ImageLocation = null;
            if (File.Exists(productImageFilePath))
            {
                PictureBox_product.ImageLocation = productImageFilePath;
            }
            else if (product.ASIN != "")
            {
                if (await Tools.DownloadProductImage(product.ASIN, productImageFilePath))
                {
                    PictureBox_product.ImageLocation = productImageFilePath;
                }
            }
            CheckBox_statusChange.Checked = product.whenStatusChanges;
            CheckBox_newStockGoesDown.Checked = product.whenNewStockCountGoesDown;
            CheckBox_priceGoesDown.Checked = product.whenPriceGoesDown;
            CheckBox_usedStockGoesDown.Checked = product.whenUsedStockCountGoesDown;
            NumericUpDown_priceThreshold.Value = product.thresholdPrice;
            NumericUpDown_newStockCountThreshold.Value = product.thresholdNewStockCount;
            NumericUpDown_usedStockCountThreshold.Value = product.thresholdUsedStockCount;
            return true;
        }

        private void ChangeButtonStatus(bool? isAddButtonEnabled = null, bool? isRemoveButtonEnabled = null, bool? isChangeRefreshButtonEnabled = null,
            bool? isStopRefreshButtonEnabled = null, bool? isForcelyRefreshButtonEnabled = null, bool? isSettingButtonEnabled = null)
        {
            AddProductButton.Enabled = isAddButtonEnabled ?? AddProductButton.Enabled;
            RemoveProductButton.Enabled = isRemoveButtonEnabled ?? RemoveProductButton.Enabled;
            ChangeRefreshRateButton.Enabled = isChangeRefreshButtonEnabled ?? ChangeRefreshRateButton.Enabled;
            StopRefreshButton.Enabled = isStopRefreshButtonEnabled ?? StopRefreshButton.Enabled;
            RefreshButton.Enabled = isForcelyRefreshButtonEnabled ?? RefreshButton.Enabled;
            SettingButton.Enabled = isSettingButtonEnabled ?? SettingButton.Enabled;
        }

        private void EnabledAllButtons()
        {
            ChangeButtonStatus(true, true, true, true, true, true);
        }

        private void DisableAllButtons()
        {
            ChangeButtonStatus(false, false, false, false, false, false);
        }
    }
}
