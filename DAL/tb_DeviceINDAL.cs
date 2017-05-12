using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类:tb_DeviceIN
	/// </summary>
	public partial class tb_DeviceINDAL
	{
		public tb_DeviceINDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tb_DeviceIN"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_DeviceIN");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(tb_DeviceIN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_DeviceIN(");
			strSql.Append("deviceId,amount,InDate,remark,createUser,createDate,updateUser,updateDate,temp1,temp2)");
			strSql.Append(" values (");
			strSql.Append("@deviceId,@amount,@InDate,@remark,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@deviceId", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text)};
			parameters[0].Value = model.deviceId;
			parameters[1].Value = model.amount;
			parameters[2].Value = model.InDate;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.createUser;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.updateUser;
			parameters[7].Value = model.updateDate;
			parameters[8].Value = model.temp1;
			parameters[9].Value = model.temp2;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(tb_DeviceIN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_DeviceIN set ");
			strSql.Append("deviceId=@deviceId,");
			strSql.Append("amount=@amount,");
			strSql.Append("InDate=@InDate,");
			strSql.Append("remark=@remark,");
			strSql.Append("createUser=@createUser,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("updateUser=@updateUser,");
			strSql.Append("updateDate=@updateDate,");
			strSql.Append("temp1=@temp1,");
			strSql.Append("temp2=@temp2");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@deviceId", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.deviceId;
			parameters[1].Value = model.amount;
			parameters[2].Value = model.InDate;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.createUser;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.updateUser;
			parameters[7].Value = model.updateDate;
			parameters[8].Value = model.temp1;
			parameters[9].Value = model.temp2;
			parameters[10].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_DeviceIN ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_DeviceIN ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_DeviceIN GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,deviceId,amount,InDate,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 from tb_DeviceIN ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			tb_DeviceIN model=new tb_DeviceIN();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public tb_DeviceIN DataRowToModel(DataRow row)
		{
			tb_DeviceIN model=new tb_DeviceIN();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["deviceId"]!=null && row["deviceId"].ToString()!="")
				{
					model.deviceId=int.Parse(row["deviceId"].ToString());
				}
				if(row["amount"]!=null && row["amount"].ToString()!="")
				{
					model.amount=int.Parse(row["amount"].ToString());
				}
				if(row["InDate"]!=null && row["InDate"].ToString()!="")
				{
					model.InDate=DateTime.Parse(row["InDate"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["createUser"]!=null && row["createUser"].ToString()!="")
				{
					model.createUser=int.Parse(row["createUser"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["updateUser"]!=null && row["updateUser"].ToString()!="")
				{
					model.updateUser=int.Parse(row["updateUser"].ToString());
				}
				if(row["updateDate"]!=null && row["updateDate"].ToString()!="")
				{
					model.updateDate=DateTime.Parse(row["updateDate"].ToString());
				}
				if(row["temp1"]!=null)
				{
					model.temp1=row["temp1"].ToString();
				}
				if(row["temp2"]!=null)
				{
					model.temp2=row["temp2"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,deviceId,amount,InDate,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
			strSql.Append(" FROM tb_DeviceIN ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,deviceId,amount,InDate,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
			strSql.Append(" FROM tb_DeviceIN ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_DeviceIN ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from View_DeviceIN T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  BasicMethod

		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

