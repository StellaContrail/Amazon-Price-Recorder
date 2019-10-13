using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Mail;

namespace Amazon_Price_Recorder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 商品情報を格納する配列を宣言
        Product[] products = new Product[256];
        // 登録してある商品の数
        int productNum = 0;
        // キャッシュデータを入れておくディレクトリの絶対パス
        string cacheFolderPath = Environment.CurrentDirectory + "\\cache";
        // 設定情報を格納する変数を宣言
        Settings settings = null;
        private async void Form1_Load(object sender, EventArgs e)
        {
            // キャッシュフォルダーが存在するか確認。無かったら作成
            if (Directory.Exists(cacheFolderPath) == false)
            {
                Directory.CreateDirectory(cacheFolderPath);
            }

            // 以前に取得した商品情報が存在するか確認
            if (File.Exists(cacheFolderPath + "\\data.dat"))
            {
                // 保存してある商品情報の読み込み
                toolStripStatusLabel.Text = "保存した商品情報を読み込んでいます";
                products = Extensions.Read(cacheFolderPath + "\\data.dat") as Product[];
                // 登録できる上限(256個)までループを回す
                for (int i = 0; i < 256; i++)
                {
                    // 登録してないところ(有効的上限)まで行ったらループを止める
                    if (products[i] == null)
                    {
                        break;
                    }
                    // ASINデータの取得
                    string ASIN = products[i].ASIN;

                    // スクレイピングを行うためのDocumentの取得
                    var document = await AmazonProductInformation.GetDocument(ASIN);
                    // 更新の必要があるデータを取得、代入する
                    products[i] = AmazonProductInformation.AcquiredData(document, products[i]);
                    // リストに登録した商品情報を追加する
                    listView1.AddProduct(products[i]);
                    // 追加した商品数分インクリメントしておく
                    productNum++;
                    toolStripStatusLabel.Text = productNum + " 個目まで読み込み完了";
                }
                toolStripStatusLabel.Text = "読み込み完了";

                // 価格推移を表示するためのChartコントロールの初期化
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Titles.Clear();
                // Chartのタイトル
                Title title = new Title("価格推移");
                // Chartの描画設定
                ChartArea area = new ChartArea();
                area.AxisX.Title = "取得順";
                area.AxisY.Title = "価格（円）";
                chart1.Titles.Add(title);
                chart1.ChartAreas.Add(area);

                // 読み込みが終わったら一番最初の商品を選択する/初期値を表示
                if (productNum > 0)
                {
                    listView1.Items[0].Selected = true;
                    listView1.Select();
                }
                else
                {
                    toolStripStatusLabel.Text = "描画しています";
                    this.UpdateForm(new Product());
                    DrawPriceHistory(new Product());
                }
            }

            // 以前に作成した設定データがあるか調べる
            if (File.Exists(cacheFolderPath + "\\setting.dat"))
            {
                settings = Extensions.Read(cacheFolderPath + "\\setting.dat") as Settings;
            }
            else
            {
                settings = new Settings("", "", "", 60000);
                Extensions.Save(settings, cacheFolderPath + "\\setting.dat");
            }

            // タイマーをスタートする
            timer1.Interval = Convert.ToInt32(settings.interval);
            timer1.Start();
            toolStripStatusLabel.Text = "準備完了 更新間隔は" + settings.interval / 1000 + " 秒です";
        }

        // 商品の追加を行う
        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            // ASINを入力させるモーダルフォームを立ち上げる
            string ASIN = "";
            ASIN_InputForm form = new ASIN_InputForm();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                ASIN = form.value;
                // 有効なASINか調べる
                if (Extensions.CheckASINValidity(ASIN))
                {
                    toolStripStatusLabel.Text = "商品情報を取得しています";
                    // スクレイピングを行うためのDocumentの取得
                    var document = await AmazonProductInformation.GetDocument(ASIN);
                    // 商品データを取得する
                    products[productNum] = AmazonProductInformation.NativeData(document, ASIN);
                    products[productNum] = AmazonProductInformation.AcquiredData(document, products[productNum]);

                    // リストに追加する
                    listView1.AddProduct(products[productNum]);
                    // 登録したので登録している商品数をインクリメントする
                    productNum++;

                    // 登録した商品にリスト中で選択する
                    listView1.Items[productNum - 1].Selected = true;
                    listView1.Select();
                    toolStripStatusLabel.Text = "商品情報登録完了";
                }
                else
                {
                    MessageBox.Show("有効なASINではありません");
                }
            }
        }

        // フォームが閉じるときに商品情報のデータを保存する
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            toolStripStatusLabel.Text = "商品情報および設定を保存しています";
            Extensions.Save(products, cacheFolderPath + "\\data.dat");
            toolStripStatusLabel.Text = "保存終了";
        }

        // Listの選択が変わった時にプレビュー画面の情報を選択した商品のものにする
        int lastSelectedIndex = -1;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedItems[0].Index;
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
            chart1.Series.Clear();
            Series seriesLine = new Series();
            seriesLine.ChartType = SeriesChartType.Line;
            seriesLine.LegendText = "価格";
            seriesLine.BorderWidth = 2;
            seriesLine.MarkerStyle = MarkerStyle.Circle;
            seriesLine.MarkerSize = 12;
            int i = 0;
            foreach (var price in product.PriceHistory)
            {
                seriesLine.Points.Add(new DataPoint(i, price.Value));
            }
            chart1.Series.Add(seriesLine);
        }

        // 商品名をクリックしたら商品ページを開くようにする
        private void label_productName_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("商品ページを開きますか？", "確認", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://www.amazon.co.jp/dp/" + label_ASIN.Text);
                toolStripStatusLabel.Text = "ウェーブページを開きました";
            }
        }

        // 商品を削除する
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // リスト内で選択している商品があるか調べる
            if (listView1.SelectedItems.Count > 0)
            {
                toolStripStatusLabel.Text = "選択された商品情報を削除しています";
                int selectedIndex = listView1.SelectedItems[0].Index;
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
                listView1.Items.RemoveAt(selectedIndex);
                // 削除操作を行った後のプレビュー画面は初期値を表示する
                Product NullProduct = new Product();
                this.UpdateForm(NullProduct);
                DrawPriceHistory(NullProduct);
                toolStripStatusLabel.Text = "削除終了";
            }
        }

        // 通知設定の保存
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = listView1.SelectedItems[0].Index;
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
            toolStripStatusLabel.Text = "通知設定の保存終了";
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
                toolStripStatusLabel.Text = "通知を行っています";
                // 通知を二度送らないようにトリガーがかかった通知設定をOFFにしておく
                this.UpdateForm(updatedProduct);
                // 更新したときに通知設定がOFFで読み込まれるように保存しておく
                Extensions.Save(products, cacheFolderPath + "\\data.dat");

                // ここに通知を送るシステムを書く
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(settings.email, this.Text);
                msg.To.Add(new MailAddress(settings.id + "@gmail.com", settings.id));
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
                sc.Credentials = new System.Net.NetworkCredential(settings.email + "@gmail.com", settings.pass);
                sc.EnableSsl = true;

                sc.Send(msg);
                msg.Dispose();

                toolStripStatusLabel.Text = "通知完了";
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "更新しています";
            // 登録してある商品情報を更新する
            for (int i = 0; i < productNum; i++)
            {
                // スクレピングを行って更新すべきデータのみを更新する（NativeDataはそのまま）
                var document = await AmazonProductInformation.GetDocument(products[i].ASIN);
                products[i] = AmazonProductInformation.AcquiredData(document, products[i]);
                // 一ヶ月前のデータは消去する
                Extensions.DeletePriceHistory(products[i], DateTime.Now.AddMonths(-1));
                toolStripStatusLabel.Text = i + 1 + " 番目更新完了";
            }
            // 選択してあった商品情報のプレビュー画面を更新する
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedItems[0].Index;
                this.UpdateForm(products[selectedIndex]);
                DrawPriceHistory(products[selectedIndex]);
            }
            toolStripStatusLabel.Text = "更新完了";
        }

        bool isRefreshHalt = false;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (isRefreshHalt)
            {
                timer1.Start();
                toolStripStatusLabel.Text = "更新を再開しました";
                isRefreshHalt = false;
                toolStripButton_refreshControl.Text = "更新を停止する";
            }
            else
            {
                timer1.Stop();
                toolStripStatusLabel.Text = "更新を停止しています";
                isRefreshHalt = true;
                toolStripButton_refreshControl.Text = "更新を再開する";
            }
        }

        private async void toolStripButton5_Click(object sender, EventArgs e)
        {
            // 更新を一時的に停止する
            timer1.Stop();
            toolStripStatusLabel.Text = "更新しています";
            // 登録してある商品情報を更新する
            for (int i = 0; i < productNum; i++)
            {
                // スクレピングを行って更新すべきデータのみを更新する（NativeDataはそのまま）
                var document = await AmazonProductInformation.GetDocument(products[i].ASIN);
                products[i] = AmazonProductInformation.AcquiredData(document, products[i]);
                // 一ヶ月前のデータは消去する
                Extensions.DeletePriceHistory(products[i], DateTime.Now.AddMonths(-1));
                toolStripStatusLabel.Text = i + 1 + " 番目更新完了";
            }
            toolStripStatusLabel.Text = "更新完了";
            timer1.Start();
            // 選択してあった商品情報のプレビュー画面を更新する
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedItems[0].Index;
                this.UpdateForm(products[selectedIndex]);
                DrawPriceHistory(products[selectedIndex]);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // ASINを入力させるモーダルフォームを立ち上げる
            decimal tickSeconds = timer1.Interval / 1000;
            RefreshRate_InputForm form = new RefreshRate_InputForm(tickSeconds);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                timer1.Stop();
                timer1.Interval = Convert.ToInt32(form.value * 1000);
                settings.interval = timer1.Interval;
                Extensions.Save(settings, cacheFolderPath + "\\setting.dat");
                timer1.Start();
                toolStripStatusLabel.Text = "更新間隔を" + timer1.Interval/1000 + " 秒に変更しました";
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Setting_InputForm form = new Setting_InputForm();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                decimal interval = settings.interval;
                settings = form.settings;
                settings.interval = interval;
                Extensions.Save(settings, cacheFolderPath + "\\setting.dat");
            }
        }
    }
}
