using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;

namespace Common.PDFViewer
{
    public class ConvertToSWF_Bak
    {
        private static object _lockObj = new object();
        #region//单例模式
        private static ConvertToSWF_Bak instance;

        private ConvertToSWF_Bak()
        {
        }

        public static ConvertToSWF_Bak GetInstance()
        {
            if (instance == null)
            {
                instance = new ConvertToSWF_Bak();
            }
            return instance;
        }
        #endregion

        private int ConvertPages = 20;

        /////Word转换成pdf
        ///// 把Word文件转换成为PDF格式文件
        ///// </summary>
        ///// <param name="sourcePath">源文件路径</param>
        ///// <param name="targetPath">目标文件路径</param>
        ///// <returns>true=转换成功</returns>
        //public bool DOC2PDF(string sourcePath, string targetPath)
        //{
        //    Loger.logger("DOC2PDF sourcePath:" + sourcePath);
        //    bool result = false;
        //    Word.WdExportFormat exportFormat = Word.WdExportFormat.wdExportFormatPDF;
        //    object paramMissing = Type.Missing;
        //    Word.ApplicationClass wordApplication = new Word.ApplicationClass();
        //    Word._Document wordDocument = null;
        //    try
        //    {
        //        object paramSourceDocPath = sourcePath;
        //        string paramExportFilePath = targetPath;
        //        Word.WdExportFormat paramExportFormat = exportFormat;
        //        bool paramOpenAfterExport = false;
        //        Word.WdExportOptimizeFor paramExportOptimizeFor = Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
        //        Word.WdExportRange paramExportRange = Word.WdExportRange.wdExportFromTo;
        //        int paramStartPage = 1;
        //        int paramEndPage = ConvertPages;
        //        Word.WdExportItem paramExportItem = Word.WdExportItem.wdExportDocumentContent;
        //        bool paramIncludeDocProps = true;
        //        bool paramKeepIRM = true;
        //        Word.WdExportCreateBookmarks paramCreateBookmarks = Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
        //        bool paramDocStructureTags = true;
        //        bool paramBitmapMissingFonts = true;
        //        bool paramUseISO19005_1 = false;
        //        wordDocument = wordApplication.Documents.Open(
        //        ref paramSourceDocPath, ref paramMissing, ref paramMissing,
        //        ref paramMissing, ref paramMissing, ref paramMissing,
        //        ref paramMissing, ref paramMissing, ref paramMissing,
        //        ref paramMissing, ref paramMissing, ref paramMissing,
        //        ref paramMissing, ref paramMissing, ref paramMissing,
        //        ref paramMissing);
        //        if (wordDocument != null)
        //            wordDocument.ExportAsFixedFormat(paramExportFilePath,
        //            paramExportFormat, paramOpenAfterExport,
        //            paramExportOptimizeFor, paramExportRange, paramStartPage,
        //            paramEndPage, paramExportItem, paramIncludeDocProps,
        //            paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
        //            paramBitmapMissingFonts, paramUseISO19005_1,
        //            ref paramMissing);
        //        result = true;
        //        //if (File.Exists(targetPath))
        //        //{
        //        //    File.Delete(targetPath);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        StackFrame sf = new StackTrace(new StackFrame(true)).GetFrame(0);
        //        Loger.logger("类" + sf.GetMethod().ReflectedType.Name + "-方法" + sf.GetMethod().Name + "-Error:" + ex.Message);
        //        sf = null;
        //        result = false;
        //    }
        //    finally
        //    {
        //        if (wordDocument != null)
        //        {
        //            wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
        //            wordDocument = null;
        //        }
        //        if (wordApplication != null)
        //        {
        //            wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
        //            wordApplication = null;
        //        }
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 把Excel文件转换成PDF格式文件
        ///// </summary>
        ///// <param name="sourcePath">源文件路径</param>
        ///// <param name="targetPath">目标文件路径</param>
        ///// <returns>true=转换成功</returns>
        //public bool XLS2PDF(string sourcePath, string targetPath)
        //{
        //    Loger.logger("XLS2PDF sourcePath:" + sourcePath);
        //    bool result = false;
        //    Excel.XlFixedFormatType targetType = Excel.XlFixedFormatType.xlTypePDF;
        //    object missing = Type.Missing;
        //    Excel.ApplicationClass application = null;
        //    Excel._Workbook workBook = null;
        //    try
        //    {
        //        application = new Excel.ApplicationClass();
        //        object target = targetPath;
        //        object type = targetType;
        //        workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing,
        //                missing, missing, missing, missing, missing, missing, missing, missing, missing);
        //        application.DisplayAlerts = false;
        //        workBook.ExportAsFixedFormat(targetType, target, Excel.XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
        //        result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        StackFrame sf = new StackTrace(new StackFrame(true)).GetFrame(0);
        //        Loger.logger("类" + sf.GetMethod().ReflectedType.Name + "-方法" + sf.GetMethod().Name + "-Error:" + ex.Message);
        //        sf = null;
        //        result = false;
        //    }
        //    finally
        //    {
        //        if (workBook != null)
        //        {
        //            workBook.Close(true, missing, missing);
        //            workBook = null;
        //        }
        //        if (application != null)
        //        {
        //            application.Quit();
        //            application = null;
        //        }
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 把PowerPoing文件转换成PDF格式文件
        ///// </summary>
        ///// <param name="sourcePath">源文件路径</param>
        ///// <param name="targetPath">目标文件路径</param>
        ///// <returns>true=转换成功</returns>
        //public bool PPT2PDF(string sourcePath, string targetPath)
        //{
        //    Loger.logger("PPT2PDF sourcePath:" + sourcePath);
        //    bool result;
        //    Loger.logger("174");
        //    PowerPoint.PpSaveAsFileType targetFileType = PowerPoint.PpSaveAsFileType.ppSaveAsPDF;
        //    Loger.logger("176");
        //    object missing = Type.Missing;
        //    PowerPoint.Application application = null;
        //    PowerPoint._Presentation persentation = null;
        //    try
        //    {
        //        //Word.WdExportOptimizeFor paramExportOptimizeFor = Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
        //        //Word.WdExportRange paramExportRange = Word.WdExportRange.wdExportFromTo;
        //        Loger.logger("184");
        //        if (GlobalConst.IsDebug)
        //        {
        //            new PowerPoint.ApplicationClass();
        //        }
        //        //IsExistPowerPoint();
        //        Loger.logger("193");
        //        // Register the IOleMessageFilter to handle any threading 
        //        // errors.
        //        MessageFilter.Register();

        //        if (IsExistPowerPoint())
        //        {
        //            Loger.logger("已存在powerpoint实例，通过Marshal获取");
        //            try
        //            {
        //                Type t = Type.GetTypeFromProgID("PowerPoint.Application");
        //                application = (PowerPoint.Application)Activator.CreateInstance(t, true);
        //                Loger.logger("Activator实例化成功");
        //            }
        //            catch
        //            {
        //                Loger.logger("Activator实例化PowerPoint.Application报错");
        //                application = Marshal.GetActiveObject("PowerPoint.Application") as PowerPoint.Application;
        //            }
        //        }
        //        else
        //        {
        //            Loger.logger("实例化powerpoint实例");
        //            application = new PowerPoint.Application();
        //        }



        //        Loger.logger(application.ToString());


        //        persentation = application.Presentations.Open(sourcePath, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
        //        Loger.logger("application.Presentations.Open() 成功");
        //        for (int i = persentation.Slides.Count; i > ConvertPages; i--)
        //        {
        //            persentation.Slides[i].Delete();
        //        }
        //        //Loger.logger("for 语句执行成功");
        //        persentation.SaveAs(targetPath, targetFileType, Microsoft.Office.Core.MsoTriState.msoTrue);

        //        // and turn off the IOleMessageFilter.
        //        MessageFilter.Revoke();

        //        Loger.logger("SaveAs成功");
        //        result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Loger.logger(string.Format("name:{0} message:{1} stacktrace:{2}", ex.GetType().FullName, ex.Message, ex.StackTrace));
        //        StackFrame sf = new StackTrace(new StackFrame(true)).GetFrame(0);
        //        Loger.logger("类" + sf.GetMethod().ReflectedType.Name + "-方法" + sf.GetMethod().Name + "-Error:" + ex.Message);
        //        sf = null;
        //        result = false;
        //    }
        //    finally
        //    {
        //        if (persentation != null)
        //        {
        //            persentation.Close();
        //            persentation = null;
        //        }
        //        if (application != null)
        //        {
        //            application.Quit();
        //            application = null;
        //        }
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //    return result;
        //}
        /// <summary>
        /// 把PDF文件转换成格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        public bool PDF2SWF(string sourcePath, string targetPath)
        {
            Loger.logger("PDF2SWF sourcePath:" + sourcePath);
            bool result = false;
            string cmdStr = "";
            string sPath = "";
            string tPath = "";
            try
            {
                if (sourcePath.Substring(sourcePath.LastIndexOf(".") + 1).ToLower().Trim() == "pdf")
                {
                    PDFWatermark(sourcePath, sourcePath.Replace(".pdf", "_W.pdf"), HttpContext.Current.Server.MapPath("/") + "/SWFTools/logo.jpg", 10f, 10f, ConvertPages);
                    //切记，使用pdf2swf.exe 打开的文件名之间不能有空格，否则会失败
                    cmdStr = HttpContext.Current.Server.MapPath("/SWFTools/pdf2swf.exe");
                    sPath = @"""" + sourcePath.Replace(".pdf", "_W.pdf") + @"""";
                    tPath = @"""" + targetPath + @"""";
                    //@"""" 四个双引号得到一个双引号，如果你所存放的文件所在文件夹名有空格的话，要在文件名的路径前后加上双引号，才能够成功
                    // -t 源文件的路径
                    // -s 参数化（也就是为pdf2swf.exe 执行添加一些窗外的参数(可省略)）
                    string argsStr = "  -t " + sPath + " -s flashversion=9 -o " + tPath + " -p 1-" + ConvertPages;
                    //string argsStr = "  -t \"" + sourcePath + "\"  -o \"" + targetPath + "\" -s drawonlyshapes -s flashversion=9";
                    //pdf2swf.exe -qG -s disablelinks -s languagedir="D:\xpdf-chinese-simplified" D:\sss\123.pdf  123%.swf
                    Loger.logger("argsStr：" + argsStr);
                    ExcutedCmd(cmdStr, argsStr);
                    if (File.Exists(sourcePath.Replace(".pdf", "_W.pdf")))
                    {
                        File.Delete(sourcePath.Replace(".pdf", "_W.pdf"));
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                StackFrame sf = new StackTrace(new StackFrame(true)).GetFrame(0);
                Loger.logger("类" + sf.GetMethod().ReflectedType.Name + "-方法" + sf.GetMethod().Name + "-Error:" + ex.Message);
                sf = null;
            }
            finally
            {
                cmdStr = null;
                sPath = null;
                tPath = null;
            }
            return result;
        }
        /// <summary> 
        ///  PDF加水印 
        /// </summary> 
        /// <param name="inputfilepath">源PDF文件</param> 
        /// <param name="outputfilepath">加水印后PDF文件 </param> 
        /// <param name="ModelPicName">水印文件路径</param> 
        /// <param name="top">离顶部距离</param> 
        /// <param name="left">离左边距离,如果为负,则为离右边距离</param> 
        /// <param name="strMsg">返回信息</param> 
        /// <returns>返回</returns> 
        public bool PDFWatermark(string inputfilepath, string outputfilepath, string ModelPicName, float top, float left, int Pages)
        {
            PdfReader pdfReader = null;
            PdfStamper pdfStamper = null;
            FileStream outputStream = null;
            iTextSharp.text.Rectangle psize = null;
            PdfContentByte waterMarkContent = null;
            iTextSharp.text.Image image = null;
            try
            {
                pdfReader = new PdfReader(inputfilepath);
                int numberOfPages = pdfReader.NumberOfPages;
                psize = pdfReader.GetPageSize(1);
                float width = psize.Width;
                float height = psize.Height;
                outputStream = new FileStream(outputfilepath, FileMode.Create);
                pdfStamper = new PdfStamper(pdfReader, outputStream);
                image = iTextSharp.text.Image.GetInstance(ModelPicName);
                image.GrayFill = 20;//透明度，灰色填充

                //image.Rotation//旋转
                //image.RotationDegrees//旋转角度
                //水印的位置 
                if (left < 0)
                {
                    left = width - image.Width + left;
                }
                image.SetAbsolutePosition(left, (height - image.Height) - top);

                //每一页加水印,也可以设置某一页加水印 
                for (int i = 1; i <= Pages && i <= numberOfPages; i++)
                {
                    waterMarkContent = pdfStamper.GetOverContent(i);
                    waterMarkContent.AddImage(image);
                }
                return true;
            }
            catch (Exception ex)
            {
                StackFrame sf = new StackTrace(new StackFrame(true)).GetFrame(0);
                Loger.logger("类" + sf.GetMethod().ReflectedType.Name + "-方法" + sf.GetMethod().Name + "-Error:" + ex.Message);
                sf = null;
                return false;
            }
            finally
            {
                if (pdfStamper != null)
                {
                    pdfStamper.Close();
                }
                if (pdfReader != null)
                {
                    pdfReader.Close();
                }
                if (outputStream != null)
                {
                    outputStream.Close();
                }
                psize = null;
                waterMarkContent = null;
                image = null;

            }
        }
        //windows进程调用
        private static void ExcutedCmd(string cmd, string args)
        {
            using (Process p = new Process())
            {
                ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
                p.StartInfo = psi;
                psi.WindowStyle = ProcessWindowStyle.Normal;
                psi.WorkingDirectory = HttpContext.Current.Server.MapPath("/SWFTools/");
                p.StartInfo.CreateNoWindow = true;
                //psi.RedirectStandardOutput = false;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                p.StandardInput.WriteLine("exit"); //需要有这句，不然程序会挂机
                string output = p.StandardOutput.ReadToEnd(); //这句可以用来获取执行命令的输出结果
                p.WaitForExit();
                Loger.logger("调用windows进程成功，output:" + output);
                //HttpContext.Current.Response.Write("ExcutedCmd-" + output);
            }
        }

        private bool IsExistPowerPoint()
        {
            Process[] pArr = Process.GetProcessesByName("POWERPNT");

            bool isExist;
            if (pArr != null && pArr.Length >= 1)
            {
                Loger.logger("powerpnt 数量：" + pArr.Length);
                isExist = true;
            }
            else
            {
                isExist = false;
            }

            //this.Kill();
            return isExist;
        }

        private void IsExistPowerPoint1()
        {
            Process[] pArr = Process.GetProcessesByName("POWERPNT");
            if (pArr != null && pArr.Length >= 1)
            {
                Loger.logger("已存在POWERPNT.EXE程序");

                lock (_lockObj)
                {
                    try
                    {
                        pArr[0].Kill();
                        pArr[0].WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        Loger.logger(string.Format("name:{0} message:{1} stacktrace:{2}", ex.GetType().FullName, ex.Message, ex.StackTrace));
                    }
                }

                pArr = Process.GetProcessesByName("POWERPNT");
                if (pArr == null || pArr.Length == 0)
                {
                    Loger.logger("成功关闭POWERPNT.EXE程序");
                }
            }
        }

        private void Kill()
        {
            string batPath;
            if (GlobalConst.IsDebug)
            {
                batPath = "/temp/killprocess.bat";
            }
            else
            {
                batPath = "/ffmpeg/killprocess.bat";
            }

            Process.Start(HttpContext.Current.Server.MapPath(batPath));
            Loger.logger("执行脚本成功");
        }
    }
}