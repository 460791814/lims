using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;
using iTextSharp.text.pdf;
using Aspose.Words;
using Aspose.Words.Saving;
using Aspose.Slides;

namespace Common.PDFViewer
{
    public class ConvertToSwfByAspno : IConvertToSWF
    {

        private static object _lockObj = new object();
        #region//单例模式
        private static ConvertToSwfByAspno instance;

        private ConvertToSwfByAspno()
        {
        }

        public static ConvertToSwfByAspno GetInstance()
        {
            if (instance == null)
            {
                instance = new ConvertToSwfByAspno();
            }
            return instance;
        }
        #endregion

        private int GetShowPages(int pageTotalCount)
        {
            return pageTotalCount;

            //不进行控制
            //int showPages = (int)Math.Ceiling(GlobalConst.PdfPagesRate * pageTotalCount);
            //if (showPages > GlobalConst.MaxPdfPages)
            //{
            //    showPages = GlobalConst.MaxPdfPages;
            //}
            //return showPages;
        }

        ///Word转换成pdf
        /// 把Word文件转换成为PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        public bool DOC2PDF(string sourcePath, string targetPath)
        {
            DateTime startDate = DateTime.Now;
            Document doc = new Document(sourcePath);

            PdfSaveOptions pdfSaveOptions = new PdfSaveOptions();
            pdfSaveOptions.PageCount = GetShowPages(doc.PageCount);//生成pdf总页数
            pdfSaveOptions.PageIndex = 0;//起始页码
            pdfSaveOptions.SaveFormat = SaveFormat.Pdf;

            try
            {
                doc.Save(targetPath, pdfSaveOptions);
            }
            catch (Exception ex)
            {
                Loger.logger(ex);
            }

            Loger.logger(string.Format("转换为{0} 耗时{1}秒", Path.GetFileName(targetPath), DateTime.Now.Subtract(startDate).TotalSeconds));
            return File.Exists(targetPath);
        }
        /// <summary>
        /// 把Excel文件转换成PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        public bool XLS2PDF(string sourcePath, string targetPath)
        {
            return false;
        }
        /// <summary>
        /// 把PowerPoing文件转换成PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        public bool PPT2PDF(string sourcePath, string targetPath)
        {
            DateTime startDate = DateTime.Now;
            Presentation presentation = new Presentation(sourcePath);
            int slidesCount = presentation.Slides.Count;
            int convertPages = GetShowPages(slidesCount);
            for (int i = slidesCount - 1; i >= 0; i--)
            {
                Slide slide = presentation.Slides[i];
                if (slide.SlidePosition > convertPages)//保留前n页，移除页码大于n的幻灯片，注意通过SlidePosition判断而不是自然索引顺序
                {
                    presentation.Slides.Remove(slide);
                }
            }

            try
            {
                presentation.Save(targetPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
            catch (Exception ex)
            {
                Loger.logger(ex);
            }
            Loger.logger(string.Format("转换为{0} 耗时{1}秒", Path.GetFileName(targetPath), DateTime.Now.Subtract(startDate).TotalSeconds));
            return File.Exists(targetPath);
        }

        public bool PDF2SWF(string sourcePath, string targetPath)
        {
            bool result = false;
            string cmdStr = "";
            string sPath = "";
            string tPath = "";
            Loger.logger("开始转换(1)：" + sourcePath + "--" + targetPath);
            try
            {
                if (sourcePath.Substring(sourcePath.LastIndexOf(".") + 1).ToLower().Trim() == "pdf")
                {
                    int convertPages = GlobalConst.MaxPdfPages;
                    PDFWatermark(sourcePath, sourcePath.Replace(".pdf", "_W.pdf"), HttpContext.Current.Server.MapPath("/") + "/SWFTools/logo.jpg", 10f, 10f, convertPages);

                    Loger.logger("开始转换(2)：" + sourcePath + "--" + targetPath);

                    //切记，使用pdf2swf.exe 打开的文件名之间不能有空格，否则会失败
                    cmdStr = HttpContext.Current.Server.MapPath("/SWFTools/pdf2swf.exe");
                    sPath = @"""" + sourcePath.Replace(".pdf", "_W.pdf") + @"""";
                    tPath = @"""" + targetPath + @"""";
                    //@"""" 四个双引号得到一个双引号，如果你所存放的文件所在文件夹名有空格的话，要在文件名的路径前后加上双引号，才能够成功
                    // -t 源文件的路径
                    // -s 参数化（也就是为pdf2swf.exe 执行添加一些窗外的参数(可省略)）
                    string argsStr = "  -t " + sPath + " -s flashversion=9 -o " + tPath + " -p 1-" + convertPages;
                    //string argsStr = "  -t \"" + sourcePath + "\"  -o \"" + targetPath + "\" -s drawonlyshapes -s flashversion=9";
                    //pdf2swf.exe -qG -s disablelinks -s languagedir="D:\xpdf-chinese-simplified" D:\sss\123.pdf  123%.swf
                    ExcutedCmd(cmdStr, argsStr);

                    Loger.logger("开始转换(3)：" + sourcePath + "--" + targetPath);

                    if (File.Exists(sourcePath.Replace(".pdf", "_W.pdf")))
                    {
                        File.Delete(sourcePath.Replace(".pdf", "_W.pdf"));
                    }

                    result = IsConvertSucceed(targetPath, 100);//最多等5秒
                }
            }
            catch (Exception ex)
            {
                Loger.logger("转换失败：" + ex.Message);
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