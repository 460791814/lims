/**  版本信息模板在安装目录下，可自行修改。
* tb_Supplier.cs
*
* 功 能： N/A
* 类 名： tb_Supplier
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/9 14:02:41   N/A    初版
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
	/// tb_Supplier:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_Supplier
	{
		public tb_Supplier()
		{
            
        }


        private tb_attachment jkz;

        public tb_attachment Jkz
        {
            get { return jkz; }
            set { jkz = value; }
        }
        private tb_attachment clws;

        public tb_attachment Clws
        {
            get { return clws; }
            set { clws = value; }
        }
        private tb_attachment jyz;

        public tb_attachment Jyz
        {
            get { return jyz; }
            set { jyz = value; }
        }
        private tb_attachment xdzm;

        public tb_attachment Xdzm
        {
            get { return xdzm; }
            set { xdzm = value; }
        }
        private tb_attachment jybg;

        public tb_attachment Jybg
        {
            get { return jybg; }
            set { jybg = value; }
        }

        #region Model
        private int _id;
        private string _name;
        private string _address;
        private string _linkman;
        private string _linknum;
        private string _remark;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
        private string _temp1;
        private string _temp2;
        private string _sendaddress;
        private string _fax;
        private string _mobliephone;
        private string _businessscope;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string linkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string linkNum
        {
            set { _linknum = value; }
            get { return _linknum; }
        }
        /// <summary>
        /// 描述
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
        /// 送货地址
        /// </summary>
        public string sendAddress
        {
            set { _sendaddress = value; }
            get { return _sendaddress; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string mobliephone
        {
            set { _mobliephone = value; }
            get { return _mobliephone; }
        }
        /// <summary>
        /// 业务范围
        /// </summary>
        public string businessscope
        {
            set { _businessscope = value; }
            get { return _businessscope; }
        }
        #endregion Model


	}
}

