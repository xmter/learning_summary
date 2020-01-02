using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.GlobeCore;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Location;
using ESRI.ArcGIS.GeoAnalyst;
namespace GISDesign
{
  
    public class IDW
    {

        public IGeoDataset GetIDW(IFeatureClass _pFeatureClass, string _pFieldName, double _pDistance, double _pCell, int _pPower)
       {
           IGeoDataset Geo = _pFeatureClass as IGeoDataset;
           object pExtent = Geo.Extent;
           object o = Type.Missing;
           IFeatureClassDescriptor pFeatureClassDes = new FeatureClassDescriptorClass();
           pFeatureClassDes.Create(_pFeatureClass, null, _pFieldName);
           IInterpolationOp pInterOp = new RasterInterpolationOpClass();
           IRasterAnalysisEnvironment pRasterAEnv = pInterOp as IRasterAnalysisEnvironment;

          // pRasterAEnv.Mask = Geo;
           pRasterAEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref pExtent, ref o);

           object pCellSize = _pCell;//可以根据不同的点图层进行设置

           pRasterAEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref pCellSize);

           IRasterRadius pRasterrad = new RasterRadiusClass();
           object obj = Type.Missing;
          // pRasterrad.SetFixed(_pDistance, ref obj);
           pRasterrad.SetVariable(12);

           object pBar = Type.Missing;

           IGeoDataset pGeoIDW = pInterOp.IDW(pFeatureClassDes as IGeoDataset, _pPower, pRasterrad, ref pBar);

           return pGeoIDW;
       }

        public void CreateRasterFromPoints(IMap pMap, IFeatureLayer pp,String Path, String Name, String Field)
        {
            //1.将Shape文件读取成FeatureClass
            //2.根据FeatureClass生成IFeatureClassDescriptor 
            //3.创建IRasterRaduis 对象
            //设置Cell
            //4.插值并生成表面
            object obj = null;

            IWorkspaceFactory pShapSpace;

            pShapSpace = new ShapefileWorkspaceFactory();

            IWorkspace pW;

            pW = pShapSpace.OpenFromFile(Path, 0);

            IFeatureWorkspace pFeatureWork;

            pFeatureWork = pW as IFeatureWorkspace;


            IFeatureClass pFeatureClass = pFeatureWork.OpenFeatureClass("Name");


            IGeoDataset Geo = pFeatureClass as IGeoDataset;

            object extend = Geo.Extent;

            object o = null;

            IFeatureClassDescriptor pFeatureClassDes = new FeatureClassDescriptorClass();

            pFeatureClassDes.Create(pFeatureClass, null, Field);

            IRasterRadius pRasterrad = new RasterRadiusClass();

            pRasterrad.SetVariable(10, ref obj);

            object dCell = 0.5;//可以根据不同的点图层进行设置

            IInterpolationOp Pinterpla = new RasterInterpolationOpClass();

            IRasterAnalysisEnvironment pRasterAnaEn = Pinterpla as IRasterAnalysisEnvironment;

            pRasterAnaEn.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref dCell);

            pRasterAnaEn.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref extend, ref o);

            IGeoDataset pGRaster;

            object hh = 3;

            pGRaster = Pinterpla.IDW((IGeoDataset)pFeatureClassDes , 2, pRasterrad, ref hh);
         

            ISurfaceOp pSurF;

            pSurF = new RasterSurfaceOpClass();

            IGeoDataset pCour;

            object  o1 = 0;

            pCour = pSurF.Contour(pGRaster, 5, ref o1);

            IFeatureLayer pLa;

            pLa = new FeatureLayerClass();

            IFeatureClass pClass = pCour as IFeatureClass;

            pLa.FeatureClass = pClass;

            pLa.Name = pClass.AliasName;

            pMap.AddLayer(pLa as ILayer);


        }

    }
}
