using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DictManage
{
    /// <summary>
	/// tb_TypeDict:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class E_tb_TypeDict
	{
		public E_tb_TypeDict()
		{}
        #region Model
        private int _typeid;
        private int? _subjectid;
        private string _typename;
        private int _parentid;
        private int? _typelevel;
        private string _directions;
        /// <summary>
        /// 类别ID
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 项目ID（1：新闻类型）
        /// </summary>
        public int? SubjectID
        {
            set { _subjectid = value; }
            get { return _subjectid; }
        }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 父ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 层级等级
        /// </summary>
        public int? TypeLevel
        {
            set { _typelevel = value; }
            get { return _typelevel; }
        }
        /// <summary>
        /// 类别说明
        /// </summary>
        public string Directions
        {
            set { _directions = value; }
            get { return _directions; }
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
