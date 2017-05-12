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
    /// 数据访问类:tb_TestReport
    /// </summary>
    public partial class D_tb_TestReport
    {
        public D_tb_TestReport()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ReportID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestReport");
            strSql.Append(" where ReportID=@ReportID");
            SqlParameter[] parameters = {
					new SqlParameter("@ReportID", SqlDbType.Int,4)
};
            parameters[0].Value = ReportID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_TestReport model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_TestReport(");
            strSql.Append("RecordIDS,TaskNoS,ReportNo,SampleNum,SampleName,Department,TestType,IssuedTime,TestingCompany,Specifications,ProductionTime,Packing,productNum,ToSampleMode,SendTestAddress,SamplingPlace,SamplingCompany,SamplingPersonnel,SamplingTime,TestTime,ShelfLife,TestBasis,Conclusion,Remarks,Explain,ApprovalPersonnelID,examinePersonnelID,MainTestPersonnelID,FilePath,AreaID,EditPersonnelID,AddTime,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@RecordIDS,@TaskNoS,@ReportNo,@SampleNum,@SampleName,@Department,@TestType,@IssuedTime,@TestingCompany,@Specifications,@ProductionTime,@Packing,@productNum,@ToSampleMode,@SendTestAddress,@SamplingPlace,@SamplingCompany,@SamplingPersonnel,@SamplingTime,@TestTime,@ShelfLife,@TestBasis,@Conclusion,@Remarks,@Explain,@ApprovalPersonnelID,@examinePersonnelID,@MainTestPersonnelID,@FilePath,@AreaID,@EditPersonnelID,@AddTime,@UpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordIDS", SqlDbType.NVarChar,100),
					new SqlParameter("@TaskNoS", SqlDbType.NVarChar,200),
					new SqlParameter("@ReportNo", SqlDbType.NVarChar,100),
					new SqlParameter("@SampleNum", SqlDbType.NVarChar,100),
					new SqlParameter("@SampleName", SqlDbType.NVarChar,100),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.Int,4),
					new SqlParameter("@IssuedTime", SqlDbType.DateTime),
					new SqlParameter("@TestingCompany", SqlDbType.NVarChar,50),
					new SqlParameter("@Specifications", SqlDbType.NVarChar,100),
					new SqlParameter("@ProductionTime", SqlDbType.DateTime),
					new SqlParameter("@Packing", SqlDbType.NVarChar,100),
					new SqlParameter("@productNum", SqlDbType.NVarChar,100),
					new SqlParameter("@ToSampleMode", SqlDbType.NVarChar,100),
					new SqlParameter("@SendTestAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@SamplingPlace", SqlDbType.NVarChar,200),
					new SqlParameter("@SamplingCompany", SqlDbType.NVarChar,100),
					new SqlParameter("@SamplingPersonnel", SqlDbType.NVarChar,100),
					new SqlParameter("@SamplingTime", SqlDbType.DateTime),
					new SqlParameter("@TestTime", SqlDbType.DateTime),
					new SqlParameter("@ShelfLife", SqlDbType.NVarChar,200),
					new SqlParameter("@TestBasis", SqlDbType.NVarChar,200),
					new SqlParameter("@Conclusion", SqlDbType.NVarChar,200),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@Explain", SqlDbType.Text),
					new SqlParameter("@ApprovalPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@examinePersonnelID", SqlDbType.Int,4),
					new SqlParameter("@MainTestPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.RecordIDS;
            parameters[1].Value = model.TaskNoS;
            parameters[2].Value = model.ReportNo;
            parameters[3].Value = model.SampleNum;
            parameters[4].Value = model.SampleName;
            parameters[5].Value = model.Department;
            parameters[6].Value = model.TestType;
            parameters[7].Value = model.IssuedTime;
            parameters[8].Value = model.TestingCompany;
            parameters[9].Value = model.Specifications;
            parameters[10].Value = model.ProductionTime;
            parameters[11].Value = model.Packing;
            parameters[12].Value = model.productNum;
            parameters[13].Value = model.ToSampleMode;
            parameters[14].Value = model.SendTestAddress;
            parameters[15].Value = model.SamplingPlace;
            parameters[16].Value = model.SamplingCompany;
            parameters[17].Value = model.SamplingPersonnel;
            parameters[18].Value = model.SamplingTime;
            parameters[19].Value = model.TestTime;
            parameters[20].Value = model.ShelfLife;
            parameters[21].Value = model.TestBasis;
            parameters[22].Value = model.Conclusion;
            parameters[23].Value = model.Remarks;
            parameters[24].Value = model.Explain;
            parameters[25].Value = model.ApprovalPersonnelID;
            parameters[26].Value = model.examinePersonnelID;
            parameters[27].Value = model.MainTestPersonnelID;
            parameters[28].Value = model.FilePath;
            parameters[29].Value = model.AreaID;
            parameters[30].Value = model.EditPersonnelID;
            parameters[31].Value = model.AddTime;
            parameters[32].Value = model.UpdateTime;

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
        public bool Update(E_tb_TestReport model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_TestReport set ");
            strSql.Append("RecordIDS=@RecordIDS,");
            strSql.Append("TaskNoS=@TaskNoS,");
            strSql.Append("ReportNo=@ReportNo,");
            strSql.Append("SampleNum=@SampleNum,");
            strSql.Append("SampleName=@SampleName,");
            strSql.Append("Department=@Department,");
            strSql.Append("TestType=@TestType,");
            strSql.Append("IssuedTime=@IssuedTime,");
            strSql.Append("TestingCompany=@TestingCompany,");
            strSql.Append("Specifications=@Specifications,");
            strSql.Append("ProductionTime=@ProductionTime,");
            strSql.Append("Packing=@Packing,");
            strSql.Append("productNum=@productNum,");
            strSql.Append("ToSampleMode=@ToSampleMode,");
            strSql.Append("SendTestAddress=@SendTestAddress,");
            strSql.Append("SamplingPlace=@SamplingPlace,");
            strSql.Append("SamplingCompany=@SamplingCompany,");
            strSql.Append("SamplingPersonnel=@SamplingPersonnel,");
            strSql.Append("SamplingTime=@SamplingTime,");
            strSql.Append("TestTime=@TestTime,");
            strSql.Append("ShelfLife=@ShelfLife,");
            strSql.Append("TestBasis=@TestBasis,");
            strSql.Append("Conclusion=@Conclusion,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("Explain=@Explain,");
            strSql.Append("ApprovalPersonnelID=@ApprovalPersonnelID,");
            strSql.Append("examinePersonnelID=@examinePersonnelID,");
            strSql.Append("MainTestPersonnelID=@MainTestPersonnelID,");
            strSql.Append("FilePath=@FilePath,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where ReportID=@ReportID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordIDS", SqlDbType.NVarChar,100),
					new SqlParameter("@TaskNoS", SqlDbType.NVarChar,200),
					new SqlParameter("@ReportNo", SqlDbType.NVarChar,100),
					new SqlParameter("@SampleNum", SqlDbType.NVarChar,100),
					new SqlParameter("@SampleName", SqlDbType.NVarChar,100),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.Int,4),
					new SqlParameter("@IssuedTime", SqlDbType.DateTime),
					new SqlParameter("@TestingCompany", SqlDbType.NVarChar,50),
					new SqlParameter("@Specifications", SqlDbType.NVarChar,100),
					new SqlParameter("@ProductionTime", SqlDbType.DateTime),
					new SqlParameter("@Packing", SqlDbType.NVarChar,100),
					new SqlParameter("@productNum", SqlDbType.NVarChar,100),
					new SqlParameter("@ToSampleMode", SqlDbType.NVarChar,100),
					new SqlParameter("@SendTestAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@SamplingPlace", SqlDbType.NVarChar,200),
					new SqlParameter("@SamplingCompany", SqlDbType.NVarChar,100),
					new SqlParameter("@SamplingPersonnel", SqlDbType.NVarChar,100),
					new SqlParameter("@SamplingTime", SqlDbType.DateTime),
					new SqlParameter("@TestTime", SqlDbType.DateTime),
					new SqlParameter("@ShelfLife", SqlDbType.NVarChar,200),
					new SqlParameter("@TestBasis", SqlDbType.NVarChar,200),
					new SqlParameter("@Conclusion", SqlDbType.NVarChar,200),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@Explain", SqlDbType.Text),
					new SqlParameter("@ApprovalPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@examinePersonnelID", SqlDbType.Int,4),
					new SqlParameter("@MainTestPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ReportID", SqlDbType.Int,4)};
            parameters[0].Value = model.RecordIDS;
            parameters[1].Value = model.TaskNoS;
            parameters[2].Value = model.ReportNo;
            parameters[3].Value = model.SampleNum;
            parameters[4].Value = model.SampleName;
            parameters[5].Value = model.Department;
            parameters[6].Value = model.TestType;
            parameters[7].Value = model.IssuedTime;
            parameters[8].Value = model.TestingCompany;
            parameters[9].Value = model.Specifications;
            parameters[10].Value = model.ProductionTime;
            parameters[11].Value = model.Packing;
            parameters[12].Value = model.productNum;
            parameters[13].Value = model.ToSampleMode;
            parameters[14].Value = model.SendTestAddress;
            parameters[15].Value = model.SamplingPlace;
            parameters[16].Value = model.SamplingCompany;
            parameters[17].Value = model.SamplingPersonnel;
            parameters[18].Value = model.SamplingTime;
            parameters[19].Value = model.TestTime;
            parameters[20].Value = model.ShelfLife;
            parameters[21].Value = model.TestBasis;
            parameters[22].Value = model.Conclusion;
            parameters[23].Value = model.Remarks;
            parameters[24].Value = model.Explain;
            parameters[25].Value = model.ApprovalPersonnelID;
            parameters[26].Value = model.examinePersonnelID;
            parameters[27].Value = model.MainTestPersonnelID;
            parameters[28].Value = model.FilePath;
            parameters[29].Value = model.AreaID;
            parameters[30].Value = model.EditPersonnelID;
            parameters[31].Value = model.AddTime;
            parameters[32].Value = model.UpdateTime;
            parameters[33].Value = model.ReportID;

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
        public bool Delete(int ReportID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestReport ");
            strSql.Append(" where ReportID=@ReportID");
            SqlParameter[] parameters = {
					new SqlParameter("@ReportID", SqlDbType.Int,4)
};
            parameters[0].Value = ReportID;

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
        public bool DeleteList(string ReportIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestReport ");
            strSql.Append(" where ReportID in (" + ReportIDlist + ")  ");
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
        public E_tb_TestReport GetModel(int ReportID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ReportID,RecordIDS,TaskNoS,ReportNo,SampleNum,SampleName,Department,TestType,IssuedTime,TestingCompany,Specifications,ProductionTime,Packing,productNum,ToSampleMode,SendTestAddress,SamplingPlace,SamplingCompany,SamplingPersonnel,SamplingTime,TestTime,ShelfLife,TestBasis,Conclusion,Remarks,Explain,ApprovalPersonnelID,examinePersonnelID,MainTestPersonnelID,FilePath,AreaID,EditPersonnelID,AddTime,UpdateTime from tb_TestReport ");
            strSql.Append(" where ReportID=@ReportID");
            SqlParameter[] parameters = {
					new SqlParameter("@ReportID", SqlDbType.Int,4)
};
            parameters[0].Value = ReportID;

            E_tb_TestReport model = new E_tb_TestReport();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ReportID"].ToString() != "")
                {
                    model.ReportID = int.Parse(ds.Tables[0].Rows[0]["ReportID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordIDS"] != null)
                {
                    model.RecordIDS = ds.Tables[0].Rows[0]["RecordIDS"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TaskNoS"] != null)
                {
                    model.TaskNoS = ds.Tables[0].Rows[0]["TaskNoS"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReportNo"] != null)
                {
                    model.ReportNo = ds.Tables[0].Rows[0]["ReportNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SampleNum"] != null)
                {
                    model.SampleNum = ds.Tables[0].Rows[0]["SampleNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SampleName"] != null)
                {
                    model.SampleName = ds.Tables[0].Rows[0]["SampleName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Department"] != null)
                {
                    model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TestType"].ToString() != "")
                {
                    model.TestType = int.Parse(ds.Tables[0].Rows[0]["TestType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssuedTime"].ToString() != "")
                {
                    model.IssuedTime = DateTime.Parse(ds.Tables[0].Rows[0]["IssuedTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TestingCompany"] != null)
                {
                    model.TestingCompany = ds.Tables[0].Rows[0]["TestingCompany"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Specifications"] != null)
                {
                    model.Specifications = ds.Tables[0].Rows[0]["Specifications"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductionTime"].ToString() != "")
                {
                    model.ProductionTime = DateTime.Parse(ds.Tables[0].Rows[0]["ProductionTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Packing"] != null)
                {
                    model.Packing = ds.Tables[0].Rows[0]["Packing"].ToString();
                }
                if (ds.Tables[0].Rows[0]["productNum"] != null)
                {
                    model.productNum = ds.Tables[0].Rows[0]["productNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ToSampleMode"] != null)
                {
                    model.ToSampleMode = ds.Tables[0].Rows[0]["ToSampleMode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SendTestAddress"] != null)
                {
                    model.SendTestAddress = ds.Tables[0].Rows[0]["SendTestAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SamplingPlace"] != null)
                {
                    model.SamplingPlace = ds.Tables[0].Rows[0]["SamplingPlace"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SamplingCompany"] != null)
                {
                    model.SamplingCompany = ds.Tables[0].Rows[0]["SamplingCompany"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SamplingPersonnel"] != null)
                {
                    model.SamplingPersonnel = ds.Tables[0].Rows[0]["SamplingPersonnel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SamplingTime"].ToString() != "")
                {
                    model.SamplingTime = DateTime.Parse(ds.Tables[0].Rows[0]["SamplingTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TestTime"].ToString() != "")
                {
                    model.TestTime = DateTime.Parse(ds.Tables[0].Rows[0]["TestTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShelfLife"] != null)
                {
                    model.ShelfLife = ds.Tables[0].Rows[0]["ShelfLife"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TestBasis"] != null)
                {
                    model.TestBasis = ds.Tables[0].Rows[0]["TestBasis"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Conclusion"] != null)
                {
                    model.Conclusion = ds.Tables[0].Rows[0]["Conclusion"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remarks"] != null)
                {
                    model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Explain"] != null)
                {
                    model.Explain = ds.Tables[0].Rows[0]["Explain"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApprovalPersonnelID"].ToString() != "")
                {
                    model.ApprovalPersonnelID = int.Parse(ds.Tables[0].Rows[0]["ApprovalPersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["examinePersonnelID"].ToString() != "")
                {
                    model.examinePersonnelID = int.Parse(ds.Tables[0].Rows[0]["examinePersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MainTestPersonnelID"].ToString() != "")
                {
                    model.MainTestPersonnelID = int.Parse(ds.Tables[0].Rows[0]["MainTestPersonnelID"].ToString());
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
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
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
            strSql.Append("select ReportID,RecordIDS,TaskNoS,ReportNo,SampleNum,SampleName,Department,TestType,IssuedTime,TestingCompany,Specifications,ProductionTime,Packing,productNum,ToSampleMode,SendTestAddress,SamplingPlace,SamplingCompany,SamplingPersonnel,SamplingTime,TestTime,ShelfLife,TestBasis,Conclusion,Remarks,Explain,ApprovalPersonnelID,examinePersonnelID,MainTestPersonnelID,FilePath,AreaID,EditPersonnelID,AddTime,UpdateTime ");
            strSql.Append(" FROM tb_TestReport ");
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
            strSql.Append(" ReportID,RecordIDS,TaskNoS,ReportNo,SampleNum,SampleName,Department,TestType,IssuedTime,TestingCompany,Specifications,ProductionTime,Packing,productNum,ToSampleMode,SendTestAddress,SamplingPlace,SamplingCompany,SamplingPersonnel,SamplingTime,TestTime,ShelfLife,TestBasis,Conclusion,Remarks,Explain,ApprovalPersonnelID,examinePersonnelID,MainTestPersonnelID,FilePath,AreaID,EditPersonnelID,AddTime,UpdateTime ");
            strSql.Append(" FROM tb_TestReport ");
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
            parameters[0].Value = "tb_TestReport";
            parameters[1].Value = "ReportID";
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
                strSql.Append("order by T.ReportID desc");
            }
            strSql.Append(")AS Row, T.*,B.PersonnelName as ApprovalPersonnelName,C.PersonnelName as examinePersonnelName,D.PersonnelName as MainTestPersonnelName,E.TypeName as TestTypeName  from tb_TestReport T ");
            strSql.Append(@"left join tb_InPersonnel as B on T.ApprovalPersonnelID=B.PersonnelID
                            left join tb_InPersonnel as C on T.examinePersonnelID=C.PersonnelID
                            left join tb_InPersonnel as D on T.MainTestPersonnelID=D.PersonnelID
                            left join tb_TypeDict as E on T.TestType=E.TypeID");
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
        /// 根据添加时间获取最大编号值
        /// </summary>
        /// <param name="AddTime"></param>
        /// <returns></returns>
        public int GetMaxNoByAddTime(DateTime AddTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) from tb_TestReport where AddTime=CAST('" + AddTime + "' as datetime)");
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        #endregion
    }
}
