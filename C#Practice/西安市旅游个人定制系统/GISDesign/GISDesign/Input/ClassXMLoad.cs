using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GISDesign
{
    class ClassXMLoad
    {
        public  static  string GetImgUrlPrefix(string pNodeName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("..//..//XMLDirectory.xml");
            XmlNodeList nodes = xmlDoc.GetElementsByTagName(pNodeName);
            if (nodes.Count > 0)
            {

                return nodes[0].ChildNodes[0].Value;
            }
            else { return ""; }
        }
    }
}
