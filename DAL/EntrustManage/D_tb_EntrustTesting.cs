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
    /// 数据访问类:D_tb_EntrustTesting
    /// </summary>
    public partial class D_tb_EntrustTesting
    {
        public D_tb_EntrustTesting()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int EntrustID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_EntrustTesting");
            strSql.Append(" where EntrustID=@EntrustID");
            SqlParameter[] parameters = {
					new SqlParameter("@EntrustID", SqlDbType.Int,4)
};
            parameters[0].Value = EntrustID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_EntrustTesting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_EntrustTesting(");
            strSql.Append("TaskNo,EntrustCompany,SampleID,ProjectID,TestPersonnelID,SubmissionTime,ReportID,IsComplete,AreaID,EditPersonnelID)");
            strSql.Append(" values (");
            strSql.Append("@TaskNo,@EntrustCompany,@SampleID,@ProjectID,@TestPersonnelID,@SubmissionTime,@ReportID,@IsComplete,@AreaID,@EditPersonnelID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TaskNo", SqlDbType.NVarChar,50),
					new SqlParameter("@EntrustCompany", SqlDbType.NVarChar,50),
					new SqlParameter("@SampleID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@TestPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@SubmissionTime", SqlDbType.DateTime),
					new SqlParameter("@ReportID", SqlDbType.Int,4),
					new SqlParameter("@IsComplete", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4)};
            parameters[0].Value = model.TaskNo;
            parameters[1].Value = model.EntrustCompany;
            parameters[2].Value = model.SampleID;
            parameters[3].Value = model.ProjectID;
            parameters[4].Value = model.TestPersonnelID;
            parameters[5].Value = model.SubmissionTime;
            parameters[6].Value = model.ReportID;
            parameters[7].Value = model.IsComplete;
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
        public bool Update(E_tb_EntrustTesting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_EntrustTesting set ");
            strSql.Append("TaskNo=@TaskNo,");
            strSql.Append("EntrustCompany=@EntrustCompany,");
            strSql.Append("SampleID=@SampleID,");
            strSql.Append("ProjectID=@ProjectID,");
            strSql.Append("TestPersonnelID=@TestPersonnelID,");
            strSql.Append("SubmissionTime=@SubmissionTime,");
            strSql.Append("ReportID=@ReportID,");
            strSql.Append("IsComplete=@IsComplete,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID");
            strSql.Append(" where EntrustID=@EntrustID");
            SqlParameter[] parameters = {
					new SqlParameter("@TaskNo", SqlDbType.NVarChar,50),
					new SqlParameter("@EntrustCompany", SqlDbType.NVarChar,50),
					new SqlParameter("@SampleID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@TestPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@SubmissionTime", SqlDbType.DateTime),
					new SqlParameter("@ReportID", SqlDbType.Int,4),
					new SqlParameter("@IsComplete", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@EntrustID", SqlDbType.Int,4)};
            parameters[0].Value = model.TaskNo;
            parameters[1].Value = model.EntrustCompany;
            parameters[2].Value = model.SampleID;
            parameters[3].Value = model.ProjectID;
            parameters[4].Value = model.TestPersonnelID;
            parameters[5].Value = model.SubmissionTime;
            parameters[6].Value = model.ReportID;
            parameters[7].Value = model.IsComplete;
            parameters[8].Value = model.AreaID;
            parameters[9].Value = model.EditPersonnelID;
            parameters[10].Value = model.EntrustID;

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
        public bool Delete(int EntrustID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_EntrustTesting ");
            strSql.Append(" where EntrustID=@EntrustID");
            SqlParameter[] parameters = {
					new SqlParameter("@EntrustID", SqlDbType.Int,4)
};
            parameters[0].Value = EntrustID;

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
        public bool DeleteList(string EntrustIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_EntrustTesting ");
            strSql.Append(" where EntrustID in (" + EntrustIDlist + ")  ");
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
        public E_tb_EntrustTesting GetModel(int EntrustID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 EntrustID,TaskNo,EntrustCompany,SampleID,ProjectID,TestPersonnelID,SubmissionTime,ReportID,IsComplete,AreaID,EditPersonnelID from tb_EntrustTesting ");
            strSql.Append(" where EntrustID=@EntrustID");
            SqlParameter[] parameters = {
					new SqlParameter("@EntrustID", SqlDbType.Int,4)
};
            parameters[0].Value = EntrustID;

            E_tb_EntrustTesting model = new E_tb_EntrustTesting();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EntrustID"].ToString() != "")
                {
                    model.EntrustID = int.Parse(ds.Tables[0].Rows[0]["EntrustID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TaskNo"] != null)
                {
                    model.TaskNo = ds.Tables[0].Rows[0]["TaskNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EntrustCompany"] != null)
                {
                    model.EntrustCompany = ds.Tables[0].Rows[0]["EntrustCompany"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SampleID"].ToString() != "")
                {
                    model.SampleID = int.Parse(ds.Tables[0].Rows[0]["SampleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProjectID"].ToString() != "")
                {
                    model.ProjectID = int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TestPersonnelID"].ToString() != "")
                {
                    model.TestPersonnelID = int.Parse(ds.Tables[0].Rows[0]["TestPersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SubmissionTime"].ToString() != "")
                {
                    model.SubmissionTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubmissionTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReportID"].ToString() != "")
                {
                    model.ReportID = int.Parse(ds.Tables[0].Rows[0]["ReportID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsComplete"].ToString() != "")
                {
                    model.IsComplete = int.Parse(ds.Tables[0].Rows[0]["IsComplete"].ToString());
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
            strSql.Append("select EntrustID,TaskNo,EntrustCompany,SampleID,ProjectID,TestPersonnelID,SubmissionTime,ReportID,IsComplete,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_EntrustTesting ");
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
            strSql.Append(" EntrustID,TaskNo,EntrustCompany,SampleID,ProjectID,TestPersonnelID,SubmissionTime,ReportID,IsComplete,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_EntrustTesting ");
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
            parameters[0].Value = "tb_EntrustTesting";
            parameters[1].Value = "EntrustID";
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
                strSql.Append("order by T.EntrustID desc");
            }
            strSql.Append(")AS Row, T.*,B.name as SampleName,C.ProjectName,D.PersonnelName,'' as strReportID ");
            strSql.Append(@" from tb_EntrustTesting T
                            left join tb_Sample as B on T.SampleID=B.id
                            left join tb_Project as C on T.ProjectID=c.ProjectID
                            left join tb_InPersonnel as D on T.TestPersonnelID=D.PersonnelID");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            total = DbHelperSQL.GetCount(strSql.ToString());
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1} order by IsComplete", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 检查是已存在该任务单号
        /// </summary>
        /// <param name="TaskNo"></param>
        /// <returns></returns>
        public int IsExistsTaskNo(string TaskNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_EntrustTesting where TaskNo='" + TaskNo + "'");
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
        #endregion
    }
}
