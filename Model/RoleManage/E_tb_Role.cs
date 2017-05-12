using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.RoleManage
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Serializable]
    public partial class E_tb_Role
    {
        public E_tb_Role()
        { }
        #region Model
        private int _roleid;
        private string _rolename;
        private int? _datarange;
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 数据范围(1:全部 2:区域 3:个人)
        /// </summary>
        public int? DataRange
        {
            set { _datarange = value; }
            get { return _datarange; }
        }
        #endregion Model


        #region 数据接口
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }

        /// <summary>
        /// 需要设置的操作ID集合
        /// </summary>
        public string ActionIDS { get; set; }
        #endregion
    }
}
