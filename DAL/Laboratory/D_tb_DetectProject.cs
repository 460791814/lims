using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.Laboratory;

namespace DAL.Laboratory
{
    /// <summary>
    /// 数据访问类:D_tb_DetectProject
    /// </summary>
    public partial class D_tb_DetectProject
    {
        public D_tb_DetectProject()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ProjectID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DetectProject");
            strSql.Append(" where ProjectID=@ProjectID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4)
};
            parameters[0].Value = ProjectID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_DetectProject model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DetectProject(");
            strSql.Append("LaboratoryID,RelationProjectID,TaskNo,ProjectName,DetectTime,HeadPersonnelID,MainPerson,Tel,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@LaboratoryID,@RelationProjectID,@TaskNo,@ProjectName,@DetectTime,@HeadPersonnelID,@MainPerson,@Tel,@UpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LaboratoryID", SqlDbType.Int,4),
					new SqlParameter("@RelationProjectID", SqlDbType.Int,4),
					new SqlParameter("@TaskNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,50),
					new SqlParameter("@DetectTime", SqlDbType.DateTime),
					new SqlParameter("@HeadPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@MainPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.LaboratoryID;
            parameters[1].Value = model.RelationProjectID;
            parameters[2].Value = model.TaskNo;
            parameters[3].Value = model.ProjectName;
            parameters[4].Value = model.DetectTime;
            parameters[5].Value = model.HeadPersonnelID;
            parameters[6].Value = model.MainPerson;
            parameters[7].Value = model.Tel;
            parameters[8].Value = model.UpdateTime;

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
        public bool Update(E_tb_DetectProject model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DetectProject set ");
            strSql.Append("LaboratoryID=@LaboratoryID,");
            strSql.Append("RelationProjectID=@RelationProjectID,");
            strSql.Append("TaskNo=@TaskNo,");
            strSql.Append("ProjectName=@ProjectName,");
            strSql.Append("DetectTime=@DetectTime,");
            strSql.Append("HeadPersonnelID=@HeadPersonnelID,");
            strSql.Append("MainPerson=@MainPerson,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where ProjectID=@ProjectID");
            SqlParameter[] parameters = {
					new SqlParameter("@LaboratoryID", SqlDbType.Int,4),
					new SqlParameter("@RelationProjectID", SqlDbType.Int,4),
					new SqlParameter("@TaskNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,50),
					new SqlParameter("@DetectTime", SqlDbType.DateTime),
					new SqlParameter("@HeadPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@MainPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ProjectID", SqlDbType.Int,4)};
            parameters[0].Value = model.LaboratoryID;
            parameters[1].Value = model.RelationProjectID;
            parameters[2].Value = model.TaskNo;
            parameters[3].Value = model.ProjectName;
            parameters[4].Value = model.DetectTime;
            parameters[5].Value = model.HeadPersonnelID;
            parameters[6].Value = model.MainPerson;
            parameters[7].Value = model.Tel;
            parameters[8].Value = model.UpdateTime;
            parameters[9].Value = model.ProjectID;

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
        public bool Delete(int ProjectID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_DetectProject ");
            strSql.Append(" where ProjectID=@ProjectID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4)
};
            parameters[0].Value = ProjectID;

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
        public bool DeleteList(string ProjectIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_DetectProject ");
            strSql.Append(" where ProjectID in (" + ProjectIDlist + ")  ");
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
        public E_tb_DetectProject GetModel(int ProjectID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProjectID,LaboratoryID,RelationProjectID,TaskNo,ProjectName,DetectTime,HeadPersonnelID,MainPerson,Tel,UpdateTime from tb_DetectProject ");
            strSql.Append(" where ProjectID=@ProjectID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4)
};
            parameters[0].Value = ProjectID;

            E_tb_DetectProject model = new E_tb_DetectProject();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProjectID"].ToString() != "")
                {
                    model.ProjectID = int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LaboratoryID"].ToString() != "")
                {
                    model.LaboratoryID = int.Parse(ds.Tables[0].Rows[0]["LaboratoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RelationProjectID"].ToString() != "")
                {
                    model.RelationProjectID = int.Parse(ds.Tables[0].Rows[0]["RelationProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TaskNo"] != null)
                {
                    model.TaskNo = ds.Tables[0].Rows[0]["TaskNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProjectName"] != null)
                {
                    model.ProjectName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DetectTime"].ToString() != "")
                {
                    model.DetectTime = DateTime.Parse(ds.Tables[0].Rows[0]["DetectTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HeadPersonnelID"].ToString() != "")
                {
                    model.HeadPersonnelID = int.Parse(ds.Tables[0].Rows[0]["HeadPersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MainPerson"] != null)
                {
                    model.MainPerson = ds.Tables[0].Rows[0]["MainPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tel"] != null)
                {
                    model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
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
            strSql.Append("select ProjectID,LaboratoryID,RelationProjectID,TaskNo,ProjectName,DetectTime,HeadPersonnelID,MainPerson,Tel,UpdateTime ");
            strSql.Append(" FROM tb_DetectProject ");
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
            strSql.Append(" ProjectID,LaboratoryID,RelationProjectID,TaskNo,ProjectName,DetectTime,HeadPersonnelID,MainPerson,Tel,UpdateTime ");
            strSql.Append(" FROM tb_DetectProject ");
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
            parameters[0].Value = "tb_DetectProject";
            parameters[1].Value = "ProjectID";
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
                strSql.Append("order by T.ProjectID desc");
            }
            strSql.Append(")AS Row, T.*,B.ExpeType,case when C.PlanTypeID=1 then '计划内' else '计划外' end as PlanType ");
            strSql.Append("from tb_DetectProject T left join tb_Project as B on T.RelationProjectID=B.ProjectID ");
            strSql.Append("left join tb_ExpePlan as C on T.RelationProjectID=C.ProjectID and T.TaskNo=C.TaskNo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            total = DbHelperSQL.GetCount(strSql.ToString());
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }



        public DataSet GetListByReport(string strWhere, string orderby, int startIndex, int endIndex, ref int total)
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
                strSql.Append("order by T.DetectTime desc");
            }
            strSql.Append(@")AS Row,  T.*");
            strSql.Append(@"from (SELECT     dbo.tb_Sample.name, dbo.tb_Project.ProjectName, count(dbo.tb_TestReportData.QualifiedLevel) as QualifiedLevel, dbo.tb_TestReportData.TestPersonnelName, 
                      dbo.tb_OriginalRecord.DetectTime,dbo.tb_TestReport.Department,dbo.tb_Area.TestReportName as GHS 
FROM         dbo.tb_Sample INNER JOIN
                      dbo.tb_OriginalRecord ON dbo.tb_Sample.id = dbo.tb_OriginalRecord.SampleID INNER JOIN
                      dbo.tb_Project ON dbo.tb_OriginalRecord.ProjectID = dbo.tb_Project.ProjectID INNER JOIN
                      dbo.tb_TestReportData ON dbo.tb_OriginalRecord.RecordID = dbo.tb_TestReportData.RecordID
                      INNER JOIN dbo.tb_TestReport ON dbo.tb_TestReport.ReportID = dbo.tb_TestReportData.ReportID
                      INNER JOIN dbo.tb_Area ON dbo.tb_Area.AreaId = dbo.tb_TestReport.AreaId   
                      group by dbo.tb_Sample.name, dbo.tb_Project.ProjectName, dbo.tb_TestReportData.TestPersonnelName, 
                      dbo.tb_OriginalRecord.DetectTime,dbo.tb_TestReport.Department,dbo.tb_Area.TestReportName) T ");
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



        public int GetListCountForReport(DataRow dr,string isPass)
        {
            int count = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT     dbo.tb_Sample.name, dbo.tb_Project.ProjectName, dbo.tb_TestReportData.QualifiedLevel, dbo.tb_TestReportData.TestPersonnelName, 
                      dbo.tb_OriginalRecord.DetectTime
FROM         dbo.tb_Sample INNER JOIN
                      dbo.tb_OriginalRecord ON dbo.tb_Sample.id = dbo.tb_OriginalRecord.SampleID INNER JOIN
                      dbo.tb_Project ON dbo.tb_OriginalRecord.ProjectID = dbo.tb_Project.ProjectID INNER JOIN
                      dbo.tb_TestReportData ON dbo.tb_OriginalRecord.RecordID = dbo.tb_TestReportData.RecordID
                       ");
            strSql.Append(" where tb_Sample.name = '" + dr["name"] + "' ");
            strSql.Append(" and tb_Project.ProjectName = '" + dr["ProjectName"] + "' ");
            strSql.Append(" and tb_TestReportData.TestPersonnelName = '" + dr["TestPersonnelName"] + "' ");
            strSql.Append(" and tb_OriginalRecord.DetectTime = '" + dr["DetectTime"] + "' ");
            if (!string.IsNullOrEmpty(isPass))
            {
                strSql.Append(" and tb_TestReportData.QualifiedLevel = '合格' ");
            }
            else
            {
                strSql.Append(" and tb_TestReportData.QualifiedLevel <> '合格' ");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                count = ds.Tables[0].Rows.Count;
            }
            return count;
        }


        public int GetAllListCountForReport(string strWhere, string isPass)
        {
            int count = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT    count(dbo.tb_TestReportData.QualifiedLevel) as QualifiedLevel 
                        FROM         dbo.tb_Sample INNER JOIN
                      dbo.tb_OriginalRecord ON dbo.tb_Sample.id = dbo.tb_OriginalRecord.SampleID INNER JOIN
                      dbo.tb_Project ON dbo.tb_OriginalRecord.ProjectID = dbo.tb_Project.ProjectID INNER JOIN
                      dbo.tb_TestReportData ON dbo.tb_OriginalRecord.RecordID = dbo.tb_TestReportData.RecordID
                        INNER JOIN dbo.tb_TestReport ON dbo.tb_TestReport.ReportID = dbo.tb_TestReportData.ReportID
                       ");
            strSql.Append(" where "+strWhere+" ");
            if (isPass=="1")
            {
                strSql.Append(" and tb_TestReportData.QualifiedLevel = '合格' ");
            }
            else if (isPass == "2")
            {
                strSql.Append(" and tb_TestReportData.QualifiedLevel <> '合格' ");
            }
            strSql.Append("group by dbo.tb_Sample.name, dbo.tb_Project.ProjectName, dbo.tb_TestReportData.TestPersonnelName, dbo.tb_OriginalRecord.DetectTime,dbo.tb_TestReport.Department");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                count = int.Parse(ds.Tables[0].Compute("sum(QualifiedLevel)", "").ToString());
            }
            return count;
        }

        public DataSet GetExportListByReport(string strWhere, string orderby)
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
                strSql.Append("order by T.DetectTime desc");
            }
            strSql.Append(@")AS Row,  T.*");
            strSql.Append(@"from (SELECT     dbo.tb_Sample.name, dbo.tb_Project.ProjectName, count(dbo.tb_TestReportData.QualifiedLevel) as QualifiedLevel, dbo.tb_TestReportData.TestPersonnelName, 
                      dbo.tb_OriginalRecord.DetectTime,dbo.tb_TestReport.Department,dbo.tb_Area.TestReportName as GHS 
FROM         dbo.tb_Sample INNER JOIN
                      dbo.tb_OriginalRecord ON dbo.tb_Sample.id = dbo.tb_OriginalRecord.SampleID INNER JOIN
                      dbo.tb_Project ON dbo.tb_OriginalRecord.ProjectID = dbo.tb_Project.ProjectID INNER JOIN
                      dbo.tb_TestReportData ON dbo.tb_OriginalRecord.RecordID = dbo.tb_TestReportData.RecordID
                      INNER JOIN dbo.tb_TestReport ON dbo.tb_TestReport.ReportID = dbo.tb_TestReportData.ReportID
                        INNER JOIN dbo.tb_Area ON dbo.tb_Area.AreaId = dbo.tb_TestReport.AreaId 
                      group by dbo.tb_Sample.name, dbo.tb_Project.ProjectName, dbo.tb_TestReportData.TestPersonnelName, 
                      dbo.tb_OriginalRecord.DetectTime,dbo.tb_TestReport.Department,dbo.tb_Area.TestReportName) T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
