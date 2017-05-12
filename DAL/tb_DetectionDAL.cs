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
	/// 数据访问类:tb_Detection
	/// </summary>
	public partial class tb_DetectionDAL
	{
        public tb_DetectionDAL()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Detection");
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
        public int Add(tb_Detection model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Detection(");
            strSql.Append("name,company,telPhone,gist,address,domethod,sampleNum,packging,detectionDate,detectionUser,createUser,createDate,updateUser,updateDate,temp1,temp2,sId)");
            strSql.Append(" values (");
            strSql.Append("@name,@company,@telPhone,@gist,@address,@domethod,@sampleNum,@packging,@detectionDate,@detectionUser,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2,@sId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,200),
					new SqlParameter("@company", SqlDbType.NVarChar,500),
					new SqlParameter("@telPhone", SqlDbType.VarChar,500),
					new SqlParameter("@gist", SqlDbType.NVarChar,200),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@domethod", SqlDbType.NVarChar,500),
					new SqlParameter("@sampleNum", SqlDbType.Int,4),
					new SqlParameter("@packging", SqlDbType.NVarChar,50),
					new SqlParameter("@detectionDate", SqlDbType.DateTime),
					new SqlParameter("@detectionUser", SqlDbType.Int,4),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1),
					new SqlParameter("@sId", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.company;
            parameters[2].Value = model.telPhone;
            parameters[3].Value = model.gist;
            parameters[4].Value = model.address;
            parameters[5].Value = model.domethod;
            parameters[6].Value = model.sampleNum;
            parameters[7].Value = model.packging;
            parameters[8].Value = model.detectionDate;
            parameters[9].Value = model.detectionUser;
            parameters[10].Value = model.createUser;
            parameters[11].Value = model.createDate;
            parameters[12].Value = model.updateUser;
            parameters[13].Value = model.updateDate;
            parameters[14].Value = model.temp1;
            parameters[15].Value = model.temp2;
            parameters[16].Value = model.sId;

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
        public bool Update(tb_Detection model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Detection set ");
            strSql.Append("name=@name,");
            strSql.Append("company=@company,");
            strSql.Append("telPhone=@telPhone,");
            strSql.Append("gist=@gist,");
            strSql.Append("address=@address,");
            strSql.Append("domethod=@domethod,");
            strSql.Append("sampleNum=@sampleNum,");
            strSql.Append("packging=@packging,");
            strSql.Append("detectionDate=@detectionDate,");
            strSql.Append("detectionUser=@detectionUser,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2,");
            strSql.Append("sId=@sId");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,200),
					new SqlParameter("@company", SqlDbType.NVarChar,500),
					new SqlParameter("@telPhone", SqlDbType.VarChar,500),
					new SqlParameter("@gist", SqlDbType.NVarChar,200),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@domethod", SqlDbType.NVarChar,500),
					new SqlParameter("@sampleNum", SqlDbType.Int,4),
					new SqlParameter("@packging", SqlDbType.NVarChar,50),
					new SqlParameter("@detectionDate", SqlDbType.DateTime),
					new SqlParameter("@detectionUser", SqlDbType.Int,4),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1),
					new SqlParameter("@sId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.company;
            parameters[2].Value = model.telPhone;
            parameters[3].Value = model.gist;
            parameters[4].Value = model.address;
            parameters[5].Value = model.domethod;
            parameters[6].Value = model.sampleNum;
            parameters[7].Value = model.packging;
            parameters[8].Value = model.detectionDate;
            parameters[9].Value = model.detectionUser;
            parameters[10].Value = model.createUser;
            parameters[11].Value = model.createDate;
            parameters[12].Value = model.updateUser;
            parameters[13].Value = model.updateDate;
            parameters[14].Value = model.temp1;
            parameters[15].Value = model.temp2;
            parameters[16].Value = model.sId;
            parameters[17].Value = model.id;

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
            strSql.Append("delete from tb_Detection ");
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
            strSql.Append("delete from tb_Detection ");
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
        public tb_Detection GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,company,telPhone,gist,address,domethod,sampleNum,packging,detectionDate,detectionUser,createUser,createDate,updateUser,updateDate,temp1,temp2,sId from tb_Detection ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_Detection model = new tb_Detection();
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
        public tb_Detection DataRowToModel(DataRow row)
        {
            tb_Detection model = new tb_Detection();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["company"] != null)
                {
                    model.company = row["company"].ToString();
                }
                if (row["telPhone"] != null)
                {
                    model.telPhone = row["telPhone"].ToString();
                }
                if (row["gist"] != null)
                {
                    model.gist = row["gist"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["domethod"] != null)
                {
                    model.domethod = row["domethod"].ToString();
                }
                if (row["sampleNum"] != null && row["sampleNum"].ToString() != "")
                {
                    model.sampleNum = int.Parse(row["sampleNum"].ToString());
                }
                if (row["packging"] != null)
                {
                    model.packging = row["packging"].ToString();
                }
                if (row["detectionDate"] != null && row["detectionDate"].ToString() != "")
                {
                    model.detectionDate = DateTime.Parse(row["detectionDate"].ToString());
                }
                if (row["detectionUser"] != null && row["detectionUser"].ToString() != "")
                {
                    model.detectionUser = int.Parse(row["detectionUser"].ToString());
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
                if (row["sId"] != null && row["sId"].ToString() != "")
                {
                    model.sId = int.Parse(row["sId"].ToString());
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
            strSql.Append("select id,name,company,telPhone,gist,address,domethod,sampleNum,packging,detectionDate,detectionUser,createUser,createDate,updateUser,updateDate,temp1,temp2,sId ");
            strSql.Append(" FROM tb_Detection ");
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
            strSql.Append(" id,name,company,telPhone,gist,address,domethod,sampleNum,packging,detectionDate,detectionUser,createUser,createDate,updateUser,updateDate,temp1,temp2,sId ");
            strSql.Append(" FROM tb_Detection ");
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
            strSql.Append("select count(1) FROM tb_Detection ");
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
            strSql.Append(")AS Row, T.*  from tb_Detection T ");
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
            parameters[0].Value = "tb_Detection";
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

        public tb_Detection GetModelBySID(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,company,telPhone,gist,address,domethod,sampleNum,packging,detectionDate,detectionUser,createUser,createDate,updateUser,updateDate,temp1,temp2,sId from tb_Detection ");
            strSql.Append(" where sId=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_Detection model = new tb_Detection();
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
    }
}