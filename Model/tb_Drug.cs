using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tb_Drug
    {
        public tb_Drug()
        { }
        #region Model
        private int _id;
        private string _drugname;
        private string _drugcode;
        private int? _drugtype;
        private int? _unit;
        private DateTime? _productdate;
        private DateTime? _validdate;
        private decimal? _amount;
        private string _manufacturers;
        private int? _cabinet;
        private int? _registrant;
        private string _risklevel;
        private bool _ismsds;
        private string _remark;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
        private string _temp1;
        private string _temp2;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 编号
        /// </summary>
        public string drugCode
        {
            set { _drugcode = value; }
            get { return _drugcode; }
        }
        /// <summary>
        /// 药品类别
        /// </summary>
        public int? drugType
        {
            set { _drugtype = value; }
            get { return _drugtype; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public int? unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? productDate
        {
            set { _productdate = value; }
            get { return _productdate; }
        }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime? validDate
        {
            set { _validdate = value; }
            get { return _validdate; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string manufacturers
        {
            set { _manufacturers = value; }
            get { return _manufacturers; }
        }
        /// <summary>
        /// 药品柜ID
        /// </summary>
        public int? cabinet
        {
            set { _cabinet = value; }
            get { return _cabinet; }
        }
        /// <summary>
        /// 登记人
        /// </summary>
        public int? registrant
        {
            set { _registrant = value; }
            get { return _registrant; }
        }
        /// <summary>
        /// 危险性分类
        /// </summary>
        public string riskLevel
        {
            set { _risklevel = value; }
            get { return _risklevel; }
        }
        /// <summary>
        /// 是否建立MSDS
        /// </summary>
        public bool isMSDS
        {
            set { _ismsds = value; }
            get { return _ismsds; }
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
        /// <summary>
        /// 
        /// </summary>
        public string temp1
        {
            set { _temp1 = value; }
            get { return _temp1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string temp2
        {
            set { _temp2 = value; }
            get { return _temp2; }
        }
        #endregion Model

    }
}
