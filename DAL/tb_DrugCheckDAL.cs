using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class tb_DrugCheckDAL
    {
        public tb_DrugCheckDAL()
        { }

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DrugCheck");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(tb_DrugCheck model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DrugCheck(");
            strSql.Append("drugCode,drugName,drugId,drugInId,drugOutId,outDate,unit,amountIN,amountOUT,amount,riskLevel,checkDate,checkUser,checkUserId,auditstatus,auditUser,auditUserId,remark,isDelete,createUser,createDate,updateUser,updateDate)");
            strSql.Append(" values (");
            strSql.Append("@drugCode,@drugName,@drugId,@drugInId,@drugOutId,@outDate,@unit,@amountIN,@amountOUT,@amount,@riskLevel,@checkDate,@checkUser,@checkUserId,@auditstatus,@auditUser,@auditUserId,@remark,@isDelete,@createUser,@createDate,@updateUser,@updateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@drugCode", SqlDbType.NVarChar,-1),
					new SqlParameter("@drugName", SqlDbType.NVarChar,-1),
					new SqlParameter("@drugId", SqlDbType.Int,4),
					new SqlParameter("@drugInId", SqlDbType.Int,4),
					new SqlParameter("@drugOutId", SqlDbType.Int,4),
					new SqlParameter("@outDate", SqlDbType.DateTime),
					new SqlParameter("@unit", SqlDbType.NVarChar,-1),
					new SqlParameter("@amountIN", SqlDbType.Int,4),
					new SqlParameter("@amountOUT", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@riskLevel", SqlDbType.NVarChar,-1),
					new SqlParameter("@checkDate", SqlDbType.DateTime),
					new SqlParameter("@checkUser", SqlDbType.NVarChar,-1),
					new SqlParameter("@checkUserId", SqlDbType.Int,4),
					new SqlParameter("@auditstatus", SqlDbType.NVarChar,-1),
					new SqlParameter("@auditUser", SqlDbType.NVarChar,-1),
					new SqlParameter("@auditUserId", SqlDbType.NVarChar,-1),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.drugCode;
            parameters[1].Value = model.drugName;
            parameters[2].Value = model.drugId;
            parameters[3].Value = model.drugInId;
            parameters[4].Value = model.drugOutId;
            parameters[5].Value = model.outDate;
            parameters[6].Value = model.unit;
            parameters[7].Value = model.amountIN;
            parameters[8].Value = model.amountOUT;
            parameters[9].Value = model.amount;
            parameters[10].Value = model.riskLevel;
            parameters[11].Value = model.checkDate;
            parameters[12].Value = model.checkUser;
            parameters[13].Value = model.checkUserId;
            parameters[14].Value = model.auditstatus;
            parameters[15].Value = model.auditUser;
            parameters[16].Value = model.auditUserId;
            parameters[17].Value = model.remark;
            parameters[18].Value = model.isDelete;
            parameters[19].Value = model.createUser;
            parameters[20].Value = model.createDate;
            parameters[21].Value = model.updateUser;
            parameters[22].Value = model.updateDate;

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
        public bool Update(tb_DrugCheck model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DrugCheck set ");
            strSql.Append("drugCode=@drugCode,");
            strSql.Append("drugName=@drugName,");
            strSql.Append("drugId=@drugId,");
            strSql.Append("drugInId=@drugInId,");
            strSql.Append("drugOutId=@drugOutId,");
            strSql.Append("outDate=@outDate,");
            strSql.Append("unit=@unit,");
            strSql.Append("amountIN=@amountIN,");
            strSql.Append("amountOUT=@amountOUT,");
            strSql.Append("amount=@amount,");
            strSql.Append("riskLevel=@riskLevel,");
            strSql.Append("checkDate=@checkDate,");
            strSql.Append("checkUser=@checkUser,");
            strSql.Append("checkUserId=@checkUserId,");
            strSql.Append("auditstatus=@auditstatus,");
            strSql.Append("auditUser=@auditUser,");
            strSql.Append("auditUserId=@auditUserId,");
            strSql.Append("remark=@remark,");
            strSql.Append("isDelete=@isDelete,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@drugCode", SqlDbType.NVarChar,-1),
					new SqlParameter("@drugName", SqlDbType.NVarChar,-1),
					new SqlParameter("@drugId", SqlDbType.Int,4),
					new SqlParameter("@drugInId", SqlDbType.Int,4),
					new SqlParameter("@drugOutId", SqlDbType.Int,4),
					new SqlParameter("@outDate", SqlDbType.DateTime),
					new SqlParameter("@unit", SqlDbType.NVarChar,-1),
					new SqlParameter("@amountIN", SqlDbType.Int,4),
					new SqlParameter("@amountOUT", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@riskLevel", SqlDbType.NVarChar,-1),
					new SqlParameter("@checkDate", SqlDbType.DateTime),
					new SqlParameter("@checkUser", SqlDbType.NVarChar,-1),
					new SqlParameter("@checkUserId", SqlDbType.Int,4),
					new SqlParameter("@auditstatus", SqlDbType.NVarChar,-1),
					new SqlParameter("@auditUser", SqlDbType.NVarChar,-1),
					new SqlParameter("@auditUserId", SqlDbType.NVarChar,-1),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@isDelete", SqlDbType.Bit,1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.drugCode;
            parameters[1].Value = model.drugName;
            parameters[2].Value = model.drugId;
            parameters[3].Value = model.drugInId;
            parameters[4].Value = model.drugOutId;
            parameters[5].Value = model.outDate;
            parameters[6].Value = model.unit;
            parameters[7].Value = model.amountIN;
            parameters[8].Value = model.amountOUT;
            parameters[9].Value = model.amount;
            parameters[10].Value = model.riskLevel;
            parameters[11].Value = model.checkDate;
            parameters[12].Value = model.checkUser;
            parameters[13].Value = model.checkUserId;
            parameters[14].Value = model.auditstatus;
            parameters[15].Value = model.auditUser;
            parameters[16].Value = model.auditUserId;
            parameters[17].Value = model.remark;
            parameters[18].Value = model.isDelete;
            parameters[19].Value = model.createUser;
            parameters[20].Value = model.createDate;
            parameters[21].Value = model.updateUser;
            parameters[22].Value = model.updateDate;
            parameters[23].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_DrugCheck ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_DrugCheck ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public tb_DrugCheck GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,drugCode,drugName,drugId,drugInId,drugOutId,outDate,unit,amountIN,amountOUT,amount,riskLevel,checkDate,checkUser,checkUserId,auditstatus,auditUser,auditUserId,remark,isDelete,createUser,createDate,updateUser,updateDate from tb_DrugCheck ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_DrugCheck model = new tb_DrugCheck();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public tb_DrugCheck DataRowToModel(DataRow row)
        {
            tb_DrugCheck model = new tb_DrugCheck();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["drugCode"] != null)
                {
                    model.drugCode = row["drugCode"].ToString();
                }
                if (row["drugName"] != null)
                {
                    model.drugName = row["drugName"].ToString();
                }
                if (row["drugId"] != null && row["drugId"].ToString() != "")
                {
                    model.drugId = int.Parse(row["drugId"].ToString());
                }
                if (row["drugInId"] != null && row["drugInId"].ToString() != "")
                {
                    model.drugInId = int.Parse(row["drugInId"].ToString());
                }
                if (row["drugOutId"] != null && row["drugOutId"].ToString() != "")
                {
                    model.drugOutId = int.Parse(row["drugOutId"].ToString());
                }
                if (row["outDate"] != null && row["outDate"].ToString() != "")
                {
                    model.outDate = DateTime.Parse(row["outDate"].ToString());
                }
                if (row["unit"] != null)
                {
                    model.unit = row["unit"].ToString();
                }
                if (row["amountIN"] != null && row["amountIN"].ToString() != "")
                {
                    model.amountIN = int.Parse(row["amountIN"].ToString());
                }
                if (row["amountOUT"] != null && row["amountOUT"].ToString() != "")
                {
                    model.amountOUT = int.Parse(row["amountOUT"].ToString());
                }
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = int.Parse(row["amount"].ToString());
                }
                if (row["riskLevel"] != null)
                {
                    model.riskLevel = row["riskLevel"].ToString();
                }
                if (row["checkDate"] != null && row["checkDate"].ToString() != "")
                {
                    model.checkDate = DateTime.Parse(row["checkDate"].ToString());
                }
                if (row["checkUser"] != null)
                {
                    model.checkUser = row["checkUser"].ToString();
                }
                if (row["checkUserId"] != null && row["checkUserId"].ToString() != "")
                {
                    model.checkUserId = int.Parse(row["checkUserId"].ToString());
                }
                if (row["auditstatus"] != null)
                {
                    model.auditstatus = row["auditstatus"].ToString();
                }
                if (row["auditUser"] != null)
                {
                    model.auditUser = row["auditUser"].ToString();
                }
                if (row["auditUserId"] != null)
                {
                    model.auditUserId = row["auditUserId"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["isDelete"] != null && row["isDelete"].ToString() != "")
                {
                    if ((row["isDelete"].ToString() == "1") || (row["isDelete"].ToString().ToLower() == "true"))
                    {
                        model.isDelete = true;
                    }
                    else
                    {
                        model.isDelete = false;
                    }
                }
                if (row["createUser"] != null && row["createUser"].ToString() != "")
                {
                    model.createUser = int.Parse(row["createUser"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["updateUser"] != null && row["updateUser"].ToString() != "")
                {
                    model.updateUser = int.Parse(row["updateUser"].ToString());
                }
                if (row["updateDate"] != null && row["updateDate"].ToString() != "")
                {
                    model.updateDate = DateTime.Parse(row["updateDate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,drugCode,drugName,drugId,drugInId,drugOutId,outDate,unit,amountIN,amountOUT,amount,riskLevel,checkDate,checkUser,checkUserId,auditstatus,auditUser,auditUserId,remark,isDelete,createUser,createDate,updateUser,updateDate ");
            strSql.Append(" FROM tb_DrugCheck ");
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
            strSql.Append(" id,drugCode,drugName,drugId,drugInId,drugOutId,outDate,unit,amountIN,amountOUT,amount,riskLevel,checkDate,checkUser,checkUserId,auditstatus,auditUser,auditUserId,remark,isDelete,createUser,createDate,updateUser,updateDate ");
            strSql.Append(" FROM tb_DrugCheck ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_DrugCheck ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_DrugCheck T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "tb_DrugCheck";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 药品统计（列表）获取数据从数据库动态计算入库和出库
        /// </summary>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <param name="_cids"></param>
        /// <param name="_riskid"></param>
        /// <returns></returns>
        public DataSet GetDrugForCheckByInAndOut(DateTime _sDate, DateTime _eDate, int _cid, string _auditstatus, string whereInPersonnel)
        {
            try
            {
                string sql = "";
                String whereCompany = "";
                if (_cid > -1)
                {
                    whereCompany = string.Format(" and dbo.tb_InPersonnel.AreaID in ({0})  ", _cid);
                }

                sql = @" SELECT tb_Base_1.baseName AS danwei, dbo.tb_Base.baseName AS weixianxing, 
                              SUM(dbo.tb_DrugIN.amount) AS ruku, SUM(dbo.tb_DrugOUT.amount) AS chuku, 
                              dbo.tb_Drug.drugName, dbo.tb_Drug.drugCode,(SUM(dbo.tb_DrugIN.amount) - SUM(dbo.tb_DrugOUT.amount)) as amount, 
                              dbo.tb_DrugIN.productDate, dbo.tb_DrugIN.validDate, dbo.tb_Area.AreaName, 
                              dbo.tb_Drug.unit, tb_Base_2.baseName AS daanwei,tb_Drug.id as durgId,tb_DrugIN.id as drugInId,tb_DrugOUT.id as drugOutId,
                              tb_DrugOUT.outDate,tb_Drug.drugCode
                              FROM dbo.tb_Drug INNER JOIN
                              dbo.tb_DrugIN ON dbo.tb_Drug.id = dbo.tb_DrugIN.drugId INNER JOIN
                              dbo.tb_DrugOUT ON dbo.tb_Drug.id = dbo.tb_DrugOUT.id INNER JOIN
                              dbo.tb_Base AS tb_Base_1 ON dbo.tb_Drug.unit = tb_Base_1.id INNER JOIN
                              dbo.tb_Base ON dbo.tb_Drug.riskLevel = dbo.tb_Base.id INNER JOIN
                              dbo.tb_InPersonnel ON 
                              dbo.tb_DrugOUT.CreateUser = dbo.tb_InPersonnel.PersonnelID INNER JOIN
                              dbo.tb_Area ON dbo.tb_InPersonnel.AreaID = dbo.tb_Area.AreaID INNER JOIN
                              dbo.tb_Base AS tb_Base_2 ON dbo.tb_Drug.unit = tb_Base_2.id  ";
                sql += string.Format(@" where (DATEDIFF(day, dbo.tb_DrugIN.productDate, dbo.tb_DrugOUT.productDate) = 0) AND
       (DATEDIFF(day, dbo.tb_DrugIN.validDate, dbo.tb_DrugOUT.validDate) = 0) and dbo.tb_DrugOUT.outDate BETWEEN '{0}' and '{1}' ", _sDate.ToShortDateString(), _eDate.ToShortDateString());
                sql += whereInPersonnel;
                sql += whereCompany;
                sql += @"  GROUP BY tb_Base_1.baseName, dbo.tb_Base.baseName, dbo.tb_Drug.drugName, 
                                  dbo.tb_Drug.drugCode, dbo.tb_Drug.amount, dbo.tb_DrugIN.productDate, 
                                  dbo.tb_DrugIN.validDate, dbo.tb_Area.AreaName, dbo.tb_Drug.unit, 
                                  tb_Base_2.baseName,tb_Drug.id,tb_DrugIN.id,tb_DrugOUT.id,tb_DrugOUT.outDate,tb_Drug.drugCode";
                sql += " order by dbo.tb_DrugIN.validDate desc";
                return DbHelperSQL.Query(sql.ToString());
            }
            catch
            {
                return new DataSet();
            }
        }

        public DataTable GetDrugCheckByCount(string where)
        {
            string sql = "select SUM(amountIN) as amountIN,SUM(amountOUT) as amountOUT,SUM(amount) as amount,drugId,drugName from tb_drugcheck ";
            if (!string.IsNullOrEmpty(where))
            {
                sql +=" where "+ where; 
            }
            sql += " group by drugId,drugName";
            return DbHelperSQL.Query(sql.ToString()).Tables[0];
        }
        #endregion  ExtensionMethod
    }
}
