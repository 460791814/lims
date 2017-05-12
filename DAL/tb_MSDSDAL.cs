using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class tb_MSDSDAL
    {
        public tb_MSDSDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_MSDS");
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
		public int Add(tb_MSDS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_MSDS(");
			strSql.Append("wId,fileName,fileUrl,fileType,createUser,createDate,temp1,temp2)");
			strSql.Append(" values (");
			strSql.Append("@wId,@fileName,@fileUrl,@fileType,@createUser,@createDate,@temp1,@temp2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4),
					new SqlParameter("@fileName", SqlDbType.NVarChar,100),
					new SqlParameter("@fileUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@fileType", SqlDbType.NVarChar,50),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text)};
			parameters[0].Value = model.wId;
			parameters[1].Value = model.fileName;
			parameters[2].Value = model.fileUrl;
			parameters[3].Value = model.fileType;
			parameters[4].Value = model.createUser;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.temp1;
			parameters[7].Value = model.temp2;

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
		public bool Update(tb_MSDS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_MSDS set ");
			strSql.Append("wId=@wId,");
			strSql.Append("fileName=@fileName,");
			strSql.Append("fileUrl=@fileUrl,");
			strSql.Append("fileType=@fileType,");
			strSql.Append("createUser=@createUser,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("temp1=@temp1,");
			strSql.Append("temp2=@temp2");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@wId", SqlDbType.Int,4),
					new SqlParameter("@fileName", SqlDbType.NVarChar,100),
					new SqlParameter("@fileUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@fileType", SqlDbType.NVarChar,50),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.wId;
			parameters[1].Value = model.fileName;
			parameters[2].Value = model.fileUrl;
			parameters[3].Value = model.fileType;
			parameters[4].Value = model.createUser;
			parameters[5].Value = model.createDate;
			parameters[6].Value = model.temp1;
			parameters[7].Value = model.temp2;
			parameters[8].Value = model.id;

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
			strSql.Append("delete from tb_MSDS ");
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
			strSql.Append("delete from tb_MSDS ");
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
		public tb_MSDS GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,wId,fileName,fileUrl,fileType,createUser,createDate,temp1,temp2 from tb_MSDS ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			tb_MSDS model=new tb_MSDS();
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
		public tb_MSDS DataRowToModel(DataRow row)
		{
			tb_MSDS model=new tb_MSDS();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["wId"]!=null && row["wId"].ToString()!="")
				{
					model.wId=int.Parse(row["wId"].ToString());
				}
				if(row["fileName"]!=null)
				{
					model.fileName=row["fileName"].ToString();
				}
				if(row["fileUrl"]!=null)
				{
					model.fileUrl=row["fileUrl"].ToString();
				}
				if(row["fileType"]!=null)
				{
					model.fileType=row["fileType"].ToString();
				}
				if(row["createUser"]!=null && row["createUser"].ToString()!="")
				{
					model.createUser=int.Parse(row["createUser"].ToString());
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
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
			strSql.Append("select id,wId,fileName,fileUrl,fileType,createUser,createDate,temp1,temp2 ");
			strSql.Append(" FROM tb_MSDS ");
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
			strSql.Append(" id,wId,fileName,fileUrl,fileType,createUser,createDate,temp1,temp2 ");
			strSql.Append(" FROM tb_MSDS ");
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
			strSql.Append("select count(1) FROM tb_MSDS ");
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
			strSql.Append(")AS Row, T.*  from tb_MSDS T ");
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
			parameters[0].Value = "tb_MSDS";
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