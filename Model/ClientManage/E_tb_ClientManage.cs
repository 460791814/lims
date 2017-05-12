using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ClientManage
{
    /// <summary>
    /// 客户管理
    /// </summary>
    [Serializable]
    public partial class E_tb_ClientManage
    {
        public E_tb_ClientManage()
        { }
        #region Model
        private int _clientid;
        private string _clientname;
        private string _contact;
        private string _email;
        private string _deputy;
        private string _address;
        private string _fixed;
        private string _tel;
        private string _fax;
        private string _zipcode;
        private string _clientlevel;
        private string _prepaidmoney;
        private string _mainbusiness;
        private string _yearentrust;
        private string _incentives;
        private string _contractno;
        private int? _contractimgid;
        private string _contractpath;
        private int? _areaid;
        private int? _editpersonnelid;
        /// <summary>
        /// 
        /// </summary>
        public int ClientID
        {
            set { _clientid = value; }
            get { return _clientid; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string ClientName
        {
            set { _clientname = value; }
            get { return _clientname; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact
        {
            set { _contact = value; }
            get { return _contact; }
        }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 代表
        /// </summary>
        public string Deputy
        {
            set { _deputy = value; }
            get { return _deputy; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 固定电话
        /// </summary>
        public string Fixed
        {
            set { _fixed = value; }
            get { return _fixed; }
        }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode
        {
            set { _zipcode = value; }
            get { return _zipcode; }
        }
        /// <summary>
        /// 客户等级
        /// </summary>
        public string ClientLevel
        {
            set { _clientlevel = value; }
            get { return _clientlevel; }
        }
        /// <summary>
        /// 预付金额
        /// </summary>
        public string PrepaidMoney
        {
            set { _prepaidmoney = value; }
            get { return _prepaidmoney; }
        }
        /// <summary>
        /// 主营业务
        /// </summary>
        public string MainBusiness
        {
            set { _mainbusiness = value; }
            get { return _mainbusiness; }
        }
        /// <summary>
        /// 年委托检验业务量
        /// </summary>
        public string YearEntrust
        {
            set { _yearentrust = value; }
            get { return _yearentrust; }
        }
        /// <summary>
        /// 优惠措施
        /// </summary>
        public string Incentives
        {
            set { _incentives = value; }
            get { return _incentives; }
        }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNo
        {
            set { _contractno = value; }
            get { return _contractno; }
        }
        /// <summary>
        /// 合同图标
        /// </summary>
        public int? ContractImgID
        {
            set { _contractimgid = value; }
            get { return _contractimgid; }
        }
        /// <summary>
        /// 扫描文件地址
        /// </summary>
        public string ContractPath
        {
            set { _contractpath = value; }
            get { return _contractpath; }
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
        /// 编辑用户
        /// </summary>
        public int? EditPersonnelID
        {
            set { _editpersonnelid = value; }
            get { return _editpersonnelid; }
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
