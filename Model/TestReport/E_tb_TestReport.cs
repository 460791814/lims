using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TestReport
{
    /// <summary>
    /// 检验报告
    /// </summary>
    [Serializable]
    public partial class E_tb_TestReport
    {
        public E_tb_TestReport()
        { }
        #region Model
        private int _reportid;
        private string _recordids;
        private string _tasknos;
        private string _reportno;
        private string _samplenum;
        private string _samplename;
        private string _department;
        private int? _testtype;
        private DateTime? _issuedtime;
        private string _testingcompany;
        private string _specifications;
        private DateTime? _productiontime;
        private string _packing;
        private string _productnum;
        private string _tosamplemode;
        private string _sendtestaddress;
        private string _samplingplace;
        private string _samplingcompany;
        private string _samplingpersonnel;
        private DateTime? _samplingtime;
        private DateTime? _testtime;
        private string _shelflife;
        private string _testbasis;
        private string _conclusion;
        private string _remarks;
        private string _explain;
        private int? _approvalpersonnelid;
        private int? _examinepersonnelid;
        private int? _maintestpersonnelid;
        private string _filepath;
        private int? _areaid;
        private int? _editpersonnelid;
        private DateTime? _addtime;
        private DateTime? _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public int ReportID
        {
            set { _reportid = value; }
            get { return _reportid; }
        }
        /// <summary>
        /// 原始记录IDS
        /// </summary>
        public string RecordIDS
        {
            set { _recordids = value; }
            get { return _recordids; }
        }
        /// <summary>
        /// 任务单号S
        /// </summary>
        public string TaskNoS
        {
            set { _tasknos = value; }
            get { return _tasknos; }
        }
        /// <summary>
        /// 报告编号
        /// </summary>
        public string ReportNo
        {
            set { _reportno = value; }
            get { return _reportno; }
        }
        /// <summary>
        /// 样品编号
        /// </summary>
        public string SampleNum
        {
            set { _samplenum = value; }
            get { return _samplenum; }
        }
        /// <summary>
        /// 样品名称
        /// </summary>
        public string SampleName
        {
            set { _samplename = value; }
            get { return _samplename; }
        }
        /// <summary>
        /// 送/抽检单位（通过任务单号进行关联获取）
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 检验类别
        /// </summary>
        public int? TestType
        {
            set { _testtype = value; }
            get { return _testtype; }
        }
        /// <summary>
        /// 批准日期
        /// </summary>
        public DateTime? IssuedTime
        {
            set { _issuedtime = value; }
            get { return _issuedtime; }
        }
        /// <summary>
        /// 检测单位
        /// </summary>
        public string TestingCompany
        {
            set { _testingcompany = value; }
            get { return _testingcompany; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string Specifications
        {
            set { _specifications = value; }
            get { return _specifications; }
        }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? ProductionTime
        {
            set { _productiontime = value; }
            get { return _productiontime; }
        }
        /// <summary>
        /// 包装形式
        /// </summary>
        public string Packing
        {
            set { _packing = value; }
            get { return _packing; }
        }
        /// <summary>
        /// 批次号（唯一）
        /// </summary>
        public string productNum
        {
            set { _productnum = value; }
            get { return _productnum; }
        }
        /// <summary>
        /// 来样方式
        /// </summary>
        public string ToSampleMode
        {
            set { _tosamplemode = value; }
            get { return _tosamplemode; }
        }
        /// <summary>
        /// 送检单位地址
        /// </summary>
        public string SendTestAddress
        {
            set { _sendtestaddress = value; }
            get { return _sendtestaddress; }
        }
        /// <summary>
        /// 抽样地点
        /// </summary>
        public string SamplingPlace
        {
            set { _samplingplace = value; }
            get { return _samplingplace; }
        }
        /// <summary>
        /// 抽样单位
        /// </summary>
        public string SamplingCompany
        {
            set { _samplingcompany = value; }
            get { return _samplingcompany; }
        }
        /// <summary>
        /// 抽样者
        /// </summary>
        public string SamplingPersonnel
        {
            set { _samplingpersonnel = value; }
            get { return _samplingpersonnel; }
        }
        /// <summary>
        /// 抽样日期
        /// </summary>
        public DateTime? SamplingTime
        {
            set { _samplingtime = value; }
            get { return _samplingtime; }
        }
        /// <summary>
        /// 检验日期
        /// </summary>
        public DateTime? TestTime
        {
            set { _testtime = value; }
            get { return _testtime; }
        }
        /// <summary>
        /// 保质期
        /// </summary>
        public string ShelfLife
        {
            set { _shelflife = value; }
            get { return _shelflife; }
        }
        /// <summary>
        /// 检验依据
        /// </summary>
        public string TestBasis
        {
            set { _testbasis = value; }
            get { return _testbasis; }
        }
        /// <summary>
        /// 检验结论
        /// </summary>
        public string Conclusion
        {
            set { _conclusion = value; }
            get { return _conclusion; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string Explain
        {
            set { _explain = value; }
            get { return _explain; }
        }
        /// <summary>
        /// 批准人员ID
        /// </summary>
        public int? ApprovalPersonnelID
        {
            set { _approvalpersonnelid = value; }
            get { return _approvalpersonnelid; }
        }
        /// <summary>
        /// 审核人员ID
        /// </summary>
        public int? examinePersonnelID
        {
            set { _examinepersonnelid = value; }
            get { return _examinepersonnelid; }
        }
        /// <summary>
        /// 主检人员ID
        /// </summary>
        public int? MainTestPersonnelID
        {
            set { _maintestpersonnelid = value; }
            get { return _maintestpersonnelid; }
        }
        /// <summary>
        /// 文件地址
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int? AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 编辑用户
        /// </summary>
        public int? EditPersonnelID
        {
            set { _editpersonnelid = value; }
            get { return _editpersonnelid; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model

        #region 数据接口
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }

        /// <summary>
        /// 批准人名称
        /// </summary>
        public string ApprovalPersonnelName { get; set; }

        /// <summary>
        /// 审核人名称
        /// </summary>
        public string examinePersonnelName { get; set; }
        
        /// <summary>
        /// 主检人名称
        /// </summary>
        public string MainTestPersonnelName { get; set; }

        /// <summary>
        /// 检验数据Json
        /// </summary>
        public string TestReportDataJson { get; set; }

        /// <summary>
        /// 检验类别名称
        /// </summary>
        public string TestTypeName { get; set; }

        #endregion
    }
}
