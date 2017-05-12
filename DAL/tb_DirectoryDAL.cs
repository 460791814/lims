using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
namespace DAL
{
	/// <summary>
	/// 数据访问类:tb_Directory
	/// </summary>
	public partial class tb_DirectoryDAL
	{
		public tb_DirectoryDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tb_Directory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Directory");
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
		public int Add(tb_Directory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Directory(");
			strSql.Append("dir_Name,dir_ParentId,dir_Level,dir_Order,createUser,updateUser,createDate,updateDate,isDelete,dir_IsLeaf,dir_Value1)");
			strSql.Append(" values (");
			strSql.Append("@dir_Name,@dir_ParentId,@dir_Level,@dir_Order,@createUser,@updateUser,@createDate,@updateDate,@isDelete,@dir_IsLeaf,@dir_Value1)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@dir_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@dir_ParentId", SqlDbType.Int,4),
					new SqlParameter("@dir_Level", SqlDbType.Int,4),
					new SqlParameter("@dir_Order", SqlDbType.Int,4),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@dir_IsLeaf", SqlDbType.Bit,1),
					new SqlParameter("@dir_Value1", SqlDbType.VarChar,-1)};
			parameters[0].Value = model.dir_Name;
			parameters[1].Value = model.dir_ParentId;
			parameters[2].Value = model.dir_Level;
			parameters[3].Value = model.dir_Order;
			parameters[4].Value = model.createUser;
			parameters[5].Value = model.updateUser;
			parameters[6].Value = model.createDate;
			parameters[7].Value = model.updateDate;
			parameters[8].Value = model.isDelete;
			parameters[9].Value = model.dir_IsLeaf;
			parameters[10].Value = model.dir_Value1;

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
		public bool Update(tb_Directory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Directory set ");
			strSql.Append("dir_Name=@dir_Name,");
			strSql.Append("dir_ParentId=@dir_ParentId,");
			strSql.Append("dir_Level=@dir_Level,");
			strSql.Append("dir_Order=@dir_Order,");
			strSql.Append("createUser=@createUser,");
			strSql.Append("updateUser=@updateUser,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("updateDate=@updateDate,");
			strSql.Append("isDelete=@isDelete,");
			strSql.Append("dir_IsLeaf=@dir_IsLeaf,");
			strSql.Append("dir_Value1=@dir_Value1");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@dir_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@dir_ParentId", SqlDbType.Int,4),
					new SqlParameter("@dir_Level", SqlDbType.Int,4),
					new SqlParameter("@dir_Order", SqlDbType.Int,4),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@dir_IsLeaf", SqlDbType.Bit,1),
					new SqlParameter("@dir_Value1", SqlDbType.VarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.dir_Name;
			parameters[1].Value = model.dir_ParentId;
			parameters[2].Value = model.dir_Level;
			parameters[3].Value = model.dir_Order;
			parameters[4].Value = model.createUser;
			parameters[5].Value = model.updateUser;
			parameters[6].Value = model.createDate;
			parameters[7].Value = model.updateDate;
			parameters[8].Value = model.isDelete;
			parameters[9].Value = model.dir_IsLeaf;
			parameters[10].Value = model.dir_Value1;
			parameters[11].Value = model.id;

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
            return DeleteList(id.ToString());
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Directory set isDelete = 1");
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
		public tb_Directory GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,dir_Name,dir_ParentId,dir_Level,dir_Order,createUser,updateUser,createDate,updateDate,isDelete,dir_IsLeaf,dir_Value1 from tb_Directory ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			tb_Directory model=new tb_Directory();
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
		public tb_Directory DataRowToModel(DataRow row)
		{
			tb_Directory model=new tb_Directory();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["dir_Name"]!=null)
				{
					model.dir_Name=row["dir_Name"].ToString();
				}
				if(row["dir_ParentId"]!=null && row["dir_ParentId"].ToString()!="")
				{
					model.dir_ParentId=int.Parse(row["dir_ParentId"].ToString());
				}
				if(row["dir_Level"]!=null && row["dir_Level"].ToString()!="")
				{
					model.dir_Level=int.Parse(row["dir_Level"].ToString());
				}
				if(row["dir_Order"]!=null && row["dir_Order"].ToString()!="")
				{
					model.dir_Order=int.Parse(row["dir_Order"].ToString());
				}
				if(row["createUser"]!=null && row["createUser"].ToString()!="")
				{
					model.createUser=int.Parse(row["createUser"].ToString());
				}
				if(row["updateUser"]!=null && row["updateUser"].ToString()!="")
				{
					model.updateUser=int.Parse(row["updateUser"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["updateDate"]!=null && row["updateDate"].ToString()!="")
				{
					model.updateDate=DateTime.Parse(row["updateDate"].ToString());
				}
				if(row["isDelete"]!=null && row["isDelete"].ToString()!="")
				{
					if((row["isDelete"].ToString()=="1")||(row["isDelete"].ToString().ToLower()=="true"))
					{
						model.isDelete=true;
					}
					else
					{
						model.isDelete=false;
					}
				}
				if(row["dir_IsLeaf"]!=null && row["dir_IsLeaf"].ToString()!="")
				{
					if((row["dir_IsLeaf"].ToString()=="1")||(row["dir_IsLeaf"].ToString().ToLower()=="true"))
					{
						model.dir_IsLeaf=true;
					}
					else
					{
						model.dir_IsLeaf=false;
					}
				}
				if(row["dir_Value1"]!=null)
				{
					model.dir_Value1=row["dir_Value1"].ToString();
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
			strSql.Append("select id,dir_Name,dir_ParentId,dir_Level,dir_Order,createUser,updateUser,createDate,updateDate,isDelete,dir_IsLeaf,dir_Value1 ");
			strSql.Append(" FROM tb_Directory ");
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
			strSql.Append(" id,dir_Name,dir_ParentId,dir_Level,dir_Order,createUser,updateUser,createDate,updateDate,isDelete,dir_IsLeaf,dir_Value1 ");
			strSql.Append(" FROM tb_Directory ");
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
			strSql.Append("select count(1) FROM tb_Directory ");
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
			strSql.Append(")AS Row, T.*  from tb_Directory T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_Directory";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

