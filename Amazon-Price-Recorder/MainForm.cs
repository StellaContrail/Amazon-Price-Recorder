using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Mail;

namespace Amazon_Price_Recorder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // 商品情報を格納する配列を宣言
        Product[] products = new Product[128];
        // 登録してある商品の数
        int productNum = 0;
        // キャッシュデータを入れておくディレクトリの絶対パス
        string cacheFolderPath = Environment.CurrentDirectory + "\\cache";
        // 設定情報を格納する変数を宣言
        Setting setting = null;
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // キャッシュフォルダーが存在するか確認。無かったら作成
            if (Directory.Exists(cacheFolderPath) == false)
            {
                Directory.CreateDirectory(cacheFolderPath);
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
                    if (products[i] == null)
                    {
                        break;
                    }
                    // ASINデータの取得
                    string ASIN = products[i].ASIN;
                    // 更新の必要があるデータを取得、代入する
                    products[i] = await AmazonProductAPI.UpdateProductData(products[i]);
                    // リストに登録した商品情報を追加する
                    productList.AddProduct(products[i]);
                    // 追加した商品数分インクリメントしておく
                    productNum++;
                    statusLabel.Text = productNum + " 個目まで読み込み完了";
                }
                statusLabel.Text = "読み込み完了";

                // 価格推移を表示するためのChartコントロールの初期化
                priceChart.Series.Clear();
                priceChart.ChartAreas.Clear();
                priceChart.Titles.Clear();
                // Chartのタイトル
                Title title = new Title("価格推移");
                // Chartの描画設定
                ChartArea area = new ChartArea();
                area.AxisX.Title = "取得順";
                area.AxisY.Title = "価格（円）";
                priceChart.Titles.Add(title);
                priceChart.ChartAreas.Add(area);

                // 読み込みが終わったら一番最初の商品を選択する/初期値を表示
                if (productNum > 0)
                {
                    productList.Items[0].Selected = true;
                    productList.Select();
                }
                else
                {
                    statusLabel.Text = "描画しています";
                    this.UpdateForm(new Product());
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
            timer.Interval = Convert.ToInt32(setting.Interval * 1000);
            timer.Start();
            statusLabel.Text = "準備完了  -  更新間隔は" + setting.Interval + " 秒です";
        }

        // フォームが閉じるときに商品情報のデータを保存する
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            statusLabel.Text = "商品情報および設定を保存しています";
            Extensions.Save(products, cacheFolderPath + "\\data.dat");
            statusLabel.Text = "保存終了";
        }

        // Listの選択が変わった時にプレビュー画面の情報を選択した商品のものにする
        int lastSelectedIndex = -1;
        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productList.SelectedItems.Count > 0)
            {
                int selectedIndex = productList.SelectedItems[0].Index;
                if (selectedIndex != lastSelectedIndex)
                {
                    lastSelectedIndex = selectedIndex;
                    this.UpdateForm(products[selectedIndex]);
                    DrawPriceHistory(products[selectedIndex]);
                }
            }
        }

        // 価格推移をChartに描画する
        private void DrawPriceHistory(Product product)
        {
            // 初期化と再設定
            priceChart.Series.Clear();
            Series seriesLine = new Series
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,

                LegendText = "価格",
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 5
            };
            foreach (KeyValuePair<DateTime, int> price in product.PriceHistory)
            {
                seriesLine.Points.AddXY(price.Key, price.Value);
            }
            DateTime dt = product.PriceHistory.OrderBy(x => x.Key).First().Key;
            var orderedPriceHistory = product.PriceHistory.OrderByDescending(x => x.Value);
            int maximumPrice = orderedPriceHistory.First().Value;
            int minimumPrice = orderedPriceHistory.Last().Value;
            priceChart.Series.Add(seriesLine);
            priceChart.ChartAreas[0].AxisY.Maximum = maximumPrice + 1000;
            priceChart.ChartAreas[0].AxisY.Minimum = minimumPrice - 1000;
            priceChart.ChartAreas[0].AxisY.Interval = 500;
            priceChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            priceChart.ChartAreas[0].AxisX.Minimum = dt.ToOADate();
            priceChart.ChartAreas[0].AxisX.Interval = 1;
        }

        // 商品名をクリックしたら商品ページを開くようにする
        private void label_productName_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("商品ページを開きますか？", "確認", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://www.amazon.co.jp/dp/" + label_ASIN.Text);
                statusLabel.Text = "商品ページを開きました";
            }
        }

        // 商品を削除する
        private void removeProductButton_Click(object sender, EventArgs e)
        {
            // リスト内で選択している商品があるか調べる
            if (productList.SelectedItems.Count > 0)
            {
                statusLabel.Text = "選択された商品情報を削除しています";
                int selectedIndex = productList.SelectedItems[0].Index;
                // 仮のProduct配列を作り、削除する商品を飛ばして代入することで
                // 削除する商品を抜かしてキューを作る
                Product[] _products = new Product[256];
                int j = 0;
                for (int i = 0; i < 256; i++)
                {
                    if (i != selectedIndex)
                    {
                        _products[j] = products[i];
                        j++;
                    }
                }
                // 削除する商品の画像をキャッシュから消す
                File.Delete(Environment.CurrentDirectory + "\\cache\\" + products[selectedIndex].ASIN + ".jpg");
                products = _products;
                // 登録してある商品数を減らす
                productNum--;
                // リストからも消す
                productList.Items.RemoveAt(selectedIndex);
                // 削除操作を行った後のプレビュー画面は初期値を表示する
                Product NullProduct = new Product();
                this.UpdateForm(NullProduct);
                DrawPriceHistory(NullProduct);
                statusLabel.Text = "選択された商品の削除を完了しました";
            }
        }

        // 通知を行う
        private void Nortificate(Product updatedProduct, string oldProductStatus)
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
                if (updatedProduct.thresholdPrice < updatedProduct.Price)
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
                if (updatedProduct.thresholdUsedStockcount < updatedProduct.UsedStockCount)
                {
                    nortificateItems[3] = true;
                    updatedProduct.whenUsedStockCountGoesDown = false;
                }
            }
            if (nortificateItems.Where(x => x).Count() > 0)
            {
                statusLabel.Text = "通知を行っています";
                // 通知を二度送らないようにトリガーがかかった通知設定をOFFにしておく
                this.UpdateForm(updatedProduct);
                // 更新したときに通知設定がOFFで読み込まれるように保存しておく
                Extensions.Save(products, cacheFolderPath + "\\data.dat");

                // ここに通知を送るシステムを書く
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(setting.Email, this.Text);
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

        private async void timer_Tick(object sender, EventArgs e)
        {
            statusLabel.Text = "更新しています";
            // 登録してある商品情報を更新する
            for (int i = 0; i < productNum; i++)
            {
                // スクレピングを行って更新すべきデータのみを更新する（NativeDataはそのまま）
                products[i] = await AmazonProductAPI.UpdateProductData(products[i]);
                // 一ヶ月前のデータは消去する
                Extensions.DeletePriceHistory(products[i], DateTime.Now.AddMonths(-1));
                statusLabel.Text = i + 1 + " 番目更新完了";
            }
            // 選択してあった商品情報のプレビュー画面を更新する
            if (productList.SelectedItems.Count > 0)
            {
                int selectedIndex = productList.SelectedItems[0].Index;
                this.UpdateForm(products[selectedIndex]);
                DrawPriceHistory(products[selectedIndex]);
            }
            statusLabel.Text = "更新完了";
        }

        bool isRefreshHalt = false;
        private void stopRefreshButton_Click(object sender, EventArgs e)
        {
            if (isRefreshHalt)
            {
                timer.Start();
                statusLabel.Text = "更新を再開しました";
                isRefreshHalt = false;
                stopRefreshButton.Text = "更新を停止する";
            }
            else
            {
                timer.Stop();
                statusLabel.Text = "更新を停止しています";
                isRefreshHalt = true;
                stopRefreshButton.Text = "更新を再開する";
            }
        }

        private void changeRefreshRateButton_Click(object sender, EventArgs e)
        {
            decimal tickSeconds = timer.Interval / 1000;
            RefreshRate_InputForm form = new RefreshRate_InputForm(tickSeconds);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                timer.Stop();
                timer.Interval = Convert.ToInt32(form.value * 1000);
                setting.Interval = form.value;
                Extensions.Save(setting, cacheFolderPath + "\\setting.dat");
                timer.Start();
                statusLabel.Text = "更新間隔を" + timer.Interval + " 秒に変更しました";
            }
        }

        private async void addProductButton_Click(object sender, EventArgs e)
        {
            // ASINを入力させるモーダルフォームを立ち上げる
            string ASIN = "";
            ASIN_InputForm form = new ASIN_InputForm();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                ASIN = form.value.Trim();
                // 有効なASINか調べる
                if (Extensions.CheckASINValidity(ASIN))
                {
                    statusLabel.Text = "商品情報を取得しています";
                    // 商品データを取得する
                    products[productNum] = await AmazonProductAPI.CreateProductData(ASIN);

                    // リストに追加する
                    productList.AddProduct(products[productNum]);
                    // 登録したので登録している商品数をインクリメントする
                    productNum++;

                    // 登録した商品にリスト中で選択する
                    productList.Items[productNum - 1].Selected = true;
                    productList.Select();
                    statusLabel.Text = "商品情報登録完了";
                }
                else
                {
                    MessageBox.Show("有効なASINではありません");
                }
            }
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            // 更新を一時的に停止する
            timer.Stop();
            statusLabel.Text = "更新しています";
            // 登録してある商品情報を更新する
            for (int i = 0; i < productNum; i++)
            {
                products[i] = await AmazonProductAPI.UpdateProductData(products[i]);
                // 一ヶ月前のデータは消去する
                Extensions.DeletePriceHistory(products[i], DateTime.Now.AddMonths(-1));
                statusLabel.Text = i + 1 + " 番目更新完了";
            }
            statusLabel.Text = "更新完了";
            timer.Start();
            // 選択してあった商品情報のプレビュー画面を更新する
            if (productList.SelectedItems.Count > 0)
            {
                int selectedIndex = productList.SelectedItems[0].Index;
                this.UpdateForm(products[selectedIndex]);
                DrawPriceHistory(products[selectedIndex]);
            }
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            Setting_InputForm form = new Setting_InputForm();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                decimal interval = setting.Interval;
                setting = form.settings;
                setting.Interval = interval;
                Extensions.Save(setting, cacheFolderPath + "\\setting.dat");
            }
        }

        private void saveSettingButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = productList.SelectedItems[0].Index;
            Product product = products[selectedIndex];
            product.whenStatusChanges = checkBox_statusChange.Checked;
            product.whenNewStockCountGoesDown = checkBox_newStockGoesDown.Checked;
            product.whenPriceGoesDown = checkBox_priceGoesDown.Checked;
            product.whenUsedStockCountGoesDown = checkBox_usedStockGoesDown.Checked;
            product.thresholdPrice = numericUpDown_priceThreshold.Value;
            product.thresholdNewStockCount = numericUpDown_newStockCountThreshold.Value;
            product.thresholdUsedStockcount = numericUpDown_usedStockCountThreshold.Value;
            // 通知設定はProductクラス内にあるためフォームを閉じる時と同じようにシリアライズ化して保存する
            Extensions.Save(products, cacheFolderPath + "\\data.dat");
            MessageBox.Show("保存しました");
            statusLabel.Text = "通知設定の保存終了";

        }
    }
}
