/**  版本信息模板在安装目录下，可自行修改。
* tb_EasyConsumeIN.cs
*
* 功 能： N/A
* 类 名： tb_EasyConsumeIN
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/4 21:23:35   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    /// <summary>
    /// 数据访问类:tb_EasyConsumeIN
    /// </summary>
    public partial class tb_EasyConsumeINDAL
    {
        public tb_EasyConsumeINDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_EasyConsumeIN");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_EasyConsumeIN");
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
        public int Add(tb_EasyConsumeIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_EasyConsumeIN(");
            strSql.Append("eId,inDate,price,amount,inMoney,product,user1,remark,createUser,createDate,updateUser,updateDate,temp1,temp2,productDate,validDate,manufacturers,GPS)");
            strSql.Append(" values (");
            strSql.Append("@eId,@inDate,@price,@amount,@inMoney,@product,@user1,@remark,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2,@productDate,@validDate,@manufacturers,@GPS)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@eId", SqlDbType.Int,4),
					new SqlParameter("@inDate", SqlDbType.DateTime),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@inMoney", SqlDbType.Decimal,9),
					new SqlParameter("@product", SqlDbType.NVarChar,-1),
					new SqlParameter("@user1", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1),
					new SqlParameter("@productDate", SqlDbType.DateTime),
					new SqlParameter("@validDate", SqlDbType.DateTime),
					new SqlParameter("@manufacturers", SqlDbType.NVarChar,500),
                    new SqlParameter("@GPS", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.eId;
            parameters[1].Value = model.inDate;
            parameters[2].Value = model.price;
            parameters[3].Value = model.amount;
            parameters[4].Value = model.inMoney;
            parameters[5].Value = model.product;
            parameters[6].Value = model.user1;
            parameters[7].Value = model.remark;
            parameters[8].Value = model.createUser;
            parameters[9].Value = model.createDate;
            parameters[10].Value = model.updateUser;
            parameters[11].Value = model.updateDate;
            parameters[12].Value = model.temp1;
            parameters[13].Value = model.temp2;
            parameters[14].Value = model.productDate;
            parameters[15].Value = model.validDate;
            parameters[16].Value = model.manufacturers;
            parameters[17].Value = model.GPS;
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
        public bool Update(tb_EasyConsumeIN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_EasyConsumeIN set ");
            strSql.Append("eId=@eId,");
            strSql.Append("inDate=@inDate,");
            strSql.Append("price=@price,");
            strSql.Append("amount=@amount,");
            strSql.Append("inMoney=@inMoney,");
            strSql.Append("product=@product,");
            strSql.Append("user1=@user1,");
            strSql.Append("remark=@remark,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2,");
            strSql.Append("productDate=@productDate,");
            strSql.Append("validDate=@validDate,");
            strSql.Append("manufacturers=@manufacturers,");
            strSql.Append("GPS=@GPS");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@eId", SqlDbType.Int,4),
					new SqlParameter("@inDate", SqlDbType.DateTime),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@inMoney", SqlDbType.Decimal,9),
					new SqlParameter("@product", SqlDbType.NVarChar,-1),
					new SqlParameter("@user1", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1),
					new SqlParameter("@productDate", SqlDbType.DateTime),
					new SqlParameter("@validDate", SqlDbType.DateTime),
					new SqlParameter("@manufacturers", SqlDbType.NVarChar,500),
                    new SqlParameter("@GPS", SqlDbType.NVarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.eId;
            parameters[1].Value = model.inDate;
            parameters[2].Value = model.price;
            parameters[3].Value = model.amount;
            parameters[4].Value = model.inMoney;
            parameters[5].Value = model.product;
            parameters[6].Value = model.user1;
            parameters[7].Value = model.remark;
            parameters[8].Value = model.createUser;
            parameters[9].Value = model.createDate;
            parameters[10].Value = model.updateUser;
            parameters[11].Value = model.updateDate;
            parameters[12].Value = model.temp1;
            parameters[13].Value = model.temp2;
            parameters[14].Value = model.productDate;
            parameters[15].Value = model.validDate;
            parameters[16].Value = model.manufacturers;
            parameters[17].Value = model.GPS;
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
            strSql.Append("delete from tb_EasyConsumeIN ");
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
            strSql.Append("delete from tb_EasyConsumeIN ");
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
        public tb_EasyConsumeIN GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_easyconsumein");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_EasyConsumeIN model = new tb_EasyConsumeIN();
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
        public tb_EasyConsumeIN DataRowToModel(DataRow row)
        {
            tb_EasyConsumeIN model = new tb_EasyConsumeIN();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["eId"] != null && row["eId"].ToString() != "")
                {
                    model.eId = int.Parse(row["eId"].ToString());
                }
                if (row["inDate"] != null && row["inDate"].ToString() != "")
                {
                    model.inDate = DateTime.Parse(row["inDate"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = int.Parse(row["amount"].ToString());
                }
                if (row["inMoney"] != null && row["inMoney"].ToString() != "")
                {
                    model.inMoney = decimal.Parse(row["inMoney"].ToString());
                }
                if (row["product"] != null)
                {
                    model.product = row["product"].ToString();
                }
                if (row["user1"] != null && row["user1"].ToString() != "")
                {
                    model.user1 = int.Parse(row["user1"].ToString());
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
            strSql.Append(" FROM tb_EasyConsumeIN ");
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
            strSql.Append(" FROM tb_EasyConsumeIN ");
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
            strSql.Append("select count(1) FROM tb_EasyConsumeIN ");
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
            string strsql1 = @"SELECT *,
                                            dbo.tb_EasyConsume.name,
                                            dbo.tb_EasyConsume.type,
                                            dbo.tb_Base.baseName AS danwei,
                                            dbo.tb_InPersonnel.PersonnelName
                                            FROM
                                            dbo.tb_EasyConsumeIN
                                            LEFT OUTER JOIN dbo.tb_EasyConsume ON dbo.tb_EasyConsumeIN.eId = dbo.tb_EasyConsume.id
                                            LEFT OUTER JOIN dbo.tb_Base ON dbo.tb_EasyConsume.unit = dbo.tb_Base.id ,
                                            dbo.tb_InPersonnel";

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
            strSql.Append(")AS Row, T.*  from tb_EasyConsumeIN T ");
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
            parameters[0].Value = "tb_EasyConsumeIN";
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
        /// 获取易消耗品入库数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetEasyConsumeINCount(string strWhere)
        {
            try
            {
                string strsql1 = @"select * from (SELECT
dbo.tb_EasyConsumeIN.id,
dbo.tb_EasyConsumeIN.eId,
dbo.tb_EasyConsumeIN.inDate,
dbo.tb_EasyConsumeIN.price,
dbo.tb_EasyConsumeIN.amount,
dbo.tb_EasyConsumeIN.inMoney,
dbo.tb_EasyConsumeIN.product,
dbo.tb_EasyConsumeIN.user1,
dbo.tb_EasyConsumeIN.remark,
dbo.tb_EasyConsumeIN.createUser,
dbo.tb_EasyConsumeIN.createDate,
dbo.tb_EasyConsumeIN.updateUser,
dbo.tb_EasyConsumeIN.updateDate,
dbo.tb_EasyConsumeIN.temp1,
dbo.tb_EasyConsumeIN.temp2,
dbo.tb_EasyConsume.name,
dbo.tb_EasyConsume.type,
dbo.tb_Base.baseName AS danwei,
dbo.tb_InPersonnel.PersonnelName

FROM
dbo.tb_EasyConsumeIN
LEFT OUTER JOIN dbo.tb_EasyConsume ON dbo.tb_EasyConsumeIN.eId = dbo.tb_EasyConsume.id
LEFT OUTER JOIN dbo.tb_Base ON dbo.tb_EasyConsume.unit = dbo.tb_Base.id ,
dbo.tb_InPersonnel) a
";
                if (!string.IsNullOrEmpty(strWhere.Trim()))
                {
                    strsql1 += " WHERE " + strWhere;
                }
                return DbHelperSQL.Query(strsql1).Tables[0].Rows.Count;
            }
            catch
            {
                return 0;
            }
        }
        #endregion  ExtensionMethod
    }
}

