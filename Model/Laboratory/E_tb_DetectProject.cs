using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Laboratory
{
    /// <summary>
    /// 检测项目表
    /// </summary>
    [Serializable]
    public partial class E_tb_DetectProject
    {
        public E_tb_DetectProject()
        { }
        #region Model
        private int _projectid;
        private int? _laboratoryid;
        private int? _relationprojectid;
        private string _taskno;
        private string _projectname;
        private DateTime? _detecttime;
        private int? _headpersonnelid;
        private string _mainperson;
        private string _tel;
        private DateTime? _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public int ProjectID
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 实验室ID
        /// </summary>
        public int? LaboratoryID
        {
            set { _laboratoryid = value; }
            get { return _laboratoryid; }
        }
        /// <summary>
        /// 关联的项目（tb_Project--ProjectID）
        /// </summary>
        public int? RelationProjectID
        {
            set { _relationprojectid = value; }
            get { return _relationprojectid; }
        }
        /// <summary>
        /// 对应的任务单号
        /// </summary>
        public string TaskNo
        {
            set { _taskno = value; }
            get { return _taskno; }
        }
        /// <summary>
        /// 检测项目名称
        /// </summary>
        public string ProjectName
        {
            set { _projectname = value; }
            get { return _projectname; }
        }
        /// <summary>
        /// 检测日期
        /// </summary>
        public DateTime? DetectTime
        {
            set { _detecttime = value; }
            get { return _detecttime; }
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
        /// 负责人
        /// </summary>
        public string MainPerson
        {
            set { _mainperson = value; }
            get { return _mainperson; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
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
        #endregion
    }
}
