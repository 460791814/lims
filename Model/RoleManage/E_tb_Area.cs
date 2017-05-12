using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.RoleManage
{
    /// <summary>
    /// 区域表
    /// </summary>
    [Serializable]
    public partial class E_tb_Area
    {
        public E_tb_Area()
        { }
        #region Model
        private string _testreportname;

        public string TestReportName
        {
            get { return _testreportname; }
            set { _testreportname = value; }
        }

        private int _areaid;
        private string _areaname;
        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName
        {
            set { _areaname = value; }
            get { return _areaname; }
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
