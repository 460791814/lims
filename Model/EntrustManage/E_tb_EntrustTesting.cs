using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.EntrustManage
{
    /// <summary>
    /// tb_EntrustTesting:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_EntrustTesting
    {
        public E_tb_EntrustTesting()
        { }
        #region Model
        private int _entrustid;
        private string _taskno;
        private string _entrustcompany;
        private int? _sampleid;
        private int? _projectid;
        private int? _testpersonnelid;
        private DateTime? _submissiontime;
        private int? _reportid;
        private int? _iscomplete;
        private int? _areaid;
        private int? _editpersonnelid;
        /// <summary>
        /// 
        /// </summary>
        public int EntrustID
        {
            set { _entrustid = value; }
            get { return _entrustid; }
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
        /// 项目ID
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
        /// 送检日期
        /// </summary>
        public DateTime? SubmissionTime
        {
            set { _submissiontime = value; }
            get { return _submissiontime; }
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
