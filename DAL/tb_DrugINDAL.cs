using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class tb_DrugINDAL
    {
        public tb_DrugINDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DrugIN");
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
        public int Add(tb_DrugIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DrugIN(");
            strSql.Append("drugId,drugCode,EnterDate,amount,putArea,isMSDS,remark,CreateUser,CreateDate,UpdateUser,UpdateDate,temp1,temp2,productDate,validDate,manufacturers,GPS)");
            strSql.Append(" values (");
            strSql.Append("@drugId,@drugCode,@EnterDate,@amount,@putArea,@isMSDS,@remark,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate,@temp1,@temp2,@productDate,@validDate,@manufacturers,@GPS)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@drugId", SqlDbType.Int,4),
					new SqlParameter("@drugCode", SqlDbType.VarChar,100),
					new SqlParameter("@EnterDate", SqlDbType.DateTime),
					new SqlParameter("@amount", SqlDbType.Decimal,9),
					new SqlParameter("@putArea", SqlDbType.NVarChar,500),
					new SqlParameter("@isMSDS", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@CreateUser", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.Int,4),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@productDate", SqlDbType.DateTime),
					new SqlParameter("@validDate", SqlDbType.DateTime),
					new SqlParameter("@manufacturers", SqlDbType.NVarChar,500),
					new SqlParameter("@GPS", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.drugId;
            parameters[1].Value = model.drugCode;
            parameters[2].Value = model.EnterDate;
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
        public bool Update(tb_DrugIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DrugIN set ");
            strSql.Append("drugId=@drugId,");
            strSql.Append("drugCode=@drugCode,");
            strSql.Append("EnterDate=@EnterDate,");
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
            strSql.Append("GPS=@GPS");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@drugId", SqlDbType.Int,4),
					new SqlParameter("@drugCode", SqlDbType.VarChar,100),
					new SqlParameter("@EnterDate", SqlDbType.DateTime),
					new SqlParameter("@amount", SqlDbType.Decimal,9),
					new SqlParameter("@putArea", SqlDbType.NVarChar,500),
					new SqlParameter("@isMSDS", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.Text),
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
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.drugId;
            parameters[1].Value = model.drugCode;
            parameters[2].Value = model.EnterDate;
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
            parameters[17].Value = model.id;

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
            strSql.Append("delete from tb_DrugIN ");
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
            strSql.Append("delete from tb_DrugIN ");
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
        public tb_DrugIN GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_DrugIN ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_DrugIN model = new tb_DrugIN();
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
        public tb_DrugIN DataRowToModel(DataRow row)
        {
            tb_DrugIN model = new tb_DrugIN();
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
                if (row["EnterDate"] != null && row["EnterDate"].ToString() != "")
                {
                    model.EnterDate = DateTime.Parse(row["EnterDate"].ToString());
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
            strSql.Append(" FROM View_DrugIN ");
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
            strSql.Append(" FROM View_DrugIN ");
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
            strSql.Append("select count(1) FROM tb_DrugIN ");
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
            strSql.Append(")AS Row, T.*  from View_DrugIN T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod

        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}