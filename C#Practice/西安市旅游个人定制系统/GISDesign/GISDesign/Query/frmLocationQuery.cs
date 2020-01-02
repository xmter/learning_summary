using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace GISDesign.Query
{
    public partial class frmLocationQuery : Form
    {
        private GISDesign.MainForm pMainform = null;//定义一个mainform，用来获取主界面mainfrom中的所有组件
        private AxMapControl MainAxMapControl;             //用来获取主界面中的那个主要的mapcontrol
        private esriSpatialRelEnum pSpatialRel;            //全局变量用来获得空间关系
        //private IFeatureSelection pResultFeatureSelection;       //用来记录最终的结果


        public frmLocationQuery(AxMapControl mapcontrol,GISDesign.MainForm _pMainForm)
        {
            InitializeComponent();
            pMainform = _pMainForm;
            MainAxMapControl = mapcontrol;
        }

        #region 下面是自己的函数
        private ISpatialFilter GenerateSpatialFilter()
        {
            frmPromptQuerying frmPrompt = new frmPromptQuerying(4);//提示：构造条件图层中 为了在异常时能将此提示窗口关闭，所以放在try外面
            try
            {
                frmPrompt.Show();
                System.Windows.Forms.Application.DoEvents();//'转让控制权，没有这一句的话提示窗口不能正常显示
                //首先要构造出spatialfilter
                //获得构造spatialfilter.geometry的所有feature
                //IMap pMap;                        //用来QI到IEnumLayer
                //IEnumLayer pEnumLayer;            //接收所有作为代选层的layers
                //ILayer pLayer;
                IFeatureLayer pFeatureLayer = null;
                IGeometry pGeometry = null;
                IEnumFeature pEnumFeature = null;          //这两行分别用于使用和不使用
                IFeatureCursor pFeatureCursor = null;      //已经选择的元素生成“筛选图形”的情况
                IFeatureClass pFeatureClass;
                IFeature pFeature;
                string strLayerName = comboBoxConditionLayer.Text;
                if (checkBoxUseSelectedOnly.Checked == false)    //如果用户自己选择“条件图层”,而不用已选中的元素
                {
                    pFeatureLayer = GetLayerbyName(strLayerName) as IFeatureLayer;  //这个layer是用来构造spatialfilter.geometry的
                    //是那个“条件图层”

                    //这里不用featureselection来获得enumfeature,从而进行下面的geometry合并，而采取featurecursor，是因为
                    //用featureselection的话，获得待合并的所有feature的一句必须这么写：featureselection=mainaxmapcontrol.map.featureselection
                    //而不能指定featureselection到map具体的一个层！（比如如果featureselection=pfeaturelayer.featureselection，
                    //然后enumfeature=featureselection，这时enumfeature就是null！其中的pfeaturelayer已经是map里的一个指定的层了）
                    //如果用featureselection=mainaxmapcontrol.map.featureselection，就会有问题：也许map上面已经有被选中的元素了，而此时用这种方法
                    //获得的enumfeature只能是这些已经选中的元素，但不应该是这样，应该获得的是指定为“条件图层”的所有feature，所以只能用featurecursor
                    //如果用featureselection的话就要这么写：
                    //IFeatureSelection pFeatureSelection = MainaxMapControl.get_Layer(strLayerName) as IFeatureSelection;
                    //pFeatureSelection.SelectFeatures(null, esriSelectionResultEnum.esriSelectionResultNew, false);//仅使用已被选中的元素时，把这句话越过去
                    //IEnumFeature pEnumFeature = MainaxMapControl.Map.FeatureSelection as IEnumFeature;
                    pFeatureClass = pFeatureLayer.FeatureClass;
                    pFeatureCursor = pFeatureClass.Search(null, true);
                    pFeature = pFeatureCursor.NextFeature();
                }
                else            //如果使用地图上已选中的元素作为“筛选图层”
                {
                    pEnumFeature = MainAxMapControl.Map.FeatureSelection as IEnumFeature;
                    pFeature = pEnumFeature.Next();
                }

                pGeometry = pFeature.Shape;
                ITopologicalOperator pTopologicalOperator;
                //合并出用以当“筛子”的geometry
                while (pFeature != null)
                {
                    
                    //下面第一句是关键，这样最终的pgeometry可以获得整个大的geometry
                    //因为TopologicalOperator本身就是一个shape，一个geometry，所以结果是它本身与参数的合并.
                    //只有用shapecopy才能够正确，用shape的话线文件就出错。为了这个问题耽搁了一星期！！！
                    //还有一种思路也可以。这里的思路是用循环合并参数geometry，另一种思路是在循环用单独的每个
                    //geometry去筛选图层里的features然后合并结果
                    pTopologicalOperator = pFeature.ShapeCopy as ITopologicalOperator;
                    //if (checkBoxBuffer.Checked == true)
                    //{
                    //    double ddistance = Convert.ToDouble(textBoxBuffer.Text);
                    //    pGeometry = pTopologicalOperator.Buffer(ddistance);
                    //    //pTopologicalOperator.Simplify();        //使拓扑关系变得正确
                    //}
                    pGeometry = pTopologicalOperator.Union(pGeometry as IGeometry);
                    if (checkBoxUseSelectedOnly.Checked == false)//用的是featurecursor
                        pFeature = pFeatureCursor.NextFeature();
                    else pFeature = pEnumFeature.Next();
                }
                //pFeatureSelection.Clear();//如果不清楚这个用来获得geometry而创建的featureselection的话，这也是一句关键，
                //后面最终的显示也将把这个featureselection显示出来

                //生成缓冲区，放在上面的循环之外执行，这样子更有效率，而且更不容易出错
                if (checkBoxBuffer.Checked == true)
                {
                    double ddistance = Convert.ToDouble(textBoxBuffer.Text);
                    pTopologicalOperator = pGeometry as ITopologicalOperator;
                    pGeometry = pTopologicalOperator.Buffer(ddistance);
                    pTopologicalOperator.Simplify();        //使拓扑关系变得正确
                    //MainAxMapControl.FlashShape(pGeometry, 2, 500, null);//闪烁以验证缓冲区正确与否
                }               
                frmPrompt.WindowState = FormWindowState.Minimized;
                frmPrompt.Dispose();
                System.Windows.Forms.Application.DoEvents();
                object m_fillsymbol;                                //后面的drawshape的参数必须是object型

                IRgbColor pRgb = new RgbColorClass();               // 获取IRGBColor接口
                pRgb.Red = 255;                                     // 设置颜色属性
                ILineSymbol outline = new SimpleLineSymbolClass();          // 获取ILine符号接口
                outline.Width = 5;
                outline.Color = pRgb;
                ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();// 获取IFillSymbol接口
                simpleFillSymbol.Outline = outline;
                simpleFillSymbol.Color = pRgb;
                simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSBackwardDiagonal;
                m_fillsymbol = simpleFillSymbol;
                //MainAxMapControl.DrawShape(pGeometry, ref m_fillsymbol);
                MainAxMapControl.FlashShape(pGeometry, 3, 500, m_fillsymbol);//闪烁，让用户知道当前的"条件图层"的形状

                ISpatialFilter pSpatialFilter = new SpatialFilterClass();
                pSpatialFilter.Geometry = pGeometry;
                pSpatialFilter.SpatialRel = pSpatialRel;        //这是个全局变量
                if (checkBoxUseSelectedOnly.Checked == true)
                    pSpatialFilter.GeometryField = "Shape";     //当使用已选中的元素作为“筛选图层”时，
                //无法像底下那样去获得geometryfield，因为pfeaturelayer(条件图层)为空
                else
                    pSpatialFilter.GeometryField = pFeatureLayer.FeatureClass.ShapeFieldName;

                return pSpatialFilter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成“条件图层”出错!请检查 | " + ex.Message);
                frmPrompt.Dispose();
                return null;//出错则不返回spatialfitler
            }
        }

        private void PerformLocationQuery(ISpatialFilter pSpatialFilter)
        {
            try
            {
                frmPromptQuerying frmPrompt = new frmPromptQuerying();//提示：空间查询中
                frmPrompt.Show();
                System.Windows.Forms.Application.DoEvents();//'转让控制权，没有这一句的话提示窗口不能正常显示
                string strLayerName;
                IFeatureLayer pFeatureLayer;
                IFeatureSelection pFeatureSelection;//用来记录查询的结果
                foreach (object itemChecked in checkedListBoxFeaturesLayer1.CheckedItems)    //对于每一个选中的层都执行查询，结果合并
                {


                    strLayerName = itemChecked.ToString();    //这个才是待查询的layer
                    pFeatureLayer = GetLayerbyName(strLayerName) as IFeatureLayer;
                    pFeatureSelection = pFeatureLayer as IFeatureSelection;
                    pFeatureSelection.SelectFeatures(pSpatialFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);//待选的层可能不止一个
                    //通过循环依次查询每个层，把结果add起来
                    
                }
                //如果复选框被选中，则定位到选择结果
                if (checkBoxZoomtoSelected.Checked == true)
                {
                    IEnumFeature pEnumFeature = MainAxMapControl.Map.FeatureSelection as IEnumFeature;
                    IFeature pFeature = pEnumFeature.Next();
                    ESRI.ArcGIS.Geometry.IEnvelope pEnvelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
                    while (pFeature != null)
                    {
                        pEnvelope.Union(pFeature.Extent);
                        pFeature = pEnumFeature.Next();
                    }
                    MainAxMapControl.ActiveView.Extent = pEnvelope;
                    MainAxMapControl.ActiveView.Refresh();//如果不这样刷新，只要查询前地图已经被放大所效果的话，定位后
                    //底图没有刷新，选择集倒是定位和刷新了
                }
                frmPrompt.Dispose();
                //把结果显示出来
                MainAxMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                //double i = MainAxMapControl.Map.SelectionCount;
                //i = Math.Round(i, 0);//小数点后指定为０位数字
                //pMainform.toolStripStatusLabel1.Text = "当前共有" + i.ToString() + "个查询结果";
            }
            catch (Exception ex)
            { 
                MessageBox.Show("生成查询结果出错!请检查 | "+ex.Message);
                return;
            }
        }

        private void AddAllLayerstoCheckListBox()
        {
            checkedListBoxFeaturesLayer1.Items.Clear();
            try
            {
                int pLayerCount = MainAxMapControl.LayerCount;
                if (pLayerCount > 0)
                {
                    checkedListBoxFeaturesLayer1.Enabled = true;//选择图层框可用
                    checkBoxShowVectorOnly1.Enabled = true;//仅显示矢量复选框可用

                    for (int i = 0; i <= pLayerCount - 1; i++)
                    {
                        if (checkBoxShowVectorOnly1.Checked)
                        {
                            if (MainAxMapControl.get_Layer(i) is IFeatureLayer)  //只添加矢量图层，栅格图层没有属性表
                                checkedListBoxFeaturesLayer1.Items.Add(MainAxMapControl.get_Layer(i).Name);
                        }

                        else
                            checkedListBoxFeaturesLayer1.Items.Add(MainAxMapControl.get_Layer(i).Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载图层出错！ | "+ex.Message);
                return;
            }
        }

        private void AddConditionLayers()           //添加条件图层，但要过滤掉在checkedlistbox里已经被选中的图层
        {
            comboBoxConditionLayer.Items.Clear();//首先清空“条件图层”
            try
            {
                int pLayerCount = MainAxMapControl.LayerCount;
                if (pLayerCount > 0)
                {
                    for (int i = 0; i <= pLayerCount - 1; i++)       //先把所有图层加到combox里
                    {
                        if(MainAxMapControl.get_Layer(i) is IFeatureLayer)
                        comboBoxConditionLayer.Items.Add(MainAxMapControl.get_Layer(i).Name);
                    }

                    foreach (object itemChecked in checkedListBoxFeaturesLayer1.CheckedItems)    //再删除掉已经选中的层
                    {
                        //这个循环中的每个层都是要删去的
                        comboBoxConditionLayer.Items.Remove(itemChecked);
                    }

                    if (comboBoxConditionLayer.Items.Count > 0)
                        comboBoxConditionLayer.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private ILayer GetLayerbyName(string strLayerName)
        {
            ILayer pLayer = null;
            for (int i = 0; i <= MainAxMapControl.LayerCount - 1; i++)
            {
                if (strLayerName == MainAxMapControl.get_Layer(i).Name)
                { pLayer = MainAxMapControl.get_Layer(i); break; }
            }
            return pLayer;
        }

        #endregion

        #region 事件
        private void checkBoxBuffer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBuffer.Checked == true)
                textBoxBuffer.Enabled = true;
            else
            {
                textBoxBuffer.Enabled = false;
            }
        }

        private void comboBoxSpatialRel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSpatialRel.SelectedIndex)
            {
                case 0: pSpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    labelDescription.Text = "从待选的图层中选择出与＂条件图层＂（或已被选中的元素）相交的那些元素"; break;
                case 1: pSpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    labelDescription.Text = "从待选的图层中选择出那些被＂条件图层＂（或已被选中的元素）所包含的元素"; break;
                case 2: pSpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                    labelDescription.Text = "从待选图层中选择出那些完全包含＂条件图层＂（或已被选中的元素）的元素"; break;
                case 3: pSpatialRel = esriSpatialRelEnum.esriSpatialRelTouches;
                    labelDescription.Text = "适用于由边界接触的情况"; break;
            }
        }

        private void buttonCancel1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            pMainform.frmLocationisOpen = false;//告诉主程序当前没有打开的位置查询窗口
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//通过位置查询窗口最小化
            PerformLocationQuery(GenerateSpatialFilter());
            this.Dispose();
            pMainform.frmLocationisOpen = false;

        }

        private void frmLocationQuery_Load(object sender, EventArgs e)
        {
            AddAllLayerstoCheckListBox();
            if(checkedListBoxFeaturesLayer1.Items.Count>0)
                buttonOk.Enabled = true;
        }

        private void checkBoxShowVectorOnly1_CheckedChanged(object sender, EventArgs e)
        {
            AddAllLayerstoCheckListBox();
            AddConditionLayers();
        }

        private void checkBoxUseSelectedOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseSelectedOnly.Checked == true)
                comboBoxConditionLayer.Enabled = false;
            else comboBoxConditionLayer.Enabled = true;
        }

        private void comboBoxConditionLayer_DropDown(object sender, EventArgs e)
        {
            //在conditionlayer的combox里面添加图层的事件一定要放在这个dropdown to show的时候，如果加在
            //checkedListBoxFeaturesLayer1_ItemCheck的时候则会出现奇怪的问题（没有细想）
            AddConditionLayers();
        }

        private void textBoxBuffer_KeyDown(object sender, KeyEventArgs e)
        {
            //缓冲只能输入数字
            // keyValue>47&&<58   :   0-9   
            // keyValue=190   :   Decimal   Point
            // keyValue=189   :   "-"
            // keyValue>34&&   keyValue<41   :Home   ,End   and   Arrow   Keys   
            // keyValue==8   :Backspace   Key  
            if ((e.KeyValue > 47 && e.KeyValue < 58) || (e.KeyValue == 190) || (e.KeyValue > 34 && e.KeyValue < 41) || (e.KeyValue == 8) || (e.KeyCode == Keys.Delete) || (e.KeyValue == 189))
            { 
            }
            else
            {
                MessageBox.Show("这里只能输入数字，请重试！");
                textBoxBuffer.Clear();
                return;
            }
        }

        #endregion

        private void frmLocationQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            pMainform.frmLocationisOpen = false;//告诉主程序当前没有打开的位置查询窗口
        }

    }
}
