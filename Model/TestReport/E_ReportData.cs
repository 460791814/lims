using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TestReport
{
    /// <summary>
    /// 检验数据实体
    /// </summary>
    public class E_ReportData
    {
        /// <summary>
        /// 检验名称
        /// </summary>
        public string TestName{get;set;}
        /// <summary>
        /// 检验标准
        /// </summary>
        public string TestStandard{get;set;}
        /// <summary>
        /// 检验结果
        /// </summary>
        public string TestResult{get;set;}
        /// <summary>
        /// 合格等级
        /// </summary>
        public string QualifiedLevel{get;set;}
        /// <summary>
        /// 检验人名称
        /// </summary>
        public string TestPersonnelName{get;set;}

        /// <summary>
        /// 原始记录文件
        /// </summary>
        public string RecordFilePath { get; set; }

        /// <summary>
        /// 原始记录ID
        /// </summary>
        public string RecordID { get; set; }
    }
}
