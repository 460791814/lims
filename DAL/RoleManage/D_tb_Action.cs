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
    /// 数据访问类:D_tb_Action
    /// </summary>
    public partial class D_tb_Action
    {
        public D_tb_Action()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ActionID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Action");
            strSql.Append(" where ActionID=@ActionID");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionID", SqlDbType.Int,4)
};
            parameters[0].Value = ActionID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_Action model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Action(");
            strSql.Append("ParentID,ActionName,ActionCode,RequestType,RequestURL,ActionType)");
            strSql.Append(" values (");
            strSql.Append("@ParentID,@ActionName,@ActionCode,@RequestType,@RequestURL,@ActionType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ActionName", SqlDbType.NVarChar,50),
					new SqlParameter("@ActionCode", SqlDbType.NVarChar,50),
					new SqlParameter("@RequestType", SqlDbType.NVarChar,50),
					new SqlParameter("@RequestURL", SqlDbType.NVarChar,50),
					new SqlParameter("@ActionType", SqlDbType.Int,4)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.ActionName;
            parameters[2].Value = model.ActionCode;
            parameters[3].Value = model.RequestType;
            parameters[4].Value = model.RequestURL;
            parameters[5].Value = model.ActionType;

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
        public bool Update(E_tb_Action model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Action set ");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("ActionName=@ActionName,");
            strSql.Append("ActionCode=@ActionCode,");
            strSql.Append("RequestType=@RequestType,");
            strSql.Append("RequestURL=@RequestURL,");
            strSql.Append("ActionType=@ActionType");
            strSql.Append(" where ActionID=@ActionID");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@ActionName", SqlDbType.NVarChar,50),
					new SqlParameter("@ActionCode", SqlDbType.NVarChar,50),
					new SqlParameter("@RequestType", SqlDbType.NVarChar,50),
					new SqlParameter("@RequestURL", SqlDbType.NVarChar,50),
					new SqlParameter("@ActionType", SqlDbType.Int,4),
					new SqlParameter("@ActionID", SqlDbType.Int,4)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.ActionName;
            parameters[2].Value = model.ActionCode;
            parameters[3].Value = model.RequestType;
            parameters[4].Value = model.RequestURL;
            parameters[5].Value = model.ActionType;
            parameters[6].Value = model.ActionID;

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
        public bool Delete(int ActionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Action ");
            strSql.Append(" where ActionID=@ActionID");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionID", SqlDbType.Int,4)
};
            parameters[0].Value = ActionID;

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
        public bool DeleteList(string ActionIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Action ");
            strSql.Append(" where ActionID in (" + ActionIDlist + ")  ");
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
        public E_tb_Action GetModel(int ActionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ActionID,ParentID,ActionName,ActionCode,RequestType,RequestURL,ActionType from tb_Action ");
            strSql.Append(" where ActionID=@ActionID");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionID", SqlDbType.Int,4)
};
            parameters[0].Value = ActionID;

            E_tb_Action model = new E_tb_Action();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ActionID"].ToString() != "")
                {
                    model.ActionID = int.Parse(ds.Tables[0].Rows[0]["ActionID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ActionName"] != null)
                {
                    model.ActionName = ds.Tables[0].Rows[0]["ActionName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ActionCode"] != null)
                {
                    model.ActionCode = ds.Tables[0].Rows[0]["ActionCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RequestType"] != null)
                {
                    model.RequestType = ds.Tables[0].Rows[0]["RequestType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RequestURL"] != null)
                {
                    model.RequestURL = ds.Tables[0].Rows[0]["RequestURL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ActionType"].ToString() != "")
                {
                    model.ActionType = int.Parse(ds.Tables[0].Rows[0]["ActionType"].ToString());
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
            strSql.Append("select ActionID,ParentID,ActionName,ActionCode,RequestType,RequestURL,ActionType ");
            strSql.Append(" FROM tb_Action ");
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
            strSql.Append(" ActionID,ParentID,ActionName,ActionCode,RequestType,RequestURL,ActionType ");
            strSql.Append(" FROM tb_Action ");
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
            parameters[0].Value = "tb_Action";
            parameters[1].Value = "ActionID";
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
                strSql.Append("order by T.ActionID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_Action T ");
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
