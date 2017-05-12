using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.DictManage;

namespace DAL.DictManage
{
    /// <summary>
	/// 数据访问类:tb_TypeDict
	/// </summary>
	public partial class D_tb_TypeDict
	{
		public D_tb_TypeDict()
		{}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TypeDict");
            strSql.Append(" where TypeID=@TypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4)
};
            parameters[0].Value = TypeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_TypeDict model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TypeDict(");
            strSql.Append("SubjectID,TypeName,ParentID,TypeLevel,Directions)");
            strSql.Append(" values (");
            strSql.Append("@SubjectID,@TypeName,@ParentID,@TypeLevel,@Directions)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SubjectID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@TypeLevel", SqlDbType.Int,4),
					new SqlParameter("@Directions", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.SubjectID;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.TypeLevel;
            parameters[4].Value = model.Directions;

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
        public bool Update(E_tb_TypeDict model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TypeDict set ");
            strSql.Append("SubjectID=@SubjectID,");
            strSql.Append("TypeName=@TypeName,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("TypeLevel=@TypeLevel,");
            strSql.Append("Directions=@Directions");
            strSql.Append(" where TypeID=@TypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@SubjectID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@TypeLevel", SqlDbType.Int,4),
					new SqlParameter("@Directions", SqlDbType.NVarChar,200),
					new SqlParameter("@TypeID", SqlDbType.Int,4)};
            parameters[0].Value = model.SubjectID;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.TypeLevel;
            parameters[4].Value = model.Directions;
            parameters[5].Value = model.TypeID;

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
        public bool Delete(int TypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TypeDict ");
            strSql.Append(" where TypeID=@TypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4)
};
            parameters[0].Value = TypeID;

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
        public bool DeleteList(string TypeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TypeDict ");
            strSql.Append(" where TypeID in (" + TypeIDlist + ")  ");
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
        public E_tb_TypeDict GetModel(int TypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TypeID,SubjectID,TypeName,ParentID,TypeLevel,Directions from tb_TypeDict ");
            strSql.Append(" where TypeID=@TypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4)
};
            parameters[0].Value = TypeID;

            E_tb_TypeDict model = new E_tb_TypeDict();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SubjectID"].ToString() != "")
                {
                    model.SubjectID = int.Parse(ds.Tables[0].Rows[0]["SubjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeName"] != null)
                {
                    model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeLevel"].ToString() != "")
                {
                    model.TypeLevel = int.Parse(ds.Tables[0].Rows[0]["TypeLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Directions"] != null)
                {
                    model.Directions = ds.Tables[0].Rows[0]["Directions"].ToString();
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
            strSql.Append("select TypeID,SubjectID,TypeName,ParentID,TypeLevel,Directions ");
            strSql.Append(" FROM tb_TypeDict ");
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
            strSql.Append(" TypeID,SubjectID,TypeName,ParentID,TypeLevel,Directions ");
            strSql.Append(" FROM tb_TypeDict ");
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
            parameters[0].Value = "tb_TypeDict";
            parameters[1].Value = "TypeID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
	}
}
