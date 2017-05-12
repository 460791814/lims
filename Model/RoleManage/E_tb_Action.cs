using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.RoleManage
{
    /// <summary>
    /// tb_Action:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_Action
    {
        public E_tb_Action()
        { }
        #region Model
        private int _actionid;
        private int? _parentid;
        private string _actionname;
        private string _actioncode;
        private string _requesttype;
        private string _requesturl;
        private int? _actiontype;
        /// <summary>
        /// 操作ID
        /// </summary>
        public int ActionID
        {
            set { _actionid = value; }
            get { return _actionid; }
        }
        /// <summary>
        /// 父操作ID
        /// </summary>
        public int? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string ActionName
        {
            set { _actionname = value; }
            get { return _actionname; }
        }
        /// <summary>
        /// 权限代码
        /// </summary>
        public string ActionCode
        {
            set { _actioncode = value; }
            get { return _actioncode; }
        }
        /// <summary>
        /// 请求类型
        /// </summary>
        public string RequestType
        {
            set { _requesttype = value; }
            get { return _requesttype; }
        }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestURL
        {
            set { _requesturl = value; }
            get { return _requesturl; }
        }
        /// <summary>
        /// 权限类型（1：模块 2：页面 3：操作）
        /// </summary>
        public int? ActionType
        {
            set { _actiontype = value; }
            get { return _actiontype; }
        }
        #endregion Model

        #region 数据接口
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }

        /// <summary>
        /// 父节点名称
        /// </summary>
        public string ParentName { get; set; }
        #endregion
    }
}
