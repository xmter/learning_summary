using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace GISDesign
{
    class BasicMethod
    {
        private static string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
           + System.Windows.Forms.Application.StartupPath + "\\个人数据库.mdb";
        public static void CopyAndOverwriteMap(AxMapControl map, AxPageLayoutControl page)
        {
            //获取拷贝接口对象
            IObjectCopy objectCopy = new ObjectCopyClass();
            object toCopyMap = map.Map;
            object copiedMap = objectCopy.Copy(toCopyMap);//复制地图到copiedMap
            object toOverWriteMap = page.ActiveView.FocusMap;//获取视图控件的焦点地图
            objectCopy.Overwrite(copiedMap, ref toOverWriteMap);//复制地图
        }
        public static void ReadMapdbToCmb()
        {
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbDataAdapter adapter;
            DataSet ds;
            DataTable dt;
            string selectSQL = "SELECT * FROM [City]";
            try
            {
                conn.Open();
                adapter = new OleDbDataAdapter(selectSQL, conn);
                ds = new DataSet();
                adapter.Fill(ds);
                dt = ds.Tables[0];
                conn.Close();

                /*tsComboBoxMaps.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tsComboBoxMaps.Items.Add(dt.Rows[i]["CName"].ToString());
                }*/
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void AddLayersToEagleEye(AxMapControl axMapControl1,AxMapControl axMapControl2)
        {
            // 当主地图显示控件的地图更换时，鹰眼中的地图也跟随更换
            axMapControl2.Map = new MapClass();
            axMapControl2.ClearLayers();
            // 添加主地图控件中的所有图层到鹰眼控件中
            for (int i = axMapControl1.LayerCount - 1; i >= 0; i--)
            {
                axMapControl2.AddLayer(axMapControl1.get_Layer(i));
            }
            // 设置 MapControl 显示范围至数据的全局范围
            axMapControl2.Extent = axMapControl1.Extent;
            // 刷新鹰眼控件地图
            axMapControl2.Refresh();
        }
    }
}
