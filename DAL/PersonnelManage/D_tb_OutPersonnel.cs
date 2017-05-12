using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.PersonnelManage;

namespace DAL.PersonnelManage
{
    /// <summary>
    /// 数据访问类:D_tb_OutPersonnel
    /// </summary>
    public partial class D_tb_OutPersonnel
    {
        public D_tb_OutPersonnel()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PersonnelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_OutPersonnel");
            strSql.Append(" where PersonnelID=@PersonnelID");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelID", SqlDbType.Int,4)
};
            parameters[0].Value = PersonnelID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_OutPersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_OutPersonnel(");
            strSql.Append("PersonnelName,Department,Sex,Reason,StartTime,EndTime,Remark,Tel,AreaID,EditPersonnelID,work_type)");
            strSql.Append(" values (");
            strSql.Append("@PersonnelName,@Department,@Sex,@Reason,@StartTime,@EndTime,@Remark,@Tel,@AreaID,@EditPersonnelID,@work_type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelName", SqlDbType.NVarChar,50),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Reason", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@work_type", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.PersonnelName;
            parameters[1].Value = model.Department;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Reason;
            parameters[4].Value = model.StartTime;
            parameters[5].Value = model.EndTime;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.Tel;
            parameters[8].Value = model.AreaID;
            parameters[9].Value = model.EditPersonnelID;
            parameters[10].Value = model.Work_type;
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
        public bool Update(E_tb_OutPersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_OutPersonnel set ");
            strSql.Append("PersonnelName=@PersonnelName,");
            strSql.Append("Department=@Department,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Reason=@Reason,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID,");
            strSql.Append("work_type=@work_type");
            strSql.Append(" where PersonnelID=@PersonnelID");

            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelName", SqlDbType.NVarChar,50),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Reason", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
                    new SqlParameter("@work_type", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonnelID", SqlDbType.Int,4)
                    };
            parameters[0].Value = model.PersonnelName;
            parameters[1].Value = model.Department;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Reason;
            parameters[4].Value = model.StartTime;
            parameters[5].Value = model.EndTime;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.Tel;
            parameters[8].Value = model.AreaID;
            parameters[9].Value = model.EditPersonnelID;
            parameters[10].Value = model.Work_type;
            parameters[11].Value = model.PersonnelID;
            

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
        public bool Delete(int PersonnelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_OutPersonnel ");
            strSql.Append(" where PersonnelID=@PersonnelID");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelID", SqlDbType.Int,4)
};
            parameters[0].Value = PersonnelID;

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
        public bool DeleteList(string PersonnelIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_OutPersonnel ");
            strSql.Append(" where PersonnelID in (" + PersonnelIDlist + ")  ");
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
        public E_tb_OutPersonnel GetModel(int PersonnelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_OutPersonnel ");
            strSql.Append(" where PersonnelID=@PersonnelID");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelID", SqlDbType.Int,4)
};
            parameters[0].Value = PersonnelID;

            E_tb_OutPersonnel model = new E_tb_OutPersonnel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PersonnelID"].ToString() != "")
                {
                    model.PersonnelID = int.Parse(ds.Tables[0].Rows[0]["PersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PersonnelName"] != null)
                {
                    model.PersonnelName = ds.Tables[0].Rows[0]["PersonnelName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Department"] != null)
                {
                    model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null)
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Reason"] != null)
                {
                    model.Reason = ds.Tables[0].Rows[0]["Reason"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null)
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tel"] != null)
                {
                    model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditPersonnelID"].ToString() != "")
                {
                    model.EditPersonnelID = int.Parse(ds.Tables[0].Rows[0]["EditPersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["work_type"].ToString() != "")
                {
                    model.Work_type = ds.Tables[0].Rows[0]["work_type"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM tb_OutPersonnel ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM tb_OutPersonnel ");
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
            parameters[0].Value = "tb_OutPersonnel";
            parameters[1].Value = "PersonnelID";
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
                strSql.Append("order by T.PersonnelID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_OutPersonnel T ");
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
