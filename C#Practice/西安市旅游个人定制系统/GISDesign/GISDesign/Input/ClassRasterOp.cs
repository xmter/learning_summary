using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using System.IO;

namespace GISDesign
{

    #region 工作空间枚举类型
    public enum GDBType
    {
        MDB = 1,
        SDE = 2,
        FGDB = 3,
        SHP = 4,
        RWS = 5

    }
    #endregion
    class ClassRasterOp
    {
        private string pGeodatabase;

        private string pMosaicName;

        public string _pMosaicName
        {
            get { return pMosaicName; }
            set { pMosaicName = value; }
        }

        private GDBType pGDBType;

        public GDBType _pGDBType
        {
            get { return pGDBType; }
            set { pGDBType = value; }
        }

        public string _pGeodatabase
        {
            get { return pGeodatabase; }
            set { pGeodatabase = value; }
        }
        public ClassRasterOp()
        {
            _pGeodatabase = ClassXMLoad.GetImgUrlPrefix("file");
            _pMosaicName = ClassXMLoad.GetImgUrlPrefix("mosaicname");
            _pGDBType = GetWSType();
        }

        private GDBType GetWSType()
        {
           string pStringType= ClassXMLoad.GetImgUrlPrefix("wstype");
           int pIntype = Convert.ToInt16(pStringType);

           return (GDBType)pIntype;
        }

        /// <summary>
        /// 配准 后面两个参数是保存的文件和类型
        /// </summary>
        /// <param name="pFromPoint"></param>
        /// <param name="pTPoint"></param>
        /// <param name="pRasterLayer"></param>
        /// <param name="pSaveFile"></param>
        /// <param name="pType"></param>
        public bool GeoReferencing(IPointCollection pFromPoint, IPointCollection pTPoint, IRasterLayer pRasterLayer, ISpatialReference pSr, string pSaveFile, string pType)
        {

            IGeoReference pGeoreference;
            pGeoreference = (IGeoReference)pRasterLayer;
            IRaster pRaster = pRasterLayer.Raster;
            //判断是否可以配准
            if (pGeoreference.CanGeoRef == true)
            {
                IRasterGeometryProc pRasterGProc = new RasterGeometryProcClass();
                pRasterGProc.Warp(pFromPoint, pTPoint, esriGeoTransTypeEnum.esriGeoTransPolyOrder2, pRaster);
                pRasterGProc.Register(pRaster);
                IRasterProps pRasterPro = pRaster as IRasterProps;
                pRasterPro.SpatialReference = pSr;//定义投影
                if (File.Exists(pSaveFile))
                {
                    File.Delete(pSaveFile);
                }
                pRasterGProc.Rectify(pSaveFile, pType, pRaster);//路径和格式（String）
                return true;
            }

            else
            {

                return false;

            }


        }

        public IWorkspace GetWorkspace(String _pDatabase, GDBType pGDBType = GDBType.FGDB)
        {
            ESRI.ArcGIS.Geodatabase.IWorkspaceFactory pWsFactory = null;

            IWorkspace pWkspace = null;

            if (pGDBType == GDBType.SHP)
            {

                pWsFactory = new ShapefileWorkspaceFactory();

            }
            else if (pGDBType == GDBType.RWS)
            {

                pWsFactory = new RasterWorkspaceFactoryClass();

            }
            else if (pGDBType == GDBType.MDB)
            {
                pWsFactory = new AccessWorkspaceFactoryClass();
            }
            else if (pGDBType == GDBType.FGDB)
            {

                pWsFactory = new ESRI.ArcGIS.DataSourcesGDB.FileGDBWorkspaceFactoryClass();
            }
            else if (pGDBType == GDBType.SDE)
            {

                pWsFactory = new ESRI.ArcGIS.DataSourcesGDB.SdeWorkspaceFactoryClass();
            }



            try
            {

                pWkspace = pWsFactory.OpenFromFile(_pDatabase, 0);

            }
            catch (Exception EX)
            {
                //MessageBox.Show(EX.ToString());

            }

            return pWkspace;
        }
        //获取栅格数据集的目录
        IRasterWorkspace GetRasterWorkspace(string pWsName)
        {
            try
            {
                IWorkspaceFactory pWorkFact = new RasterWorkspaceFactoryClass();
                return pWorkFact.OpenFromFile(pWsName, 0) as IRasterWorkspace;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       public  IRasterDataset OpenFileRasterDataset(string pFolderName, string pDatasetName)
        {

            IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactoryClass();
            IRasterWorkspace pRasterWorkspace = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(pFolderName, 0);


            IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDatasetName);
            return pRasterDataset;
        }


       
        public IMosaicDataset OpenMosaicDataset(IWorkspace pWorks, string pMosaicDatasetName)
        {
            IMosaicDataset pMosicDataset = null;
            IMosaicWorkspaceExtensionHelper pMosaicWsExHelper = new MosaicWorkspaceExtensionHelperClass();

            IMosaicWorkspaceExtension pMosaicWsExt = pMosaicWsExHelper.FindExtension(pWorks);

            if (pMosaicWsExt != null)
            {
                try
                {
                    pMosicDataset = pMosaicWsExt.OpenMosaicDataset(pMosaicDatasetName);
                }
                catch (Exception ex)
                {


                    return pMosicDataset;
                }

            }

            return pMosicDataset;

        }
        //

     public  IRasterType GetRasterType(string pTypeName)
        {
            IRasterTypeName pRasterTypeName = new RasterTypeNameClass();
            pRasterTypeName.Name = pTypeName;

            ESRI.ArcGIS.esriSystem.IName pName = pRasterTypeName as ESRI.ArcGIS.esriSystem.IName;

            IRasterType pRasterType = pName.Open() as IRasterType;


            return pRasterType;

        }
     public bool AddRasterDatesetToMD(IMosaicDataset pMosaicDataset, IRasterDataset pRasteDataset, IRasterType pRasterType)
        {
         try
         {
             IRasterDatasetCrawler pRasterDatasetCrawler = new RasterDatasetCrawlerClass();

             pRasterDatasetCrawler.RasterDataset = pRasteDataset;

             IDataset pDataset = pRasteDataset as IDataset;

             ESRI.ArcGIS.esriSystem.IName pName = pDataset.FullName;

             pRasterDatasetCrawler.DatasetName = pName;

             IMosaicDatasetOperation pMosaicDatasetOperation = (IMosaicDatasetOperation)pMosaicDataset;

             IAddRastersParameters AddRastersArgs = new AddRastersParametersClass();

             AddRastersArgs.Crawler = pRasterDatasetCrawler as IDataSourceCrawler;

             AddRastersArgs.RasterType = pRasterType;

             pMosaicDatasetOperation.AddRasters(AddRastersArgs, null);

             return true;
         }
         catch (System.Exception ex)
         {
             return false;
         }
            



        }

     public ITable GetMosicTable(IMosaicDataset pMosaic)
     {
         ITable pTable = pMosaic.Catalog as ITable;

         return pTable;
     }

     public bool ExistRow(IMosaicDataset pMosaic,string pValue)
     {
            ITable pTable= GetMosicTable(pMosaic);

              IQueryFilter pQueryFileter = new QueryFilterClass();//sevp_aoc_rdcp_sldas_ebref_achn_l88_pi_201212050010
              pQueryFileter.SubFields = "Name";
              pQueryFileter.WhereClause = "Name =" + pValue;

              if (pTable.RowCount(pQueryFileter) > 0)

                  return true;
              return false;
     
        }

     public ITable GetMosaicDatasetTable(IMosaicDataset pMosaicDataset)
     {
         ITable pTable = null;
         IEnumName pEnumName = pMosaicDataset.Children;
         pEnumName.Reset();
         ESRI.ArcGIS.esriSystem.IName pName;
         while ((pName = pEnumName.Next()) != null)
         {
             pTable = pName.Open() as ITable;
             int i = pTable.Fields.FieldCount;
             if (i >= 21) break;
         }//镶嵌数据集属性表默认23个字段            }

         return pTable;
     }

     public bool UpdataTable(ITable pTable, string pFromField, string pToField)
     {
         int pIndex = pTable.FindField(pFromField);

         int pIndex1 = pTable.FindField(pToField);

         try
         {
             if (pIndex != -1)
             {
                 if (pIndex1 != -1)
                 {
                     ICursor pCursor = pTable.Update(null, false);

                     IRow pRow = pCursor.NextRow();

                     while (pRow != null)
                     {
                         string[] pArr = pRow.get_Value(pIndex).ToString().Split('_');
                         //sevp_aoc_rdcp_sldas_ebref_achn_l88_pi_201212050010
                         string pFileName = pArr[pArr.Length - 1];

                         int pDay = Convert.ToInt16(pFileName.Substring(6, 2));
                         int pHour = Convert.ToInt16(pFileName.Substring(8, 2)) + 8;
                         if (pHour >= 24)
                         {
                             pDay = pDay + 1;

                             pHour = pHour - 24;
                         }
                         string pData = pFileName.Substring(0, 4) + "-" + pFileName.Substring(4, 2) + "-" + pDay.ToString("00") + " " + pHour.ToString() + ":" + pFileName.Substring(10, 2) + ":00";
                         pRow.set_Value(pIndex1, pData);

                         pCursor.UpdateRow(pRow);

                         pRow = pCursor.NextRow();

                     }


                 }


             }
         }
         catch (System.Exception ex)
         {
             return false;
         }


         return true;
        
     }

     public bool FixBug(ITable pTable, string pFromField, object pValue)
     {
         int pIndex = pTable.FindField(pFromField);


         try
         {
             if (pIndex != -1)
             {
                
                     ICursor pCursor = pTable.Update(null, false);

                     IRow pRow = pCursor.NextRow();

                     while (pRow != null)
                     {

                         //string pData = pFileName.Substring(0, 4) + "-" + pFileName.Substring(4, 2) + "-" + pDay.ToString("00") + " " + pHour.ToString() + ":" + pFileName.Substring(10, 2) + ":00";
                         pRow.set_Value(pIndex, pValue);

                         pCursor.UpdateRow(pRow);

                         pRow = pCursor.NextRow();

                   


                 }


             }
         }
         catch (System.Exception ex)
         {
             return false;
         }


         return true;
        
     }

     

    }
}
