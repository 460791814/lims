using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;

namespace Common.PDFViewer
{
    public class Loger
    {
        public static String LogPath = System.Web.HttpContext.Current.Server.MapPath("/") + "\\log";
        /// <summary>
        /// 日志文件路径
        /// </summary>
        //public String LogPath = "D:\\log";

        /// <summary>
        /// 构造函数
        /// </summary>
        public Loger()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public static void logger(Exception ex)
        {
            string content = string.Format("UrlReffer:{3}\r\nEx Name:{0} \r\n Msg:{1} \r\n StackTrace:{2}\r\n", ex.GetType().FullName,
              ex.Message, ex.StackTrace, HttpContext.Current.Request.UrlReferrer);
            Loger.loggerError(content);
        }

        /// <summary>
        /// 输出日志信息
        /// </summary>
        /// <param name="msg">日志信息</param>
        public static void logger(String msg)
        {
            try
            {
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                if (month.Length < 2)
                {
                    month = "0" + month;
                }
                if (day.Length < 2)
                {
                    day = "0" + day;
                }
                string filePath = LogPath + "\\" + DateTime.Now.Year.ToString() + month;
                string fileName = filePath + "\\" + day + ".Log";

                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }

                WriteLog(fileName, msg);
            }
            catch (Exception ex)
            {
                //System.Web.HttpContext.Current.Response.Write(ex.Message);
                //System.Web.HttpContext.Current.Response.End();
            }
        }

        private static void WriteLog(string fileName, string msg)
        {
            FileStream filestream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            StreamWriter writer = new StreamWriter(filestream, System.Text.Encoding.Default);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString() + "#", msg);
            writer.Flush();
            writer.Close();
            filestream.Close();
        }


        /// <summary>
        /// 输出错误的日志信息
        /// </summary>
        /// <param name="msg">日志信息</param>
        public static void loggerError(String msg)
        {
            try
            {
                string fileName = LogPath +@"\PreviewError.txt";
                WriteLog(fileName, msg);
            }
            catch (Exception ex)
            {
                //System.Web.HttpContext.Current.Response.Write(ex.Message);
                //System.Web.HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 记录pdf、swf脚本
        /// </summary>
        /// <param name="msg">日志信息</param>
        public static void LoggerScript(String script)
        {
            try
            {
                string fileName = LogPath + @"\PreviewScript.txt";
                WriteLog(fileName, script);
            }
            catch (Exception ex)
            {
                //System.Web.HttpContext.Current.Response.Write(ex.Message);
                //System.Web.HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 记录pdf、swf输出信息
        /// </summary>
        /// <param name="msg">日志信息</param>
        public static void LoggerConvertToolOutput(String outInfo)
        {
            try
            {
                string fileName = LogPath + @"\PreviewConvertOutput.txt";
                WriteLog(fileName, outInfo);
            }
            catch (Exception ex)
            {
                //System.Web.HttpContext.Current.Response.Write(ex.Message);
                //System.Web.HttpContext.Current.Response.End();
            }
        }

        /*
        private string Show_Command(Report obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format(@"{0} seq1:{1} seq2:{2} seq3:{3}{0} ReportType:{4}{0} UserNumber:{5}{0} State:{6}{0} ErrorCode:0", Environment.NewLine, obj.OldNodeNumber, obj.OldDateTimeNumber, obj.OldOrdinalNumber, obj.ReportType, obj.UserNumber, obj.State, obj.ErrorCode));
            sb.Append("Report");
            return sb.ToString();
        }
        */
    }
}