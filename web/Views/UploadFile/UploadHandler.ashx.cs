using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace OnlineClass.Web.TeacherCenter
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HttpPostedFile oFile = context.Request.Files["fileinput"];


            string ex = Path.GetExtension(oFile.FileName).ToLower();
            if (ex == ".jpg" || ex == ".jpeg" || ex == ".gif" || ex == ".png" || ex == ".doc" || ex == ".docx" || ex == ".pdf" || ex == ".xls" || ex == ".xlsx" || ex == ".zip" || ex == ".rar")
            {
                if (oFile.ContentLength <= 2048 * 1024)
                { //图片大小小于2M

                    string strdate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString();
                    string saveName = oFile.FileName.Replace(ex, "") + "(" + strdate + ")" + ex;//实际保存文件名
                    string fileName = saveName;//Utils.GetNewFileName() + ex;
                    string _FileNewName = "/UpFile/" + fileName;
                    string _FileSavePath = HttpContext.Current.Server.MapPath(_FileNewName);
                    if (Directory.Exists(Path.GetDirectoryName(_FileSavePath)) == false)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(_FileSavePath));
                    }
                    oFile.SaveAs(_FileSavePath);
                    context.Response.Write(fileName);
                }
                else
                {
                    context.Response.Write("1");
                }
            }
            else
            {
                context.Response.Write("2");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}