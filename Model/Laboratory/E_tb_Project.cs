using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Laboratory
{
    /// <summary>
	/// tb_Project:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class E_tb_Project
	{
		public E_tb_Project()
		{}
        #region Model
        private int _projectid;
        private int _areaid;
        private int _laboratoryid;
        private int? _projecttypeid;
        private string _projectname;
        private string _expetype;
        private string _expemethod;
        private string _exprange;
        private string _filepath;
        private string _sampledatarange;
        private string _remark;
        private DateTime? _updatetime;
        private string _filename;
        private int? _ispescheck;
        private string _insStand;

        public string InsStand
        {
            get { return _insStand; }
            set { _insStand = value; }
        }
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 实验室ID
        /// </summary>
        public int LaboratoryID
        {
            set { _laboratoryid = value; }
            get { return _laboratoryid; }
        }
        /// <summary>
        /// 项目类别ID
        /// </summary>
        public int? ProjectTypeID
        {
            set { _projecttypeid = value; }
            get { return _projecttypeid; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            set { _projectname = value; }
            get { return _projectname; }
        }
        /// <summary>
        /// 检验类别
        /// </summary>
        public string ExpeType
        {
            set { _expetype = value; }
            get { return _expetype; }
        }
        /// <summary>
        /// 实验方法
        /// </summary>
        public string ExpeMethod
        {
            set { _expemethod = value; }
            get { return _expemethod; }
        }
        /// <summary>
        /// 检验范围
        /// </summary>
        public string ExpRange
        {
            set { _exprange = value; }
            get { return _exprange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 样品数据范围
        /// </summary>
        public string SampleDataRange
        {
            set { _sampledatarange = value; }
            get { return _sampledatarange; }
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
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 是否为农药残留检查（0：否、1：是）
        /// </summary>
        public int? IsPesCheck
        {
            set { _ispescheck = value; }
            get { return _ispescheck; }
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
