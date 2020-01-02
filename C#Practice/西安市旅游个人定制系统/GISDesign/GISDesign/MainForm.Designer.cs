namespace GISDesign
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进行选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部选中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反向选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.缩放到已选范围ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.常用工具栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图导航工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.网络分析工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最短路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘图工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按位置查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.快速查找ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缓冲区分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.叠加分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDW内插ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axToolbarControl5 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.axToolbarControl3 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.axToolbarControl6 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axToolbarControl2 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FindPath = new System.Windows.Forms.ToolStripButton();
            this.PathSolve = new System.Windows.Forms.ToolStripButton();
            this.axToolbarControl4 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl5)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.toolStripMenuItem2,
            this.选择ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.空间分析ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(44, 21);
            this.menuFile.Text = "文件";
            this.menuFile.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(160, 22);
            this.menuNewDoc.Text = "新建 &New";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(160, 22);
            this.menuOpenDoc.Text = "打开 &Open";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(160, 22);
            this.menuSaveDoc.Text = "保存 &Save";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveAs.Image")));
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(160, 22);
            this.menuSaveAs.Text = "另存为 Save &as";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(157, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Image = global::MapControlApplication1.Properties.Resources.exit;
            this.menuExitApp.ImageTransparentColor = System.Drawing.Color.Silver;
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(160, 22);
            this.menuExitApp.Text = "退出 &Exit";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem29});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem2.Text = "视图";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "数据视图";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem29
            // 
            this.toolStripMenuItem29.Name = "toolStripMenuItem29";
            this.toolStripMenuItem29.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem29.Text = "版面视图";
            this.toolStripMenuItem29.Click += new System.EventHandler(this.toolStripMenuItem29_Click);
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.进行选择ToolStripMenuItem,
            this.全部选中ToolStripMenuItem,
            this.反向选择ToolStripMenuItem,
            this.清除选择ToolStripMenuItem,
            this.toolStripSeparator1,
            this.缩放到已选范围ToolStripMenuItem});
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选择ToolStripMenuItem.Text = "选择";
            // 
            // 进行选择ToolStripMenuItem
            // 
            this.进行选择ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("进行选择ToolStripMenuItem.Image")));
            this.进行选择ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.进行选择ToolStripMenuItem.Name = "进行选择ToolStripMenuItem";
            this.进行选择ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.进行选择ToolStripMenuItem.Text = "进行选择";
            this.进行选择ToolStripMenuItem.Click += new System.EventHandler(this.进行选择ToolStripMenuItem_Click);
            // 
            // 全部选中ToolStripMenuItem
            // 
            this.全部选中ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("全部选中ToolStripMenuItem.Image")));
            this.全部选中ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.全部选中ToolStripMenuItem.Name = "全部选中ToolStripMenuItem";
            this.全部选中ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.全部选中ToolStripMenuItem.Text = "全部选中";
            this.全部选中ToolStripMenuItem.Click += new System.EventHandler(this.全部选中ToolStripMenuItem_Click);
            // 
            // 反向选择ToolStripMenuItem
            // 
            this.反向选择ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("反向选择ToolStripMenuItem.Image")));
            this.反向选择ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.反向选择ToolStripMenuItem.Name = "反向选择ToolStripMenuItem";
            this.反向选择ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.反向选择ToolStripMenuItem.Text = "反向选择";
            this.反向选择ToolStripMenuItem.Click += new System.EventHandler(this.反向选择ToolStripMenuItem_Click);
            // 
            // 清除选择ToolStripMenuItem
            // 
            this.清除选择ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("清除选择ToolStripMenuItem.Image")));
            this.清除选择ToolStripMenuItem.Name = "清除选择ToolStripMenuItem";
            this.清除选择ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.清除选择ToolStripMenuItem.Text = "清除选择";
            this.清除选择ToolStripMenuItem.Click += new System.EventHandler(this.清除选择ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 缩放到已选范围ToolStripMenuItem
            // 
            this.缩放到已选范围ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("缩放到已选范围ToolStripMenuItem.Image")));
            this.缩放到已选范围ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.缩放到已选范围ToolStripMenuItem.Name = "缩放到已选范围ToolStripMenuItem";
            this.缩放到已选范围ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.缩放到已选范围ToolStripMenuItem.Text = "缩放到已选范围";
            this.缩放到已选范围ToolStripMenuItem.Click += new System.EventHandler(this.缩放到已选范围ToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.常用工具栏ToolStripMenuItem,
            this.地图导航工具ToolStripMenuItem,
            this.网络分析工具ToolStripMenuItem,
            this.绘图工具ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 常用工具栏ToolStripMenuItem
            // 
            this.常用工具栏ToolStripMenuItem.Checked = true;
            this.常用工具栏ToolStripMenuItem.CheckOnClick = true;
            this.常用工具栏ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.常用工具栏ToolStripMenuItem.Name = "常用工具栏ToolStripMenuItem";
            this.常用工具栏ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.常用工具栏ToolStripMenuItem.Text = "常用工具栏";
            this.常用工具栏ToolStripMenuItem.Click += new System.EventHandler(this.常用工具栏ToolStripMenuItem_Click);
            // 
            // 地图导航工具ToolStripMenuItem
            // 
            this.地图导航工具ToolStripMenuItem.CheckOnClick = true;
            this.地图导航工具ToolStripMenuItem.Name = "地图导航工具ToolStripMenuItem";
            this.地图导航工具ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.地图导航工具ToolStripMenuItem.Text = "地图导航工具";
            this.地图导航工具ToolStripMenuItem.Click += new System.EventHandler(this.地图导航工具ToolStripMenuItem_Click);
            // 
            // 网络分析工具ToolStripMenuItem
            // 
            this.网络分析工具ToolStripMenuItem.CheckOnClick = true;
            this.网络分析工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.最短路径ToolStripMenuItem});
            this.网络分析工具ToolStripMenuItem.Name = "网络分析工具ToolStripMenuItem";
            this.网络分析工具ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.网络分析工具ToolStripMenuItem.Text = "网络分析工具";
            this.网络分析工具ToolStripMenuItem.Click += new System.EventHandler(this.网络分析工具ToolStripMenuItem_Click);
            // 
            // 最短路径ToolStripMenuItem
            // 
            this.最短路径ToolStripMenuItem.CheckOnClick = true;
            this.最短路径ToolStripMenuItem.Name = "最短路径ToolStripMenuItem";
            this.最短路径ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.最短路径ToolStripMenuItem.Text = "最短路径";
            this.最短路径ToolStripMenuItem.Click += new System.EventHandler(this.最短路径ToolStripMenuItem_Click);
            // 
            // 绘图工具ToolStripMenuItem
            // 
            this.绘图工具ToolStripMenuItem.CheckOnClick = true;
            this.绘图工具ToolStripMenuItem.Name = "绘图工具ToolStripMenuItem";
            this.绘图工具ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.绘图工具ToolStripMenuItem.Text = "绘图工具";
            this.绘图工具ToolStripMenuItem.Click += new System.EventHandler(this.绘图工具ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.按属性查询ToolStripMenuItem,
            this.按位置查询ToolStripMenuItem,
            this.toolStripSeparator2,
            this.快速查找ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.查询ToolStripMenuItem.Text = "空间查询";
            // 
            // 按属性查询ToolStripMenuItem
            // 
            this.按属性查询ToolStripMenuItem.Image = global::MapControlApplication1.Properties.Resources.ArcView_table;
            this.按属性查询ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.按属性查询ToolStripMenuItem.Name = "按属性查询ToolStripMenuItem";
            this.按属性查询ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.按属性查询ToolStripMenuItem.Text = "按属性查询";
            this.按属性查询ToolStripMenuItem.Click += new System.EventHandler(this.按属性查询ToolStripMenuItem_Click);
            // 
            // 按位置查询ToolStripMenuItem
            // 
            this.按位置查询ToolStripMenuItem.Image = global::MapControlApplication1.Properties.Resources.select_using_graphics;
            this.按位置查询ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.按位置查询ToolStripMenuItem.Name = "按位置查询ToolStripMenuItem";
            this.按位置查询ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.按位置查询ToolStripMenuItem.Text = "按位置查询";
            this.按位置查询ToolStripMenuItem.Click += new System.EventHandler(this.按位置查询ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // 快速查找ToolStripMenuItem
            // 
            this.快速查找ToolStripMenuItem.Image = global::MapControlApplication1.Properties.Resources.find;
            this.快速查找ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Teal;
            this.快速查找ToolStripMenuItem.Name = "快速查找ToolStripMenuItem";
            this.快速查找ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.快速查找ToolStripMenuItem.Text = "快速查找";
            this.快速查找ToolStripMenuItem.Click += new System.EventHandler(this.快速查找ToolStripMenuItem_Click);
            // 
            // 空间分析ToolStripMenuItem
            // 
            this.空间分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.缓冲区分析ToolStripMenuItem,
            this.叠加分析ToolStripMenuItem,
            this.iDW内插ToolStripMenuItem});
            this.空间分析ToolStripMenuItem.Name = "空间分析ToolStripMenuItem";
            this.空间分析ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.空间分析ToolStripMenuItem.Text = "空间分析";
            // 
            // 缓冲区分析ToolStripMenuItem
            // 
            this.缓冲区分析ToolStripMenuItem.Name = "缓冲区分析ToolStripMenuItem";
            this.缓冲区分析ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.缓冲区分析ToolStripMenuItem.Text = "缓冲区分析";
            this.缓冲区分析ToolStripMenuItem.Click += new System.EventHandler(this.缓冲区分析ToolStripMenuItem_Click);
            // 
            // 叠加分析ToolStripMenuItem
            // 
            this.叠加分析ToolStripMenuItem.Name = "叠加分析ToolStripMenuItem";
            this.叠加分析ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.叠加分析ToolStripMenuItem.Text = "叠加分析";
            this.叠加分析ToolStripMenuItem.Click += new System.EventHandler(this.叠加分析ToolStripMenuItem_Click);
            // 
            // iDW内插ToolStripMenuItem
            // 
            this.iDW内插ToolStripMenuItem.Name = "iDW内插ToolStripMenuItem";
            this.iDW内插ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.iDW内插ToolStripMenuItem.Text = "iDW内插";
            this.iDW内插ToolStripMenuItem.Click += new System.EventHandler(this.iDW内插ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.联系我们ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 联系我们ToolStripMenuItem
            // 
            this.联系我们ToolStripMenuItem.Name = "联系我们ToolStripMenuItem";
            this.联系我们ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.联系我们ToolStripMenuItem.Text = "联系我们";
            this.联系我们ToolStripMenuItem.Click += new System.EventHandler(this.联系我们ToolStripMenuItem_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(635, 442);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl1_OnMouseUp);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnViewRefreshed += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnViewRefreshedEventHandler(this.axMapControl1_OnViewRefreshed);
            this.axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl1_OnAfterScreenDraw);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(466, 278);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 553);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 553);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(0, 17);
            // 
            // axMapControl2
            // 
            this.axMapControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl2.Location = new System.Drawing.Point(0, 0);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(181, 176);
            this.axMapControl2.TabIndex = 11;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 474);
            this.panel1.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.axMapControl2);
            this.splitContainer1.Size = new System.Drawing.Size(181, 474);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 0;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(181, 294);
            this.axTOCControl1.TabIndex = 0;
            this.axTOCControl1.UseWaitCursor = true;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            this.axTOCControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnDoubleClickEventHandler(this.axTOCControl1_OnDoubleClick);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl1.Location = new System.Drawing.Point(3, 28);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(831, 28);
            this.axToolbarControl1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(649, 474);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axToolbarControl5);
            this.tabPage1.Controls.Add(this.axMapControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(641, 448);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // axToolbarControl5
            // 
            this.axToolbarControl5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.axToolbarControl5.Location = new System.Drawing.Point(617, 36);
            this.axToolbarControl5.Name = "axToolbarControl5";
            this.axToolbarControl5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl5.OcxState")));
            this.axToolbarControl5.Size = new System.Drawing.Size(28, 396);
            this.axToolbarControl5.TabIndex = 3;
            this.axToolbarControl5.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(641, 448);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "版面";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.axToolbarControl3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitter2);
            this.splitContainer2.Panel2.Controls.Add(this.axPageLayoutControl1);
            this.splitContainer2.Size = new System.Drawing.Size(635, 442);
            this.splitContainer2.SplitterDistance = 28;
            this.splitContainer2.TabIndex = 1;
            // 
            // axToolbarControl3
            // 
            this.axToolbarControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axToolbarControl3.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl3.Name = "axToolbarControl3";
            this.axToolbarControl3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl3.OcxState")));
            this.axToolbarControl3.Size = new System.Drawing.Size(28, 442);
            this.axToolbarControl3.TabIndex = 1;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 442);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(603, 442);
            this.axPageLayoutControl1.TabIndex = 0;
            this.axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl1_OnMouseDown);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(649, 474);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(649, 474);
            this.toolStripContainer1.TabIndex = 14;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.axToolbarControl6);
            this.splitContainer3.Panel1.Controls.Add(this.axToolbarControl2);
            this.splitContainer3.Panel1.Controls.Add(this.axToolbarControl1);
            this.splitContainer3.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(834, 553);
            this.splitContainer3.SplitterDistance = 45;
            this.splitContainer3.TabIndex = 15;
            // 
            // axToolbarControl6
            // 
            this.axToolbarControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl6.Location = new System.Drawing.Point(251, 25);
            this.axToolbarControl6.Name = "axToolbarControl6";
            this.axToolbarControl6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl6.OcxState")));
            this.axToolbarControl6.Size = new System.Drawing.Size(221, 28);
            this.axToolbarControl6.TabIndex = 3;
            this.axToolbarControl6.Visible = false;
            // 
            // axToolbarControl2
            // 
            this.axToolbarControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.axToolbarControl2.Location = new System.Drawing.Point(482, 25);
            this.axToolbarControl2.Name = "axToolbarControl2";
            this.axToolbarControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl2.OcxState")));
            this.axToolbarControl2.Size = new System.Drawing.Size(352, 28);
            this.axToolbarControl2.TabIndex = 2;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer5.Panel2.Controls.Add(this.axToolbarControl4);
            this.splitContainer5.Size = new System.Drawing.Size(834, 504);
            this.splitContainer5.SplitterDistance = 474;
            this.splitContainer5.TabIndex = 1;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.toolStripContainer1);
            this.splitContainer4.Size = new System.Drawing.Size(834, 474);
            this.splitContainer4.SplitterDistance = 181;
            this.splitContainer4.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindPath,
            this.PathSolve});
            this.toolStrip1.Location = new System.Drawing.Point(6, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(58, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // FindPath
            // 
            this.FindPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FindPath.Image = ((System.Drawing.Image)(resources.GetObject("FindPath.Image")));
            this.FindPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FindPath.Name = "FindPath";
            this.FindPath.Size = new System.Drawing.Size(23, 22);
            this.FindPath.Text = "查找路径";
            this.FindPath.Click += new System.EventHandler(this.FindPath_Click);
            // 
            // PathSolve
            // 
            this.PathSolve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PathSolve.Image = ((System.Drawing.Image)(resources.GetObject("PathSolve.Image")));
            this.PathSolve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PathSolve.Name = "PathSolve";
            this.PathSolve.Size = new System.Drawing.Size(23, 22);
            this.PathSolve.Text = "解决";
            this.PathSolve.Click += new System.EventHandler(this.PathSolve_Click_1);
            // 
            // axToolbarControl4
            // 
            this.axToolbarControl4.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.axToolbarControl4.AllowDrop = true;
            this.axToolbarControl4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.axToolbarControl4.Location = new System.Drawing.Point(257, 0);
            this.axToolbarControl4.Name = "axToolbarControl4";
            this.axToolbarControl4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl4.OcxState")));
            this.axToolbarControl4.Size = new System.Drawing.Size(577, 28);
            this.axToolbarControl4.TabIndex = 3;
            this.axToolbarControl4.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 575);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "GISDesign";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl5)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem29;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.Splitter splitter2;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按位置查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进行选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部选中ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反向选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 缩放到已选范围ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 快速查找ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缓冲区分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl2;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl4;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl5;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl6;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 常用工具栏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图导航工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网络分析工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘图工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 叠加分析ToolStripMenuItem;
        public ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.ToolStripMenuItem iDW内插ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最短路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton FindPath;
        private System.Windows.Forms.ToolStripButton PathSolve;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系我们ToolStripMenuItem;
    }
}

