using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TestReport
{
    /// <summary>
    /// tb_TestReportData:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_TestReportData
    {
        public E_tb_TestReportData()
        { }
        #region Model
        private int _reportdataid;
        private int? _recordid;
        private string _recordfilepath;
        private int? _reportid;
        private string _testname;
        private string _teststandard;
        private string _testresult;
        private string _qualifiedlevel;
        private string _testpersonnelname;
        /// <summary>
        /// 
        /// </summary>
        public int ReportDataID
        {
            set { _reportdataid = value; }
            get { return _reportdataid; }
        }
        /// <summary>
        /// 原始记录ID
        /// </summary>
        public int? RecordID
        {
            set { _recordid = value; }
            get { return _recordid; }
        }
        /// <summary>
        /// 原始记录文件
        /// </summary>
        public string RecordFilePath
        {
            set { _recordfilepath = value; }
            get { return _recordfilepath; }
        }
        /// <summary>
        /// 检验报告ID
        /// </summary>
        public int? ReportID
        {
            set { _reportid = value; }
            get { return _reportid; }
        }
        /// <summary>
        /// 检验名称
        /// </summary>
        public string TestName
        {
            set { _testname = value; }
            get { return _testname; }
        }
        /// <summary>
        /// 检验标准
        /// </summary>
        public string TestStandard
        {
            set { _teststandard = value; }
            get { return _teststandard; }
        }
        /// <summary>
        /// 检验结果
        /// </summary>
        public string TestResult
        {
            set { _testresult = value; }
            get { return _testresult; }
        }
        /// <summary>
        /// 合格/不合格
        /// </summary>
        public string QualifiedLevel
        {
            set { _qualifiedlevel = value; }
            get { return _qualifiedlevel; }
        }
        /// <summary>
        /// 检验人名称
        /// </summary>
        public string TestPersonnelName
        {
            set { _testpersonnelname = value; }
            get { return _testpersonnelname; }
        }
        #endregion Model

    }
}
