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
    /// 数据访问类:tb_OriginalRecord
    /// </summary>
    public partial class D_tb_OriginalRecord
    {
        public D_tb_OriginalRecord()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RecordID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_OriginalRecord");
            strSql.Append(" where RecordID=@RecordID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4)
};
            parameters[0].Value = RecordID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_OriginalRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_OriginalRecord(");
            strSql.Append("ProjectID,TaskNo,DetectTime,DetectPersonnelID,FilePath,Contents,AreaID,EditPersonnelID,SampleID,InsStand)");
            strSql.Append(" values (");
            strSql.Append("@ProjectID,@TaskNo,@DetectTime,@DetectPersonnelID,@FilePath,@Contents,@AreaID,@EditPersonnelID,@SampleID,@InsStand)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@TaskNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DetectTime", SqlDbType.DateTime),
					new SqlParameter("@DetectPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,150),
					new SqlParameter("@Contents", SqlDbType.NVarChar,200),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@SampleID", SqlDbType.Int,4),
                    new SqlParameter("@InsStand", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.ProjectID;
            parameters[1].Value = model.TaskNo;
            parameters[2].Value = model.DetectTime;
            parameters[3].Value = model.DetectPersonnelID;
            parameters[4].Value = model.FilePath;
            parameters[5].Value = model.Contents;
            parameters[6].Value = model.AreaID;
            parameters[7].Value = model.EditPersonnelID;
            parameters[8].Value = model.SampleID;
            parameters[9].Value = model.InsStand;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                model.RecordID = Convert.ToInt32(obj);
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_OriginalRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_OriginalRecord set ");
            strSql.Append("ProjectID=@ProjectID,");
            strSql.Append("TaskNo=@TaskNo,");
            strSql.Append("DetectTime=@DetectTime,");
            strSql.Append("DetectPersonnelID=@DetectPersonnelID,");
            strSql.Append("FilePath=@FilePath,");
            strSql.Append("Contents=@Contents,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID,");
            strSql.Append("SampleID=@SampleID,");
            strSql.Append("InsStand=@InsStand");
            strSql.Append(" where RecordID=@RecordID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@TaskNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DetectTime", SqlDbType.DateTime),
					new SqlParameter("@DetectPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,150),
					new SqlParameter("@Contents", SqlDbType.NVarChar,200),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@SampleID", SqlDbType.Int,4),
					new SqlParameter("@RecordID", SqlDbType.Int,4),
                    new SqlParameter("@InsStand", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.ProjectID;
            parameters[1].Value = model.TaskNo;
            parameters[2].Value = model.DetectTime;
            parameters[3].Value = model.DetectPersonnelID;
            parameters[4].Value = model.FilePath;
            parameters[5].Value = model.Contents;
            parameters[6].Value = model.AreaID;
            parameters[7].Value = model.EditPersonnelID;
            parameters[8].Value = model.SampleID;
            parameters[9].Value = model.RecordID;
            parameters[10].Value = model.InsStand;

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
        public bool Delete(int RecordID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_OriginalRecord ");
            strSql.Append(" where RecordID=@RecordID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4)
};
            parameters[0].Value = RecordID;

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
        public bool DeleteList(string RecordIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_OriginalRecord ");
            strSql.Append(" where RecordID in (" + RecordIDlist + ")  ");
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
        public E_tb_OriginalRecord GetModel(int RecordID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_OriginalRecord");
            strSql.Append(" where RecordID=@RecordID");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.Int,4)
            };
            parameters[0].Value = RecordID;

            E_tb_OriginalRecord model = new E_tb_OriginalRecord();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RecordID"].ToString() != "")
                {
                    model.RecordID = int.Parse(ds.Tables[0].Rows[0]["RecordID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProjectID"].ToString() != "")
                {
                    model.ProjectID = int.Parse(ds.Tables[0].Rows[0]["ProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TaskNo"] != null)
                {
                    model.TaskNo = ds.Tables[0].Rows[0]["TaskNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DetectTime"].ToString() != "")
                {
                    model.DetectTime = DateTime.Parse(ds.Tables[0].Rows[0]["DetectTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DetectPersonnelID"].ToString() != "")
                {
                    model.DetectPersonnelID = int.Parse(ds.Tables[0].Rows[0]["DetectPersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FilePath"] != null)
                {
                    model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contents"] != null)
                {
                    model.Contents = ds.Tables[0].Rows[0]["Contents"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditPersonnelID"].ToString() != "")
                {
                    model.EditPersonnelID = int.Parse(ds.Tables[0].Rows[0]["EditPersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SampleID"].ToString() != "")
                {
                    model.SampleID = int.Parse(ds.Tables[0].Rows[0]["SampleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InsStand"] != null)
                {
                    model.InsStand = ds.Tables[0].Rows[0]["InsStand"].ToString();
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
            strSql.Append(" FROM tb_OriginalRecord ");
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
            strSql.Append(" FROM tb_OriginalRecord ");
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
            parameters[0].Value = "tb_OriginalRecord";
            parameters[1].Value = "RecordID";
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
                strSql.Append("order by T.RecordID desc");
            }
            strSql.Append(")AS Row, T.*,B.ProjectName,C.PersonnelName as DetectPersonnelName,E.name as SampleName  from tb_OriginalRecord T ");
            strSql.Append(" left join tb_Project as B on T.ProjectID=B.ProjectID");
            strSql.Append(" left join tb_InPersonnel as C on T.DetectPersonnelID=C.PersonnelID");
            strSql.Append(" left join tb_ExpePlan as D on T.TaskNo=D.TaskNo");
            strSql.Append(" left join tb_Sample as E on T.SampleID=E.id");
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
        /// 根据样品名称获取对应的原始记录ID集合
        /// </summary>
        /// <param name="SampleID">样品ID</param>
        /// <returns></returns>
        public DataTable GetRecordIDListBySampleID(int SampleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RecordID from tb_OriginalRecord as A left join tb_ExpePlan as B on A.TaskNo=B.TaskNo where B.SampleID=" + SampleID + " group by RecordID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion

    }
}
