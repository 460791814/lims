using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class tb_DrugOUTDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DrugOUT");
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
        public int Add(tb_DrugOUT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DrugOUT(");
            strSql.Append("drugId,drugCode,outDate,amount,putArea,isMSDS,remark,CreateUser,CreateDate,UpdateUser,UpdateDate,temp1,temp2,productDate,validDate,manufacturers,GPS,recipients)");
            strSql.Append(" values (");
            strSql.Append("@drugId,@drugCode,@outDate,@amount,@putArea,@isMSDS,@remark,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate,@temp1,@temp2,@productDate,@validDate,@manufacturers,@GPS,@recipients)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@drugId", SqlDbType.Int,4),
					new SqlParameter("@drugCode", SqlDbType.VarChar,100),
					new SqlParameter("@outDate", SqlDbType.DateTime),
					new SqlParameter("@amount", SqlDbType.Decimal,9),
					new SqlParameter("@putArea", SqlDbType.NVarChar,500),
					new SqlParameter("@isMSDS", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@productDate", SqlDbType.DateTime),
					new SqlParameter("@validDate", SqlDbType.DateTime),
					new SqlParameter("@manufacturers", SqlDbType.NVarChar,500),
					new SqlParameter("@GPS", SqlDbType.NVarChar,-1),
					new SqlParameter("@recipients", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.drugId;
            parameters[1].Value = model.drugCode;
            parameters[2].Value = model.outDate;
            parameters[3].Value = model.amount;
            parameters[4].Value = model.putArea;
            parameters[5].Value = model.isMSDS;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.CreateUser;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.UpdateUser;
            parameters[10].Value = model.UpdateDate;
            parameters[11].Value = model.temp1;
            parameters[12].Value = model.temp2;
            parameters[13].Value = model.productDate;
            parameters[14].Value = model.validDate;
            parameters[15].Value = model.manufacturers;
            parameters[16].Value = model.GPS;
            parameters[17].Value = model.recipients;

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
        public bool Update(tb_DrugOUT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DrugOUT set ");
            strSql.Append("drugId=@drugId,");
            strSql.Append("drugCode=@drugCode,");
            strSql.Append("outDate=@outDate,");
            strSql.Append("amount=@amount,");
            strSql.Append("putArea=@putArea,");
            strSql.Append("isMSDS=@isMSDS,");
            strSql.Append("remark=@remark,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateDate=@UpdateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2,");
            strSql.Append("productDate=@productDate,");
            strSql.Append("validDate=@validDate,");
            strSql.Append("manufacturers=@manufacturers,");
            strSql.Append("GPS=@GPS,");
            strSql.Append("recipients=@recipients");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@drugId", SqlDbType.Int,4),
					new SqlParameter("@drugCode", SqlDbType.VarChar,100),
					new SqlParameter("@outDate", SqlDbType.DateTime),
					new SqlParameter("@amount", SqlDbType.Decimal,9),
					new SqlParameter("@putArea", SqlDbType.NVarChar,500),
					new SqlParameter("@isMSDS", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@productDate", SqlDbType.DateTime),
					new SqlParameter("@validDate", SqlDbType.DateTime),
					new SqlParameter("@manufacturers", SqlDbType.NVarChar,500),
					new SqlParameter("@GPS", SqlDbType.NVarChar,-1),
					new SqlParameter("@recipients", SqlDbType.NVarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.drugId;
            parameters[1].Value = model.drugCode;
            parameters[2].Value = model.outDate;
            parameters[3].Value = model.amount;
            parameters[4].Value = model.putArea;
            parameters[5].Value = model.isMSDS;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.CreateUser;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.UpdateUser;
            parameters[10].Value = model.UpdateDate;
            parameters[11].Value = model.temp1;
            parameters[12].Value = model.temp2;
            parameters[13].Value = model.productDate;
            parameters[14].Value = model.validDate;
            parameters[15].Value = model.manufacturers;
            parameters[16].Value = model.GPS;
            parameters[17].Value = model.recipients;
            parameters[18].Value = model.id;

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
            strSql.Append("delete from tb_DrugOUT ");
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
            strSql.Append("delete from tb_DrugOUT ");
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
        public tb_DrugOUT GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_DrugOUT ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_DrugOUT model = new tb_DrugOUT();
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
        public tb_DrugOUT DataRowToModel(DataRow row)
        {
            tb_DrugOUT model = new tb_DrugOUT();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["drugId"] != null && row["drugId"].ToString() != "")
                {
                    model.drugId = int.Parse(row["drugId"].ToString());
                }
                if (row["drugCode"] != null)
                {
                    model.drugCode = row["drugCode"].ToString();
                }
                if (row["outDate"] != null && row["outDate"].ToString() != "")
                {
                    model.outDate = DateTime.Parse(row["outDate"].ToString());
                }
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = decimal.Parse(row["amount"].ToString());
                }
                if (row["putArea"] != null)
                {
                    model.putArea = row["putArea"].ToString();
                }
                if (row["isMSDS"] != null && row["isMSDS"].ToString() != "")
                {
                    if ((row["isMSDS"].ToString() == "1") || (row["isMSDS"].ToString().ToLower() == "true"))
                    {
                        model.isMSDS = true;
                    }
                    else
                    {
                        model.isMSDS = false;
                    }
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["CreateUser"] != null && row["CreateUser"].ToString() != "")
                {
                    model.CreateUser = int.Parse(row["CreateUser"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["UpdateUser"] != null && row["UpdateUser"].ToString() != "")
                {
                    model.UpdateUser = int.Parse(row["UpdateUser"].ToString());
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
                if (row["temp1"] != null)
                {
                    model.temp1 = row["temp1"].ToString();
                }
                if (row["temp2"] != null)
                {
                    model.temp2 = row["temp2"].ToString();
                }
                if (row["productDate"] != null && row["productDate"].ToString() != "")
                {
                    model.productDate = DateTime.Parse(row["productDate"].ToString());
                }
                if (row["validDate"] != null && row["validDate"].ToString() != "")
                {
                    model.validDate = DateTime.Parse(row["validDate"].ToString());
                }
                if (row["manufacturers"] != null)
                {
                    model.manufacturers = row["manufacturers"].ToString();
                }
                if (row["GPS"] != null)
                {
                    model.GPS = row["GPS"].ToString();
                }
                if (row["recipients"] != null)
                {
                    model.recipients = row["recipients"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM tb_DrugOUT ");
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
            strSql.Append(" id,drugId,drugCode,outDate,amount,putArea,isMSDS,remark,CreateUser,CreateDate,UpdateUser,UpdateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_DrugOUT ");
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
            strSql.Append("select count(1) FROM tb_DrugOUT ");
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
            strSql.Append(")AS Row, T.*  from View_DrugOUT T ");
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
            parameters[0].Value = "tb_DrugOUT";
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
        #region 药品统计
        /// <summary>
        /// 药品统计（图表）
        /// </summary>
        /// <param name="_date">日期</param>
        /// <param name="_datetype">日期类型（年或月）</param>
        /// <param name="_compayid">单位ID</param>
        /// <param name="_riskid">危险性等级</param>
        /// <returns></returns>
        public DataSet GetDrugOutForReport(DateTime _date, string _datetype, string _compayid, string _riskid, string _drugid)
        {
            try
            {
                string sql = "";
                String whereRisk = "";
                String whereCompany = "";
                String whereDate = "";
                String whereDrug = "";
                if (!string.IsNullOrEmpty(_drugid))
                {
                    whereDrug = " and dbo.tb_Drug.id in (" + _drugid.Substring(0, _drugid.Length - 1) + ") ";
                }
                if (!_riskid.Equals("-1"))
                {
                    whereRisk = string.Format(" and dbo.tb_Drug.riskLevel = {0} ", _riskid);
                }
                if (!_compayid.Equals("-1"))
                {
                    whereCompany = string.Format(" and dbo.tb_InPersonnel.AreaID in ({0})  ", _compayid);
                }
                if (_datetype.Equals("nian"))
                {
                    whereDate = " and Year(dbo.tb_DrugOUT.outDate) = " + _date.Year;
                }
                else if (_datetype.Equals("yue"))
                {
                    whereDate = " and Year(dbo.tb_DrugOUT.outDate) " + _date.Year;
                    whereDate += " and Month(dbo.tb_DrugOUT.outDate) " + _date.Month;
                }
                sql = @"SELECT tb_Base_1.baseName AS danwei, dbo.tb_Base.baseName AS weixianxing, 
                              SUM(dbo.tb_DrugIN.amount) AS ruku, SUM(dbo.tb_DrugOUT.amount) AS chuku, 
                              dbo.tb_Drug.drugName, dbo.tb_Drug.drugCode,(SUM(dbo.tb_DrugIN.amount) - SUM(dbo.tb_DrugOUT.amount)) as amount, 
                              dbo.tb_DrugIN.productDate, dbo.tb_DrugIN.validDate, dbo.tb_Area.AreaName, 
                              dbo.tb_Drug.unit, tb_Base_2.baseName AS daanwei
                              FROM dbo.tb_Drug INNER JOIN
                              dbo.tb_DrugIN ON dbo.tb_Drug.id = dbo.tb_DrugIN.drugId INNER JOIN
                              dbo.tb_DrugOUT ON dbo.tb_Drug.id = dbo.tb_DrugOUT.id INNER JOIN
                              dbo.tb_Base AS tb_Base_1 ON dbo.tb_Drug.unit = tb_Base_1.id INNER JOIN
                              dbo.tb_Base ON dbo.tb_Drug.riskLevel = dbo.tb_Base.id INNER JOIN
                              dbo.tb_InPersonnel ON 
                              dbo.tb_DrugOUT.CreateUser = dbo.tb_InPersonnel.PersonnelID INNER JOIN
                              dbo.tb_Area ON dbo.tb_InPersonnel.AreaID = dbo.tb_Area.AreaID INNER JOIN
                              dbo.tb_Base AS tb_Base_2 ON dbo.tb_Drug.unit = tb_Base_2.id ";
                sql += @" where (DATEDIFF(day, dbo.tb_DrugIN.productDate, dbo.tb_DrugOUT.productDate) = 0) AND
       (DATEDIFF(day, dbo.tb_DrugIN.validDate, dbo.tb_DrugOUT.validDate) = 0) ";
                sql += whereDate;
                sql += whereDrug;
                sql += whereCompany;
                sql += whereRisk;
                sql += @"  GROUP BY tb_Base_1.baseName, dbo.tb_Base.baseName, dbo.tb_Drug.drugName, 
                                  dbo.tb_Drug.drugCode, dbo.tb_Drug.amount, dbo.tb_DrugIN.productDate, 
                                  dbo.tb_DrugIN.validDate, dbo.tb_Area.AreaName, dbo.tb_Drug.unit, 
                                  tb_Base_2.baseName ";
                sql += " order by dbo.tb_DrugIN.validDate desc";
                return DbHelperSQL.Query(sql.ToString());
            }
            catch
            {
                return new DataSet();
            }
        }

        /// <summary>
        /// 药品统计（列表）
        /// </summary>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <param name="_cids"></param>
        /// <param name="_riskid"></param>
        /// <returns></returns>
        public DataSet GetDrugOutForReport(DateTime _sDate, DateTime _eDate, int _cid, int _riskid)
        {
            try
            {
                string sql = "";
                String whereRisk = "";
                String whereCompany = "";
                if (_riskid > -1)
                {
                    whereRisk = string.Format(" and dbo.tb_Drug.riskLevel = {0} ", _riskid);
                }
                if (_cid > -1)
                {
                    whereCompany = string.Format(" and dbo.tb_InPersonnel.AreaID in ({0})  ", _cid);
                }

                sql = @" SELECT tb_Base_1.baseName AS danwei, dbo.tb_Base.baseName AS weixianxing, 
                              SUM(dbo.tb_DrugIN.amount) AS ruku, SUM(dbo.tb_DrugOUT.amount) AS chuku, 
                              dbo.tb_Drug.drugName, dbo.tb_Drug.drugCode,(SUM(dbo.tb_DrugIN.amount) - SUM(dbo.tb_DrugOUT.amount)) as amount, 
                              dbo.tb_DrugIN.productDate, dbo.tb_DrugIN.validDate, dbo.tb_Area.AreaName, 
                              dbo.tb_Drug.unit, tb_Base_2.baseName AS daanwei
                              FROM dbo.tb_Drug INNER JOIN
                              dbo.tb_DrugIN ON dbo.tb_Drug.id = dbo.tb_DrugIN.drugId INNER JOIN
                              dbo.tb_DrugOUT ON dbo.tb_Drug.id = dbo.tb_DrugOUT.id INNER JOIN
                              dbo.tb_Base AS tb_Base_1 ON dbo.tb_Drug.unit = tb_Base_1.id INNER JOIN
                              dbo.tb_Base ON dbo.tb_Drug.riskLevel = dbo.tb_Base.id INNER JOIN
                              dbo.tb_InPersonnel ON 
                              dbo.tb_DrugOUT.CreateUser = dbo.tb_InPersonnel.PersonnelID INNER JOIN
                              dbo.tb_Area ON dbo.tb_InPersonnel.AreaID = dbo.tb_Area.AreaID INNER JOIN
                              dbo.tb_Base AS tb_Base_2 ON dbo.tb_Drug.unit = tb_Base_2.id ";
                sql += string.Format(@" where (DATEDIFF(day, dbo.tb_DrugIN.productDate, dbo.tb_DrugOUT.productDate) = 0) AND
       (DATEDIFF(day, dbo.tb_DrugIN.validDate, dbo.tb_DrugOUT.validDate) = 0) and dbo.tb_DrugOUT.outDate BETWEEN '{0}' and '{1}' ", _sDate.ToShortDateString(), _eDate.ToShortDateString());
                sql += whereCompany;
                sql += whereRisk;
                sql += @"  GROUP BY tb_Base_1.baseName, dbo.tb_Base.baseName, dbo.tb_Drug.drugName, 
                                  dbo.tb_Drug.drugCode, dbo.tb_Drug.amount, dbo.tb_DrugIN.productDate, 
                                  dbo.tb_DrugIN.validDate, dbo.tb_Area.AreaName, dbo.tb_Drug.unit, 
                                  tb_Base_2.baseName ";
                sql += " order by dbo.tb_DrugIN.validDate desc";
                return DbHelperSQL.Query(sql.ToString());
            }
            catch
            {
                return new DataSet();
            }
        }
        #endregion 药品统计
        #endregion  ExtensionMethod


    }
}