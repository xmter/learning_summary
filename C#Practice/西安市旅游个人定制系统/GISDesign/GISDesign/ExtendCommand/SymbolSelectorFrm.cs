using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

using ESRI.ArcGIS.esriSystem;

using ESRI.ArcGIS.SystemUI;

using ESRI.ArcGIS.Controls;

using ESRI.ArcGIS.Geodatabase;


namespace GISDesign
{
    public partial class SymbolSelectorFrm : Form
    {
        private IStyleGalleryItem pStyleGalleryItem;

        private ILegendClass pLegendClass;

        private ILayer pLayer;

        public ISymbol pSymbol;

        public Image pSymbolImage;
        bool contextMenuMoreSymbolInitiated = false;



        public SymbolSelectorFrm(ILegendClass tempLegendClass, ILayer tempLayer)
        {

            InitializeComponent();

            this.pLegendClass = tempLegendClass;

            this.pLayer = tempLayer;

        }
        private void SetFeatureClassStyle(esriSymbologyStyleClass symbologyStyleClass)
        {

            this.axSymbologyControl.StyleClass = symbologyStyleClass;

            ISymbologyStyleClass pSymbologyStyleClass = this.axSymbologyControl.GetStyleClass(symbologyStyleClass);

            if (this.pLegendClass != null)
            {

                IStyleGalleryItem currentStyleGalleryItem = new ServerStyleGalleryItem();

                currentStyleGalleryItem.Name = "当前符号";

                currentStyleGalleryItem.Item = pLegendClass.Symbol;

                pSymbologyStyleClass.AddItem(currentStyleGalleryItem, 0);

                this.pStyleGalleryItem = currentStyleGalleryItem;

            }

            pSymbologyStyleClass.SelectItem(0);

        }
       /* private string ReadRegistry(string sKey)
        {

            //Open the subkey for reading

            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey, true);

            if (rk == null) return "";

            // Get the data from a specified item in the key.

            return (string)rk.GetValue("InstallDir");

        }
        */
        private void SymbolSelectorFrm_Load(object sender, EventArgs e)
        {
            //取得ArcGIS安装路径

         //   string sInstall = ReadRegistry("SOFTWARE\\ESRI\\CoreRuntime");



            //载入ESRI.ServerStyle文件到SymbologyControl

            //this.axSymbologyControl.LoadStyleFile("D:\\Program Files (x86)\\ArcGIS\\Engine10.0\\Styles\\ESRI.ServerStyle");
            this.axSymbologyControl.LoadStyleFile("D:\\Program Files (x86)\\ArcGIS\\Engine10.0\\Styles\\ESRI.ServerStyle");



            //确定图层的类型(点线面),设置好SymbologyControl的StyleClass,设置好各控件的可见性(visible)

            IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)pLayer;

            switch (((IFeatureLayer)pLayer).FeatureClass.ShapeType)
            {

                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:

                    this.SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassMarkerSymbols);

                    this.lblAngle.Visible = true;

                    this.nudAngle.Visible = true;

                    this.lblSize.Visible = true;

                    this.nudSize.Visible = true;

                    this.lblWidth.Visible = false;

                    this.nudWidth.Visible = false;

                    this.lblOutlineColor.Visible = false;

                    this.btnOutlineColor.Visible = false;

                    break;

                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:

                    this.SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassLineSymbols);

                    this.lblAngle.Visible = false;

                    this.nudAngle.Visible = false;

                    this.lblSize.Visible = false;

                    this.nudSize.Visible = false;

                    this.lblWidth.Visible = true;

                    this.nudWidth.Visible = true;

                    this.lblOutlineColor.Visible = false;

                    this.btnOutlineColor.Visible = false;

                    break;

                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:

                    this.SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassFillSymbols);

                    this.lblAngle.Visible = false;

                    this.nudAngle.Visible = false;

                    this.lblSize.Visible = false;

                    this.nudSize.Visible = false;

                    this.lblWidth.Visible = true;

                    this.nudWidth.Visible = true;

                    this.lblOutlineColor.Visible = true;

                    this.btnOutlineColor.Visible = true;

                    break;

                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultiPatch:

                    this.SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassFillSymbols);

                    this.lblAngle.Visible = false;

                    this.nudAngle.Visible = false;

                    this.lblSize.Visible = false;

                    this.nudSize.Visible = false;

                    this.lblWidth.Visible = true;

                    this.nudWidth.Visible = true;

                    this.lblOutlineColor.Visible = true;

                    this.btnOutlineColor.Visible = true;

                    break;

                default:

                    this.Close();

                    break;

            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //取得选定的符号

            this.pSymbol = (ISymbol)pStyleGalleryItem.Item;

            //更新预览图像

            this.pSymbolImage = this.ptbPreview.Image;

            //关闭窗体

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void axSymbologyControl_OnDoubleClick(object sender, ISymbologyControlEvents_OnDoubleClickEvent e)
        {
            this.btnOK.PerformClick();
        }
        private void PreviewImage()
        {

            stdole.IPictureDisp picture = this.axSymbologyControl.GetStyleClass(this.axSymbologyControl.StyleClass).PreviewItem(pStyleGalleryItem, this.ptbPreview.Width, this.ptbPreview.Height);

            System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));

            this.ptbPreview.Image = image;

        }

        private void axSymbologyControl_OnStyleClassChanged(object sender, ISymbologyControlEvents_OnStyleClassChangedEvent e)
        {
            switch ((esriSymbologyStyleClass)(e.symbologyStyleClass))
            {

                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:

                    this.lblAngle.Visible = true;

                    this.nudAngle.Visible = true;

                    this.lblSize.Visible = true;

                    this.nudSize.Visible = true;

                    this.lblWidth.Visible = false;

                    this.nudWidth.Visible = false;

                    this.lblOutlineColor.Visible = false;

                    this.btnOutlineColor.Visible = false;

                    break;

                case esriSymbologyStyleClass.esriStyleClassLineSymbols:

                    this.lblAngle.Visible = false;

                    this.nudAngle.Visible = false;

                    this.lblSize.Visible = false;

                    this.nudSize.Visible = false;

                    this.lblWidth.Visible = true;

                    this.nudWidth.Visible = true;

                    this.lblOutlineColor.Visible = false;

                    this.btnOutlineColor.Visible = false;

                    break;

                case esriSymbologyStyleClass.esriStyleClassFillSymbols:

                    this.lblAngle.Visible = false;

                    this.nudAngle.Visible = false;

                    this.lblSize.Visible = false;

                    this.nudSize.Visible = false;

                    this.lblWidth.Visible = true;

                    this.nudWidth.Visible = true;

                    this.lblOutlineColor.Visible = true;

                    this.btnOutlineColor.Visible = true;

                    break;

            }
        }

        private void axSymbologyControl_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            pStyleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;

            Color color;

            switch (this.axSymbologyControl.StyleClass)
            {

                //点符号

                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:

                    color = this.ConvertIRgbColorToColor(((IMarkerSymbol)pStyleGalleryItem.Item).Color as IRgbColor);

                    //设置点符号角度和大小初始值

                    this.nudAngle.Value = (decimal)((IMarkerSymbol)this.pStyleGalleryItem.Item).Angle;

                    this.nudSize.Value = (decimal)((IMarkerSymbol)this.pStyleGalleryItem.Item).Size;

                    break;

                //线符号

                case esriSymbologyStyleClass.esriStyleClassLineSymbols:

                    color = this.ConvertIRgbColorToColor(((ILineSymbol)pStyleGalleryItem.Item).Color as IRgbColor);

                    //设置线宽初始值

                    this.nudWidth.Value = (decimal)((ILineSymbol)this.pStyleGalleryItem.Item).Width;

                    break;

                //面符号

                case esriSymbologyStyleClass.esriStyleClassFillSymbols:

                    color = this.ConvertIRgbColorToColor(((IFillSymbol)pStyleGalleryItem.Item).Color as IRgbColor);

                    this.btnOutlineColor.BackColor = this.ConvertIRgbColorToColor(((IFillSymbol)pStyleGalleryItem.Item).Outline.Color as IRgbColor);

                    //设置外框线宽度初始值

                    this.nudWidth.Value = (decimal)((IFillSymbol)this.pStyleGalleryItem.Item).Outline.Width;

                    break;

                default:

                    color = Color.Black;

                    break;

            }

            //设置按钮背景色

            this.btnColor.BackColor = color;

            //预览符号

            this.PreviewImage();
        }

        private void nudSize_ValueChanged(object sender, EventArgs e)
        {
            ((IMarkerSymbol)this.pStyleGalleryItem.Item).Size = (double)this.nudSize.Value;

            this.PreviewImage();
        }

        private void nudAngle_ValueChanged(object sender, EventArgs e)
        {
            ((IMarkerSymbol)this.pStyleGalleryItem.Item).Angle = (double)this.nudAngle.Value;

            this.PreviewImage();
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            switch (this.axSymbologyControl.StyleClass)
            {

                case esriSymbologyStyleClass.esriStyleClassLineSymbols:

                    ((ILineSymbol)this.pStyleGalleryItem.Item).Width = Convert.ToDouble(this.nudWidth.Value);

                    break;

                case esriSymbologyStyleClass.esriStyleClassFillSymbols:

                    //取得面符号的轮廓线符号

                    ILineSymbol pLineSymbol = ((IFillSymbol)this.pStyleGalleryItem.Item).Outline;

                    pLineSymbol.Width = Convert.ToDouble(this.nudWidth.Value);

                    ((IFillSymbol)this.pStyleGalleryItem.Item).Outline = pLineSymbol;

                    break;

            }

            this.PreviewImage();
        }
        public Color ConvertIRgbColorToColor(IRgbColor pRgbColor)
        {
            return ColorTranslator.FromOle(pRgbColor.RGB);
        }
        public IColor ConvertColorToIColor(Color color)
        {

            IColor pColor = new RgbColorClass();

            pColor.RGB = color.B * 65536 + color.G * 256 + color.R;

            return pColor;

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {

                //将颜色按钮的背景颜色设置为用户选定的颜色

                this.btnColor.BackColor = this.colorDialog.Color;

                //设置符号颜色为用户选定的颜色

                switch (this.axSymbologyControl.StyleClass)
                {

                    //点符号

                    case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:

                        ((IMarkerSymbol)this.pStyleGalleryItem.Item).Color = this.ConvertColorToIColor(this.colorDialog.Color);

                        break;

                    //线符号

                    case esriSymbologyStyleClass.esriStyleClassLineSymbols:

                        ((ILineSymbol)this.pStyleGalleryItem.Item).Color = this.ConvertColorToIColor(this.colorDialog.Color);

                        break;

                    //面符号

                    case esriSymbologyStyleClass.esriStyleClassFillSymbols:

                        ((IFillSymbol)this.pStyleGalleryItem.Item).Color = this.ConvertColorToIColor(this.colorDialog.Color);

                        break;

                }

                //更新符号预览

                this.PreviewImage();

            }
        }

        private void btnOutlineColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {

                //取得面符号中的外框线符号

                ILineSymbol pLineSymbol = ((IFillSymbol)this.pStyleGalleryItem.Item).Outline;

                //设置外框线颜色

                pLineSymbol.Color = this.ConvertColorToIColor(this.colorDialog.Color);

                //重新设置面符号中的外框线符号

                ((IFillSymbol)this.pStyleGalleryItem.Item).Outline = pLineSymbol;

                //设置按钮背景颜色

                this.btnOutlineColor.BackColor = this.colorDialog.Color;

                //更新符号预览

                this.PreviewImage();

            }
        }

        private void btnMoreSymbols_Click(object sender, EventArgs e)
        {
            if (this.contextMenuMoreSymbolInitiated == false)
            {

               // string sInstall = ReadRegistry("SOFTWARE\\ESRI\\CoreRuntime");

                string path = System.IO.Path.GetFullPath( "D:\\Program Files (x86)\\ArcGIS\\Engine10.0\\Styles");

                //取得菜单项数量

                string[] styleNames = System.IO.Directory.GetFiles(path, "*.ServerStyle");

                ToolStripMenuItem[] symbolContextMenuItem = new ToolStripMenuItem[styleNames.Length + 1];

                //循环添加其它符号菜单项到菜单

                for (int i = 0; i < styleNames.Length; i++)
                {

                    symbolContextMenuItem[i] = new ToolStripMenuItem();

                    symbolContextMenuItem[i].CheckOnClick = true;

                    symbolContextMenuItem[i].Text = System.IO.Path.GetFileNameWithoutExtension(styleNames[i]);

                    if (symbolContextMenuItem[i].Text == "ESRI")
                    {

                        symbolContextMenuItem[i].Checked = true;

                    }

                    symbolContextMenuItem[i].Name = styleNames[i];

                }

                //添加“更多符号”菜单项到菜单最后一项

                symbolContextMenuItem[styleNames.Length] = new ToolStripMenuItem();

                symbolContextMenuItem[styleNames.Length].Text = "添加符号";

                symbolContextMenuItem[styleNames.Length].Name = "AddMoreSymbol";



                //添加所有的菜单项到菜单

                this.contextMenuStripMoreSymbol.Items.AddRange(symbolContextMenuItem);

                this.contextMenuMoreSymbolInitiated = true;

            }

            //显示菜单

            this.contextMenuStripMoreSymbol.Show(this.btnMoreSymbols.Location);
        }

        private void contextMenuStripMoreSymbol_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem pToolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            //如果单击的是“添加符号”

            if (pToolStripMenuItem.Name == "AddMoreSymbol")
            {

                //弹出打开文件对话框

                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //导入style file到SymbologyControl

                    this.axSymbologyControl.LoadStyleFile(this.openFileDialog.FileName);

                    //刷新axSymbologyControl控件

                    this.axSymbologyControl.Refresh();

                }

            }

            else//如果是其它选项
            {

                if (pToolStripMenuItem.Checked == false)
                {

                    this.axSymbologyControl.LoadStyleFile(pToolStripMenuItem.Name);

                    this.axSymbologyControl.Refresh();

                }

                else
                {

                    this.axSymbologyControl.RemoveFile(pToolStripMenuItem.Name);

                    this.axSymbologyControl.Refresh();

                }

            }
        }

        
    }
}