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
    /// 数据访问类:tb_Laboratory
    /// </summary>
    public partial class D_tb_Laboratory
    {
        public D_tb_Laboratory()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LaboratoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Laboratory");
            strSql.Append(" where LaboratoryID=@LaboratoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@LaboratoryID", SqlDbType.Int,4)
};
            parameters[0].Value = LaboratoryID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_Laboratory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Laboratory(");
            strSql.Append("AreaID,LaboratoryName,LaboratoryTypeID,Directions,UpdateTime,OrderID,IsUse)");
            strSql.Append(" values (");
            strSql.Append("@AreaID,@LaboratoryName,@LaboratoryTypeID,@Directions,@UpdateTime,@OrderID,@IsUse)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@LaboratoryName", SqlDbType.NVarChar,50),
					new SqlParameter("@LaboratoryTypeID", SqlDbType.Int,4),
					new SqlParameter("@Directions", SqlDbType.Text),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@IsUse", SqlDbType.Int,4)};
            parameters[0].Value = model.AreaID;
            parameters[1].Value = model.LaboratoryName;
            parameters[2].Value = model.LaboratoryTypeID;
            parameters[3].Value = model.Directions;
            parameters[4].Value = model.UpdateTime;
            parameters[5].Value = model.OrderID;
            parameters[6].Value = model.IsUse;

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
        public bool Update(E_tb_Laboratory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Laboratory set ");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("LaboratoryName=@LaboratoryName,");
            strSql.Append("LaboratoryTypeID=@LaboratoryTypeID,");
            strSql.Append("Directions=@Directions,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("IsUse=@IsUse");
            strSql.Append(" where LaboratoryID=@LaboratoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@LaboratoryName", SqlDbType.NVarChar,50),
					new SqlParameter("@LaboratoryTypeID", SqlDbType.Int,4),
					new SqlParameter("@Directions", SqlDbType.Text),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@IsUse", SqlDbType.Int,4),
					new SqlParameter("@LaboratoryID", SqlDbType.Int,4)};
            parameters[0].Value = model.AreaID;
            parameters[1].Value = model.LaboratoryName;
            parameters[2].Value = model.LaboratoryTypeID;
            parameters[3].Value = model.Directions;
            parameters[4].Value = model.UpdateTime;
            parameters[5].Value = model.OrderID;
            parameters[6].Value = model.IsUse;
            parameters[7].Value = model.LaboratoryID;

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
        public bool Delete(int LaboratoryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Laboratory ");
            strSql.Append(" where LaboratoryID=@LaboratoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@LaboratoryID", SqlDbType.Int,4)
};
            parameters[0].Value = LaboratoryID;

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
        public bool DeleteList(string LaboratoryIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Laboratory ");
            strSql.Append(" where LaboratoryID in (" + LaboratoryIDlist + ")  ");
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
        public E_tb_Laboratory GetModel(int LaboratoryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LaboratoryID,AreaID,LaboratoryName,LaboratoryTypeID,Directions,UpdateTime,OrderID,IsUse from tb_Laboratory ");
            strSql.Append(" where LaboratoryID=@LaboratoryID");
            SqlParameter[] parameters = {
					new SqlParameter("@LaboratoryID", SqlDbType.Int,4)
};
            parameters[0].Value = LaboratoryID;

            E_tb_Laboratory model = new E_tb_Laboratory();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["LaboratoryID"].ToString() != "")
                {
                    model.LaboratoryID = int.Parse(ds.Tables[0].Rows[0]["LaboratoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LaboratoryName"] != null)
                {
                    model.LaboratoryName = ds.Tables[0].Rows[0]["LaboratoryName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LaboratoryTypeID"].ToString() != "")
                {
                    model.LaboratoryTypeID = int.Parse(ds.Tables[0].Rows[0]["LaboratoryTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Directions"] != null)
                {
                    model.Directions = ds.Tables[0].Rows[0]["Directions"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsUse"].ToString() != "")
                {
                    model.IsUse = int.Parse(ds.Tables[0].Rows[0]["IsUse"].ToString());
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
            strSql.Append("select LaboratoryID,AreaID,LaboratoryName,LaboratoryTypeID,Directions,UpdateTime,OrderID,IsUse ");
            strSql.Append(" FROM tb_Laboratory ");
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
            strSql.Append(" LaboratoryID,AreaID,LaboratoryName,LaboratoryTypeID,Directions,UpdateTime,OrderID,IsUse ");
            strSql.Append(" FROM tb_Laboratory ");
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
            parameters[0].Value = "tb_Laboratory";
            parameters[1].Value = "LaboratoryID";
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
            string strPageSQL = "select * from (select ROW_NUMBER() over (order by orderID) as Rid,* from({0}) as Temp ) as T";
            string strSQL = @"
                    select 
	                    Temp_Laboratory.*,
	                    Temp_DetectProject.ProjectID, 
	                    Temp_DetectProject.ProjectName, 
	                    Temp_DetectProject.DetectTime, 
	                    Temp_DetectProject.MainPerson, 
	                    Temp_DetectProject.Tel, 
	                    Temp_DetectProject.UpdateTime as DetectUpdateTime
                    from 
                    (
	                    select A.*,B.TypeName as LaboratoryTypeName from tb_Laboratory as A left join tb_TypeDict as B on A.LaboratoryTypeID=B.TypeID
                    ) as Temp_Laboratory
                    left join 
                    (
	                    select * from tb_DetectProject where ProjectID in 
	                    (
		                    select max(ProjectID) from 
		                    (
			                    select B.* from 
			                    (
				                    select LaboratoryID,max(DetectTime) as DetectTime from tb_DetectProject group by LaboratoryID
			                    ) as A
			                    inner join tb_DetectProject as B on A.LaboratoryID=B.LaboratoryID and A.DetectTime=B.DetectTime
		                    ) as T
		                    group by LaboratoryID
	                    )
                    ) as Temp_DetectProject on Temp_Laboratory.LaboratoryID=Temp_DetectProject.LaboratoryID " + ((strWhere.Length > 0) ? " where " + strWhere : "");
            total = DbHelperSQL.GetCount(strSQL);
            strPageSQL = string.Format(strPageSQL, strSQL) + string.Format(" WHERE T.Rid between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strPageSQL);
        }
        #endregion
    }
}
