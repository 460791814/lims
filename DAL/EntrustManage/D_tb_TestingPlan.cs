using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.EntrustManage;

namespace DAL.EntrustManage
{
    /// <summary>
    /// 数据访问类:tb_TestingPlan
    /// </summary>
    public partial class D_tb_TestingPlan
    {
        public D_tb_TestingPlan()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TestID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestingPlan");
            strSql.Append(" where TestID=@TestID");
            SqlParameter[] parameters = {
					new SqlParameter("@TestID", SqlDbType.Int,4)
};
            parameters[0].Value = TestID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_TestingPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TestingPlan(");
            strSql.Append("PlanName,Version,ControlledNum,Department,WeavePersonnel,WeaveTime,Remark,FilePath,AreaID,EditPersonnelID)");
            strSql.Append(" values (");
            strSql.Append("@PlanName,@Version,@ControlledNum,@Department,@WeavePersonnel,@WeaveTime,@Remark,@FilePath,@AreaID,@EditPersonnelID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PlanName", SqlDbType.NVarChar,50),
					new SqlParameter("@Version", SqlDbType.NVarChar,50),
					new SqlParameter("@ControlledNum", SqlDbType.NVarChar,50),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@WeavePersonnel", SqlDbType.NVarChar,50),
					new SqlParameter("@WeaveTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4)};
            parameters[0].Value = model.PlanName;
            parameters[1].Value = model.Version;
            parameters[2].Value = model.ControlledNum;
            parameters[3].Value = model.Department;
            parameters[4].Value = model.WeavePersonnel;
            parameters[5].Value = model.WeaveTime;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.FilePath;
            parameters[8].Value = model.AreaID;
            parameters[9].Value = model.EditPersonnelID;

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
        public bool Update(E_tb_TestingPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TestingPlan set ");
            strSql.Append("PlanName=@PlanName,");
            strSql.Append("Version=@Version,");
            strSql.Append("ControlledNum=@ControlledNum,");
            strSql.Append("Department=@Department,");
            strSql.Append("WeavePersonnel=@WeavePersonnel,");
            strSql.Append("WeaveTime=@WeaveTime,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("FilePath=@FilePath,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID");
            strSql.Append(" where TestID=@TestID");
            SqlParameter[] parameters = {
					new SqlParameter("@PlanName", SqlDbType.NVarChar,50),
					new SqlParameter("@Version", SqlDbType.NVarChar,50),
					new SqlParameter("@ControlledNum", SqlDbType.NVarChar,50),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@WeavePersonnel", SqlDbType.NVarChar,50),
					new SqlParameter("@WeaveTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@TestID", SqlDbType.Int,4)};
            parameters[0].Value = model.PlanName;
            parameters[1].Value = model.Version;
            parameters[2].Value = model.ControlledNum;
            parameters[3].Value = model.Department;
            parameters[4].Value = model.WeavePersonnel;
            parameters[5].Value = model.WeaveTime;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.FilePath;
            parameters[8].Value = model.AreaID;
            parameters[9].Value = model.EditPersonnelID;
            parameters[10].Value = model.TestID;

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
        public bool Delete(int TestID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestingPlan ");
            strSql.Append(" where TestID=@TestID");
            SqlParameter[] parameters = {
					new SqlParameter("@TestID", SqlDbType.Int,4)
};
            parameters[0].Value = TestID;

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
        public bool DeleteList(string TestIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestingPlan ");
            strSql.Append(" where TestID in (" + TestIDlist + ")  ");
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
        public E_tb_TestingPlan GetModel(int TestID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TestID,PlanName,Version,ControlledNum,Department,WeavePersonnel,WeaveTime,Remark,FilePath,AreaID,EditPersonnelID from tb_TestingPlan ");
            strSql.Append(" where TestID=@TestID");
            SqlParameter[] parameters = {
					new SqlParameter("@TestID", SqlDbType.Int,4)
};
            parameters[0].Value = TestID;

            E_tb_TestingPlan model = new E_tb_TestingPlan();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TestID"].ToString() != "")
                {
                    model.TestID = int.Parse(ds.Tables[0].Rows[0]["TestID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlanName"] != null)
                {
                    model.PlanName = ds.Tables[0].Rows[0]["PlanName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Version"] != null)
                {
                    model.Version = ds.Tables[0].Rows[0]["Version"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ControlledNum"] != null)
                {
                    model.ControlledNum = ds.Tables[0].Rows[0]["ControlledNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Department"] != null)
                {
                    model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WeavePersonnel"] != null)
                {
                    model.WeavePersonnel = ds.Tables[0].Rows[0]["WeavePersonnel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WeaveTime"].ToString() != "")
                {
                    model.WeaveTime = DateTime.Parse(ds.Tables[0].Rows[0]["WeaveTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null)
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FilePath"] != null)
                {
                    model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditPersonnelID"].ToString() != "")
                {
                    model.EditPersonnelID = int.Parse(ds.Tables[0].Rows[0]["EditPersonnelID"].ToString());
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
            strSql.Append("select TestID,PlanName,Version,ControlledNum,Department,WeavePersonnel,WeaveTime,Remark,FilePath,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_TestingPlan ");
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
            strSql.Append(" TestID,PlanName,Version,ControlledNum,Department,WeavePersonnel,WeaveTime,Remark,FilePath,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_TestingPlan ");
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
            parameters[0].Value = "tb_TestingPlan";
            parameters[1].Value = "TestID";
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
                strSql.Append("order by T.TestID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_TestingPlan T ");
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
