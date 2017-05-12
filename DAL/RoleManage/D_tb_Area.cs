using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.RoleManage;

namespace DAL.RoleManage
{
    /// <summary>
    /// 数据访问类:D_tb_Area
    /// </summary>
    public partial class D_tb_Area
    {
        public D_tb_Area()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AreaID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Area");
            strSql.Append(" where AreaID=@AreaID");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4)
};
            parameters[0].Value = AreaID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_Area model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Area(");
            strSql.Append("TestReportName,");
            strSql.Append("AreaName)");
            strSql.Append(" values (");
            strSql.Append("@trn,");
            strSql.Append("@AreaName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaName", SqlDbType.NVarChar,50),
                    new SqlParameter("@trn", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AreaName;
            parameters[1].Value = model.TestReportName;

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
        public bool Update(E_tb_Area model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Area set ");
            strSql.Append("TestReportName=@trn,");
            strSql.Append("AreaName=@AreaName");
            strSql.Append(" where AreaID=@AreaID");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
                    new SqlParameter("@trn", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AreaName;
            parameters[1].Value = model.AreaID;
            parameters[2].Value = model.TestReportName;

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
        public bool Delete(int AreaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Area ");
            strSql.Append(" where AreaID=@AreaID");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4)
};
            parameters[0].Value = AreaID;

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
        public bool DeleteList(string AreaIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Area ");
            strSql.Append(" where AreaID in (" + AreaIDlist + ")  ");
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
        public E_tb_Area GetModel(int AreaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_Area ");
            strSql.Append(" where AreaID=@AreaID");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4)
};
            parameters[0].Value = AreaID;

            E_tb_Area model = new E_tb_Area();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AreaName"] != null)
                {
                    model.AreaName = ds.Tables[0].Rows[0]["AreaName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TestReportName"] != null)
                {
                    model.TestReportName = ds.Tables[0].Rows[0]["TestReportName"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AreaID,AreaName ");
            strSql.Append(" FROM tb_Area ");
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
            strSql.Append(" AreaID,AreaName ");
            strSql.Append(" FROM tb_Area ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            parameters[0].Value = "tb_Area";
            parameters[1].Value = "AreaID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method


        #region 数据接口
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, ref int total)
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
                strSql.Append("order by T.AreaID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Area T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            total = DbHelperSQL.GetCount(strSql.ToString());
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

    }
}
