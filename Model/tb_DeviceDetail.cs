/**  版本信息模板在安装目录下，可自行修改。
* tb_DeviceDetail.cs
*
* 功 能： N/A
* 类 名： tb_DeviceDetail
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
	/// tb_DeviceDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_DeviceDetail
	{
		public tb_DeviceDetail()
		{}
		#region Model
		private int _id;
		private int? _deviceid;
		private DateTime? _mdate;
		private int? _thour;
		private int? _chour;
		private string _ac;
		private int? _userid1;
		private int? _blevel;
		private string _bproject;
		private int? _bcompanyid;
		private int? _userid2;
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
		/// 设备Id（tb_Device外键）
		/// </summary>
		public int? deviceId
		{
			set{ _deviceid=value;}
			get{return _deviceid;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime? mDate
		{
			set{ _mdate=value;}
			get{return _mdate;}
		}
		/// <summary>
		/// 运行小时-本期
		/// </summary>
		public int? tHour
		{
			set{ _thour=value;}
			get{return _thour;}
		}
		/// <summary>
		/// 运行小时-累计
		/// </summary>
		public int? cHour
		{
			set{ _chour=value;}
			get{return _chour;}
		}
		/// <summary>
		/// 使用期间异常情况
		/// </summary>
		public string AC
		{
			set{ _ac=value;}
			get{return _ac;}
		}
		/// <summary>
		/// 通知何人
		/// </summary>
		public int? userId1
		{
			set{ _userid1=value;}
			get{return _userid1;}
		}
		/// <summary>
		/// 保养等级
		/// </summary>
		public int? bLevel
		{
			set{ _blevel=value;}
			get{return _blevel;}
		}
		/// <summary>
		/// 主要保养项目
		/// </summary>
		public string bProject
		{
			set{ _bproject=value;}
			get{return _bproject;}
		}
		/// <summary>
		/// 保养单位
		/// </summary>
		public int? bCompanyId
		{
			set{ _bcompanyid=value;}
			get{return _bcompanyid;}
		}
		/// <summary>
		/// 保养人
		/// </summary>
		public int? userId2
		{
			set{ _userid2=value;}
			get{return _userid2;}
		}
		/// <summary>
		/// 验收人
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

