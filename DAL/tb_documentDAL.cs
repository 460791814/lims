using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
namespace DAL
{
    /// <summary>
    /// 数据访问类:tb_document
    /// </summary>
    public partial class tb_documentDAL
    {
        public tb_documentDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_document");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(tb_document model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_document(");
            strSql.Append("doc_Code,doc_Name,doc_Guid,direct_Id,doc_Type,doc_URL,doc_Size,doc_CreateUser,doc_UpdateUser,doc_CreateDate,doc_UpdateDate,isDelete,doc_Revo,doc_Source,doc_Path,temp1,temp2,remark,doc_Status,doc_KeyWord)");
            strSql.Append(" values (");
            strSql.Append("@doc_Code,@doc_Name,@doc_Guid,@direct_Id,@doc_Type,@doc_URL,@doc_Size,@doc_CreateUser,@doc_UpdateUser,@doc_CreateDate,@doc_UpdateDate,@isDelete,@doc_Revo,@doc_Source,@doc_Path,@temp1,@temp2,@remark,@doc_Status,@doc_KeyWord)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@doc_Code", SqlDbType.NVarChar,100),
					new SqlParameter("@doc_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@doc_Guid", SqlDbType.VarChar,100),
					new SqlParameter("@direct_Id", SqlDbType.Int,4),
					new SqlParameter("@doc_Type", SqlDbType.VarChar,10),
					new SqlParameter("@doc_URL", SqlDbType.NVarChar,-1),
					new SqlParameter("@doc_Size", SqlDbType.VarChar,100),
					new SqlParameter("@doc_CreateUser", SqlDbType.Int,4),
					new SqlParameter("@doc_UpdateUser", SqlDbType.Int,4),
					new SqlParameter("@doc_CreateDate", SqlDbType.DateTime),
					new SqlParameter("@doc_UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@doc_Revo", SqlDbType.VarChar,100),
					new SqlParameter("@doc_Source", SqlDbType.VarChar,300),
					new SqlParameter("@doc_Path", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp1", SqlDbType.NVarChar,300),
					new SqlParameter("@temp2", SqlDbType.NVarChar,300),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@doc_Status", SqlDbType.Int,4),
					new SqlParameter("@doc_KeyWord", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.doc_Code;
            parameters[1].Value = model.doc_Name;
            parameters[2].Value = model.doc_Guid;
            parameters[3].Value = model.direct_Id;
            parameters[4].Value = model.doc_Type;
            parameters[5].Value = model.doc_URL;
            parameters[6].Value = model.doc_Size;
            parameters[7].Value = model.doc_CreateUser;
            parameters[8].Value = model.doc_UpdateUser;
            parameters[9].Value = model.doc_CreateDate;
            parameters[10].Value = model.doc_UpdateDate;
            parameters[11].Value = model.isDelete;
            parameters[12].Value = model.doc_Revo;
            parameters[13].Value = model.doc_Source;
            parameters[14].Value = model.doc_Path;
            parameters[15].Value = model.temp1;
            parameters[16].Value = model.temp2;
            parameters[17].Value = model.remark;
            parameters[18].Value = model.doc_Status;
            parameters[19].Value = model.doc_KeyWord;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(tb_document model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_document set ");
            strSql.Append("doc_Code=@doc_Code,");
            strSql.Append("doc_Name=@doc_Name,");
            strSql.Append("doc_Guid=@doc_Guid,");
            strSql.Append("direct_Id=@direct_Id,");
            strSql.Append("doc_Type=@doc_Type,");
            strSql.Append("doc_URL=@doc_URL,");
            strSql.Append("doc_Size=@doc_Size,");
            strSql.Append("doc_CreateUser=@doc_CreateUser,");
            strSql.Append("doc_UpdateUser=@doc_UpdateUser,");
            strSql.Append("doc_CreateDate=@doc_CreateDate,");
            strSql.Append("doc_UpdateDate=@doc_UpdateDate,");
            strSql.Append("isDelete=@isDelete,");
            strSql.Append("doc_Revo=@doc_Revo,");
            strSql.Append("doc_Source=@doc_Source,");
            strSql.Append("doc_Path=@doc_Path,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2,");
            strSql.Append("remark=@remark,");
            strSql.Append("doc_Status=@doc_Status,");
            strSql.Append("doc_KeyWord=@doc_KeyWord");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@doc_Code", SqlDbType.NVarChar,100),
					new SqlParameter("@doc_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@doc_Guid", SqlDbType.VarChar,100),
					new SqlParameter("@direct_Id", SqlDbType.Int,4),
					new SqlParameter("@doc_Type", SqlDbType.VarChar,10),
					new SqlParameter("@doc_URL", SqlDbType.NVarChar,-1),
					new SqlParameter("@doc_Size", SqlDbType.VarChar,100),
					new SqlParameter("@doc_CreateUser", SqlDbType.Int,4),
					new SqlParameter("@doc_UpdateUser", SqlDbType.Int,4),
					new SqlParameter("@doc_CreateDate", SqlDbType.DateTime),
					new SqlParameter("@doc_UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@doc_Revo", SqlDbType.VarChar,100),
					new SqlParameter("@doc_Source", SqlDbType.VarChar,300),
					new SqlParameter("@doc_Path", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp1", SqlDbType.NVarChar,300),
					new SqlParameter("@temp2", SqlDbType.NVarChar,300),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@doc_Status", SqlDbType.Int,4),
					new SqlParameter("@doc_KeyWord", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.doc_Code;
            parameters[1].Value = model.doc_Name;
            parameters[2].Value = model.doc_Guid;
            parameters[3].Value = model.direct_Id;
            parameters[4].Value = model.doc_Type;
            parameters[5].Value = model.doc_URL;
            parameters[6].Value = model.doc_Size;
            parameters[7].Value = model.doc_CreateUser;
            parameters[8].Value = model.doc_UpdateUser;
            parameters[9].Value = model.doc_CreateDate;
            parameters[10].Value = model.doc_UpdateDate;
            parameters[11].Value = model.isDelete;
            parameters[12].Value = model.doc_Revo;
            parameters[13].Value = model.doc_Source;
            parameters[14].Value = model.doc_Path;
            parameters[15].Value = model.temp1;
            parameters[16].Value = model.temp2;
            parameters[17].Value = model.remark;
            parameters[18].Value = model.doc_Status;
            parameters[19].Value = model.doc_KeyWord;
            parameters[20].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_document ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_document ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public tb_document GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,doc_Code,doc_Name,doc_Guid,direct_Id,doc_Type,doc_URL,doc_Size,doc_CreateUser,doc_UpdateUser,doc_CreateDate,doc_UpdateDate,isDelete,doc_Revo,doc_Source,doc_Path,temp1,temp2,remark,doc_Status,doc_KeyWord from tb_document ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_document model = new tb_document();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public tb_document DataRowToModel(DataRow row)
        {
            tb_document model = new tb_document();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["doc_Code"] != null)
                {
                    model.doc_Code = row["doc_Code"].ToString();
                }
                if (row["doc_Name"] != null)
                {
                    model.doc_Name = row["doc_Name"].ToString();
                }
                if (row["doc_Guid"] != null)
                {
                    model.doc_Guid = row["doc_Guid"].ToString();
                }
                if (row["direct_Id"] != null && row["direct_Id"].ToString() != "")
                {
                    model.direct_Id = int.Parse(row["direct_Id"].ToString());
                }
                if (row["doc_Type"] != null)
                {
                    model.doc_Type = row["doc_Type"].ToString();
                }
                if (row["doc_URL"] != null)
                {
                    model.doc_URL = row["doc_URL"].ToString();
                }
                if (row["doc_Size"] != null)
                {
                    model.doc_Size = row["doc_Size"].ToString();
                }
                if (row["doc_CreateUser"] != null && row["doc_CreateUser"].ToString() != "")
                {
                    model.doc_CreateUser = int.Parse(row["doc_CreateUser"].ToString());
                }
                if (row["doc_UpdateUser"] != null && row["doc_UpdateUser"].ToString() != "")
                {
                    model.doc_UpdateUser = int.Parse(row["doc_UpdateUser"].ToString());
                }
                if (row["doc_CreateDate"] != null && row["doc_CreateDate"].ToString() != "")
                {
                    model.doc_CreateDate = DateTime.Parse(row["doc_CreateDate"].ToString());
                }
                if (row["doc_UpdateDate"] != null && row["doc_UpdateDate"].ToString() != "")
                {
                    model.doc_UpdateDate = DateTime.Parse(row["doc_UpdateDate"].ToString());
                }
                if (row["isDelete"] != null && row["isDelete"].ToString() != "")
                {
                    if ((row["isDelete"].ToString() == "1") || (row["isDelete"].ToString().ToLower() == "true"))
                    {
                        model.isDelete = true;
                    }
                    else
                    {
                        model.isDelete = false;
                    }
                }
                if (row["doc_Revo"] != null)
                {
                    model.doc_Revo = row["doc_Revo"].ToString();
                }
                if (row["doc_Source"] != null)
                {
                    model.doc_Source = row["doc_Source"].ToString();
                }
                if (row["doc_Path"] != null)
                {
                    model.doc_Path = row["doc_Path"].ToString();
                }
                if (row["temp1"] != null)
                {
                    model.temp1 = row["temp1"].ToString();
                }
                if (row["temp2"] != null)
                {
                    model.temp2 = row["temp2"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["doc_Status"] != null && row["doc_Status"].ToString() != "")
                {
                    model.doc_Status = int.Parse(row["doc_Status"].ToString());
                }
                if (row["doc_KeyWord"] != null)
                {
                    model.doc_KeyWord = row["doc_KeyWord"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,doc_Code,doc_Name,doc_Guid,direct_Id,doc_Type,doc_URL,doc_Size,doc_CreateUser,doc_UpdateUser,doc_CreateDate,doc_UpdateDate,isDelete,doc_Revo,doc_Source,doc_Path,temp1,temp2,remark,doc_Status,doc_KeyWord ");
            strSql.Append(" FROM tb_document ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,doc_Code,doc_Name,doc_Guid,direct_Id,doc_Type,doc_URL,doc_Size,doc_CreateUser,doc_UpdateUser,doc_CreateDate,doc_UpdateDate,isDelete,doc_Revo,doc_Source,doc_Path,temp1,temp2,remark,doc_Status,doc_KeyWord ");
            strSql.Append(" FROM tb_document ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_document ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_document T ");
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
            parameters[0].Value = "tb_document";
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

