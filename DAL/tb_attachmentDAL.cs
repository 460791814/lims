/**  版本信息模板在安装目录下，可自行修改。
* tb_attachment.cs
*
* 功 能： N/A
* 类 名： tb_attachment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/9 14:32:57   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
namespace DAL
{
    /// <summary>
    /// 数据访问类:tb_attachment
    /// </summary>
    public partial class tb_attachmentDAL
    {
        public tb_attachmentDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_attachment");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_attachment");
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
        public int Add(tb_attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_attachment(");
            strSql.Append("fileName,filePath,fileSize,type1,type2,tId,createUser,createDate,updateUser,updateDate,temp1,temp2)");
            strSql.Append(" values (");
            strSql.Append("@fileName,@filePath,@fileSize,@type1,@type2,@tId,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@fileName", SqlDbType.NVarChar,200),
					new SqlParameter("@filePath", SqlDbType.NVarChar,-1),
					new SqlParameter("@fileSize", SqlDbType.VarChar,50),
					new SqlParameter("@type1", SqlDbType.VarChar,50),
					new SqlParameter("@type2", SqlDbType.VarChar,50),
					new SqlParameter("@tId", SqlDbType.Int,4),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.fileName;
            parameters[1].Value = model.filePath;
            parameters[2].Value = model.fileSize;
            parameters[3].Value = model.type1;
            parameters[4].Value = model.type2;
            parameters[5].Value = model.tId;
            parameters[6].Value = model.createUser;
            parameters[7].Value = model.createDate;
            parameters[8].Value = model.updateUser;
            parameters[9].Value = model.updateDate;
            parameters[10].Value = model.temp1;
            parameters[11].Value = model.temp2;

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
        public bool Update(tb_attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_attachment set ");
            strSql.Append("fileName=@fileName,");
            strSql.Append("filePath=@filePath,");
            strSql.Append("fileSize=@fileSize,");
            strSql.Append("type1=@type1,");
            strSql.Append("type2=@type2,");
            strSql.Append("tId=@tId,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@fileName", SqlDbType.NVarChar,200),
					new SqlParameter("@filePath", SqlDbType.NVarChar,-1),
					new SqlParameter("@fileSize", SqlDbType.VarChar,50),
					new SqlParameter("@type1", SqlDbType.VarChar,50),
					new SqlParameter("@type2", SqlDbType.VarChar,50),
					new SqlParameter("@tId", SqlDbType.Int,4),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.fileName;
            parameters[1].Value = model.filePath;
            parameters[2].Value = model.fileSize;
            parameters[3].Value = model.type1;
            parameters[4].Value = model.type2;
            parameters[5].Value = model.tId;
            parameters[6].Value = model.createUser;
            parameters[7].Value = model.createDate;
            parameters[8].Value = model.updateUser;
            parameters[9].Value = model.updateDate;
            parameters[10].Value = model.temp1;
            parameters[11].Value = model.temp2;
            parameters[12].Value = model.id;

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
            strSql.Append("delete from tb_attachment ");
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

        public bool Delete(string _type1, string _type2, int tId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_attachment ");
            strSql.Append(" where tId=@tId and type1=@type1 and type2=@type2");
            SqlParameter[] parameters = {
					new SqlParameter("@tId", SqlDbType.Int,4),
                    new SqlParameter("@type1", SqlDbType.VarChar,50),
                    new SqlParameter("@type2", SqlDbType.VarChar,50),
			};
            parameters[0].Value = tId;
            parameters[1].Value = _type1;
            parameters[2].Value = _type2;

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
            strSql.Append("delete from tb_attachment ");
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
        public tb_attachment GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,fileName,filePath,fileSize,type1,type2,tId,createUser,createDate,updateUser,updateDate,temp1,temp2 from tb_attachment ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_attachment model = new tb_attachment();
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
        public tb_attachment DataRowToModel(DataRow row)
        {
            tb_attachment model = new tb_attachment();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["fileName"] != null)
                {
                    model.fileName = row["fileName"].ToString();
                }
                if (row["filePath"] != null)
                {
                    model.filePath = row["filePath"].ToString();
                }
                if (row["fileSize"] != null)
                {
                    model.fileSize = row["fileSize"].ToString();
                }
                if (row["type1"] != null)
                {
                    model.type1 = row["type1"].ToString();
                }
                if (row["type2"] != null)
                {
                    model.type2 = row["type2"].ToString();
                }
                if (row["tId"] != null && row["tId"].ToString() != "")
                {
                    model.tId = int.Parse(row["tId"].ToString());
                }
                if (row["createUser"] != null && row["createUser"].ToString() != "")
                {
                    model.createUser = int.Parse(row["createUser"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["updateUser"] != null && row["updateUser"].ToString() != "")
                {
                    model.updateUser = int.Parse(row["updateUser"].ToString());
                }
                if (row["updateDate"] != null && row["updateDate"].ToString() != "")
                {
                    model.updateDate = DateTime.Parse(row["updateDate"].ToString());
                }
                if (row["temp1"] != null)
                {
                    model.temp1 = row["temp1"].ToString();
                }
                if (row["temp2"] != null)
                {
                    model.temp2 = row["temp2"].ToString();
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
            strSql.Append("select id,fileName,filePath,fileSize,type1,type2,tId,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_attachment ");
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
            strSql.Append(" id,fileName,filePath,fileSize,type1,type2,tId,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_attachment ");
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
            strSql.Append("select count(1) FROM tb_attachment ");
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
            strSql.Append(")AS Row, T.*  from tb_attachment T ");
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
            parameters[0].Value = "tb_attachment";
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

