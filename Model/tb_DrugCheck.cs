using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tb_DrugCheck
    {
        public tb_DrugCheck()
        { }
        #region Model
        private int _id;
        private string _drugcode;
        private string _drugname;
        private int? _drugid;
        private int? _druginid;
        private int? _drugoutid;
        private DateTime? _outdate;
        private string _unit;
        private int? _amountin;
        private int? _amountout;
        private int? _amount;
        private string _risklevel;
        private DateTime? _checkdate;
        private string _checkuser;
        private int? _checkuserid;
        private string _auditstatus;
        private string _audituser;
        private string _audituserid;
        private string _remark;
        private bool _isdelete;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 药品编号
        /// </summary>
        public string drugCode
        {
            set { _drugcode = value; }
            get { return _drugcode; }
        }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string drugName
        {
            set { _drugname = value; }
            get { return _drugname; }
        }
        /// <summary>
        /// 药品ID
        /// </summary>
        public int? drugId
        {
            set { _drugid = value; }
            get { return _drugid; }
        }
        /// <summary>
        /// 药品入库ID
        /// </summary>
        public int? drugInId
        {
            set { _druginid = value; }
            get { return _druginid; }
        }
        /// <summary>
        /// 药品出库ID
        /// </summary>
        public int? drugOutId
        {
            set { _drugoutid = value; }
            get { return _drugoutid; }
        }
        /// <summary>
        /// 药品出库时间
        /// </summary>
        public DateTime? outDate
        {
            set { _outdate = value; }
            get { return _outdate; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 入库
        /// </summary>
        public int? amountIN
        {
            set { _amountin = value; }
            get { return _amountin; }
        }
        /// <summary>
        /// 出库
        /// </summary>
        public int? amountOUT
        {
            set { _amountout = value; }
            get { return _amountout; }
        }
        /// <summary>
        /// 库存
        /// </summary>
        public int? amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 危险性等级
        /// </summary>
        public string riskLevel
        {
            set { _risklevel = value; }
            get { return _risklevel; }
        }
        /// <summary>
        /// 盘点日期
        /// </summary>
        public DateTime? checkDate
        {
            set { _checkdate = value; }
            get { return _checkdate; }
        }
        /// <summary>
        /// 盘点人
        /// </summary>
        public string checkUser
        {
            set { _checkuser = value; }
            get { return _checkuser; }
        }
        /// <summary>
        /// 盘点人ID
        /// </summary>
        public int? checkUserId
        {
            set { _checkuserid = value; }
            get { return _checkuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string auditstatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string auditUser
        {
            set { _audituser = value; }
            get { return _audituser; }
        }
        /// <summary>
        /// 审核人ID
        /// </summary>
        public string auditUserId
        {
            set { _audituserid = value; }
            get { return _audituserid; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 是否删除（0未删除、1已删除）
        /// </summary>
        public bool isDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? createUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? updateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        #endregion Model
    }
}
