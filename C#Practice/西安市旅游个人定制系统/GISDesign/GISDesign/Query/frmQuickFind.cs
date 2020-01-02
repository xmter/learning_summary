using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Controls;

namespace GISDesign.Query
{
    public partial class frmQuickFind : Form
    {
        private GISDesign.MainForm pMainform = null;//定义一个mainform，用来获取主界面mainfrom中的所有组件
        private AxMapControl MainAxMapControl;             //用来获取主界面中的那个主要的mapcontrol
        IFeatureCursor FeatureCursor;      //为了不写重复而繁缛的循环语句,将这个东西定位全局变量.否则
        //查询结果需要一次全部循环,双击结果的时候还有一次全部循环

        public frmQuickFind(AxMapControl mapcontrol, MainForm _pMainForm)
        {
            InitializeComponent();
            pMainform = _pMainForm;
            MainAxMapControl = mapcontrol;
        }

        private void frmQuickFind_Load(object sender, EventArgs e)
        {
            AddAllLayerstoComboBox();
            if (comboBoxLayers.Items.Count != 0)
            {
                comboBoxLayers.SelectedIndex = 0;//让combox的当前选中的项目变为第一项，即让其默认选中第一项。否则的话为空，这样在
                //变换checkboxShowVectorOnly后，如果listBox列表不清空（已经改进了这个问题），则会出现listBOXfields有内容
                //而combox为空的情况，进而点击任意列明的时候，需要列出属性值，这里需要根据combox的
                //当前值来获取图层，具体见listBoxFields_SelectedIndexChanged(object sender, EventArgs e)
                //，而其值为空，就会出错了
                AddFieldtoCombobox();
                buttonNewSearch.Enabled = true;
                buttonSearch.Enabled = true;
            }
        }

        private void AddAllLayerstoComboBox()
        {
            try
            {
                comboBoxLayers.Items.Clear();

                int pLayerCount = MainAxMapControl.LayerCount;
                if (pLayerCount > 0)
                {
                    comboBoxLayers.Enabled = true;//下拉菜单可用

                    for (int i = 0; i <= pLayerCount - 1; i++)
                    {
                        if (MainAxMapControl.get_Layer(i) is IFeatureLayer)  //只添加矢量图层，栅格图层没有属性表
                            comboBoxLayers.Items.Add(MainAxMapControl.get_Layer(i).Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private ILayer GetLayerByName(string strLayerName)
        {
            ILayer pLayer = null;
            for (int i = 0; i <= MainAxMapControl.LayerCount - 1; i++)
            {
                if (strLayerName == MainAxMapControl.get_Layer(i).Name)
                { pLayer = MainAxMapControl.get_Layer(i); break; }
            }
            return pLayer;
        }

        private void AddFieldtoCombobox()
        {
            comboBoxField.Items.Clear();
            string strLayerName = comboBoxLayers.Text;
            IFeatureLayer pFeatureLayer = GetLayerByName(strLayerName) as IFeatureLayer;
            for (int i = 0; i <= pFeatureLayer.FeatureClass.Fields.FieldCount - 1; i++)
                comboBoxField.Items.Add(pFeatureLayer.FeatureClass.Fields.get_Field(i).Name);
        }

        private void PerformSearch()
        {
            if (textBoxKeyword.Text == "")
                MessageBox.Show("请输入所要查找的关键字！");
            else
            {
                string strFieldName = comboBoxField.Text;
                if (strFieldName == "")
                {
                    MessageBox.Show("请选择所要查找的属性字段！");
                    return;
                }
                listBoxResults.Items.Clear();
                IQueryFilter pQueryFilter = new QueryFilterClass();
                IFeatureClass pFeatureClass = (GetLayerByName(comboBoxLayers.Text) as IFeatureLayer).FeatureClass;
                IFeatureCursor pFeatureCursor;//这个是局部的
                IFeature pFeature;
                int i = 0;//用于标记结果数目
                if (strFieldName != "")
                {
                    if (checkBoxBlurSearch.Checked == true)
                        pQueryFilter.WhereClause = strFieldName + " Like " + "'" + "%" + textBoxKeyword.Text + "%" + "'";
                    else if (pFeatureClass.Fields.get_Field(pFeatureClass.Fields.FindField(strFieldName)).Type == esriFieldType.esriFieldTypeString)
                        pQueryFilter.WhereClause = strFieldName + "=" + "'" + textBoxKeyword.Text + "'";
                    else pQueryFilter.WhereClause = strFieldName + "=" + textBoxKeyword.Text;
                    pFeatureCursor = pFeatureClass.Search(pQueryFilter, true);
                    FeatureCursor = pFeatureClass.Search(pQueryFilter, true);//因为cursor一旦移动到底，是不能够再回到开头的，所以这里获得两个，一个以后留在双击的时候用
                    pFeature = pFeatureCursor.NextFeature();
                    if (pFeature == null)
                        MessageBox.Show("找不到结果！");
                    else
                    {
                        while (pFeature != null)
                        {
                            //把结果添加到列表中,列表中的字符是每个查找到的feature的相应字段的值
                            listBoxResults.Items.Add(pFeature.get_Value(pFeature.Fields.FindField(strFieldName)));
                            pFeature = pFeatureCursor.NextFeature();
                            i++;
                        }
                    }

                    labelResultNumber.Text = "共" + i.ToString() + "项";
                }

            }
        }

        private void frmQuickFind_FormClosed(object sender, FormClosedEventArgs e)
        {
            pMainform.frmQuickFindisOpen = false;
        }

        private void buttonNewSearch_Click(object sender, EventArgs e)
        {
            textBoxKeyword.Clear();
            listBoxResults.Items.Clear();
            labelResultNumber.Text = "共  " + "项";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void comboBoxField_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFieldName = comboBoxField.Text;
            IFeatureClass pFeatureClass = (GetLayerByName(comboBoxLayers.Text) as IFeatureLayer).FeatureClass;
            int index = pFeatureClass.Fields.FindField(strFieldName);
            if (pFeatureClass.Fields.get_Field(index).Type != esriFieldType.esriFieldTypeString)
            {
                checkBoxBlurSearch.Checked = false;
                checkBoxBlurSearch.Enabled = false;//非字符串的字段不能够进行模糊查找
            }
            else
                checkBoxBlurSearch.Enabled = true;
        }

        private void comboBoxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddFieldtoCombobox();
        }

        private void listBoxResults_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string strKeyword = listBoxResults.SelectedItem.ToString();//选中的结果项目
                if (strKeyword != "")
                {
                    IFeature pFeature;
                    //下面两个变量是用来把指定的元素变成选中状态的设置的，以后可以用这个方法
                    IFeatureSelection pFeatureSelection = (GetLayerByName(comboBoxLayers.Text) as IFeatureLayer) as IFeatureSelection;
                    pFeatureSelection.Clear();//底下那个ｏｉｄ的方法是在搞不定，只有用这个方法达到目的了
                    ISelectionSet pSelectionSet = pFeatureSelection.SelectionSet;
                    IEnvelope pEnvelope = new EnvelopeClass();
                    pFeature = FeatureCursor.NextFeature();//这个featurecursor是全局变量，也就是第一步查找的结果
                    int index = (GetLayerByName(comboBoxLayers.Text) as IFeatureLayer).FeatureClass.Fields.FindField(comboBoxField.Text);
                    //int oid=0;//如果用户在没有关闭查找窗口的情况下对结果列表做了多次双击，则每次双击都要清除上一次双击背选中的元素
                    while (pFeature != null)
                    {
                        if (pFeature.get_Value(index).ToString() == strKeyword)
                        {
                            //if (oid != 0)
                            //    pSelectionSet.RemoveList(1, ref oid);
                            pSelectionSet.Add(pFeature.OID);    //把这个feature加到当前选择集中
                            //oid = pFeature.OID;
                            if (pFeature.Shape.GeometryType == esriGeometryType.esriGeometryPoint || pFeature.Shape.GeometryType == esriGeometryType.esriGeometryMultipoint)
                            {
                                //如果双击的对象是一个点，这样子才能够缩放到该点
                                pEnvelope.PutCoords(0, 0, 0.3, 0.3);//确定ｅｎｖｅｌｏｐｅ大小
                                IPoint pPoint = pFeature.Shape as IPoint;
                                pEnvelope.CenterAt(pPoint);
                            }
                            else
                                pEnvelope = pFeature.Extent;
                            break;
                        }
                        pFeature = FeatureCursor.NextFeature();
                    }

                    MainAxMapControl.Extent = pEnvelope;
                    MainAxMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("缩放到指定元素出错！ | " + ex.Message);
                return;
            }
        }

        private void listBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}