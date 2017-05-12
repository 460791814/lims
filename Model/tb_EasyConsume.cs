/**  版本信息模板在安装目录下，可自行修改。
* tb_EasyConsume.cs
*
* 功 能： N/A
* 类 名： tb_EasyConsume
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/4 21:23:34   N/A    初版
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
	/// tb_EasyConsume:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_EasyConsume
	{
		public tb_EasyConsume()
		{}
        #region Model
        private int _id;
        private string _name;
        private string _type;
        private int? _unit;
        private int? _amount;
        private string _product;
        private decimal _price;
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
        /// 名称
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
        /// 单位
        /// </summary>
        public int? unit
        {
            set { _unit = value; }
            get { return _unit; }
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
        /// 厂家产地
        /// </summary>
        public string product
        {
            set { _product = value; }
            get { return _product; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal price
        {
            get { return _price; }
            set { _price = value; }
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

