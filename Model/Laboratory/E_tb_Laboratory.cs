using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Laboratory
{
    /// <summary>
    /// 实验室表
    /// </summary>
    [Serializable]
    public partial class E_tb_Laboratory
    {
        public E_tb_Laboratory()
        { }
        #region Model
        private int _laboratoryid;
        private int? _areaid;
        private string _laboratoryname;
        private int? _laboratorytypeid;
        private string _directions;
        private DateTime? _updatetime;
        private int? _orderid;
        private int? _isuse = 0;
        /// <summary>
        /// 
        /// </summary>
        public int LaboratoryID
        {
            set { _laboratoryid = value; }
            get { return _laboratoryid; }
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
        /// 实验室名称
        /// </summary>
        public string LaboratoryName
        {
            set { _laboratoryname = value; }
            get { return _laboratoryname; }
        }
        /// <summary>
        /// 实验室类别ID
        /// </summary>
        public int? LaboratoryTypeID
        {
            set { _laboratorytypeid = value; }
            get { return _laboratorytypeid; }
        }
        /// <summary>
        /// 实验室说明
        /// </summary>
        public string Directions
        {
            set { _directions = value; }
            get { return _directions; }
        }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 排序ID
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 是否使用（0：空闲 1：使用中）
        /// </summary>
        public int? IsUse
        {
            set { _isuse = value; }
            get { return _isuse; }
        }
        #endregion Model

        #region 数据接口
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }

        /// <summary>
        /// 用户所属区域
        /// </summary>
        public int UserAreaID { get; set; }

        /// <summary>
        /// 用户数据权限
        /// </summary>
        public int UserDataRange { get; set; }
        #endregion

    }
}
