using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.ExpePlan;

namespace DAL.ExpePlan
{
    /// <summary>
    /// 数据访问类:D_tb_ExpePlan
    /// </summary>
    public partial class D_tb_ExpePlan
    {
        public D_tb_ExpePlan()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PlanID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_ExpePlan");
            strSql.Append(" where PlanID=@PlanID");
            SqlParameter[] parameters = {
					new SqlParameter("@PlanID", SqlDbType.Int,4)
};
            parameters[0].Value = PlanID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ExpePlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_ExpePlan(");
            strSql.Append("PlanTypeID,ProjectID,SampleID,InspectTime,InspectPlace,InspectMethod,HeadPersonnelID,TaskNo,Status,Remark,AreaID,EditPersonnelID,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@PlanTypeID,@ProjectID,@SampleID,@InspectTime,@InspectPlace,@InspectMethod,@HeadPersonnelID,@TaskNo,@Status,@Remark,@AreaID,@EditPersonnelID,@UpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PlanTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@SampleID", SqlDbType.Int,4),
					new SqlParameter("@InspectTime", SqlDbType.DateTime),
					new SqlParameter("@InspectPlace", SqlDbType.NVarChar,100),
					new SqlParameter("@InspectMethod", SqlDbType.NVarChar),
					new SqlParameter("@HeadPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@TaskNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.PlanTypeID;
            parameters[1].Value = model.ProjectID;
            parameters[2].Value = model.SampleID;
            parameters[3].Value = model.InspectTime;
            parameters[4].Value = model.InspectPlace;
            parameters[5].Value = model.InspectMethod;
            parameters[6].Value = model.HeadPersonnelID;
            parameters[7].Value = model.TaskNo;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.AreaID;
            parameters[11].Value = model.EditPersonnelID;
            parameters[12].Value = model.UpdateTime;

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
        public bool Update(E_tb_ExpePlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_ExpePlan set ");
            strSql.Append("PlanTypeID=@PlanTypeID,");
            strSql.Append("ProjectID=@ProjectID,");
            strSql.Append("SampleID=@SampleID,");
            strSql.Append("InspectTime=@InspectTime,");
            strSql.Append("InspectPlace=@InspectPlace,");
            strSql.Append("InspectMethod=@InspectMethod,");
            strSql.Append("HeadPersonnelID=@HeadPersonnelID,");
            strSql.Append("TaskNo=@TaskNo,");
            strSql.Append("Status=@Status,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where PlanID=@PlanID");
            SqlParameter[] parameters = {
					new SqlParameter("@PlanTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@SampleID", SqlDbType.Int,4),
					new SqlParameter("@InspectTime", SqlDbType.DateTime),
					new SqlParameter("@InspectPlace", SqlDbType.NVarChar,100),
					new SqlParameter("@InspectMethod", SqlDbType.NVarChar),
					new SqlParameter("@HeadPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@TaskNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@PlanID", SqlDbType.Int,4)};
            parameters[0].Value = model.PlanTypeID;
            parameters[1].Value = model.ProjectID;
            parameters[2].Value = model.SampleID;
            parameters[3].Value = model.InspectTime;
            parameters[4].Value = model.InspectPlace;
            parameters[5].Value = model.InspectMethod;
            parameters[6].Value = model.HeadPersonnelID;
            parameters[7].Value = model.TaskNo;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.AreaID;
            parameters[11].Value = model.EditPersonnelID;
            parameters[12].Value = model.UpdateTime;
            parameters[13].Value = model.PlanID;

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
        public bool Delete(int PlanID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_ExpePlan ");
            strSql.Append(" where PlanID=@PlanID");
            SqlParameter[] parameters = {
					new SqlParameter("@PlanID", SqlDbType.Int,4)
};
            parameters[0].Value = PlanID;

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
        public bool DeleteList(string PlanIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_ExpePlan ");
            strSql.Append(" where PlanID in (" + PlanIDlist + ")  ");
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
        public E_tb_ExpePlan GetModel(int PlanID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PlanID,PlanTypeID,ProjectID,SampleID,InspectTime,InspectPlace,InspectMethod,HeadPersonnelID,TaskNo,Status,Remark,AreaID,EditPersonnelID,UpdateTime from tb_ExpePlan ");
            strSql.Append(" where PlanID=@PlanID");
            SqlParameter[] parameters = {
					new SqlParameter("@PlanID", SqlDbType.Int,4)
};
            parameters[0].Value = PlanID;

            E_tb_ExpePlan model = new E_tb_ExpePlan();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PlanID"].ToString() != "")
                {
                    model.PlanID = int.Parse(ds.Tables[0].Rows[0]["PlanID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlanTypeID"].ToString() != "")
                {
                    model.PlanTypeID = int.Parse(ds.Tables[0].Rows[0]["PlanTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProjectID"].ToString() != "")
                {
                    model.ProjectID = int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SampleID"].ToString() != "")
                {
                    model.SampleID = int.Parse(ds.Tables[0].Rows[0]["SampleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InspectTime"].ToString() != "")
                {
                    model.InspectTime = DateTime.Parse(ds.Tables[0].Rows[0]["InspectTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InspectPlace"] != null)
                {
                    model.InspectPlace = ds.Tables[0].Rows[0]["InspectPlace"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InspectMethod"] != null)
                {
                    model.InspectMethod = ds.Tables[0].Rows[0]["InspectMethod"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HeadPersonnelID"].ToString() != "")
                {
                    model.HeadPersonnelID = int.Parse(ds.Tables[0].Rows[0]["HeadPersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TaskNo"] != null)
                {
                    model.TaskNo = ds.Tables[0].Rows[0]["TaskNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null)
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditPersonnelID"].ToString() != "")
                {
                    model.EditPersonnelID = int.Parse(ds.Tables[0].Rows[0]["EditPersonnelID"].ToString());
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
            strSql.Append("select PlanID,PlanTypeID,ProjectID,SampleID,InspectTime,InspectPlace,InspectMethod,HeadPersonnelID,TaskNo,Status,Remark,AreaID,EditPersonnelID,UpdateTime ");
            strSql.Append(" FROM tb_ExpePlan ");
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
            strSql.Append(" PlanID,PlanTypeID,ProjectID,SampleID,InspectTime,InspectPlace,InspectMethod,HeadPersonnelID,TaskNo,Status,Remark,AreaID,EditPersonnelID,UpdateTime ");
            strSql.Append(" FROM tb_ExpePlan ");
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
            parameters[0].Value = "tb_ExpePlan";
            parameters[1].Value = "PlanID";
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
                strSql.Append("order by T.PlanID desc");
            }
            strSql.Append(")AS Row, T.*,A.ProjectName,B.PersonnelName as HeadPersonnelName,C.name as SampleName ");
            strSql.Append(@"from tb_ExpePlan T  
                            left join tb_Project as A on T.ProjectID=A.ProjectID
                            left join tb_InPersonnel as B on T.HeadPersonnelID=B.PersonnelID 
                            left join tb_Sample as C on T.SampleID=C.id ");
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
        /// 根据实验计划ID集合更新计划完成状态
        /// </summary>
        /// <param name="PlanIDS"></param>
        /// <returns></returns>
        public int UpdateStatusByPlanIDS(string PlanIDS,int ReportID)
        {
            //更新委托检验状态
            StringBuilder str = new StringBuilder();
            str.Append("update tb_EntrustTesting set IsComplete=1,ReportID=" + ReportID + " where TaskNo in (select TaskNo from tb_ExpePlan where PlanTypeID=2 and PlanID in (" + PlanIDS + "))");
            DbHelperSQL.ExecuteSql(str.ToString());

            //更新检验计划状态
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update tb_ExpePlan set Status=1 where PlanID in (" + PlanIDS + ")");
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 检查是已存在该任务单号
        /// </summary>
        /// <param name="TaskNo"></param>
        /// <returns></returns>
        public int IsExistsTaskNo(string TaskNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_ExpePlan where TaskNo='" + TaskNo + "'");
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
        /// 获得实验计划超出检验时间内容
        /// 作者：章建国
        /// </summary>
        public DataSet GetUNFinishList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
Count(*) AS unfinish,
dbo.tb_ExpePlan.HeadPersonnelID,
dbo.tb_InPersonnel.PersonnelName

FROM
dbo.tb_ExpePlan
INNER JOIN dbo.tb_InPersonnel ON dbo.tb_InPersonnel.PersonnelID = dbo.tb_ExpePlan.HeadPersonnelID
WHERE
dbo.tb_ExpePlan.Status = 0 AND
DATEDIFF(DAY,InspectTime,GETDATE()) > 5
GROUP BY
dbo.tb_ExpePlan.HeadPersonnelID,dbo.tb_InPersonnel.PersonnelName
   ORDER BY unfinish desc");
            return DbHelperSQL.Query(strSql.ToString());
        }


        public DataSet GetAllUNFinishList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
Sum(unfinish) AS unfinish,
HeadPersonnelID,
PersonnelName
FROM
View_UnComplateTest
GROUP BY
HeadPersonnelID,PersonnelName
   ORDER BY unfinish desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion


    }
}
