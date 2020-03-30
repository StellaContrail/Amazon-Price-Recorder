namespace Amazon_Price_Recorder
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_refreshControl = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.leastPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isAmazonSelling = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label_usedStock = new System.Windows.Forms.Label();
            this.label_newStock = new System.Windows.Forms.Label();
            this.label_ranking = new System.Windows.Forms.Label();
            this.label_reference_price = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDown_usedStockCountThreshold = new System.Windows.Forms.NumericUpDown();
            this.checkBox_usedStockGoesDown = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDown_newStockCountThreshold = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown_priceThreshold = new System.Windows.Forms.NumericUpDown();
            this.checkBox_priceGoesDown = new System.Windows.Forms.CheckBox();
            this.checkBox_newStockGoesDown = new System.Windows.Forms.CheckBox();
            this.checkBox_statusChange = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_ASIN = new System.Windows.Forms.Label();
            this.label_Amazon_pricecut = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_Amazon_price = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox_product = new System.Windows.Forms.PictureBox();
            this.label_productName = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_usedStockCountThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_newStockCountThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_priceThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.toolStripButton_refreshControl,
            this.toolStripSeparator4,
            this.toolStripButton5,
            this.toolStripSeparator5,
            this.toolStripButton6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1365, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(87, 22);
            this.toolStripButton1.Text = "商品を追加する";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(86, 22);
            this.toolStripButton2.Text = "商品を取り消す";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(111, 22);
            this.toolStripButton3.Text = "更新間隔を変更する";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_refreshControl
            // 
            this.toolStripButton_refreshControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_refreshControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_refreshControl.Name = "toolStripButton_refreshControl";
            this.toolStripButton_refreshControl.Size = new System.Drawing.Size(87, 22);
            this.toolStripButton_refreshControl.Text = "更新を停止する";
            this.toolStripButton_refreshControl.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(59, 22);
            this.toolStripButton5.Text = "強制更新";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton6.Text = "設定";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 664);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1365, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1365, 639);
            this.splitContainer1.SplitterDistance = 453;
            this.splitContainer1.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productName,
            this.leastPrice,
            this.stock,
            this.isAmazonSelling});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(453, 639);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // productName
            // 
            this.productName.Text = "商品名";
            this.productName.Width = 198;
            // 
            // leastPrice
            // 
            this.leastPrice.Text = "最安値";
            // 
            // stock
            // 
            this.stock.Text = "新品/中古";
            this.stock.Width = 69;
            // 
            // isAmazonSelling
            // 
            this.isAmazonSelling.Text = "Amazonからの出品";
            this.isAmazonSelling.Width = 110;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.label_usedStock);
            this.splitContainer2.Panel1.Controls.Add(this.label_newStock);
            this.splitContainer2.Panel1.Controls.Add(this.label_ranking);
            this.splitContainer2.Panel1.Controls.Add(this.label_reference_price);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox_product);
            this.splitContainer2.Panel1.Controls.Add(this.label_productName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chart1);
            this.splitContainer2.Size = new System.Drawing.Size(908, 639);
            this.splitContainer2.SplitterDistance = 249;
            this.splitContainer2.TabIndex = 0;
            // 
            // label_usedStock
            // 
            this.label_usedStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_usedStock.AutoSize = true;
            this.label_usedStock.Location = new System.Drawing.Point(327, 223);
            this.label_usedStock.Name = "label_usedStock";
            this.label_usedStock.Size = new System.Drawing.Size(58, 12);
            this.label_usedStock.TabIndex = 23;
            this.label_usedStock.Text = "usedStock";
            // 
            // label_newStock
            // 
            this.label_newStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_newStock.AutoSize = true;
            this.label_newStock.Location = new System.Drawing.Point(327, 205);
            this.label_newStock.Name = "label_newStock";
            this.label_newStock.Size = new System.Drawing.Size(54, 12);
            this.label_newStock.TabIndex = 22;
            this.label_newStock.Text = "newStock";
            // 
            // label_ranking
            // 
            this.label_ranking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ranking.AutoSize = true;
            this.label_ranking.Location = new System.Drawing.Point(327, 65);
            this.label_ranking.Name = "label_ranking";
            this.label_ranking.Size = new System.Drawing.Size(42, 12);
            this.label_ranking.TabIndex = 21;
            this.label_ranking.Text = "ranking";
            // 
            // label_reference_price
            // 
            this.label_reference_price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_reference_price.AutoSize = true;
            this.label_reference_price.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_reference_price.Location = new System.Drawing.Point(326, 47);
            this.label_reference_price.Name = "label_reference_price";
            this.label_reference_price.Size = new System.Drawing.Size(97, 12);
            this.label_reference_price.TabIndex = 20;
            this.label_reference_price.Text = "reference_price";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(226, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "その他中古品  ：";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(226, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "その他新品　 　：";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(233, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "総合ランキング：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(233, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "参考価格　 　：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.numericUpDown_usedStockCountThreshold);
            this.groupBox2.Controls.Add(this.checkBox_usedStockGoesDown);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.numericUpDown_newStockCountThreshold);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.numericUpDown_priceThreshold);
            this.groupBox2.Controls.Add(this.checkBox_priceGoesDown);
            this.groupBox2.Controls.Add(this.checkBox_newStockGoesDown);
            this.groupBox2.Controls.Add(this.checkBox_statusChange);
            this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(476, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 193);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通知設定";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(372, 41);
            this.button1.TabIndex = 11;
            this.button1.Text = "設定を保存する";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(231, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(145, 12);
            this.label16.TabIndex = 10;
            this.label16.Text = "個を下回ったときに知らせる";
            // 
            // numericUpDown_usedStockCountThreshold
            // 
            this.numericUpDown_usedStockCountThreshold.Location = new System.Drawing.Point(177, 100);
            this.numericUpDown_usedStockCountThreshold.Name = "numericUpDown_usedStockCountThreshold";
            this.numericUpDown_usedStockCountThreshold.Size = new System.Drawing.Size(48, 19);
            this.numericUpDown_usedStockCountThreshold.TabIndex = 9;
            // 
            // checkBox_usedStockGoesDown
            // 
            this.checkBox_usedStockGoesDown.AutoSize = true;
            this.checkBox_usedStockGoesDown.Location = new System.Drawing.Point(29, 103);
            this.checkBox_usedStockGoesDown.Name = "checkBox_usedStockGoesDown";
            this.checkBox_usedStockGoesDown.Size = new System.Drawing.Size(145, 16);
            this.checkBox_usedStockGoesDown.TabIndex = 8;
            this.checkBox_usedStockGoesDown.Text = "その他中古品の在庫が";
            this.checkBox_usedStockGoesDown.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(221, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(145, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "個を下回ったときに知らせる";
            // 
            // numericUpDown_newStockCountThreshold
            // 
            this.numericUpDown_newStockCountThreshold.Location = new System.Drawing.Point(167, 75);
            this.numericUpDown_newStockCountThreshold.Name = "numericUpDown_newStockCountThreshold";
            this.numericUpDown_newStockCountThreshold.Size = new System.Drawing.Size(48, 19);
            this.numericUpDown_newStockCountThreshold.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(186, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 12);
            this.label14.TabIndex = 5;
            this.label14.Text = "円を下回ったときに知らせる";
            // 
            // numericUpDown_priceThreshold
            // 
            this.numericUpDown_priceThreshold.Location = new System.Drawing.Point(96, 48);
            this.numericUpDown_priceThreshold.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown_priceThreshold.Name = "numericUpDown_priceThreshold";
            this.numericUpDown_priceThreshold.Size = new System.Drawing.Size(84, 19);
            this.numericUpDown_priceThreshold.TabIndex = 4;
            // 
            // checkBox_priceGoesDown
            // 
            this.checkBox_priceGoesDown.AutoSize = true;
            this.checkBox_priceGoesDown.Location = new System.Drawing.Point(29, 51);
            this.checkBox_priceGoesDown.Name = "checkBox_priceGoesDown";
            this.checkBox_priceGoesDown.Size = new System.Drawing.Size(61, 16);
            this.checkBox_priceGoesDown.TabIndex = 3;
            this.checkBox_priceGoesDown.Text = "値段が";
            this.checkBox_priceGoesDown.UseVisualStyleBackColor = true;
            // 
            // checkBox_newStockGoesDown
            // 
            this.checkBox_newStockGoesDown.AutoSize = true;
            this.checkBox_newStockGoesDown.Location = new System.Drawing.Point(29, 78);
            this.checkBox_newStockGoesDown.Name = "checkBox_newStockGoesDown";
            this.checkBox_newStockGoesDown.Size = new System.Drawing.Size(132, 16);
            this.checkBox_newStockGoesDown.TabIndex = 2;
            this.checkBox_newStockGoesDown.Text = "その他新品の在庫が";
            this.checkBox_newStockGoesDown.UseVisualStyleBackColor = true;
            // 
            // checkBox_statusChange
            // 
            this.checkBox_statusChange.AutoSize = true;
            this.checkBox_statusChange.Location = new System.Drawing.Point(29, 26);
            this.checkBox_statusChange.Name = "checkBox_statusChange";
            this.checkBox_statusChange.Size = new System.Drawing.Size(298, 16);
            this.checkBox_statusChange.TabIndex = 0;
            this.checkBox_statusChange.Text = "Amazon.co.jp の在庫状況が変化したときに知らせる\r\n";
            this.checkBox_statusChange.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label_ASIN);
            this.groupBox1.Controls.Add(this.label_Amazon_pricecut);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label_Amazon_price);
            this.groupBox1.Controls.Add(this.label_status);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(226, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 118);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品情報";
            // 
            // label_ASIN
            // 
            this.label_ASIN.AutoSize = true;
            this.label_ASIN.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_ASIN.Location = new System.Drawing.Point(54, 97);
            this.label_ASIN.Name = "label_ASIN";
            this.label_ASIN.Size = new System.Drawing.Size(31, 12);
            this.label_ASIN.TabIndex = 25;
            this.label_ASIN.Text = "ASIN";
            // 
            // label_Amazon_pricecut
            // 
            this.label_Amazon_pricecut.AutoSize = true;
            this.label_Amazon_pricecut.BackColor = System.Drawing.Color.White;
            this.label_Amazon_pricecut.ForeColor = System.Drawing.Color.Red;
            this.label_Amazon_pricecut.Location = new System.Drawing.Point(54, 77);
            this.label_Amazon_pricecut.Name = "label_Amazon_pricecut";
            this.label_Amazon_pricecut.Size = new System.Drawing.Size(105, 12);
            this.label_Amazon_pricecut.TabIndex = 13;
            this.label_Amazon_pricecut.Text = "Amazon_pricecut";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(7, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "ASIN：";
            // 
            // label_Amazon_price
            // 
            this.label_Amazon_price.AutoSize = true;
            this.label_Amazon_price.Location = new System.Drawing.Point(54, 60);
            this.label_Amazon_price.Name = "label_Amazon_price";
            this.label_Amazon_price.Size = new System.Drawing.Size(82, 12);
            this.label_Amazon_price.TabIndex = 12;
            this.label_Amazon_price.Text = "AmazonPrice";
            // 
            // label_status
            // 
            this.label_status.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_status.Location = new System.Drawing.Point(55, 14);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(175, 32);
            this.label_status.TabIndex = 10;
            this.label_status.Text = "status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(5, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "値段 ：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "状態 ：";
            // 
            // pictureBox_product
            // 
            this.pictureBox_product.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_product.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_product.Location = new System.Drawing.Point(19, 49);
            this.pictureBox_product.Name = "pictureBox_product";
            this.pictureBox_product.Size = new System.Drawing.Size(201, 193);
            this.pictureBox_product.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_product.TabIndex = 13;
            this.pictureBox_product.TabStop = false;
            // 
            // label_productName
            // 
            this.label_productName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_productName.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_productName.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_productName.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label_productName.Location = new System.Drawing.Point(0, 0);
            this.label_productName.Name = "label_productName";
            this.label_productName.Size = new System.Drawing.Size(908, 48);
            this.label_productName.TabIndex = 12;
            this.label_productName.Text = "product_name";
            this.label_productName.Click += new System.EventHandler(this.label_productName_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(908, 386);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 686);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Amazon Price Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_usedStockCountThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_newStockCountThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_priceThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton_refreshControl;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader productName;
        private System.Windows.Forms.ColumnHeader leastPrice;
        private System.Windows.Forms.ColumnHeader stock;
        private System.Windows.Forms.ColumnHeader isAmazonSelling;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        internal System.Windows.Forms.Label label_usedStock;
        internal System.Windows.Forms.Label label_newStock;
        internal System.Windows.Forms.Label label_ranking;
        internal System.Windows.Forms.Label label_reference_price;
        internal System.Windows.Forms.Label label_Amazon_pricecut;
        internal System.Windows.Forms.Label label_Amazon_price;
        internal System.Windows.Forms.Label label_status;
        internal System.Windows.Forms.PictureBox pictureBox_product;
        internal System.Windows.Forms.Label label_productName;
        internal System.Windows.Forms.Label label_ASIN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.NumericUpDown numericUpDown_usedStockCountThreshold;
        internal System.Windows.Forms.CheckBox checkBox_usedStockGoesDown;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.NumericUpDown numericUpDown_newStockCountThreshold;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.NumericUpDown numericUpDown_priceThreshold;
        internal System.Windows.Forms.CheckBox checkBox_priceGoesDown;
        internal System.Windows.Forms.CheckBox checkBox_newStockGoesDown;
        internal System.Windows.Forms.CheckBox checkBox_statusChange;
    }
}

