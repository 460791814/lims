using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.EntrustManage
{
    /// <summary>
	/// 委托计量
	/// </summary>
    [Serializable]
    public partial class E_tb_EntrustMeterage
    {
        public E_tb_EntrustMeterage()
        { }
        #region Model
        private int _meterageid;
        private string _taskno;
        private string _entrustcompany;
        private int? _sampleid;
        private DateTime? _submissiontime;
        private int? _projectid;
        private int? _testpersonnelid;
        private string _meteragereport;
        private int? _iscomplete;
        private int? _areaid;
        private int? _editpersonnelid;
        /// <summary>
        /// 
        /// </summary>
        public int MeterageID
        {
            set { _meterageid = value; }
            get { return _meterageid; }
        }
        /// <summary>
        /// 任务单号
        /// </summary>
        public string TaskNo
        {
            set { _taskno = value; }
            get { return _taskno; }
        }
        /// <summary>
        /// 委托单位
        /// </summary>
        public string EntrustCompany
        {
            set { _entrustcompany = value; }
            get { return _entrustcompany; }
        }
        /// <summary>
        /// 样品ID
        /// </summary>
        public int? SampleID
        {
            set { _sampleid = value; }
            get { return _sampleid; }
        }
        /// <summary>
        /// 送检日期
        /// </summary>
        public DateTime? SubmissionTime
        {
            set { _submissiontime = value; }
            get { return _submissiontime; }
        }
        /// <summary>
        /// 计量项目
        /// </summary>
        public int? ProjectID
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 检验人ID
        /// </summary>
        public int? TestPersonnelID
        {
            set { _testpersonnelid = value; }
            get { return _testpersonnelid; }
        }
        /// <summary>
        /// 计量报告
        /// </summary>
        public string MeterageReport
        {
            set { _meteragereport = value; }
            get { return _meteragereport; }
        }
        /// <summary>
        /// 是否完成（0：未完成、1：完成）
        /// </summary>
        public int? IsComplete
        {
            set { _iscomplete = value; }
            get { return _iscomplete; }
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
        #endregion Model
        #region 数据接口
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }
        #endregion
    }
}
