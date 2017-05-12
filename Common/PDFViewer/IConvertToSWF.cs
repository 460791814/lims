using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.PDFViewer
{
    public interface IConvertToSWF
    {
        ///Word转换成pdf
        /// 把Word文件转换成为PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        bool DOC2PDF(string sourcePath, string targetPath);
        /// <summary>
        /// 把Excel文件转换成PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        bool XLS2PDF(string sourcePath, string targetPath);
        /// <summary>
        /// 把PowerPoing文件转换成PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        bool PPT2PDF(string sourcePath, string targetPath);
        /// <summary>
        /// 把PDF文件转换成格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        bool PDF2SWF(string sourcePath, string targetPath);
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
        bool PDFWatermark(string inputfilepath, string outputfilepath, string ModelPicName, float top, float left, int Pages);
    }
}
