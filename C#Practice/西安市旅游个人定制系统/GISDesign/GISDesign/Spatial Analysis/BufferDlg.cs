// Copyright 2006 ESRI
//
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
//
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
//
// See use restrictions at /arcgis/developerkit/userestrictions.

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.AnalysisTools;

namespace GISDesign
{
    public partial class BufferDlg : Form
    {
        //in order to scroll the messages textbox to the bottom we must import this Win32 call
        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr wnd,
                                              uint Msg,
                                              IntPtr wParam,
                                              IntPtr lParam);

        private IHookHelper m_hookHelper = null;
        private const uint WM_VSCROLL = 0x0115;
        private const uint SB_BOTTOM = 7;

        public BufferDlg(IHookHelper hookHelper)
        {
            InitializeComponent();

            m_hookHelper = hookHelper;
        }

        private void bufferDlg_Load(object sender, EventArgs e)
        {
            if (null == m_hookHelper || null == m_hookHelper.Hook || 0 == m_hookHelper.FocusMap.LayerCount)
                return;

            //load all the feature layers in the map to the layers combo
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                cboLayers.Items.Add(layer.Name);
            }
            //select the first layer
            if (cboLayers.Items.Count > 0)
                cboLayers.SelectedIndex = 0;

            string tempDir = System.IO.Path.GetTempPath();
            txtOutputPath.Text = System.IO.Path.Combine(tempDir, ((string)cboLayers.SelectedItem + "_buffer.shp"));

            //set the default units of the buffer
            int units = Convert.ToInt32(m_hookHelper.FocusMap.MapUnits);
            cboUnits.SelectedIndex = units;
        }

        private void btnOutputLayer_Click(object sender, EventArgs e)
        {
            //set the output layer
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "Shapefile (*.shp)|*.shp";
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "Output Layer";
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = (string)cboLayers.SelectedItem + "_buffer.shp";

            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                txtOutputPath.Text = saveDlg.FileName;
        }

        private void btnBuffer_Click(object sender, EventArgs e)
        {
            //make sure that all parameters are okay
            double bufferDistance;
            //转换distance为double类型
            double.TryParse(txtBufferDistance.Text, out bufferDistance);
            if (0.0 == bufferDistance)
            {
                MessageBox.Show("Bad buffer distance!");
                return;
            }
            //判断输出路径是否合法
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtOutputPath.Text)) ||
              ".shp" != System.IO.Path.GetExtension(txtOutputPath.Text))
            {
                MessageBox.Show("Bad output filename!");
                return;
            }
            //判断图层个数
            if (m_hookHelper.FocusMap.LayerCount == 0)
                return;

            //get the layer from the map
            IFeatureLayer layer = GetFeatureLayer((string)cboLayers.SelectedItem);
            if (null == layer)
            {
                txtMessages.Text += "Layer " + (string)cboLayers.SelectedItem + "cannot be found!\r\n";
                return;
            }

            //scroll the textbox to the bottom
            ScrollToBottom();

            txtMessages.Text += "\r\n分析开始，这可能需要几分钟时间,请稍候..\r\n";
            txtMessages.Update();
            //get an instance of the geoprocessor
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;

            //create a new instance of a buffer tool
            ESRI.ArcGIS.AnalysisTools.Buffer buffer = new ESRI.ArcGIS.AnalysisTools.Buffer(layer, txtOutputPath.Text, Convert.ToString(bufferDistance) + " " + (string)cboUnits.SelectedItem);
            buffer.dissolve_option = "ALL";//这个要设成ALL,否则相交部分不会融合
            //buffer.line_side = "FULL";//默认是"FULL",最好不要改否则出错
            //buffer.line_end_type = "ROUND";//默认是"ROUND",最好不要改否则出错

            //execute the buffer tool (very easy :-))
            IGeoProcessorResult results = null;

            try
            {
                results = (IGeoProcessorResult)gp.Execute(buffer, null);
            }
            catch (Exception ex)
            {
                txtMessages.Text += "Failed to buffer layer: " + layer.Name + "\r\n";
            }
            if (results.Status != esriJobStatus.esriJobSucceeded)
            {
                txtMessages.Text += "Failed to buffer layer: " + layer.Name + "\r\n";
            }

            //scroll the textbox to the bottom
            ScrollToBottom();

            txtMessages.Text += "\r\n分析完成.\r\n";
            txtMessages.Text += "-----------------------------------------------------------------------------------------\r\n";
            //scroll the textbox to the bottom
            ScrollToBottom();

        }

        private string ReturnMessages(Geoprocessor gp)
        {
            StringBuilder sb = new StringBuilder();
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    System.Diagnostics.Trace.WriteLine(gp.GetMessage(Count));
                    sb.AppendFormat("{0}\n", gp.GetMessage(Count));
                }
            }
            return sb.ToString();
        }

        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
            IEnumLayer layers = GetLayers();
            layers.Reset();

            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }

            return null;
        }

        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";
            IEnumLayer layers = m_hookHelper.FocusMap.get_Layers(uid, true);

            return layers;
        }

        private void ScrollToBottom()
        {
            PostMessage((IntPtr)txtMessages.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, (IntPtr)IntPtr.Zero);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}