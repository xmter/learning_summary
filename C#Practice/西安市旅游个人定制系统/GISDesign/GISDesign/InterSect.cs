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



namespace GISDesign
{
   
    public class InterSect
    {
        ILayer pFirst;

        ILayer pSecond;

        IFeatureLayer pFeatureLayer1;
        IFeatureClass pFeatureClass1;
        ITable pTable1;

        IFeatureLayer pFeatureLayer2;
        IFeatureClass pFeatureClass2;
        ITable pTable2;

         public InterSect()
        {

        }

        public InterSect(AxMapControl pMapControl, String Name1, String Name2,String Path, String Name3)//两个图层的叠加，Name3为输出名称
        {
            if (PuanDuan(pMapControl, Name1) == -1 || PuanDuan(pMapControl, Name2) == -1)
            {
                return;
            }
            else
            {
                pFirst =pMapControl .Map .get_Layer ((PuanDuan(pMapControl, Name1)));

                pSecond =pMapControl .Map .get_Layer ((PuanDuan(pMapControl, Name2)));
            }

            init();
            OutPut(pMapControl, Path, Name3);

        }
        public  void init()
        {
            this.pFeatureLayer1 = this.pFirst as IFeatureLayer;

            this.pTable1 = this.pFeatureLayer1 as ITable;

            this.pFeatureClass1 = this.pFeatureLayer1.FeatureClass;


            this.pFeatureLayer2 = this.pSecond as IFeatureLayer;

            this.pTable2 = this.pFeatureLayer2 as ITable;

            this.pFeatureClass2 = this.pFeatureLayer2.FeatureClass;

        }

        public void OutPut(AxMapControl pMapControl, String Path,String Name)
        {

            // set output featureclass name and shape type
            IFeatureClassName pOutName;

            pOutName = new FeatureClassNameClass();

            pOutName.FeatureType = esriFeatureType.esriFTSimple;

            pOutName.ShapeFieldName = "Shape";

            pOutName.ShapeType = this.pFeatureClass1.ShapeType;

            //set output location and feature class name

            IWorkspaceName pWsN;

            pWsN = new WorkspaceNameClass();

            pWsN.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory";


            //IWorkspaceFactory pWFC;能用Factory实现，对这些对象间的关系还有点模糊。

           // pWFC = new WorkspaceFactoryClass();

           // pWsN = pWFC.Create(Path, "Test", null, 0);

           // IFeatureWorkspace pShape;

          

            pWsN.PathName = Path;

            IDatasetName pDN;

            pDN = pOutName as IDatasetName;

            pDN.Name = Name;

            pDN.WorkspaceName = pWsN;
            //set tolerence

            double tol = 0.1;

            IBasicGeoprocessor pBGP;

            pBGP = new BasicGeoprocessorClass();

            pBGP.SpatialReference = pMapControl.Map.SpatialReference;

            IFeatureClass pOutClass;

            pOutClass = pBGP.Intersect(this.pTable1, false, this.pTable2, false, tol, pOutName);

           // pOutClass = pBGP.Union(this.pTable1, false, this.pTable2, false, tol, pOutName);

          // pOutClass= pBGP.Clip(this.pTable1, false, this.pTable2, false, tol, pOutName);

          /*  IArray pArry;

            pArry = new ArrayClass();

            pArry.Add(pTable1);

            pArry.Add(this.pTable2);
            pOutClass = pBGP.Merge(pArry, this.pTable1, pOutName);
           */

            //ITable pToutTable;

          //  pToutTable = new TableClass();

            //IField  pField;

           // pField =pFeatureLayer1 .FeatureClass .Fields .get_Field (pFeatureClass1 .FindField ("name"));
           

            IFeatureLayer pOutLayer;

            pOutLayer = new FeatureLayerClass();

            pOutLayer.FeatureClass = pOutClass;

            pOutLayer.Name = pOutClass.AliasName;

            pMapControl.AddLayer(pOutLayer);

             

        }

    
        public   int    PuanDuan(AxMapControl pMapControl, String Name)
        {
            IEnumLayer pEnum;
            ILayer pEnuLayer;

            int j = -1;
           
            pEnum = pMapControl.Map.get_Layers(null, false);

            if (pEnum == null || pMapControl .Map .LayerCount ==0)
            {
                return 0;
            }
            else
            {
                pEnum.Reset();
                 int i = 0;

                for (pEnuLayer = pEnum.Next(); pEnuLayer != null;pEnuLayer = pEnum.Next())
                {
                    i++;

                    if (pEnuLayer is IFeatureLayer && pEnuLayer .Name ==Name )
                    {
                        j = i;
                        break;
                    }
                }
            }
            return j-1;
        }

        public IFeatureClass Intsect(IFeatureClass _pFtClass, IFeatureClass _pFtOverlay, string _FilePath, string _pFileName)
        {

            IFeatureClassName pOutPut = new FeatureClassNameClass();

            pOutPut.ShapeType = _pFtClass.ShapeType;

            pOutPut.ShapeFieldName = _pFtClass.ShapeFieldName;

            pOutPut.FeatureType = esriFeatureType.esriFTSimple;

            IWorkspaceName pWsN = new WorkspaceNameClass();

            pWsN.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory";

            pWsN.PathName = _FilePath;

            IDatasetName pDatasetName = pOutPut as IDatasetName;

            pDatasetName.Name = _pFileName;

            pDatasetName.WorkspaceName = pWsN;

            IBasicGeoprocessor pBasicGeo = new BasicGeoprocessorClass();

            IFeatureClass pFeatureClass = pBasicGeo.Intersect(_pFtClass as ITable, false, _pFtOverlay as ITable, false, 0.1, pOutPut);

            return pFeatureClass;

        }
    }


}
