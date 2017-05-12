using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;


namespace Common.PDFViewer
{
    public class ConvertToSWFByUnoConv : IConvertToSWF
    {
        /// <summary>
        /// 转换为pdf的模板
        /// {0}:最大pdf页面处理数
        /// {1}:pdf文件保存目录,如：D:\videotest\doc\temp。注意不要能写成这样D:\videotest\doc\temp\
        /// {2}:源文件全路径
        /// pdfConvertErr.txt：用来保存unoconv程序的错误信息
        /// </summary>
        private const string ToPdfTemplate = @"""D:\Program Files (x86)\OpenOffice.org 3\program\python.exe"" ""D:\FlashRoot\docpreview\unoconv-master\unoconv"" --server localhost --port 2002 -f pdf -e PageRange=1-{0} -o ""{1}"" ""{2}"" 2>D:\FlashRoot\log\pdfConvertErr.txt";

        /// <summary>
        /// 本地测试模板
        /// </summary>
        private const string ToPdfTemplateLocal = @"""D:\Program Files\openoffice\program\python.exe"" ""D:\xiaowj\learn\在线预览\ppt\docpreview\unoconv-master\unoconv"" -f pdf -e PageRange=1-{0} -o ""{1}"" ""{2}"" 2>D:\videotest\doc\pdfConvertErr.txt";

        private static object _lockObj = new object();
        #region//单例模式
        private static ConvertToSWFByUnoConv instance;

        private ConvertToSWFByUnoConv()
        {
        }

        public static ConvertToSWFByUnoConv GetInstance()
        {
            if (instance == null)
            {
                instance = new ConvertToSWFByUnoConv();
            }
            return instance;
        }
        #endregion

        private int ConvertPages = GlobalConst.MaxPdfPages;

        ///Word转换成pdf
        /// 把Word文件转换成为PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        public bool DOC2PDF(string sourcePath, string targetPath)
        {
            return this.ToPDF(sourcePath, targetPath);
        }
        /// <summary>
        /// 把Excel文件转换成PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        public bool XLS2PDF(string sourcePath, string targetPath)
        {
            return this.ToPDF(sourcePath, targetPath);
        }
        /// <summary>
        /// 把PowerPoing文件转换成PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        public bool PPT2PDF(string sourcePath, string targetPath)
        {
            return this.ToPDF(sourcePath, targetPath);
        }

        public bool PDF2SWF(string sourcePath, string targetPath)
        {
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
                    ExcutedCmd(cmdStr, argsStr);
                 
                        if (File.Exists(sourcePath.Replace(".pdf", "_W.pdf")))
                        {
                            File.Delete(sourcePath.Replace(".pdf", "_W.pdf"));
                        }
                    
                    result = IsConvertSucceed(targetPath, 100);//最多等5秒
                }
            }
            catch (Exception ex)
            {
                Loger.logger(ex);
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
                Loger.logger(ex);
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


        /// <summary>
        /// 转换为pdf文档
        /// </summary>
        /// <param name="sourcePath">源文件全路径</param>
        /// <param name="targetPath">目标文件全路径</param>
        /// <returns>true or false</returns>
        public bool ToPDF(string sourcePath, string targetPath)
        {
            string cmdArg;
            string targetDirectory = Path.GetDirectoryName(targetPath);
            if (GlobalConst.IsDebug)
            {
                cmdArg = string.Format(ToPdfTemplateLocal, ConvertPages, targetDirectory, sourcePath);
            }
            else
            {
                cmdArg = string.Format(ToPdfTemplate, ConvertPages, targetDirectory, sourcePath);
            }

            List<string> cmdList = new List<string>();
            cmdList.Add(cmdArg);
            ExcutedCmd(cmdList);
            return IsConvertSucceed(targetPath, 240);//最多等12秒
        }

        /// <summary>
        /// 是否目标文件转换成功
        /// </summary>
        /// <param name="targetFile">目标文件</param>
        /// <param name="waitTimes">等待时间*50ms</param>
        /// <returns>true or false</returns>
        private bool IsConvertSucceed(string targetFile, int waitTimes)
        {
            int curWaitTimes = waitTimes;
            while (!File.Exists(targetFile) && waitTimes > 0)
            {
                System.Threading.Thread.Sleep(50);
                waitTimes--;
            }

            Loger.logger(string.Format("转换为{0} 耗时{1}秒", Path.GetFileName(targetFile), ((curWaitTimes - waitTimes) * 50 / 1000)));

            return File.Exists(targetFile);
        }

        /// <summary>
        /// windows进程调用
        /// </summary>
        /// <param name="argList">参数列表</param>
        private static void ExcutedCmd(List<string> argList)
        {
            string cmdExe = @"C:\Windows\System32\cmd.exe";
            string workDirectory = @"C:\Windows\System32\";
            ExcutedCmd(cmdExe, workDirectory, argList, true);
        }

        /// <summary>
        /// windows进程调用
        /// </summary>
        /// <param name="cmd">exe文件</param>
        /// <param name="workDirectory">工作目录</param>
        /// <param name="argList">参数列表</param>
        /// <param name="isWindowCmd">是否windows 命令行程序</param>
        private static void ExcutedCmd(string cmd, string workDirectory, List<string> argList, bool isWindowCmd)
        {
            using (Process p = new Process())
            {
                string args = argList[0];
                ProcessStartInfo psi;
                if (isWindowCmd)//windows 命令行，通过后续写入命令执行
                {
                    psi = new ProcessStartInfo(cmd, null);
                }
                else //其他程序，直接调用命令
                {
                    psi = new ProcessStartInfo(cmd, args);
                }
                p.StartInfo = psi;
                psi.WindowStyle = ProcessWindowStyle.Normal;
                psi.WorkingDirectory = workDirectory;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
                Loger.LoggerScript("pdf cmd:" + args);

                try
                {
                    p.Start();
                    if (isWindowCmd)//windows 命令行，写入命令执行
                    {
                        if (argList != null && argList.Count > 0)
                        {
                            foreach (string arg in argList)
                            {
                                p.StandardInput.WriteLine(arg);
                            }
                        }
                    }
                    p.StandardInput.WriteLine("exit"); //需要有这句，不然程序会挂机
                    //Loger.LoggerConvertToolOutput("pdf Output:\r\n" + p.StandardOutput.ReadToEnd());
                    p.WaitForExit(2000);
                    if (!p.HasExited)
                    {
                        p.Kill();
                    }
                }
                catch (Exception ex)
                {
                    Loger.logger(ex);
                }
            }
        }

        static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string msg = e.Data;
            if (!string.IsNullOrEmpty(msg))
            {
                Loger.LoggerConvertToolOutput("pdf ErrOutput:" + msg);
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
                Loger.logger("pdf to swf 调用windows进程成功");
                //HttpContext.Current.Response.Write("ExcutedCmd-" + output);
            }
        }


    }
}