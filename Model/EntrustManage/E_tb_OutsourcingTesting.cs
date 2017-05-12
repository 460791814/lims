using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.EntrustManage
{
    /// <summary>
    /// 外委检验
    /// </summary>
    [Serializable]
    public partial class E_tb_OutsourcingTesting
    {
        public E_tb_OutsourcingTesting()
        { }
        #region Model
        private int _outsourcingid;
        private string _entrustcompany;
        private int? _sampleid;
        private DateTime? _submissiontime;
        private string _submissioncompany;
        private int? _projectid;
        private string _outsourcingreport;
        private int? _iscomplete;
        private int? _areaid;
        private int? _editpersonnelid;
        /// <summary>
        /// 
        /// </summary>
        public int OutsourcingID
        {
            set { _outsourcingid = value; }
            get { return _outsourcingid; }
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
        /// 送检时间
        /// </summary>
        public DateTime? SubmissionTime
        {
            set { _submissiontime = value; }
            get { return _submissiontime; }
        }
        /// <summary>
        /// 送检单位
        /// </summary>
        public string SubmissionCompany
        {
            set { _submissioncompany = value; }
            get { return _submissioncompany; }
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
        /// 委外检验报告
        /// </summary>
        public string OutsourcingReport
        {
            set { _outsourcingreport = value; }
            get { return _outsourcingreport; }
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
