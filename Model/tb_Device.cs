/**  版本信息模板在安装目录下，可自行修改。
* tb_Device.cs
*
* 功 能： N/A
* 类 名： tb_Device
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/29 14:00:14   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// tb_Device:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_Device
	{
        public tb_Device()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _type;
        private string _pcode;
        private string _ecode;
        private DateTime? _buydate;
        private DateTime? _usedate;
        private decimal? _price;
        private string _depercitionnum;
        private string _verificationnum;
        private int? _unit;
        private DateTime? _lastverificationdate;
        private string _verificationresult;
        private DateTime? _nextverificationdate;
        private int? _technologystatus;
        private string _problem;
        private int? _companyid;
        private string _userid;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
        private string _temp1;
        private string _temp2;
        private int? _amount;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 资产编号
        /// </summary>
        public string pCode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string eCode
        {
            set { _ecode = value; }
            get { return _ecode; }
        }
        /// <summary>
        /// 购置日期
        /// </summary>
        public DateTime? buyDate
        {
            set { _buydate = value; }
            get { return _buydate; }
        }
        /// <summary>
        /// 启用日期
        /// </summary>
        public DateTime? useDate
        {
            set { _usedate = value; }
            get { return _usedate; }
        }
        /// <summary>
        /// 原值
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 折旧年限
        /// </summary>
        public string depercitionNum
        {
            set { _depercitionnum = value; }
            get { return _depercitionnum; }
        }
        /// <summary>
        /// 检定周期
        /// </summary>
        public string verificationNum
        {
            set { _verificationnum = value; }
            get { return _verificationnum; }
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
        /// 上次检定日期
        /// </summary>
        public DateTime? lastVerificationDate
        {
            set { _lastverificationdate = value; }
            get { return _lastverificationdate; }
        }
        /// <summary>
        /// 检定结论
        /// </summary>
        public string verificationResult
        {
            set { _verificationresult = value; }
            get { return _verificationresult; }
        }
        /// <summary>
        /// 下次检定日期
        /// </summary>
        public DateTime? nextVerificationDate
        {
            set { _nextverificationdate = value; }
            get { return _nextverificationdate; }
        }
        /// <summary>
        /// 技术状况
        /// </summary>
        public int? technologyStatus
        {
            set { _technologystatus = value; }
            get { return _technologystatus; }
        }
        /// <summary>
        /// 存在问题及部位
        /// </summary>
        public string problem
        {
            set { _problem = value; }
            get { return _problem; }
        }
        /// <summary>
        /// 使用单位
        /// </summary>
        public int? companyId
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 使用人
        /// </summary>
        public string userId
        {
            set { _userid = value; }
            get { return _userid; }
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
        /// <summary>
        /// 库存
        /// </summary>
        public int? amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        #endregion Model

    }
}