using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;

public class GeoMapLoad
{
    public static IMapDocument pMapDocument;
    public static void LoadGeoData(AxMapControl axMapControl1, AxMapControl axMapControl2, string strFileN)
    {
        string strFExtenN = System.IO.Path.GetExtension(strFileN);
        switch (strFExtenN)
        {
            case ".shp":
                {
                    string strPath = System.IO.Path.GetDirectoryName(strFileN);
                    string strFile = System.IO.Path.GetFileNameWithoutExtension(strFileN);
                    axMapControl1.AddShapeFile(strPath, strFile);
                    axMapControl2.ClearLayers();
                    axMapControl2.AddShapeFile(strPath, strFile);
                    axMapControl2.Extent = axMapControl2.FullExtent;
                    break;
                }
            case ".bmp":
            case ".tif":
            case ".jpg":
            case ".img":
                {
                    IWorkspaceFactory pWSF = new RasterWorkspaceFactoryClass();
                    string pathName = System.IO.Path.GetDirectoryName(strFileN);
                    string fileName = System.IO.Path.GetFileName(strFileN);
                    IWorkspace pWS = pWSF.OpenFromFile(pathName, 0);
                    IRasterWorkspace pRWS = pWS as IRasterWorkspace;
                    IRasterDataset pRasterDataSet = pRWS.OpenRasterDataset(fileName);
                    IRasterPyramid pRasPyramid = pRasterDataSet as IRasterPyramid;
                    if (pRasPyramid != null)
                    {
                        if (!(pRasPyramid.Present))
                        {
                            pRasPyramid.Create();
                        }
                    }
                    IRaster pRaster = pRasterDataSet.CreateDefaultRaster();
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromRaster(pRaster);
                    ILayer pLayer = pRasterLayer as ILayer;
                    axMapControl1.AddLayer(pLayer, 0);
                    axMapControl2.ClearLayers();
                    axMapControl2.AddLayer(pLayer, 0);
                    axMapControl2.Extent = axMapControl2.FullExtent;
                    break;
                }
            case ".mxd":
                {
                    if (axMapControl1.CheckMxFile(strFExtenN))
                    {
                        axMapControl1.LoadMxFile(strFExtenN);
                    }
                    else
                        MessageBox.Show("所选择的文件不是Mxd文件！", "提示信息");
                    break;
                }
            default:
                break;
        }
    }
    public static void OperateMapDoc(AxMapControl axMapControl1, AxMapControl axMapControl2, string strOperateType)
    {
        OpenFileDialog OpenFileDialog = new OpenFileDialog();
        SaveFileDialog SaveFileDialog = new SaveFileDialog();
        OpenFileDialog.Filter = "地图文档文件(*.mxd)|*.mxd";
        SaveFileDialog.Filter = "地图文档文件(*.mxd)|*.mxd";
        string strDocFileN = string.Empty;
        pMapDocument = new MapDocumentClass();
        switch (strOperateType)
        {
            case "NewDoc":
                {
                    SaveFileDialog.Title = "输入需要新建地图文档的名称";
                    SaveFileDialog.ShowDialog();
                    strDocFileN = SaveFileDialog.FileName;
                    if (strDocFileN == string.Empty)
                        return;
                    pMapDocument.New(strDocFileN);
                    pMapDocument.Open(strDocFileN, "");
                    axMapControl1.Map = pMapDocument.get_Map(0);
                    break;
                }
            case "OpenDoc":
                {
                    OpenFileDialog.Title = "输入需要加载的地图文档";
                    OpenFileDialog.ShowDialog();
                    strDocFileN = OpenFileDialog.FileName;
                    if (strDocFileN == string.Empty)
                        return;
                    pMapDocument.Open(strDocFileN, "");
                    for (int i = 0; i < pMapDocument.MapCount; i++)
                    {
                        axMapControl1.Map = pMapDocument.get_Map(i);
                        //axMapControl2.Map = pMapDocument.get_Map(i);
                    }
                    axMapControl1.Refresh();
                    
                    break;
                }
            case "SaveDoc":
                {
                    if (pMapDocument.get_IsReadOnly(pMapDocument.DocumentFilename) == true)
                    {
                        MessageBox.Show("此地图为只读文档", "信息提示");
                        return;
                    }
                    pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                    MessageBox.Show("保存成功！", "信息提示");
                    break;
                }
            case "SaveDocAS":
                {
                    SaveFileDialog.Filter = "地图文档另存";
                    SaveFileDialog.ShowDialog();
                    strDocFileN = SaveFileDialog.FileName;
                    if (strDocFileN == string.Empty)
                        return;
                    if (strDocFileN == pMapDocument.DocumentFilename)
                    {
                        pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                        MessageBox.Show("保存成功！", "信息提示");
                        break;
                    }
                    else
                    {
                        pMapDocument.SaveAs(strDocFileN, true, true);
                        MessageBox.Show("保存成功", "信息提示");
                    }
                    break;
                }
            default:
                break;
        }
    }




}
