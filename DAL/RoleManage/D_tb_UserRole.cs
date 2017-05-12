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
    /// 数据访问类:D_tb_UserRole
    /// </summary>
    public partial class D_tb_UserRole
    {
        public D_tb_UserRole()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserRoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_UserRole");
            strSql.Append(" where UserRoleID=@UserRoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserRoleID", SqlDbType.Int,4)
};
            parameters[0].Value = UserRoleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_UserRole(");
            strSql.Append("PersonnelID,RoleID)");
            strSql.Append(" values (");
            strSql.Append("@PersonnelID,@RoleID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.PersonnelID;
            parameters[1].Value = model.RoleID;

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
        public bool Update(E_tb_UserRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_UserRole set ");
            strSql.Append("PersonnelID=@PersonnelID,");
            strSql.Append("RoleID=@RoleID");
            strSql.Append(" where UserRoleID=@UserRoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@UserRoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.PersonnelID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.UserRoleID;

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
        public bool Delete(int UserRoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_UserRole ");
            strSql.Append(" where UserRoleID=@UserRoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserRoleID", SqlDbType.Int,4)
};
            parameters[0].Value = UserRoleID;

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
        public bool DeleteList(string UserRoleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_UserRole ");
            strSql.Append(" where UserRoleID in (" + UserRoleIDlist + ")  ");
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
        public E_tb_UserRole GetModel(int UserRoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserRoleID,PersonnelID,RoleID from tb_UserRole ");
            strSql.Append(" where UserRoleID=@UserRoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserRoleID", SqlDbType.Int,4)
};
            parameters[0].Value = UserRoleID;

            E_tb_UserRole model = new E_tb_UserRole();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserRoleID"].ToString() != "")
                {
                    model.UserRoleID = int.Parse(ds.Tables[0].Rows[0]["UserRoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PersonnelID"].ToString() != "")
                {
                    model.PersonnelID = int.Parse(ds.Tables[0].Rows[0]["PersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
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
            strSql.Append("select UserRoleID,PersonnelID,RoleID ");
            strSql.Append(" FROM tb_UserRole ");
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
            strSql.Append(" UserRoleID,PersonnelID,RoleID ");
            strSql.Append(" FROM tb_UserRole ");
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
            parameters[0].Value = "tb_UserRole";
            parameters[1].Value = "UserRoleID";
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
                strSql.Append("order by T.UserRoleID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_UserRole T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            total = DbHelperSQL.GetCount(strSql.ToString());
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_UserRole ");
            strSql.Append(" where " + strWhere);
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
        #endregion
    }
}
