/**  版本信息模板在安装目录下，可自行修改。
* tb_EasyConsumeIN.cs
*
* 功 能： N/A
* 类 名： tb_EasyConsumeIN
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/4 21:23:35   N/A    初版
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
	/// tb_EasyConsumeIN:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_EasyConsumeIN
	{
		public tb_EasyConsumeIN()
		{}
        #region Model
        private int _id;
        private int? _eid;
        private DateTime? _indate;
        private decimal? _price;
        private int? _amount;
        private decimal? _inmoney;
        private string _product;
        private int? _user1;
        private string _remark;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
        private string _temp1;
        private string _temp2;
        private DateTime? _productdate;
        private DateTime? _validdate;
        private string _manufacturers;
        private string _GPS;

        public string GPS
        {
            get { return _GPS; }
            set { _GPS = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// tb_EasyConsume（外键）
        /// </summary>
        public int? eId
        {
            set { _eid = value; }
            get { return _eid; }
        }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime? inDate
        {
            set { _indate = value; }
            get { return _indate; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int? amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 入库金额
        /// </summary>
        public decimal? inMoney
        {
            set { _inmoney = value; }
            get { return _inmoney; }
        }
        /// <summary>
        /// 厂家与产地
        /// </summary>
        public string product
        {
            set { _product = value; }
            get { return _product; }
        }
        /// <summary>
        /// 经手人
        /// </summary>
        public int? user1
        {
            set { _user1 = value; }
            get { return _user1; }
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
        /// 生产厂家
        /// </summary>
        public string manufacturers
        {
            set { _manufacturers = value; }
            get { return _manufacturers; }
        }
        #endregion Model

	}
}

