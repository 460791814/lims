using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class tb_DrugDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(tb_Drug model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Drug(");
            strSql.Append("drugName,drugCode,drugType,unit,productDate,validDate,amount,manufacturers,cabinet,registrant,riskLevel,isMSDS,remark,createUser,createDate,updateUser,updateDate,temp1,temp2)");
            strSql.Append(" values (");
            strSql.Append("@drugName,@drugCode,@drugType,@unit,@productDate,@validDate,@amount,@manufacturers,@cabinet,@registrant,@riskLevel,@isMSDS,@remark,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@drugName", SqlDbType.NVarChar,200),
					new SqlParameter("@drugCode", SqlDbType.VarChar,300),
					new SqlParameter("@drugType", SqlDbType.Int,4),
					new SqlParameter("@unit", SqlDbType.Int,4),
					new SqlParameter("@productDate", SqlDbType.DateTime),
					new SqlParameter("@validDate", SqlDbType.DateTime),
					new SqlParameter("@amount", SqlDbType.Decimal,9),
					new SqlParameter("@manufacturers", SqlDbType.NVarChar,500),
					new SqlParameter("@cabinet", SqlDbType.Int,4),
					new SqlParameter("@registrant", SqlDbType.Int,4),
					new SqlParameter("@riskLevel", SqlDbType.NVarChar,50),
					new SqlParameter("@isMSDS", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text)};
            parameters[0].Value = model.drugName;
            parameters[1].Value = model.drugCode;
            parameters[2].Value = model.drugType;
            parameters[3].Value = model.unit;
            parameters[4].Value = model.productDate;
            parameters[5].Value = model.validDate;
            parameters[6].Value = model.amount;
            parameters[7].Value = model.manufacturers;
            parameters[8].Value = model.cabinet;
            parameters[9].Value = model.registrant;
            parameters[10].Value = model.riskLevel;
            parameters[11].Value = model.isMSDS;
            parameters[12].Value = model.remark;
            parameters[13].Value = model.createUser;
            parameters[14].Value = model.createDate;
            parameters[15].Value = model.updateUser;
            parameters[16].Value = model.updateDate;
            parameters[17].Value = model.temp1;
            parameters[18].Value = model.temp2;

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
        public bool Update(tb_Drug model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Drug set ");
            strSql.Append("drugName=@drugName,");
            strSql.Append("drugCode=@drugCode,");
            strSql.Append("drugType=@drugType,");
            strSql.Append("unit=@unit,");
            strSql.Append("productDate=@productDate,");
            strSql.Append("validDate=@validDate,");
            strSql.Append("amount=@amount,");
            strSql.Append("manufacturers=@manufacturers,");
            strSql.Append("cabinet=@cabinet,");
            strSql.Append("registrant=@registrant,");
            strSql.Append("riskLevel=@riskLevel,");
            strSql.Append("isMSDS=@isMSDS,");
            strSql.Append("remark=@remark,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@drugName", SqlDbType.NVarChar,200),
					new SqlParameter("@drugCode", SqlDbType.VarChar,300),
					new SqlParameter("@drugType", SqlDbType.Int,4),
					new SqlParameter("@unit", SqlDbType.Int,4),
					new SqlParameter("@productDate", SqlDbType.DateTime),
					new SqlParameter("@validDate", SqlDbType.DateTime),
					new SqlParameter("@amount", SqlDbType.Decimal,9),
					new SqlParameter("@manufacturers", SqlDbType.NVarChar,500),
					new SqlParameter("@cabinet", SqlDbType.Int,4),
					new SqlParameter("@registrant", SqlDbType.Int,4),
					new SqlParameter("@riskLevel", SqlDbType.NVarChar,50),
					new SqlParameter("@isMSDS", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.drugName;
            parameters[1].Value = model.drugCode;
            parameters[2].Value = model.drugType;
            parameters[3].Value = model.unit;
            parameters[4].Value = model.productDate;
            parameters[5].Value = model.validDate;
            parameters[6].Value = model.amount;
            parameters[7].Value = model.manufacturers;
            parameters[8].Value = model.cabinet;
            parameters[9].Value = model.registrant;
            parameters[10].Value = model.riskLevel;
            parameters[11].Value = model.isMSDS;
            parameters[12].Value = model.remark;
            parameters[13].Value = model.createUser;
            parameters[14].Value = model.createDate;
            parameters[15].Value = model.updateUser;
            parameters[16].Value = model.updateDate;
            parameters[17].Value = model.temp1;
            parameters[18].Value = model.temp2;
            parameters[19].Value = model.id;

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
        /// 得到一个对象实体
        /// </summary>
        public tb_Drug GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,drugName,drugCode,drugType,unit,productDate,validDate,amount,manufacturers,cabinet,registrant,riskLevel,isMSDS,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 from tb_Drug ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_Drug model = new tb_Drug();
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
        public tb_Drug DataRowToModel(DataRow row)
        {
            tb_Drug model = new tb_Drug();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["drugName"] != null)
                {
                    model.drugName = row["drugName"].ToString();
                }
                if (row["drugCode"] != null)
                {
                    model.drugCode = row["drugCode"].ToString();
                }
                if (row["drugType"] != null && row["drugType"].ToString() != "")
                {
                    model.drugType = int.Parse(row["drugType"].ToString());
                }
                if (row["unit"] != null && row["unit"].ToString() != "")
                {
                    model.unit = int.Parse(row["unit"].ToString());
                }
                if (row["productDate"] != null && row["productDate"].ToString() != "")
                {
                    model.productDate = DateTime.Parse(row["productDate"].ToString());
                }
                if (row["validDate"] != null && row["validDate"].ToString() != "")
                {
                    model.validDate = DateTime.Parse(row["validDate"].ToString());
                }
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = decimal.Parse(row["amount"].ToString());
                }
                if (row["manufacturers"] != null)
                {
                    model.manufacturers = row["manufacturers"].ToString();
                }
                if (row["cabinet"] != null && row["cabinet"].ToString() != "")
                {
                    model.cabinet = int.Parse(row["cabinet"].ToString());
                }
                if (row["registrant"] != null && row["registrant"].ToString() != "")
                {
                    model.registrant = int.Parse(row["registrant"].ToString());
                }
                if (row["riskLevel"] != null)
                {
                    model.riskLevel = row["riskLevel"].ToString();
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
                if (row["temp1"] != null)
                {
                    model.temp1 = row["temp1"].ToString();
                }
                if (row["temp2"] != null)
                {
                    model.temp2 = row["temp2"].ToString();
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
            strSql.Append("select id,drugName,drugCode,drugType,unit,productDate,validDate,amount,manufacturers,cabinet,registrant,riskLevel,isMSDS,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_Drug ");
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
            strSql.Append(" id,drugName,drugCode,drugType,unit,productDate,validDate,amount,manufacturers,cabinet,registrant,riskLevel,isMSDS,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_Drug ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取药品单位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUNIT(int id)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select danwei from View_Drug");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
                parameters[0].Value = id;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                return ds.Tables[0].Rows[0]["danwei"].ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Drug");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_Drug ");
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
            strSql.Append("delete from tb_Drug ");
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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_Drug ");
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
                strSql.Append("order by T." + orderby + " desc");
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from View_Drug T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod

        /// <summary>
        /// 药品盘点
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDrugListForCheck(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append(" (");
            strSql1.Append(" SELECT     tb_Base_1.baseName as danwei, dbo.tb_Base.baseName AS weixianxing, SUM(dbo.tb_DrugIN.amount) AS ruku, SUM(dbo.tb_DrugOUT.amount) AS chuku, dbo.tb_Drug.drugName, dbo.tb_Drug.drugCode, dbo.tb_Drug.amount  ");
            strSql1.Append(" FROM         dbo.tb_Drug INNER JOIN ");
            strSql1.Append(" dbo.tb_DrugIN ON dbo.tb_Drug.id = dbo.tb_DrugIN.drugId INNER JOIN ");
            strSql1.Append(" dbo.tb_DrugOUT ON dbo.tb_Drug.id = dbo.tb_DrugOUT.id INNER JOIN ");
            strSql1.Append("  dbo.tb_Base AS tb_Base_1 ON dbo.tb_Drug.unit = tb_Base_1.id INNER JOIN ");
            strSql1.Append("  dbo.tb_Base ON dbo.tb_Drug.riskLevel = dbo.tb_Base.id ");
            strSql1.Append(strWhere); strWhere = "";
            strSql1.Append(" GROUP BY tb_Base_1.baseName, dbo.tb_Base.baseName, dbo.tb_Drug.drugName, dbo.tb_Drug.drugCode, dbo.tb_Drug.amount ");
            strSql1.Append(" )");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.drugName desc");
            }
            strSql.Append(")AS Row, T.*  from " + strSql1.ToString() + " T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return dt;
        }

        /// <summary>
        /// 药品盘点 总数
        /// </summary>
        /// <returns></returns>
        public int GetDrugListForCheckCount(string where)
        {
            try
            {
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append(" SELECT     tb_Base_1.baseName as danwei, dbo.tb_Base.baseName AS weixianxing, SUM(dbo.tb_DrugIN.amount) AS ruku, SUM(dbo.tb_DrugOUT.amount) AS chuku, dbo.tb_Drug.drugName, dbo.tb_Drug.drugCode, dbo.tb_Drug.amount  ");
                strSql1.Append(" FROM         dbo.tb_Drug INNER JOIN ");
                strSql1.Append(" dbo.tb_DrugIN ON dbo.tb_Drug.id = dbo.tb_DrugIN.drugId INNER JOIN ");
                strSql1.Append(" dbo.tb_DrugOUT ON dbo.tb_Drug.id = dbo.tb_DrugOUT.drugId INNER JOIN ");
                strSql1.Append("  dbo.tb_Base AS tb_Base_1 ON dbo.tb_Drug.unit = tb_Base_1.id INNER JOIN ");
                strSql1.Append("  dbo.tb_Base ON dbo.tb_Drug.riskLevel = dbo.tb_Base.id ");
                strSql1.Append(where);
                strSql1.Append(" GROUP BY tb_Base_1.baseName, dbo.tb_Base.baseName, dbo.tb_Drug.drugName, dbo.tb_Drug.drugCode, dbo.tb_Drug.amount ");
                int count = DbHelperSQL.Query(strSql1.ToString()).Tables[0].Rows.Count;
                return count;
            }
            catch
            {
                return 0;
            }
        }

        public DataSet GetAllView_Drug(string where)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(" select * from View_Drug ");
            if (!string.IsNullOrEmpty(where))
            {
                strsql.Append(" where " + where);
            }
            return DbHelperSQL.Query(strsql.ToString());
        }
    }
}