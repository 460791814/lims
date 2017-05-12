using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.TestReport;

namespace DAL.TestReport
{
    /// <summary>
    /// 数据访问类:tb_TestReportData
    /// </summary>
    public partial class D_tb_TestReportData
    {
        public D_tb_TestReportData()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ReportDataID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestReportData");
            strSql.Append(" where ReportDataID=@ReportDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@ReportDataID", SqlDbType.Int,4)
};
            parameters[0].Value = ReportDataID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_TestReportData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TestReportData(");
            strSql.Append("RecordID,RecordFilePath,ReportID,TestName,TestStandard,TestResult,QualifiedLevel,TestPersonnelName)");
            strSql.Append(" values (");
            strSql.Append("@RecordID,@RecordFilePath,@ReportID,@TestName,@TestStandard,@TestResult,@QualifiedLevel,@TestPersonnelName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4),
					new SqlParameter("@RecordFilePath", SqlDbType.NVarChar,150),
					new SqlParameter("@ReportID", SqlDbType.Int,4),
					new SqlParameter("@TestName", SqlDbType.NVarChar,50),
					new SqlParameter("@TestStandard", SqlDbType.NVarChar,50),
					new SqlParameter("@TestResult", SqlDbType.NVarChar,200),
					new SqlParameter("@QualifiedLevel", SqlDbType.NVarChar,50),
					new SqlParameter("@TestPersonnelName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.RecordID;
            parameters[1].Value = model.RecordFilePath;
            parameters[2].Value = model.ReportID;
            parameters[3].Value = model.TestName;
            parameters[4].Value = model.TestStandard;
            parameters[5].Value = model.TestResult;
            parameters[6].Value = model.QualifiedLevel;
            parameters[7].Value = model.TestPersonnelName;

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
        public bool Update(E_tb_TestReportData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TestReportData set ");
            strSql.Append("RecordID=@RecordID,");
            strSql.Append("RecordFilePath=@RecordFilePath,");
            strSql.Append("ReportID=@ReportID,");
            strSql.Append("TestName=@TestName,");
            strSql.Append("TestStandard=@TestStandard,");
            strSql.Append("TestResult=@TestResult,");
            strSql.Append("QualifiedLevel=@QualifiedLevel,");
            strSql.Append("TestPersonnelName=@TestPersonnelName");
            strSql.Append(" where ReportDataID=@ReportDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4),
					new SqlParameter("@RecordFilePath", SqlDbType.NVarChar,150),
					new SqlParameter("@ReportID", SqlDbType.Int,4),
					new SqlParameter("@TestName", SqlDbType.NVarChar,50),
					new SqlParameter("@TestStandard", SqlDbType.NVarChar,50),
					new SqlParameter("@TestResult", SqlDbType.NVarChar,200),
					new SqlParameter("@QualifiedLevel", SqlDbType.NVarChar,50),
					new SqlParameter("@TestPersonnelName", SqlDbType.NVarChar,50),
					new SqlParameter("@ReportDataID", SqlDbType.Int,4)};
            parameters[0].Value = model.RecordID;
            parameters[1].Value = model.RecordFilePath;
            parameters[2].Value = model.ReportID;
            parameters[3].Value = model.TestName;
            parameters[4].Value = model.TestStandard;
            parameters[5].Value = model.TestResult;
            parameters[6].Value = model.QualifiedLevel;
            parameters[7].Value = model.TestPersonnelName;
            parameters[8].Value = model.ReportDataID;

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
        public bool Delete(int ReportDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestReportData ");
            strSql.Append(" where ReportDataID=@ReportDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@ReportDataID", SqlDbType.Int,4)
};
            parameters[0].Value = ReportDataID;

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
        public bool DeleteList(string ReportDataIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestReportData ");
            strSql.Append(" where ReportDataID in (" + ReportDataIDlist + ")  ");
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
        public E_tb_TestReportData GetModel(int ReportDataID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ReportDataID,RecordID,RecordFilePath,ReportID,TestName,TestStandard,TestResult,QualifiedLevel,TestPersonnelName from tb_TestReportData ");
            strSql.Append(" where ReportDataID=@ReportDataID");
            SqlParameter[] parameters = {
					new SqlParameter("@ReportDataID", SqlDbType.Int,4)
};
            parameters[0].Value = ReportDataID;

            E_tb_TestReportData model = new E_tb_TestReportData();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ReportDataID"].ToString() != "")
                {
                    model.ReportDataID = int.Parse(ds.Tables[0].Rows[0]["ReportDataID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordID"].ToString() != "")
                {
                    model.RecordID = int.Parse(ds.Tables[0].Rows[0]["RecordID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordFilePath"] != null)
                {
                    model.RecordFilePath = ds.Tables[0].Rows[0]["RecordFilePath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReportID"].ToString() != "")
                {
                    model.ReportID = int.Parse(ds.Tables[0].Rows[0]["ReportID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TestName"] != null)
                {
                    model.TestName = ds.Tables[0].Rows[0]["TestName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TestStandard"] != null)
                {
                    model.TestStandard = ds.Tables[0].Rows[0]["TestStandard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TestResult"] != null)
                {
                    model.TestResult = ds.Tables[0].Rows[0]["TestResult"].ToString();
                }
                if (ds.Tables[0].Rows[0]["QualifiedLevel"] != null)
                {
                    model.QualifiedLevel = ds.Tables[0].Rows[0]["QualifiedLevel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TestPersonnelName"] != null)
                {
                    model.TestPersonnelName = ds.Tables[0].Rows[0]["TestPersonnelName"].ToString();
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
            strSql.Append("select ReportDataID,RecordID,RecordFilePath,ReportID,TestName,TestStandard,TestResult,QualifiedLevel,TestPersonnelName ");
            strSql.Append(" FROM tb_TestReportData ");
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
            strSql.Append(" ReportDataID,RecordID,RecordFilePath,ReportID,TestName,TestStandard,TestResult,QualifiedLevel,TestPersonnelName ");
            strSql.Append(" FROM tb_TestReportData ");
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
            parameters[0].Value = "tb_TestReportData";
            parameters[1].Value = "ReportDataID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method


        #region 扩展方法
        /// <summary>
        /// 批量删除
        /// </summary>
        public bool DeleteByWhere(string StrWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestReportData ");
            if (StrWhere.Length > 0)
            {
                strSql.Append(" where " + StrWhere);
            }
            
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
