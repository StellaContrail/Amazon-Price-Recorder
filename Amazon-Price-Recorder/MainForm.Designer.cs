namespace Amazon_Price_Recorder
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Menubar = new System.Windows.Forms.ToolStrip();
            this.AddProductButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveProductButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ChangeRefreshRateButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.StopRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SettingButton = new System.Windows.Forms.ToolStripButton();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ProductList = new System.Windows.Forms.ListView();
            this.productName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.leastPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isAmazonSelling = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Label_usedStock = new System.Windows.Forms.Label();
            this.Label_newStock = new System.Windows.Forms.Label();
            this.Label_ranking = new System.Windows.Forms.Label();
            this.Label_reference_price = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveSettingButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.NumericUpDown_usedStockCountThreshold = new System.Windows.Forms.NumericUpDown();
            this.CheckBox_usedStockGoesDown = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.NumericUpDown_newStockCountThreshold = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.NumericUpDown_priceThreshold = new System.Windows.Forms.NumericUpDown();
            this.CheckBox_priceGoesDown = new System.Windows.Forms.CheckBox();
            this.CheckBox_newStockGoesDown = new System.Windows.Forms.CheckBox();
            this.CheckBox_statusChange = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label_ASIN = new System.Windows.Forms.Label();
            this.Label_Amazon_pricecut = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Label_Amazon_price = new System.Windows.Forms.Label();
            this.Label_status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PictureBox_product = new System.Windows.Forms.PictureBox();
            this.Label_productName = new System.Windows.Forms.Label();
            this.PriceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Menubar.SuspendLayout();
            this.Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_usedStockCountThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_newStockCountThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_priceThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // Menubar
            // 
            this.Menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddProductButton,
            this.toolStripSeparator1,
            this.RemoveProductButton,
            this.toolStripSeparator2,
            this.ChangeRefreshRateButton,
            this.toolStripSeparator3,
            this.StopRefreshButton,
            this.toolStripSeparator4,
            this.RefreshButton,
            this.toolStripSeparator5,
            this.SettingButton});
            this.Menubar.Location = new System.Drawing.Point(0, 0);
            this.Menubar.Name = "Menubar";
            this.Menubar.Size = new System.Drawing.Size(1365, 25);
            this.Menubar.TabIndex = 1;
            this.Menubar.Text = "toolStrip1";
            // 
            // AddProductButton
            // 
            this.AddProductButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddProductButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(87, 22);
            this.AddProductButton.Text = "商品を追加する";
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // RemoveProductButton
            // 
            this.RemoveProductButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RemoveProductButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveProductButton.Name = "RemoveProductButton";
            this.RemoveProductButton.Size = new System.Drawing.Size(86, 22);
            this.RemoveProductButton.Text = "商品を取り消す";
            this.RemoveProductButton.Click += new System.EventHandler(this.RemoveProductButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ChangeRefreshRateButton
            // 
            this.ChangeRefreshRateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ChangeRefreshRateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChangeRefreshRateButton.Name = "ChangeRefreshRateButton";
            this.ChangeRefreshRateButton.Size = new System.Drawing.Size(111, 22);
            this.ChangeRefreshRateButton.Text = "更新間隔を変更する";
            this.ChangeRefreshRateButton.Click += new System.EventHandler(this.ChangeRefreshRateButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // StopRefreshButton
            // 
            this.StopRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StopRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopRefreshButton.Name = "StopRefreshButton";
            this.StopRefreshButton.Size = new System.Drawing.Size(87, 22);
            this.StopRefreshButton.Text = "更新を停止する";
            this.StopRefreshButton.Click += new System.EventHandler(this.StopRefreshButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(59, 22);
            this.RefreshButton.Text = "強制更新";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // SettingButton
            // 
            this.SettingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SettingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(35, 22);
            this.SettingButton.Text = "設定";
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.Status.Location = new System.Drawing.Point(0, 664);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(1365, 22);
            this.Status.TabIndex = 3;
            this.Status.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Status";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ProductList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1365, 639);
            this.splitContainer1.SplitterDistance = 453;
            this.splitContainer1.TabIndex = 4;
            // 
            // ProductList
            // 
            this.ProductList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productName,
            this.leastPrice,
            this.stock,
            this.isAmazonSelling});
            this.ProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductList.FullRowSelect = true;
            this.ProductList.GridLines = true;
            this.ProductList.HideSelection = false;
            this.ProductList.Location = new System.Drawing.Point(0, 0);
            this.ProductList.MultiSelect = false;
            this.ProductList.Name = "ProductList";
            this.ProductList.Size = new System.Drawing.Size(453, 639);
            this.ProductList.TabIndex = 0;
            this.ProductList.UseCompatibleStateImageBehavior = false;
            this.ProductList.View = System.Windows.Forms.View.Details;
            this.ProductList.SelectedIndexChanged += new System.EventHandler(this.ProductList_SelectedIndexChanged);
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
            this.splitContainer2.Panel1.Controls.Add(this.Label_usedStock);
            this.splitContainer2.Panel1.Controls.Add(this.Label_newStock);
            this.splitContainer2.Panel1.Controls.Add(this.Label_ranking);
            this.splitContainer2.Panel1.Controls.Add(this.Label_reference_price);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.PictureBox_product);
            this.splitContainer2.Panel1.Controls.Add(this.Label_productName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.PriceChart);
            this.splitContainer2.Size = new System.Drawing.Size(908, 639);
            this.splitContainer2.SplitterDistance = 249;
            this.splitContainer2.TabIndex = 0;
            // 
            // Label_usedStock
            // 
            this.Label_usedStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_usedStock.AutoSize = true;
            this.Label_usedStock.Location = new System.Drawing.Point(327, 223);
            this.Label_usedStock.Name = "Label_usedStock";
            this.Label_usedStock.Size = new System.Drawing.Size(58, 12);
            this.Label_usedStock.TabIndex = 23;
            this.Label_usedStock.Text = "usedStock";
            // 
            // Label_newStock
            // 
            this.Label_newStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_newStock.AutoSize = true;
            this.Label_newStock.Location = new System.Drawing.Point(327, 205);
            this.Label_newStock.Name = "Label_newStock";
            this.Label_newStock.Size = new System.Drawing.Size(54, 12);
            this.Label_newStock.TabIndex = 22;
            this.Label_newStock.Text = "newStock";
            // 
            // Label_ranking
            // 
            this.Label_ranking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_ranking.AutoSize = true;
            this.Label_ranking.Location = new System.Drawing.Point(327, 65);
            this.Label_ranking.Name = "Label_ranking";
            this.Label_ranking.Size = new System.Drawing.Size(42, 12);
            this.Label_ranking.TabIndex = 21;
            this.Label_ranking.Text = "ranking";
            // 
            // Label_reference_price
            // 
            this.Label_reference_price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_reference_price.AutoSize = true;
            this.Label_reference_price.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_reference_price.Location = new System.Drawing.Point(326, 47);
            this.Label_reference_price.Name = "Label_reference_price";
            this.Label_reference_price.Size = new System.Drawing.Size(97, 12);
            this.Label_reference_price.TabIndex = 20;
            this.Label_reference_price.Text = "reference_price";
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
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "ランキング　 　：";
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
            this.groupBox2.Controls.Add(this.SaveSettingButton);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.NumericUpDown_usedStockCountThreshold);
            this.groupBox2.Controls.Add(this.CheckBox_usedStockGoesDown);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.NumericUpDown_newStockCountThreshold);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.NumericUpDown_priceThreshold);
            this.groupBox2.Controls.Add(this.CheckBox_priceGoesDown);
            this.groupBox2.Controls.Add(this.CheckBox_newStockGoesDown);
            this.groupBox2.Controls.Add(this.CheckBox_statusChange);
            this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(476, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 193);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通知設定";
            // 
            // SaveSettingButton
            // 
            this.SaveSettingButton.Location = new System.Drawing.Point(29, 136);
            this.SaveSettingButton.Name = "SaveSettingButton";
            this.SaveSettingButton.Size = new System.Drawing.Size(372, 41);
            this.SaveSettingButton.TabIndex = 11;
            this.SaveSettingButton.Text = "設定を保存する";
            this.SaveSettingButton.UseVisualStyleBackColor = true;
            this.SaveSettingButton.Click += new System.EventHandler(this.SaveSettingButton_Click);
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
            // NumericUpDown_usedStockCountThreshold
            // 
            this.NumericUpDown_usedStockCountThreshold.Location = new System.Drawing.Point(177, 100);
            this.NumericUpDown_usedStockCountThreshold.Name = "NumericUpDown_usedStockCountThreshold";
            this.NumericUpDown_usedStockCountThreshold.Size = new System.Drawing.Size(48, 19);
            this.NumericUpDown_usedStockCountThreshold.TabIndex = 9;
            // 
            // CheckBox_usedStockGoesDown
            // 
            this.CheckBox_usedStockGoesDown.AutoSize = true;
            this.CheckBox_usedStockGoesDown.Location = new System.Drawing.Point(29, 103);
            this.CheckBox_usedStockGoesDown.Name = "CheckBox_usedStockGoesDown";
            this.CheckBox_usedStockGoesDown.Size = new System.Drawing.Size(145, 16);
            this.CheckBox_usedStockGoesDown.TabIndex = 8;
            this.CheckBox_usedStockGoesDown.Text = "その他中古品の在庫が";
            this.CheckBox_usedStockGoesDown.UseVisualStyleBackColor = true;
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
            // NumericUpDown_newStockCountThreshold
            // 
            this.NumericUpDown_newStockCountThreshold.Location = new System.Drawing.Point(167, 75);
            this.NumericUpDown_newStockCountThreshold.Name = "NumericUpDown_newStockCountThreshold";
            this.NumericUpDown_newStockCountThreshold.Size = new System.Drawing.Size(48, 19);
            this.NumericUpDown_newStockCountThreshold.TabIndex = 6;
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
            // NumericUpDown_priceThreshold
            // 
            this.NumericUpDown_priceThreshold.Location = new System.Drawing.Point(96, 48);
            this.NumericUpDown_priceThreshold.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.NumericUpDown_priceThreshold.Name = "NumericUpDown_priceThreshold";
            this.NumericUpDown_priceThreshold.Size = new System.Drawing.Size(84, 19);
            this.NumericUpDown_priceThreshold.TabIndex = 4;
            // 
            // CheckBox_priceGoesDown
            // 
            this.CheckBox_priceGoesDown.AutoSize = true;
            this.CheckBox_priceGoesDown.Location = new System.Drawing.Point(29, 51);
            this.CheckBox_priceGoesDown.Name = "CheckBox_priceGoesDown";
            this.CheckBox_priceGoesDown.Size = new System.Drawing.Size(61, 16);
            this.CheckBox_priceGoesDown.TabIndex = 3;
            this.CheckBox_priceGoesDown.Text = "値段が";
            this.CheckBox_priceGoesDown.UseVisualStyleBackColor = true;
            // 
            // CheckBox_newStockGoesDown
            // 
            this.CheckBox_newStockGoesDown.AutoSize = true;
            this.CheckBox_newStockGoesDown.Location = new System.Drawing.Point(29, 78);
            this.CheckBox_newStockGoesDown.Name = "CheckBox_newStockGoesDown";
            this.CheckBox_newStockGoesDown.Size = new System.Drawing.Size(132, 16);
            this.CheckBox_newStockGoesDown.TabIndex = 2;
            this.CheckBox_newStockGoesDown.Text = "その他新品の在庫が";
            this.CheckBox_newStockGoesDown.UseVisualStyleBackColor = true;
            // 
            // CheckBox_statusChange
            // 
            this.CheckBox_statusChange.AutoSize = true;
            this.CheckBox_statusChange.Location = new System.Drawing.Point(29, 26);
            this.CheckBox_statusChange.Name = "CheckBox_statusChange";
            this.CheckBox_statusChange.Size = new System.Drawing.Size(298, 16);
            this.CheckBox_statusChange.TabIndex = 0;
            this.CheckBox_statusChange.Text = "Amazon.co.jp の在庫状況が変化したときに知らせる\r\n";
            this.CheckBox_statusChange.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.Label_ASIN);
            this.groupBox1.Controls.Add(this.Label_Amazon_pricecut);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Label_Amazon_price);
            this.groupBox1.Controls.Add(this.Label_status);
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
            // Label_ASIN
            // 
            this.Label_ASIN.AutoSize = true;
            this.Label_ASIN.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_ASIN.Location = new System.Drawing.Point(54, 97);
            this.Label_ASIN.Name = "Label_ASIN";
            this.Label_ASIN.Size = new System.Drawing.Size(31, 12);
            this.Label_ASIN.TabIndex = 25;
            this.Label_ASIN.Text = "ASIN";
            // 
            // Label_Amazon_pricecut
            // 
            this.Label_Amazon_pricecut.AutoSize = true;
            this.Label_Amazon_pricecut.BackColor = System.Drawing.Color.White;
            this.Label_Amazon_pricecut.ForeColor = System.Drawing.Color.Red;
            this.Label_Amazon_pricecut.Location = new System.Drawing.Point(54, 77);
            this.Label_Amazon_pricecut.Name = "Label_Amazon_pricecut";
            this.Label_Amazon_pricecut.Size = new System.Drawing.Size(105, 12);
            this.Label_Amazon_pricecut.TabIndex = 13;
            this.Label_Amazon_pricecut.Text = "Amazon_pricecut";
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
            // Label_Amazon_price
            // 
            this.Label_Amazon_price.AutoSize = true;
            this.Label_Amazon_price.Location = new System.Drawing.Point(54, 60);
            this.Label_Amazon_price.Name = "Label_Amazon_price";
            this.Label_Amazon_price.Size = new System.Drawing.Size(82, 12);
            this.Label_Amazon_price.TabIndex = 12;
            this.Label_Amazon_price.Text = "AmazonPrice";
            // 
            // Label_status
            // 
            this.Label_status.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_status.Location = new System.Drawing.Point(55, 14);
            this.Label_status.Name = "Label_status";
            this.Label_status.Size = new System.Drawing.Size(175, 32);
            this.Label_status.TabIndex = 10;
            this.Label_status.Text = "status";
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
            // PictureBox_product
            // 
            this.PictureBox_product.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox_product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBox_product.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox_product.Location = new System.Drawing.Point(19, 49);
            this.PictureBox_product.Name = "PictureBox_product";
            this.PictureBox_product.Size = new System.Drawing.Size(201, 193);
            this.PictureBox_product.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_product.TabIndex = 13;
            this.PictureBox_product.TabStop = false;
            // 
            // Label_productName
            // 
            this.Label_productName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_productName.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label_productName.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_productName.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Label_productName.Location = new System.Drawing.Point(0, 0);
            this.Label_productName.Name = "Label_productName";
            this.Label_productName.Size = new System.Drawing.Size(908, 48);
            this.Label_productName.TabIndex = 12;
            this.Label_productName.Text = "product_name";
            this.Label_productName.Click += new System.EventHandler(this.Label_productName_Click);
            // 
            // PriceChart
            // 
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea2.Name = "ChartArea1";
            this.PriceChart.ChartAreas.Add(chartArea2);
            this.PriceChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.PriceChart.Legends.Add(legend2);
            this.PriceChart.Location = new System.Drawing.Point(0, 0);
            this.PriceChart.Name = "PriceChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.MarkerSize = 3;
            series2.Name = "Series1";
            this.PriceChart.Series.Add(series2);
            this.PriceChart.Size = new System.Drawing.Size(908, 386);
            this.PriceChart.TabIndex = 0;
            this.PriceChart.Text = "priceChart";
            // 
            // Timer
            // 
            this.Timer.Interval = 10000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 686);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Menubar);
            this.Name = "MainForm";
            this.Text = "Amazon Price Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Menubar.ResumeLayout(false);
            this.Menubar.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_usedStockCountThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_newStockCountThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_priceThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menubar;
        private System.Windows.Forms.ToolStripButton AddProductButton;
        private System.Windows.Forms.ToolStripButton RemoveProductButton;
        private System.Windows.Forms.ToolStripButton ChangeRefreshRateButton;
        private System.Windows.Forms.ToolStripButton StopRefreshButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton SettingButton;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView ProductList;
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
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DataVisualization.Charting.Chart PriceChart;
        internal System.Windows.Forms.Label Label_usedStock;
        internal System.Windows.Forms.Label Label_newStock;
        internal System.Windows.Forms.Label Label_ranking;
        internal System.Windows.Forms.Label Label_reference_price;
        internal System.Windows.Forms.Label Label_Amazon_pricecut;
        internal System.Windows.Forms.Label Label_Amazon_price;
        internal System.Windows.Forms.Label Label_status;
        internal System.Windows.Forms.PictureBox PictureBox_product;
        internal System.Windows.Forms.Label Label_productName;
        internal System.Windows.Forms.Label Label_ASIN;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SaveSettingButton;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_usedStockCountThreshold;
        internal System.Windows.Forms.CheckBox CheckBox_usedStockGoesDown;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_newStockCountThreshold;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.NumericUpDown NumericUpDown_priceThreshold;
        internal System.Windows.Forms.CheckBox CheckBox_priceGoesDown;
        internal System.Windows.Forms.CheckBox CheckBox_newStockGoesDown;
        internal System.Windows.Forms.CheckBox CheckBox_statusChange;
    }
}

