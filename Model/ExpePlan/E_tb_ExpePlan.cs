using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ExpePlan
{
    /// <summary>
    /// 实验计划表
    /// </summary>
    [Serializable]
    public partial class E_tb_ExpePlan
    {
        public E_tb_ExpePlan()
        { }
        #region Model
        private int _planid;
        private int? _plantypeid;
        private int? _projectid;
        private int? _sampleid;
        private DateTime? _inspecttime;
        private string _inspectplace;
        private string _inspectmethod;
        private int? _headpersonnelid;
        private string _taskno;
        private int? _status;
        private string _remark;
        private int? _areaid;
        private int? _editpersonnelid;
        private DateTime? _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public int PlanID
        {
            set { _planid = value; }
            get { return _planid; }
        }
        /// <summary>
        /// 计划类别（1：计划内 2：计划外）
        /// </summary>
        public int? PlanTypeID
        {
            set { _plantypeid = value; }
            get { return _plantypeid; }
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
        /// 
        /// </summary>
        public int? SampleID
        {
            set { _sampleid = value; }
            get { return _sampleid; }
        }
        /// <summary>
        /// 检验时间
        /// </summary>
        public DateTime? InspectTime
        {
            set { _inspecttime = value; }
            get { return _inspecttime; }
        }
        /// <summary>
        /// 检验地点
        /// </summary>
        public string InspectPlace
        {
            set { _inspectplace = value; }
            get { return _inspectplace; }
        }
        /// <summary>
        /// 检验方法
        /// </summary>
        public string InspectMethod
        {
            set { _inspectmethod = value; }
            get { return _inspectmethod; }
        }
        /// <summary>
        /// 负责人ID
        /// </summary>
        public int? HeadPersonnelID
        {
            set { _headpersonnelid = value; }
            get { return _headpersonnelid; }
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
        /// 状态
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 区域
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
        /// 更新时间
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
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 负责人名称
        /// </summary>
        public string HeadPersonnelName { get; set; }
        #endregion

    }
}
