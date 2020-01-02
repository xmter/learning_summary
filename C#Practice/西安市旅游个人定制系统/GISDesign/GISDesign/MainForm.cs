using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.DisplayUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using GISDesign.ExtendCommand;
using GISDesign.MapSurrounds;
using GISDesign.Query;

using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.NetworkAnalystUI;
using ESRI.ArcGIS.ArcMapUI;

using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Framework;

using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Output;

namespace GISDesign
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
       // private ITOCControl2 m_TocControl = null;
        private IToolbarMenu m_meunMap = null;
        public bool frmAttriQueryisOpen = false;      //用于按属性查询
        public bool frmLocationisOpen = false;      //用于按位置查询
        public bool frmQuickFindisOpen = false;    //用于快速查找
        private ICommand m_pCommand;
        string m_checkedToolName;
        //TOCControl中Map菜单
        private IToolbarMenu m_menuMap = null;
        #endregion
        //网络分析
        private IGeometricNetwork m_ipGeometricNetwork;
        private IMap m_ipMap;
        private IPointCollection m_ipPoints;//输入点集合
        private IPointToEID m_ipPointToEID;
        private double m_dblPathCost = 0;
        private IEnumNetEID m_ipEnumNetEID_Junctions;
        private IEnumNetEID m_ipEnumNetEID_Edges;
        private IPolyline m_ipPolyline;
        private IActiveView m_ipActiveView;
        private bool clicked;
        IGraphicsContainer pGC;
        int clickedcount = 0;
       


       
        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;
            this.WindowState = FormWindowState.Maximized;
            axTOCControl1.SetBuddyControl(axMapControl1);
            axToolbarControl1.SetBuddyControl(axMapControl1);

            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;

            //Add ToolbarControl items
            axToolbarControl3.AddItem("esriControls.ControlsOpenDocCommand", 0, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl3.AddItem("esriControls.ControlsPageZoomInTool", 0, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl3.AddItem("esriControls.ControlsPageZoomOutTool", 0, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl3.AddItem("esriControls.ControlsPageZoomWholePageCommand", 0, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl3.AddItem("esriControls.ControlsMapZoomInTool", 0, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl3.AddItem("esriControls.ControlsMapZoomOutTool", 0, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl3.AddItem("esriControls.ControlsMapPanTool", 0, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl3.AddItem("esriControls.ControlsMapFullExtentCommand", 0, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl3.AddItem("esriControls.ControlsSelectTool", 0, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            
            //Create a new ToolbarPalette 
            IToolbarPalette toolbarPalette = new ToolbarPalette();
            toolbarPalette.Caption = "Map Surrounds";
            toolbarPalette.AddItem(new CreateNorthArrow(), -1, -1);
            toolbarPalette.AddItem(new CreateScaleBar(), -1, -1);
            toolbarPalette.AddItem(new CreateScaleText(), -1, -1);
            //Add the ToolbarPalette to the ToolbarControl
            axToolbarControl3.AddItem(toolbarPalette, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
           
            
        }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
            axMapControl2.ClearLayers();
            IGraphicsContainer pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;
            //在绘制前，清除axMapControl2中的任何图形元素
            pGraphicsContainer.DeleteAllElements();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
            for (int i = m_mapControl.LayerCount-1; i>=0; i--)
            {
                axMapControl2.AddLayer(m_mapControl.get_Layer(i));
            }
            axMapControl2.Extent = axMapControl2.FullExtent;
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
            //IMap pMap = axMapControl1.Map;
            if (axMapControl1.LayerCount > 0)
            {
                //// 当主地图显示控件的地图更换时，鹰眼中的地图也跟随更换
                //axMapControl2.Map = new MapClass();
                //axMapControl2.ClearLayers();
                //// 添加主地图控件中的所有图层到鹰眼控件中
                //for (int i = axMapControl1.LayerCount - 1; i >=0 ; i--)
                //{
                //    axMapControl2.AddLayer(axMapControl1.get_Layer(i));
                //}
                //// 设置 MapControl 显示范围至数据的全局范围
                //// axMapControl2.Extent = axMapControl1.Extent;
                //axMapControl2.Extent = axMapControl1.Extent;
                //// 刷新鹰眼控件地图
                //axMapControl2.Refresh();
                //axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                BasicMethod.AddLayersToEagleEye(axMapControl1, axMapControl2);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {

           
            #region  主窗体右键
            /////地图视窗鼠标事件
            IToolbarMenu mapPopMenu = null;
            mapPopMenu = new ToolbarMenu();
            if (e.button == 2)
            {
                /* IMap pMap = axMapControl1.Map;
                 IActiveView pActiveView = pMap as IActiveView;
                 IEnvelope pEnv = axMapControl1.TrackRectangle();
                 pActiveView.Extent = pEnv;
                 pActiveView.Refresh();*/

                //地图视窗右键菜单功能

                mapPopMenu.AddItem(new ControlsSelectTool(), -1, 0, false, esriCommandStyles.esriCommandStyleIconAndText);
                mapPopMenu.AddItem(new ControlsMapPanTool(), -1, 1, false, esriCommandStyles.esriCommandStyleIconAndText);
                mapPopMenu.AddItem(new ControlsMapFullExtentCommand(), -1, 2, false, esriCommandStyles.esriCommandStyleIconAndText);
                mapPopMenu.AddItem(new ControlsMapIdentifyTool(), -1, 3, false, esriCommandStyles.esriCommandStyleIconAndText);//识别工具
                mapPopMenu.AddItem(new ControlsMapZoomInFixedCommand(), -1, 4, false, esriCommandStyles.esriCommandStyleIconAndText);//
                mapPopMenu.AddItem(new ControlsMapZoomInFixedCommand(), -1, 5, false, esriCommandStyles.esriCommandStyleIconAndText);
                mapPopMenu.AddItem(new ControlsSelectFeaturesTool(), -1, 6, false, esriCommandStyles.esriCommandStyleIconAndText);//选择要素工具
                mapPopMenu.AddItem(new ControlsClearSelectionCommand(), -1, 7, false, esriCommandStyles.esriCommandStyleIconAndText);//缩放所选要素
                mapPopMenu.AddItem(new ControlsZoomToSelectedCommand(), -1, 8, false, esriCommandStyles.esriCommandStyleIconAndText);
                mapPopMenu.AddItem(new ControlsMapZoomToLastExtentBackCommand(), -1, 9, false, esriCommandStyles.esriCommandStyleIconAndText);
                mapPopMenu.AddItem(new ControlsMapZoomToLastExtentForwardCommand(), -1, 10, false, esriCommandStyles.esriCommandStyleIconAndText);
                mapPopMenu.SetHook(axMapControl1);//// 得到地图视窗右键菜单
                mapPopMenu.PopupMenu(e.x, e.y, axMapControl1.hWnd);//弹出显示菜单
            }
            /*  if (e.button == 1)//左键因为右键要取消
              {
                  IMap pMap = axMapControl1.Map;
                   IActiveView pActiveView = pMap as IActiveView;
                   IEnvelope pEnv = axMapControl1.TrackRectangle();
                   pActiveView.Extent = pEnv;
                   pActiveView.Refresh();
              }
             * */
            //此事件不会触发
            if (e.button == 3)//如果鼠标中间改为ControlsMapPanTool会更好
            {
                IMap pMap = axMapControl1.Map;
                IActiveView pActiveView = pMap as IActiveView;
                IEnvelope pEnv = axMapControl1.TrackRectangle();
                pActiveView.Extent = pEnv;
                pActiveView.Refresh();
            }
            #endregion

            //if (e.button == 2)
            //{
            //    IMap pMap = axMapControl1.Map;
            //    IActiveView pActiveView = pMap as IActiveView;
            //    IEnvelope pEnv = axMapControl1.TrackRectangle();
            //    pActiveView.Extent = pEnv;
            //    pActiveView.Refresh();
            //}
            //网络分析
            if (clicked != true)
                return;
            IPoint ipNew;
            if (m_ipPoints == null)
            {
                m_ipPoints = new MultipointClass();
            }
            ipNew = m_ipActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
            object o = Type.Missing;
            m_ipPoints.AddPoint(ipNew, ref o, ref o);

            IElement element;
            ITextElement textelement = new TextElementClass();
            element = textelement as IElement;
            clickedcount++;
            textelement.Text = clickedcount.ToString();
            element.Geometry = m_ipActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
            pGC.AddElement(element, 0);
            m_ipActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            //如果不是右键按下直接返回
            if (e.button != 2) return;

            if (e.button == 2)
            {

                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap map = null;
                ILayer layer = null;
                object other = null;
                object index = null;
                RightMenu rtMenu = new RightMenu(axTOCControl1);
                IToolbarMenu m_meunLayer = rtMenu.getToolbarMenu();
                m_meunLayer.SetHook(m_mapControl);
                //判断所选菜单的类型 
                rtMenu.m_TocC.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

                //确定选定的菜单类型，Map 或是图层菜单 
                if (item == esriTOCControlItem.esriTOCControlItemMap)
                    rtMenu.m_TocC.SelectItem(map, null);
                else
                    rtMenu.m_TocC.SelectItem(layer, null);

                //设置CustomProperty 为layer (用于自定义的Layer 命令) 
                m_mapControl.CustomProperty = layer;
                if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    
                    //动态添加ShowAttributeTable菜单项
                    m_meunLayer.AddItem(new OpenAttributeTable(layer), -1, 2, true, esriCommandStyles.esriCommandStyleTextOnly);
                    m_meunLayer.PopupMenu(e.x, e.y, rtMenu.m_TocC.hWnd);
                    //移除OpenAttributeTable菜单项，以防止重复添加
                    m_meunLayer.Remove(2);
                }
            }
        }

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //if (this.axMapControl2.Map.LayerCount != 0)
            //{
            //    // 按下鼠标左键移动矩形框
            //    if (e.button == 1)
            //    {
            //        IPoint pPoint = new PointClass();
            //        pPoint.PutCoords(e.mapX, e.mapY);
            //        IEnvelope pEnvelope = this.axMapControl1.Extent;
            //        pEnvelope.CenterAt(pPoint);
            //        this.axMapControl1.Extent = pEnvelope;
            //        this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            //    }
            //    // 按下鼠标右键绘制矩形框
            //    else if (e.button == 2)
            //    {
            //        IEnvelope pEnvelop = this.axMapControl2.TrackRectangle();
            //        this.axMapControl1.Extent = pEnvelop;
            //        this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            //    }
            //}
            if (axMapControl2.Map.LayerCount > 0)
            {
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();

                    pPoint.PutCoords(e.mapX, e.mapY);

                    axMapControl1.CenterAt(pPoint);

                    axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                else if (e.button == 2)
                {
                    IEnvelope pEnv = axMapControl2.TrackRectangle();

                    axMapControl1.Extent = pEnv;

                    axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }
        }

        private void axMapControl2_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            //if (e.button != 1)
            //    return;
            //IPoint pPt = new PointClass();
            //pPt.X = e.mapX;
            //pPt.Y = e.mapY;
            //axMapControl1.CenterAt(pPt);
            //axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            if (e.button == 1)
            {
                IPoint pPoint = new PointClass();

                pPoint.PutCoords(e.mapX, e.mapY);

                axMapControl1.CenterAt(pPoint);

                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

            }
        }

        private void menuFile_Click(object sender, EventArgs e)
        {

        }

       private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
            toolStripMenuItem29.Image = null;
            //toolStripMenuItem1.Image = GISDesign.Properties.Resources._0b907cd9b2e1861511df9bc9;
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
            toolStripMenuItem1.Image = null;
            //toolStripMenuItem29.Image = GISDesign.Properties.Resources._0b907cd9b2e1861511df9bc9;
        }

        private void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            // axMapControl1.CurrentTool = null;
        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            IActiveView pActiveView = axPageLayoutControl1.ActiveView.FocusMap as IActiveView;
            IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
            displayTransformation.VisibleBounds = axMapControl1.Extent;
            axPageLayoutControl1.ActiveView.Refresh();
            BasicMethod.CopyAndOverwriteMap(axMapControl1, axPageLayoutControl1);
        }

        private void axMapControl1_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        {
            axTOCControl1.Update();
            BasicMethod.CopyAndOverwriteMap(axMapControl1, axPageLayoutControl1);
        }

        //private void toolStripButton9_Click(object sender, EventArgs e)
        //{
        //    frmMapManage m_mapManage = new frmMapManage(axPageLayoutControl1.Object, false);
        //    m_mapManage.ShowDialog();
        //    // fresh the combobox.
        //    BasicMethod.ReadMapdbToCmb();
        //}

        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            //if (e.button == 2) return;
            //if (m_checkedToolName != "")
            //{
            //    switch (m_checkedToolName)
            //    {
            //        case "tspAddText":
            //            frmTextElement m_textElement = new frmTextElement(axPageLayoutControl1.Object, e.pageX, e.pageY);
            //            m_textElement.ShowDialog();

            //            tspAddText.Checked = false;
            //            break;
            //        case "tspAddScale":
            //            frmScaleElement m_scaleElement = new frmScaleElement(axPageLayoutControl1.Object, e.pageX, e.pageY);

            //            m_scaleElement.ShowDialog();
            //            tspAddScale.Checked = false;
            //            break;
            //        case "tspAddLegend":
            //            frmLegendElement m_legendElement = new frmLegendElement(axPageLayoutControl1.Object, e.pageX, e.pageY);

            //            m_legendElement.ShowDialog();
            //            tspAddLegend.Checked = false;
            //            break;
            //        case "tspAddNorth":
            //            IEnvelope pEnvelope = axPageLayoutControl1.TrackRectangle();
            //            frmNorthElement m_northElement = new frmNorthElement(axPageLayoutControl1.Object, e.pageX, e.pageY/*pEnvelope*/);

            //            m_northElement.ShowDialog();
            //            tspAddNorth.Checked = false;
            //            break;
            //        default:
            //            break;
            //    }
            //    m_checkedToolName = "";
            //    this.axPageLayoutControl1.MousePointer = esriControlsMousePointer.esriPointerDefault;
            //}
        }

      
        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            // 得到新范围
            IEnvelope pEnvelope = (IEnvelope)e.newEnvelope;
            IGraphicsContainer pGraphicsContainer = axMapControl2.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            //在绘制前，清除axMapControl2中的任何图形元素
            pGraphicsContainer.DeleteAllElements();
            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pElement = pRectangleEle as IElement;
            pElement.Geometry = pEnvelope;
            //设置鹰眼图中的红线框
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;
            //产生一个线符号对象
            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 3;
            pOutline.Color = pColor;
            //设置颜色属性
            pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 0;
            //设置填充符号的属性
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutline;
            IFillShapeElement pFillShapeEle = pElement as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeEle, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

      
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

        }

        private void 按属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAttriQueryisOpen != true)
            {
                frmAttriQuery frmAttriQuery1 = new frmAttriQuery(this.axMapControl1,this);
                frmAttriQuery1.Show();
                frmAttriQueryisOpen = true;
            }
        }

        private void 按位置查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLocationisOpen != true)
            {
                frmLocationQuery frmLocQuery = new frmLocationQuery(this.axMapControl1,this);
                frmLocQuery.Show();
                frmLocationisOpen = true;
            }
        }

        private void 快速查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 进行选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCommand;
            pCommand = new ESRI.ArcGIS.Controls.ControlsSelectFeaturesToolClass();
            if (tabControl1.SelectedTab == tabPage1)
                pCommand.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = pCommand as ESRI.ArcGIS.SystemUI.ITool;
        }

        private void 全部选中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCommand;
            pCommand = new ESRI.ArcGIS.Controls.ControlsSelectAllCommandClass();
            pCommand.OnCreate(axMapControl1.Object);
            pCommand.OnClick();
        }

        private void 反向选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCommand;
            pCommand = new ESRI.ArcGIS.Controls.ControlsSwitchSelectionCommandClass();
            pCommand.OnCreate(axMapControl1.Object);
            pCommand.OnClick();
        }

        private void 清除选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCommand;
            pCommand = new ESRI.ArcGIS.Controls.ControlsClearSelectionCommandClass();
            pCommand.OnCreate(axMapControl1.Object);
            pCommand.OnClick();
        }

        private void 缩放到已选范围ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand pCommand;
            pCommand = new ESRI.ArcGIS.Controls.ControlsZoomToSelectedCommandClass();
            pCommand.OnCreate(axMapControl1.Object);
            pCommand.OnClick();
        }

        private void 快速查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmQuickFindisOpen != true)
            {
                frmQuickFind frmQuickFind = new frmQuickFind(this.axMapControl1,this);
                frmQuickFind.Show();
                frmQuickFindisOpen = true;
            }
        }

        private void axTOCControl1_OnDoubleClick(object sender, ITOCControlEvents_OnDoubleClickEvent e)
        {
            esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;

            IBasicMap basicMap = null;

            ILayer layer = null;

            object unk = null;

            object data = null;

            axTOCControl1.HitTest(e.x, e.y, ref itemType, ref basicMap, ref layer, ref unk, ref data);

            if (e.button == 1)
            {

                if (itemType == esriTOCControlItem.esriTOCControlItemLegendClass)
                {

                    //取得图例

                    ILegendClass pLegendClass = ((ILegendGroup)unk).get_Class((int)data);

                    //创建符号选择器SymbolSelector实例

                    SymbolSelectorFrm SymbolSelectorFrm = new SymbolSelectorFrm(pLegendClass, layer);

                    if (SymbolSelectorFrm.ShowDialog() == DialogResult.OK)
                    {

                        //局部更新主Map控件

                        axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

                        //设置新的符号

                        pLegendClass.Symbol = SymbolSelectorFrm.pSymbol;

                        //更新主Map控件和图层控件

                        this.axMapControl1.ActiveView.Refresh();

                        this.axTOCControl1.Refresh();

                    }
                }
            }
        }

        Boolean flag = true;
        private void 常用工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (flag == false)
            {
                flag = true;
                // axToolbarControl4.Visible = flag;
            }
            else
            {
                flag = false;
            }
            axToolbarControl1.Visible = flag;
        }
        Boolean flag5 = false;
        private void 地图导航工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag5 == true)
            {
                flag5 = false;
                // axToolbarControl4.Visible = flag;
            }
            else
            {
                flag5 = true;
            }
            axToolbarControl5.Visible = flag5;
        }
        Boolean flag4 = false;
        private void 网络分析工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag4 == true)
            {
                flag4 = false;
                
            }
            else
            {
                flag4 = true;
            }
            axToolbarControl4.Visible = flag4;
        }
        Boolean flag6= false;
        private void 绘图工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag6 == true)
            {
                flag6 = false;

            }
            else
            {
                flag6 = true;
            }
            axToolbarControl6.Visible = flag6;
        }
      
        private void 叠加分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GDBInput pGDB = new GDBInput();

            IWorkspace pWs = pGDB.GetWorkspace("D:\\第二次公开课\\IDW\\JiAn", GISDesign.GDBInput.GDBType.SHP);

            IFeatureClass pFeatureClass = pGDB.GetFeatureClass(pWs as IFeatureWorkspace, "BoundMask");

            IFeatureClass pFt = pGDB.GetFeatureClass(pWs as IFeatureWorkspace, "Bound");

            IFeatureClass pFt1 = new InterSect().Intsect(pFeatureClass, pFt, "D:\\第二次公开课\\IDW\\JiAn", "test11");

            IFeatureLayer pFeatureLayer = new FeatureLayerClass();

            pFeatureLayer.FeatureClass = pFt1;

            axMapControl1.Map.AddLayer(pFeatureLayer as ILayer);

            axMapControl1.ActiveView.Refresh();

        }

        private void iDW内插ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDW pIDW = new IDW();

            IGeoDataset pGeoDataset = pIDW.GetIDW((axMapControl1.Map.get_Layer(0) as IFeatureLayer).FeatureClass, "H", .013866668, 0.5, 2);

            IRaster pRaster = pGeoDataset as IRaster;

            // ILayerFile pLayerFile = new LayerFileClass();

            // pLayerFile.Open(@"..\\..\\..\\..\\..\\Idw_shp.lyr");



            IRasterLayer pRsterLayer = new RasterLayerClass();

            pRsterLayer.CreateFromRaster(pRaster);

            //  pRsterLayer.Renderer = (pLayerFile.Layer as IRasterLayer).Renderer;


            axMapControl1.AddLayer(pRsterLayer);
        }
        
        public MainForm()
        {
            LoadingForm load = new LoadingForm();
            load.ShowDialog(this);
            InitializeComponent();
            m_ipActiveView = axMapControl1.ActiveView;
            m_ipMap = m_ipActiveView.FocusMap;
            clicked = false;
            pGC = m_ipMap as IGraphicsContainer;
        }
        public void OpenFeatureDatasetNetwork(IFeatureDataset FeatureDataset)
        {
            CloseWorkspace();
            if (!InitializeNetworkAndMap(FeatureDataset))
                Console.WriteLine("打开network出错");
        }
        //路径成本
        public double PathCost
        {
            get { return m_dblPathCost; }
        }
        //返回路径的几何体
        public IPolyline PathPolyLine()
        {
            IEIDInfo ipEIDInfo;
            IGeometry ipGeometry;
            if (m_ipPolyline != null) return m_ipPolyline;

            m_ipPolyline = new PolylineClass();
            IGeometryCollection ipNewGeometryColl = m_ipPolyline as IGeometryCollection;//引用传递

            ISpatialReference ipSpatialReference = m_ipMap.SpatialReference;
            IEIDHelper ipEIDHelper = new EIDHelperClass();
            ipEIDHelper.GeometricNetwork = m_ipGeometricNetwork;
            ipEIDHelper.OutputSpatialReference = ipSpatialReference;
            ipEIDHelper.ReturnGeometries = true;
            IEnumEIDInfo ipEnumEIDInfo = ipEIDHelper.CreateEnumEIDInfo(m_ipEnumNetEID_Edges);
            int count = ipEnumEIDInfo.Count;
            ipEnumEIDInfo.Reset();
            for (int i = 0; i < count; i++)
            {
                ipEIDInfo = ipEnumEIDInfo.Next();
                ipGeometry = ipEIDInfo.Geometry;
                ipNewGeometryColl.AddGeometryCollection(ipGeometry as IGeometryCollection);
            }
            return m_ipPolyline;
        }
        //解决路径
        public void SolvePath(string WeightName)
        {
            try
            {
                int intEdgeUserClassID;
                int intEdgeUserID;
                int intEdgeUserSubID;
                int intEdgeID;
                IPoint ipFoundEdgePoint;
                double dblEdgePercent;
                ITraceFlowSolverGEN ipTraceFlowSolver = new TraceFlowSolverClass() as ITraceFlowSolverGEN;
                INetSolver ipNetSolver = ipTraceFlowSolver as INetSolver;
                INetwork ipNetwork = m_ipGeometricNetwork.Network;
                ipNetSolver.SourceNetwork = ipNetwork;
                INetElements ipNetElements = ipNetwork as INetElements;
                int intCount = m_ipPoints.PointCount;//这里的points有值吗？
                //定义一个边线旗数组
                IEdgeFlag[] pEdgeFlagList = new EdgeFlagClass[intCount];
                for (int i = 0; i < intCount; i++)
                {
                    INetFlag ipNetFlag = new EdgeFlagClass() as INetFlag;
                    IPoint ipEdgePoint = m_ipPoints.get_Point(i);
                    //查找输入点的最近的边线
                    m_ipPointToEID.GetNearestEdge(ipEdgePoint, out intEdgeID, out ipFoundEdgePoint, out dblEdgePercent);
                    ipNetElements.QueryIDs(intEdgeID, esriElementType.esriETEdge, out intEdgeUserClassID, out intEdgeUserID, out intEdgeUserSubID);
                    ipNetFlag.UserClassID = intEdgeUserClassID;
                    ipNetFlag.UserID = intEdgeUserID;
                    ipNetFlag.UserSubID = intEdgeUserSubID;
                    IEdgeFlag pTemp = (IEdgeFlag)(ipNetFlag as IEdgeFlag);
                    pEdgeFlagList[i] = pTemp;
                }
                ipTraceFlowSolver.PutEdgeOrigins(ref pEdgeFlagList);
                INetSchema ipNetSchema = ipNetwork as INetSchema;
                INetWeight ipNetWeight = ipNetSchema.get_WeightByName(WeightName);
                INetSolverWeights ipNetSolverWeights = ipTraceFlowSolver as INetSolverWeights;
                ipNetSolverWeights.FromToEdgeWeight = ipNetWeight;//开始边线的权重
                ipNetSolverWeights.ToFromEdgeWeight = ipNetWeight;//终止边线的权重
                object[] vaRes = new object[intCount - 1];
                //通过findpath得到边线和交汇点的集合
                ipTraceFlowSolver.FindPath(esriFlowMethod.esriFMConnected,
                 esriShortestPathObjFn.esriSPObjFnMinSum,
                 out m_ipEnumNetEID_Junctions, out m_ipEnumNetEID_Edges, intCount - 1, ref vaRes);
                //计算元素成本
                m_dblPathCost = 0;
                for (int i = 0; i < vaRes.Length; i++)
                {
                    double m_Va = (double)vaRes[i];//我修改过
                    m_dblPathCost = m_dblPathCost + m_Va;
                }
                m_ipPolyline = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //初始化几何网络和地图 
        private bool InitializeNetworkAndMap(IFeatureDataset FeatureDataset)
        {
            IFeatureClassContainer ipFeatureClassContainer;
            IFeatureClass ipFeatureClass;
            IGeoDataset ipGeoDataset;
            ILayer ipLayer;
            IFeatureLayer ipFeatureLayer;
            IEnvelope ipEnvelope, ipMaxEnvelope;
            double dblSearchTol;
            INetworkCollection ipNetworkCollection = FeatureDataset as INetworkCollection;
            int count = ipNetworkCollection.GeometricNetworkCount;
            //获取第一个几何网络工作空间
            m_ipGeometricNetwork = ipNetworkCollection.get_GeometricNetwork(0);
            INetwork ipNetwork = m_ipGeometricNetwork.Network;
            if (m_ipMap != null)
            {
                //m_ipMap = new MapClass();
                ipFeatureClassContainer = m_ipGeometricNetwork as IFeatureClassContainer;
                count = ipFeatureClassContainer.ClassCount;
                for (int i = 0; i < count; i++)
                {
                    ipFeatureClass = ipFeatureClassContainer.get_Class(i);
                    ipFeatureLayer = new FeatureLayerClass();
                    ipFeatureLayer.FeatureClass = ipFeatureClass;
                    for (int j = 0; j < m_ipMap.LayerCount; j++)
                    {
                        if (m_ipMap.get_Layer(j).Name.ToUpper() == ipFeatureLayer.Name.ToUpper())
                        {
                            continue;
                        }
                    }
                    m_ipMap.AddLayer(ipFeatureLayer);
                }
                m_ipActiveView.Refresh();
            }
            count = m_ipMap.LayerCount;
            ipMaxEnvelope = new EnvelopeClass();
            for (int i = 0; i < count; i++)
            {
                ipLayer = m_ipMap.get_Layer(i);
                ipFeatureLayer = ipLayer as IFeatureLayer;
                ipGeoDataset = ipFeatureLayer as IGeoDataset;
                ipEnvelope = ipGeoDataset.Extent;
                ipMaxEnvelope.Union(ipEnvelope);
            }
            m_ipPointToEID = new PointToEIDClass();
            m_ipPointToEID.SourceMap = m_ipMap;
            m_ipPointToEID.GeometricNetwork = m_ipGeometricNetwork;
            double dblWidth = ipMaxEnvelope.Width;
            double dblHeight = ipMaxEnvelope.Height;
            if (dblWidth > dblHeight)
                dblSearchTol = dblWidth / 100;
            else
                dblSearchTol = dblHeight / 100;
            m_ipPointToEID.SnapTolerance = dblSearchTol;
            return true;
        }
        //关闭工作空间            
        private void CloseWorkspace()
        {
            m_ipGeometricNetwork = null;
            m_ipPoints = null;
            m_ipPointToEID = null;
            m_ipEnumNetEID_Junctions = null;
            m_ipEnumNetEID_Edges = null;
            m_ipPolyline = null;
        }
        public void OpenAccessNetwork(string AccessFileName, string FeatureDatasetName)
        {
            IWorkspaceFactory ipWorkspaceFactory;
            IWorkspace ipWorkspace;
            IFeatureWorkspace ipFeatureWorkspace;
            IFeatureDataset ipFeatureDataset;
            CloseWorkspace();

            //open the mdb
            ipWorkspaceFactory = new AccessWorkspaceFactory();
            ipWorkspace = ipWorkspaceFactory.OpenFromFile(AccessFileName, 0);

            //et the FeatureWorkspace
            ipFeatureWorkspace = ipWorkspace as IFeatureWorkspace;

            //open the FeatureDataset
            ipFeatureDataset = ipFeatureWorkspace.OpenFeatureDataset(FeatureDatasetName);

            //initialize Network and Map (m_ipNetwork, m_ipMap)
            if (InitializeNetworkAndMap(ipFeatureDataset))
            {
                MessageBox.Show("Error!");
            }
        }

        private void FindPath_Click(object sender, EventArgs e)
        {
            if (m_ipMap.LayerCount == 0)
                return;
            ILayer ipLayer = m_ipMap.get_Layer(0);
            IFeatureLayer ipFeatureLayer = ipLayer as IFeatureLayer;
            IFeatureDataset ipFDS = ipFeatureLayer.FeatureClass.FeatureDataset;
            OpenFeatureDatasetNetwork(ipFDS);
            clicked = true;
        }

        private void PathSolve_Click_1(object sender, EventArgs e)
        {
            SolvePath("Weight");//先解析路径
            IPolyline ipPolyResult = PathPolyLine();//最后返回最短路径
            clicked = false;


            IRgbColor color = new RgbColorClass();
            color.Red = 255;
            IElement element = new LineElementClass();
            ILineSymbol linesymbol = new SimpleLineSymbolClass();
            linesymbol.Color = color as IColor;
            linesymbol.Width = 100;
            element.Geometry = m_ipPolyline;
            pGC.AddElement(element, 2);
            m_ipActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            CloseWorkspace();
        }


        private void 缓冲区分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //定义参数  
            IHookHelper map_hookHelper = new HookHelperClass();

            //参数赋值  
            //Hook定义  
            map_hookHelper.Hook = this.axMapControl1.Object;
            //窗体调用             
            BufferDlg BAFrm = new BufferDlg(map_hookHelper);
            BAFrm.ShowDialog();  
        }

        Boolean flag7 = false;
        private void 最短路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag7 == true)
            {
                flag7 = false;
                // axToolbarControl4.Visible = flag;
            }
            else
            {
                flag7 = true ;
            }
            toolStrip1.Visible = flag7;
        }

        private void 联系我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutFrm about = new AboutFrm();
            about.ShowDialog();
        }
       
        #region 时态展示
      
        /*
         * Timer pTimer = null;
        int pCount = 0;
        ITimeExtent pTimeExtent = null;

        IMosaicLayer pMoaicLayer = null;
        private void 时态展示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pTimer = new Timer();
            pMoaicLayer = axMapControl1.get_Layer(0) as IMosaicLayer;
            pTimer.Enabled = true;

            Disp(axMapControl1.Map, pMoaicLayer, "MTime");

            pTimer.Tick += new EventHandler(pTimer_Tick);
        }
        private void Disp(IMap pMap, IMosaicLayer pMosaicLayer, string pField)
        {

            ITimeZoneFactory pTZFac = new TimeZoneFactoryClass();
            ITimeData pTimeData = pMosaicLayer as ITimeData;
            String pTimeZoneId = pTZFac.QueryLocalTimeZoneWindowsID();
            ITimeReference timeRef = pTZFac.CreateTimeReferenceFromWindowsID(pTimeZoneId);
            if (pTimeData.SupportsTime)
            {

                pTimeData.UseTime = true;//启用时间
                ITimeTableDefinition pTimeDataDef = pMosaicLayer as ITimeTableDefinition;
                pTimeDataDef.StartTimeFieldName = pField;//设置时间字段
                pTimeDataDef.TimeReference = timeRef;
                ITimeDataDisplay pTimeAnimProp = pMosaicLayer as ITimeDataDisplay;
                pTimeAnimProp.TimeIntervalUnits = esriTimeUnits.esriTimeUnitsHours;
                pTimeAnimProp.TimeInterval = 1;
                pTimeAnimProp.TimeDataCumulative = false;
                pTimeExtent = pTimeData.GetFullTimeExtent();//获取时间范围
            }

            //
            IActiveView pActiveView = pMap as IActiveView;
            IScreenDisplay pScreenDisplay = pActiveView.ScreenDisplay;
            ITimeDisplay pTimeDisplay = pScreenDisplay as ITimeDisplay;
            pTimeDisplay.TimeReference = timeRef;

            //ITime pStartTime = new TimeClass();
            //pStartTime.Year = pTimeExtent.StartTime.Year; pStartTime.Month = pTimeExtent.StartTime.Month; pStartTime.Day = pTimeExtent.StartTime.Day; pStartTime.Hour = pTimeExtent.StartTime.Hour;
            //ITime pEndTime = new TimeClass();
            //pEndTime.Year = pTimeExtent.EndTime.Year; pEndTime.Month = pTimeExtent.EndTime.Month; pEndTime.Day = pTimeExtent.EndTime.Day; pEndTime.Hour = pTimeExtent.EndTime.Hour;

            //pTimeExt = new TimeExtentClass();
            //pTimeExt.StartTime = pStartTime;
            //pTimeExt.EndTime = pEndTime;
            pTimeDisplay.TimeValue = pTimeExtent as ITimeValue;
            pActiveView.Refresh();

        }
        ITimeExtent pTimeExt = new TimeExtentClass();
        private void pTimer_Tick(object sender, EventArgs e)
        {
            try
            {


                IMap pMap = axMapControl1.Map;
                IActiveView pActiveView = pMap as IActiveView;
                IMapTimeDisplay pMapDis = pMap as IMapTimeDisplay;
                IScreenDisplay pScreenDisplay = pActiveView.ScreenDisplay;

                ITimeDisplay pTimeDisplay = pScreenDisplay as ITimeDisplay;
                ITime pStartTime = pTimeExtent.StartTime;
                ITime pEndTime = (ITime)((IClone)pStartTime).Clone();
                ((ITimeOffsetOperator)pEndTime).AddHours(1 * pCount);
                pTimeExt.SetExtent(pStartTime, pEndTime);
                pTimeExt.StartTime = pEndTime;
                pCount += 1;
                if (pEndTime.Compare(pTimeExtent.EndTime) >= 1)
                {
                    pTimer.Enabled = false;

                    // pMapDis.PlayOption = esriMapTimePlayOption.esriMapTimeReverseAfterPlaying;
                    pTimeExt.SetExtent(pTimeExtent.StartTime, pTimeExtent.EndTime);

                }

                pMapDis.TimeValue = pTimeExt as ITimeValue; //设置播放时间范围内的数据
                pMapDis.DisplaySpeed = 10;

                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);


            }
            catch (Exception Err)
            {

            }
        }
        */
        #endregion



    }
}