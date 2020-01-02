using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using System.IO;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Carto;

namespace GISDesign
{

    
    class GDBInput
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


        #region 获取栅格数据，栅格目录，创建栅格数据集
        /// <summary>
        /// 获取栅格数据
        /// </summary>
        /// <param name="pWorkSpace"></param>
        /// <param name="RasterName"></param>
        /// <returns></returns>
        public IRasterDataset GetRasterDataset(IRasterWorkspace pWorkSpace, string RasterName)
        {

            if (pWorkSpace == null) return null;
            try
            {
                return pWorkSpace.OpenRasterDataset(RasterName);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 创建栅格数据集
        /// </summary>
        /// <param name="pGDBType"></param>
        /// <param name="pPath"></param>
        /// <param name="pFileName"></param>
        /// <param name="pWidth"></param>
        /// <param name="pHeight"></param>
        /// <param name="pXCell"></param>
        /// <param name="pYCell"></param>
        /// <param name="pNumBand"></param>
        /// <returns></returns>
        public IRasterDataset CreateRasterDataset(GDBType pGDBType, string pPath, string pFileName, int pWidth, int pHeight, double pXCell, double pYCell, int pNumBand)
        {
            try
            {
                IRasterWorkspace2 pRWs = GetWorkspace(pPath, pGDBType) as IRasterWorkspace2;

                ISpatialReference sr = new UnknownCoordinateSystemClass();

                IPoint origin = new PointClass();
                origin.PutCoords(0.0, 0.0);
                IRasterDataset rasterDataset = pRWs.CreateRasterDataset(pFileName, "TIFF",
                    origin, pWidth, pHeight, pXCell, pYCell, pNumBand, rstPixelType.PT_UCHAR, sr,
                    true);


                return rasterDataset;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }



        /// <summary>
        /// 获取栅格目录
        /// </summary>
        /// <param name="pWs"></param>
        /// <param name="pCatlogName"></param>
        /// <returns></returns>
        public IRasterCatalog GetCatlog(IWorkspace pWs, string pCatlogName)
        {
            IRasterWorkspaceEx pRsWx = pWs as IRasterWorkspaceEx;

            return pRsWx.OpenRasterCatalog(pCatlogName);

        }
        /// <summary>
        /// 获取工作空间SDE，文件型数据库，MDB,以及shapefile文件所在工作空间,这里可以用一个枚举
        /// </summary>
        /// <param name="_pDatabase"></param>
        /// <returns></returns>
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

        #endregion

        #region 栅格直接入库和入到栅格目录
        /// <summary>
        /// 栅格目录
        /// </summary>
        /// <param name="pWs"></param>
        /// <param name="pCatlogName"></param>
        /// <param name="pImage"></param>
        public void RasterCatlogInput(IWorkspace pWs, string pCatlogName, string pImage)
        {
            IRasterWorkspaceEx pRsWx = pWs as IRasterWorkspaceEx;

            //IRasterCatalog pRsCat = pRsWx.OpenRasterCatalog(pCatlogName);

            IRasterCatalogLoader pRastCatLoader = new RasterCatalogLoaderClass();
            pRastCatLoader.Workspace = pWs;
            pRastCatLoader.LoadDatasets(pCatlogName, pImage, null);
        }
        public bool CopyRaster(IRasterWorkspace2 pRW, string pFileName, IRasterWorkspaceEx pWorkSpace, string pDestName)
        {
            try
            {

                IRasterDataset pRds = pRW.OpenRasterDataset(pFileName);


                IRasterProps pRasterProps = (IRasterProps)pRds.CreateDefaultRaster();
                IRasterStorageDef pRasterStorageDef = new RasterStorageDefClass();

                IRasterDef pRasterDef = new RasterDefClass();
                pRasterDef.SpatialReference = pRasterProps.SpatialReference;
                IGeometryDef pGeoDef = new GeometryDefClass();
                IGeometryDefEdit pGeoDefEdit = pGeoDef as IGeometryDefEdit;
                pGeoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                pGeoDefEdit.AvgNumPoints_2 = 4;
                pGeoDefEdit.GridCount_2 = 1;
                pGeoDefEdit.set_GridSize(0, 1000);
                pGeoDefEdit.SpatialReference_2 = pRasterProps.SpatialReference;
                IRasterDataset pRasterDataset = pWorkSpace.SaveAsRasterDataset(pDestName, pRds.CreateDefaultRaster(), pRasterStorageDef, "", pRasterDef, pGeoDef);

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }



        }
        public bool CreateRaster(IRasterDataset pRDs, IRasterWorkspaceEx pWorkSpace)
        {
            IRasterProps pRasterProps = (IRasterProps)pRDs.CreateDefaultRaster();
            IRasterStorageDef pRasterStorageDef = new RasterStorageDefClass();
            pRasterStorageDef.CompressionType = esriRasterCompressionType.esriRasterCompressionJPEG2000;
            pRasterStorageDef.CompressionQuality = 50;
            pRasterStorageDef.PyramidLevel = 2;
            pRasterStorageDef.PyramidResampleType = rstResamplingTypes.RSP_BilinearInterpolation;
            pRasterStorageDef.TileHeight = 128;
            pRasterStorageDef.TileWidth = 128;
            IRasterDef pRasterDef = new RasterDefClass();
            pRasterDef.Description = "RasterDataset";
            pRasterDef.SpatialReference = pRasterProps.SpatialReference;
            IGeometryDef pGeoDef = new GeometryDefClass();
            IGeometryDefEdit pGeoDefEdit = pGeoDef as IGeometryDefEdit;
            pGeoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
            pGeoDefEdit.AvgNumPoints_2 = 4;
            pGeoDefEdit.GridCount_2 = 1;
            pGeoDefEdit.set_GridSize(0, 1000);
            pGeoDefEdit.SpatialReference_2 = pRasterProps.SpatialReference;
            IRasterDataset pRasterDataset = pWorkSpace.CreateRasterDataset("zzy", 3, rstPixelType.PT_UCHAR, pRasterStorageDef, "", pRasterDef, pGeoDef);
            pRasterDataset = pRDs;
            return true;

        }


        /// <summary>
        /// 栅格入库类似ArcMap中的Load
        /// </summary>
        /// <param name="pWs"></param>
        /// <param name="pRasterName"></param>
        /// <param name="pRaser"></param>
        public void RasterInput(IWorkspace pWs, string pRasterName, IRaster pRaser)
        {
            IRasterWorkspaceEx pRsWx = pWs as IRasterWorkspaceEx;

            IRasterLoader pRastCatLoader = new RasterLoaderClass();

            pRastCatLoader.MosaicColormapMode = rstMosaicColormapMode.MM_FIRST;
            pRastCatLoader.Load(pRsWx.OpenRasterDataset(pRasterName), pRaser);

        }


        #endregion




        /// <summary>
        /// 合并栅格目录中的所有栅格
        /// </summary>
        /// <param name="pRasterCatalog"></param>
        /// <param name="outputFolder"></param>
        /// <param name="pOutputName"></param>
        public void Mosaic(IRasterCatalog pRasterCatalog, IWorkspace pWorkspace, string pOutputName)
        {

            IMosaicRaster pMosaicRaster = new MosaicRasterClass();
            pMosaicRaster.RasterCatalog = pRasterCatalog;


            pMosaicRaster.MosaicColormapMode = rstMosaicColormapMode.MM_MATCH;
            pMosaicRaster.MosaicOperatorType = rstMosaicOperatorType.MT_LAST;

            ISaveAs pSaveas = (ISaveAs)pMosaicRaster;
            pSaveas.SaveAs(pOutputName, pWorkspace, "IMAGINE Image");
        }

        /// <summary>
        /// 根据图层名称获取图层
        /// </summary>
        /// <param name="pMap"></param>
        /// <param name="LayerName"></param>
        /// <returns></returns>
        public ILayer GetLayer(IMap pMap, string LayerName)
        {
            IEnumLayer pEnunLayer = pMap.get_Layers(null, false);

            pEnunLayer.Reset();

            ILayer pRetureLayer;

            pRetureLayer = pEnunLayer.Next();

            while (pRetureLayer != null)
            {
                if (pRetureLayer.Name == LayerName)
                {
                    break;
                }

                pRetureLayer = pEnunLayer.Next();
            }
            return pRetureLayer;
        }


        #region 镶嵌数据集入库
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

        /// <summary>
        /// 获取栅格类型
        /// </summary>
        /// <param name="pTypeName"></param>
        /// <returns></returns>
        public IRasterType GetRasterType(string pTypeName)
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

        #endregion

        #region 矢量数据入库
        public IFeatureClass GetFeatureClass(IFeatureWorkspace pWorkSpace, string pFeatureName)
        {
            if (pWorkSpace == null) return null;
            try
            {
                return pWorkSpace.OpenFeatureClass(pFeatureName);
            }
            catch
            {
                return null;
            }
        }
        public void IFeatureDataConverter(IWorkspace pSourceWorkspace, IWorkspace pTargetWorkspace, string pSFeatureClass, string pDFeatureClass)
        {

            IDataset sourceWorkspaceDataset = (IDataset)pSourceWorkspace;
            IWorkspaceName sourceWorkspaceName = (IWorkspaceName)sourceWorkspaceDataset.FullName;

            IFeatureClassName sourceFeatureClassName = new FeatureClassNameClass();
            IDatasetName sourceDatasetName = (IDatasetName)sourceFeatureClassName;
            sourceDatasetName.WorkspaceName = sourceWorkspaceName;
            sourceDatasetName.Name = pSFeatureClass;

            IDataset targetWorkspaceDataset = (IDataset)pTargetWorkspace;
            IWorkspaceName targetWorkspaceName = (IWorkspaceName)targetWorkspaceDataset.FullName;

            IFeatureClassName targetFeatureClassName = new FeatureClassNameClass();
            IDatasetName targetDatasetName = (IDatasetName)targetFeatureClassName;
            targetDatasetName.WorkspaceName = targetWorkspaceName;
            targetDatasetName.Name = pDFeatureClass;

            ESRI.ArcGIS.esriSystem.IName sourceName = (ESRI.ArcGIS.esriSystem.IName)sourceFeatureClassName;
            IFeatureClass sourceFeatureClass = (IFeatureClass)sourceName.Open();

            IFieldChecker fieldChecker = new FieldCheckerClass();
            IFields targetFeatureClassFields;
            IFields sourceFeatureClassFields = sourceFeatureClass.Fields;
            IEnumFieldError enumFieldError;

            fieldChecker.InputWorkspace = pSourceWorkspace;
            fieldChecker.ValidateWorkspace = pTargetWorkspace;
            fieldChecker.Validate(sourceFeatureClassFields, out enumFieldError, out targetFeatureClassFields);

            IField geometryField;
            for (int i = 0; i < targetFeatureClassFields.FieldCount; i++)
            {
                if (targetFeatureClassFields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                {
                    geometryField = targetFeatureClassFields.get_Field(i);

                    IGeometryDef geometryDef = geometryField.GeometryDef;

                    IGeometryDefEdit targetFCGeoDefEdit = (IGeometryDefEdit)geometryDef;
                    targetFCGeoDefEdit.GridCount_2 = 1;
                    targetFCGeoDefEdit.set_GridSize(0, 0);

                    targetFCGeoDefEdit.SpatialReference_2 = geometryField.GeometryDef.SpatialReference;

                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = "";

                    IFeatureDataConverter fctofc = new FeatureDataConverterClass();
                    IEnumInvalidObject enumErrors = fctofc.ConvertFeatureClass(sourceFeatureClassName, queryFilter, null, targetFeatureClassName, geometryDef, targetFeatureClassFields, "", 1000, 0);
                    break;
                }
            }
        }

        #endregion
    }
   

}


