/**  版本信息模板在安装目录下，可自行修改。
* tb_Detection.cs
*
* 功 能： N/A
* 类 名： tb_Detection
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/9 14:32:58   N/A    初版
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
	/// tb_Detection:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_Detection
	{
		public tb_Detection()
		{}

        #region Model
        private int _id;
        private string _name;
        private string _company;
        private string _telphone;
        private string _gist;
        private string _address;
        private string _domethod;
        private int? _samplenum;
        private string _packging;
        private DateTime? _detectiondate;
        private int? _detectionuser;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
        private string _temp1;
        private string _temp2;
        private int? _sid;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 样品名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 抽样单位
        /// </summary>
        public string company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string telPhone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 抽样依据
        /// </summary>
        public string gist
        {
            set { _gist = value; }
            get { return _gist; }
        }
        /// <summary>
        /// 地点
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 抽样方法
        /// </summary>
        public string domethod
        {
            set { _domethod = value; }
            get { return _domethod; }
        }
        /// <summary>
        /// 样品数量
        /// </summary>
        public int? sampleNum
        {
            set { _samplenum = value; }
            get { return _samplenum; }
        }
        /// <summary>
        /// 包装方式
        /// </summary>
        public string packging
        {
            set { _packging = value; }
            get { return _packging; }
        }
        /// <summary>
        /// 抽样日期
        /// </summary>
        public DateTime? detectionDate
        {
            set { _detectiondate = value; }
            get { return _detectiondate; }
        }
        /// <summary>
        /// 抽样人
        /// </summary>
        public int? detectionUser
        {
            set { _detectionuser = value; }
            get { return _detectionuser; }
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
        /// 
        /// </summary>
        public int? sId
        {
            set { _sid = value; }
            get { return _sid; }
        }
        #endregion Model

    }
}

