using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.RoleManage
{
    /// <summary>
    /// tb_RoleAction:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_RoleAction
    {
        public E_tb_RoleAction()
        { }
        #region Model
        private int _roleactionid;
        private int _roleid;
        private int? _actionid;
        /// <summary>
        /// 角色操作ID
        /// </summary>
        public int RoleActionID
        {
            set { _roleactionid = value; }
            get { return _roleactionid; }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 操作ID
        /// </summary>
        public int? ActionID
        {
            set { _actionid = value; }
            get { return _actionid; }
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
