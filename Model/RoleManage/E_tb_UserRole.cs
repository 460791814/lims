using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.RoleManage
{
    /// <summary>
    /// 用户角色关系表
    /// </summary>
    [Serializable]
    public partial class E_tb_UserRole
    {
        public E_tb_UserRole()
        { }
        #region Model
        private int _userroleid;
        private int _personnelid;
        private int _roleid;
        /// <summary>
        /// 用户角色关系ID
        /// </summary>
        public int UserRoleID
        {
            set { _userroleid = value; }
            get { return _userroleid; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int PersonnelID
        {
            set { _personnelid = value; }
            get { return _personnelid; }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
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
