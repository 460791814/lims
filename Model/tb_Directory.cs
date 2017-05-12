using System;
namespace Model
{
	/// <summary>
	/// tb_Directory:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_Directory
	{
		public tb_Directory()
		{}
		#region Model
		private int _id;
		private string _dir_name;
		private int? _dir_parentid;
		private int? _dir_level;
		private int? _dir_order;
		private int? _createuser;
		private int? _updateuser;
		private DateTime? _createdate;
		private DateTime? _updatedate;
		private bool _isdelete;
		private bool _dir_isleaf;
		private string _dir_value1;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dir_Name
		{
			set{ _dir_name=value;}
			get{return _dir_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dir_ParentId
		{
			set{ _dir_parentid=value;}
			get{return _dir_parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dir_Level
		{
			set{ _dir_level=value;}
			get{return _dir_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dir_Order
		{
			set{ _dir_order=value;}
			get{return _dir_order;}
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
		public int? updateUser
		{
			set{ _updateuser=value;}
			get{return _updateuser;}
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
		public DateTime? updateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 是否是子节点 0不是子节点 1是子节点
		/// </summary>
		public bool dir_IsLeaf
		{
			set{ _dir_isleaf=value;}
			get{return _dir_isleaf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dir_Value1
		{
			set{ _dir_value1=value;}
			get{return _dir_value1;}
		}
		#endregion Model

	}
}

