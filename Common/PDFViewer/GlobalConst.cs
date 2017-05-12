using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Common.PDFViewer
{
    /// <summary>
    /// 全局常量
    /// xiaowj
    /// 2014-5-19
    /// </summary>
    public class GlobalConst
    {
        private static string _isDebug = null;

        private static string _maxPdfPages = null;

        private static string _pdfPagesRate = null;

        /// <summary>
        /// 是否调试状态
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                if (_isDebug == null)
                {
                    _isDebug = ConfigurationManager.AppSettings["IsDebug"];
                }
                return _isDebug == "true";
            }
        }

        /// <summary>
        /// 最大pdf页面处理数
        /// </summary>
        public static int MaxPdfPages
        {
            get
            {
                if (_maxPdfPages == null)
                {
                    _maxPdfPages = ConfigurationManager.AppSettings["MaxPdfPages"];
                    int page;
                    if (string.IsNullOrEmpty(_maxPdfPages)||(!int.TryParse(_maxPdfPages,out page)))//没有配置分页，默认为5
                    {
                        _maxPdfPages = "5";
                    }
                }

                return int.Parse(_maxPdfPages);
            }
        }

        /// <summary>
        /// pdf页面显示比例
        /// </summary>
        public static double PdfPagesRate
        {
            get
            {
                if (_pdfPagesRate == null)
                {
                    _pdfPagesRate = ConfigurationManager.AppSettings["PdfPagesRate"];
                    double pageRate;
                    if (string.IsNullOrEmpty(_pdfPagesRate) || (!double.TryParse(_pdfPagesRate, out pageRate)))//没有配置分页，默认为0.5
                    {
                        _maxPdfPages = "0.5";
                    }
                }

                return double.Parse(_pdfPagesRate);
            }
        }
    }
}