using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.OriginalRecord;

namespace DAL.OriginalRecord
{
    /// <summary>
    /// 数据访问类:tb_RecordSample
    /// </summary>
    public partial class D_tb_RecordSample
    {
        public D_tb_RecordSample()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RecordSampleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_RecordSample");
            strSql.Append(" where RecordSampleID=@RecordSampleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordSampleID", SqlDbType.Int,4)
};
            parameters[0].Value = RecordSampleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_RecordSample model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_RecordSample(");
            strSql.Append("RecordID,RecordFilePath,SampleID,SampleName,Result)");
            strSql.Append(" values (");
            strSql.Append("@RecordID,@RecordFilePath,@SampleID,@SampleName,@Result)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4),
					new SqlParameter("@RecordFilePath", SqlDbType.NVarChar,150),
					new SqlParameter("@SampleID", SqlDbType.Int,4),
					new SqlParameter("@SampleName", SqlDbType.NVarChar,50),
					new SqlParameter("@Result", SqlDbType.Float,8)};
            parameters[0].Value = model.RecordID;
            parameters[1].Value = model.RecordFilePath;
            parameters[2].Value = model.SampleID;
            parameters[3].Value = model.SampleName;
            parameters[4].Value = model.Result;

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
        public bool Update(E_tb_RecordSample model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_RecordSample set ");
            strSql.Append("RecordID=@RecordID,");
            strSql.Append("RecordFilePath=@RecordFilePath,");
            strSql.Append("SampleID=@SampleID,");
            strSql.Append("SampleName=@SampleName,");
            strSql.Append("Result=@Result");
            strSql.Append(" where RecordSampleID=@RecordSampleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4),
					new SqlParameter("@RecordFilePath", SqlDbType.NVarChar,150),
					new SqlParameter("@SampleID", SqlDbType.Int,4),
					new SqlParameter("@SampleName", SqlDbType.NVarChar,50),
					new SqlParameter("@Result", SqlDbType.Float,8),
					new SqlParameter("@RecordSampleID", SqlDbType.Int,4)};
            parameters[0].Value = model.RecordID;
            parameters[1].Value = model.RecordFilePath;
            parameters[2].Value = model.SampleID;
            parameters[3].Value = model.SampleName;
            parameters[4].Value = model.Result;
            parameters[5].Value = model.RecordSampleID;

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
        public bool Delete(int RecordSampleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_RecordSample ");
            strSql.Append(" where RecordSampleID=@RecordSampleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordSampleID", SqlDbType.Int,4)
};
            parameters[0].Value = RecordSampleID;

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
        public bool DeleteList(string RecordSampleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_RecordSample ");
            strSql.Append(" where RecordSampleID in (" + RecordSampleIDlist + ")  ");
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
        public E_tb_RecordSample GetModel(int RecordSampleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RecordSampleID,RecordID,RecordFilePath,SampleID,SampleName,Result from tb_RecordSample ");
            strSql.Append(" where RecordSampleID=@RecordSampleID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordSampleID", SqlDbType.Int,4)
};
            parameters[0].Value = RecordSampleID;

            E_tb_RecordSample model = new E_tb_RecordSample();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RecordSampleID"].ToString() != "")
                {
                    model.RecordSampleID = int.Parse(ds.Tables[0].Rows[0]["RecordSampleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordID"].ToString() != "")
                {
                    model.RecordID = int.Parse(ds.Tables[0].Rows[0]["RecordID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordFilePath"] != null)
                {
                    model.RecordFilePath = ds.Tables[0].Rows[0]["RecordFilePath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SampleID"].ToString() != "")
                {
                    model.SampleID = int.Parse(ds.Tables[0].Rows[0]["SampleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SampleName"] != null)
                {
                    model.SampleName = ds.Tables[0].Rows[0]["SampleName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Result"].ToString() != "")
                {
                    model.Result = decimal.Parse(ds.Tables[0].Rows[0]["Result"].ToString());
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
            strSql.Append("select RecordSampleID,RecordID,RecordFilePath,SampleID,SampleName,Result ");
            strSql.Append(" FROM tb_RecordSample ");
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
            strSql.Append(" RecordSampleID,RecordID,RecordFilePath,SampleID,SampleName,Result ");
            strSql.Append(" FROM tb_RecordSample ");
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
            parameters[0].Value = "tb_RecordSample";
            parameters[1].Value = "RecordSampleID";
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
        /// 按照条件删除数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool DeleteListByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_RecordSample ");
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

        /// <summary>
        /// 关联原始记录对应的样品数据
        /// </summary>
        /// <param name="RecordID">原始记录ID</param>
        /// <param name="FilePath">原始记录文件名称</param>
        /// <returns></returns>
        public bool UpdateRecordIDByFilePath(int RecordID, string FilePath)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_RecordSample set RecordID=" + RecordID);
            strSql.Append(" where RecordFilePath='" + FilePath + "'");
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
        /// 更具项目获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListForProject(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (select A.*,B.DetectTime,B.ProjectID from tb_RecordSample as A left join tb_OriginalRecord as B on A.RecordID=B.RecordID) as T ");
            if (strWhere.Length > 0)
            {
                strSql.Append(" where "+strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据项目ID获取符合要求的样品数据列表
        /// </summary>
        /// <param name="ProjectID">项目ID</param>
        /// <returns></returns>
        public DataSet GetSampleByProjectID(int ProjectID)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.SampleID,A.SampleName from tb_RecordSample as A left join tb_OriginalRecord as B on A.RecordID=B.RecordID ");
            strSql.Append(" where B.ProjectID=" + ProjectID + " group by SampleID,SampleName ");

            return DbHelperSQL.Query(strSql.ToString());
        }

           

        #endregion
    }
}
