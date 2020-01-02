using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
namespace GISDesign
{
    class RightMenu
    {
       private IToolbarMenu ToolMenu = new ToolbarMenuClass();
       public AxTOCControl m_TocC;
        public RightMenu(AxTOCControl m_Toc)
        {
            m_TocC = m_Toc;
            ToolMenu.RemoveAll();
            ToolMenu.AddItem(new RemoveLayer(), -1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            ToolMenu.AddItem(new ZoomtoLayer(), -1, 1, true, esriCommandStyles.esriCommandStyleTextOnly);
        }
        public IToolbarMenu getToolbarMenu()
        {
            return ToolMenu;
        }
    }
}
