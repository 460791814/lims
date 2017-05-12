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
    /// 数据访问类:tb_DrugRegion
    /// </summary>
    public partial class tb_DrugRegionDAL
    {
        public tb_DrugRegionDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DrugRegion");
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
        public int Add(tb_DrugRegion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DrugRegion(");
            strSql.Append("lockId,regionName,createUser,createDate,updateUser,updateDate)");
            strSql.Append(" values (");
            strSql.Append("@lockId,@regionName,@createUser,@createDate,@updateUser,@updateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@lockId", SqlDbType.Int,4),
					new SqlParameter("@regionName", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.lockId;
            parameters[1].Value = model.regionName;
            parameters[2].Value = model.createUser;
            parameters[3].Value = model.createDate;
            parameters[4].Value = model.updateUser;
            parameters[5].Value = model.updateDate;

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
        public bool Update(tb_DrugRegion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DrugRegion set ");
            strSql.Append("lockId=@lockId,");
            strSql.Append("regionName=@regionName,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@lockId", SqlDbType.Int,4),
					new SqlParameter("@regionName", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.lockId;
            parameters[1].Value = model.regionName;
            parameters[2].Value = model.createUser;
            parameters[3].Value = model.createDate;
            parameters[4].Value = model.updateUser;
            parameters[5].Value = model.updateDate;
            parameters[6].Value = model.id;

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
            strSql.Append("delete from tb_DrugRegion ");
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
            strSql.Append("delete from tb_DrugRegion ");
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
        public tb_DrugRegion GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,lockId,regionName,createUser,createDate,updateUser,updateDate from tb_DrugRegion ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_DrugRegion model = new tb_DrugRegion();
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
        public tb_DrugRegion DataRowToModel(DataRow row)
        {
            tb_DrugRegion model = new tb_DrugRegion();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["lockId"] != null && row["lockId"].ToString() != "")
                {
                    model.lockId = int.Parse(row["lockId"].ToString());
                }
                if (row["regionName"] != null)
                {
                    model.regionName = row["regionName"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,lockId,regionName,createUser,createDate,updateUser,updateDate ");
            strSql.Append(" FROM tb_DrugRegion ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by regionName");
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
            strSql.Append(" id,lockId,regionName,createUser,createDate,updateUser,updateDate ");
            strSql.Append(" FROM tb_DrugRegion ");
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
            strSql.Append("select count(1) FROM tb_DrugRegion ");
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
            strSql.Append(@")AS Row, T.*  from (SELECT dbo.tb_DrugRegion.regionName,dbo.tb_Drug.drugName,tb_DrugRegion.lockId, 
                                  dbo.tb_DrugRegion.id AS regionId, dbo.tb_Base.baseName as danwei, dbo.tb_DrugIN.*
                                  FROM dbo.tb_DrugIN INNER JOIN
                                  dbo.tb_DrugRegion ON dbo.tb_DrugIN.GPS = dbo.tb_DrugRegion.id INNER JOIN
                                  dbo.tb_DrugLock ON dbo.tb_DrugRegion.lockId = dbo.tb_DrugLock.id INNER JOIN
                                  dbo.tb_Drug ON dbo.tb_DrugIN.drugId = dbo.tb_Drug.id INNER JOIN
                                  dbo.tb_Base ON dbo.tb_Drug.unit = dbo.tb_Base.id) T ");
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
            parameters[0].Value = "tb_DrugRegion";
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
        public int GetListCount(string where)
        {
            string strSql = @"SELECT dbo.tb_DrugRegion.regionName, dbo.tb_DrugRegion.id AS regionId, 
                                          dbo.tb_DrugIN.*
                                          FROM dbo.tb_DrugIN INNER JOIN
                                          dbo.tb_DrugRegion ON dbo.tb_DrugIN.GPS = dbo.tb_DrugRegion.id INNER JOIN
                                          dbo.tb_DrugLock ON dbo.tb_DrugRegion.lockId = dbo.tb_DrugLock.id";
            return DbHelperSQL.Query(strSql).Tables[0].Rows.Count;
        }
        #endregion  ExtensionMethod
    }
}
