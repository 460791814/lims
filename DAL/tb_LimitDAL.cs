using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
        /// <summary>
	/// 数据访问类:tb_Limit
	/// </summary>
	public partial class tb_LimitDAL
	{
		public tb_LimitDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Limit");
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
		public int Add(tb_Limit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Limit(");
			strSql.Append("limitType,limitId,limitRead,limitWrite,limitDelete,fileId)");
			strSql.Append(" values (");
			strSql.Append("@limitType,@limitId,@limitRead,@limitWrite,@limitDelete,@fileId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@limitType", SqlDbType.NVarChar,50),
					new SqlParameter("@limitId", SqlDbType.Int,4),
					new SqlParameter("@limitRead", SqlDbType.Bit,1),
					new SqlParameter("@limitWrite", SqlDbType.Bit,1),
					new SqlParameter("@limitDelete", SqlDbType.Bit,1),
					new SqlParameter("@fileId", SqlDbType.Int,4)};
			parameters[0].Value = model.limitType;
			parameters[1].Value = model.limitId;
			parameters[2].Value = model.limitRead;
			parameters[3].Value = model.limitWrite;
			parameters[4].Value = model.limitDelete;
			parameters[5].Value = model.fileId;

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
		public bool Update(tb_Limit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Limit set ");
			strSql.Append("limitType=@limitType,");
			strSql.Append("limitId=@limitId,");
			strSql.Append("limitRead=@limitRead,");
			strSql.Append("limitWrite=@limitWrite,");
			strSql.Append("limitDelete=@limitDelete,");
			strSql.Append("fileId=@fileId");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@limitType", SqlDbType.NVarChar,50),
					new SqlParameter("@limitId", SqlDbType.Int,4),
					new SqlParameter("@limitRead", SqlDbType.Bit,1),
					new SqlParameter("@limitWrite", SqlDbType.Bit,1),
					new SqlParameter("@limitDelete", SqlDbType.Bit,1),
					new SqlParameter("@fileId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.limitType;
			parameters[1].Value = model.limitId;
			parameters[2].Value = model.limitRead;
			parameters[3].Value = model.limitWrite;
			parameters[4].Value = model.limitDelete;
			parameters[5].Value = model.fileId;
			parameters[6].Value = model.id;

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
			strSql.Append("delete from tb_Limit ");
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
			strSql.Append("delete from tb_Limit ");
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
		public tb_Limit GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,limitType,limitId,limitRead,limitWrite,limitDelete,fileId from tb_Limit ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			tb_Limit model=new tb_Limit();
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
		public tb_Limit DataRowToModel(DataRow row)
		{
			tb_Limit model=new tb_Limit();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["limitType"]!=null)
				{
					model.limitType=row["limitType"].ToString();
				}
				if(row["limitId"]!=null && row["limitId"].ToString()!="")
				{
					model.limitId=int.Parse(row["limitId"].ToString());
				}
				if(row["limitRead"]!=null && row["limitRead"].ToString()!="")
				{
					if((row["limitRead"].ToString()=="1")||(row["limitRead"].ToString().ToLower()=="true"))
					{
						model.limitRead=true;
					}
					else
					{
						model.limitRead=false;
					}
				}
				if(row["limitWrite"]!=null && row["limitWrite"].ToString()!="")
				{
					if((row["limitWrite"].ToString()=="1")||(row["limitWrite"].ToString().ToLower()=="true"))
					{
						model.limitWrite=true;
					}
					else
					{
						model.limitWrite=false;
					}
				}
				if(row["limitDelete"]!=null && row["limitDelete"].ToString()!="")
				{
					if((row["limitDelete"].ToString()=="1")||(row["limitDelete"].ToString().ToLower()=="true"))
					{
						model.limitDelete=true;
					}
					else
					{
						model.limitDelete=false;
					}
				}
				if(row["fileId"]!=null && row["fileId"].ToString()!="")
				{
					model.fileId=int.Parse(row["fileId"].ToString());
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
			strSql.Append("select id,limitType,limitId,limitRead,limitWrite,limitDelete,fileId ");
			strSql.Append(" FROM tb_Limit ");
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
			strSql.Append(" id,limitType,limitId,limitRead,limitWrite,limitDelete,fileId ");
			strSql.Append(" FROM tb_Limit ");
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
			strSql.Append("select count(1) FROM tb_Limit ");
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
			strSql.Append(")AS Row, T.*  from tb_Limit T ");
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
			parameters[0].Value = "tb_Limit";
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
