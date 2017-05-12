/**  版本信息模板在安装目录下，可自行修改。
* tb_DeviceOUT.cs
*
* 功 能： N/A
* 类 名： tb_DeviceOUT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/29 14:00:15   N/A    初版
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
	/// tb_DeviceOUT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_DeviceOUT
	{
		public tb_DeviceOUT()
		{}
		#region Model
		private int _id;
		private int? _deviceid;
		private int? _amount;
		private int? _userid1;
		private string _usefor;
		private DateTime? _gdate;
		private int? _userid2;
		private DateTime? _bdate;
		private int? _userid3;
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
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 设备Id（tb_device外键）
		/// </summary>
		public int? deviceId
		{
			set{ _deviceid=value;}
			get{return _deviceid;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int? amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 领用人
		/// </summary>
		public int? userId1
		{
			set{ _userid1=value;}
			get{return _userid1;}
		}
		/// <summary>
		/// 用途
		/// </summary>
		public string useFor
		{
			set{ _usefor=value;}
			get{return _usefor;}
		}
		/// <summary>
		/// 领用日期
		/// </summary>
		public DateTime? gDate
		{
			set{ _gdate=value;}
			get{return _gdate;}
		}
		/// <summary>
		/// 归还人
		/// </summary>
		public int? userId2
		{
			set{ _userid2=value;}
			get{return _userid2;}
		}
		/// <summary>
		/// 归还日期
		/// </summary>
		public DateTime? bDate
		{
			set{ _bdate=value;}
			get{return _bdate;}
		}
		/// <summary>
		/// 经办人
		/// </summary>
		public int? userId3
		{
			set{ _userid3=value;}
			get{return _userid3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? createUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? updateUser
		{
			set{ _updateuser=value;}
			get{return _updateuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string temp1
		{
			set{ _temp1=value;}
			get{return _temp1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string temp2
		{
			set{ _temp2=value;}
			get{return _temp2;}
		}
		#endregion Model

	}
}

