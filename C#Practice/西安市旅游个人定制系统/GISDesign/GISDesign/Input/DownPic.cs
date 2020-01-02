using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;

namespace GISDesign
{
    public class DownPic
    {




        private string pXmlDir = "";

        public string _pXmlDir
        {
            get { return pXmlDir; }
            set { pXmlDir = value; }
        }
       

        public DownPic()
        {

            this._pXmlDir = ClassXMLoad.GetImgUrlPrefix("DirectoryPath");
        }
     


        public string DownImageFile(byte[] pByte,string FileName)
        {

            try
            {
                string pFullpath = Path.Combine(pXmlDir, FileName);

                if (File.Exists(pFullpath))
                    File.Delete(pFullpath);

                FileStream pFilestream = new FileStream(pFullpath, FileMode.OpenOrCreate, FileAccess.Write);

                pFilestream.Write(pByte, 0, (int)pByte.Length);
                pFilestream.Close();

                return pFullpath;
            }
            catch (System.Exception ex)
            {
                return "";
            }
            

           
        }
        /// <summary>
        /// web.dll中
        /// </summary>
        /// <param name="Response"></param>
        /// <param name="picName"></param>
        /// <param name="content"></param>
        //private void WriteResponse(HttpResponse Response, string picName, byte[] content)
        //{
        //    Response.Clear();
        //    Response.ClearHeaders();
        //    Response.Buffer = false;
        //    Response.ContentType = "application/octet-stream";
        //    Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(picName, Encoding.Default));
        //    Response.AppendHeader("Content-Length", content.Length.ToString());
        //    Response.BinaryWrite(content);
        //    Response.Flush();
        //    Response.End();
        //}
       // http://i.weather.com.cn/i/product/pic/l/sevp_aoc_rdcp_sldas_ebref_achn_l88_pi_20121110195000001.gif
        public byte[] GetImageContent(string picName)
        {
            //string fileURL = GetImgUrlPrefix() + picName;
            string fileURL =picName;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileURL);
            request.AllowAutoRedirect = true;

            WebProxy proxy = new WebProxy();
            proxy.BypassProxyOnLocal = true;
            proxy.UseDefaultCredentials = true;

            request.Proxy = proxy;

            WebResponse response = request.GetResponse();

     
            using (Stream stream = response.GetResponseStream())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Byte[] buffer = new Byte[1024];
                    int current = 0;
                    while ((current = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        ms.Write(buffer, 0, current);
                    }

                    
                    return ms.ToArray();
                }
            }
        }
    


    }
}
