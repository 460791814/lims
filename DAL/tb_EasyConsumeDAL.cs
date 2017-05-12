/**  版本信息模板在安装目录下，可自行修改。
* tb_EasyConsume.cs
*
* 功 能： N/A
* 类 名： tb_EasyConsume
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/4 21:23:34   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
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
    /// 数据访问类:tb_EasyConsume
    /// </summary>
    public partial class tb_EasyConsumeDAL
    {
        public tb_EasyConsumeDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_EasyConsume");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_EasyConsume");
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
        public int Add(tb_EasyConsume model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_EasyConsume(");
            strSql.Append("name,type,unit,amount,product,price,remark,createUser,createDate,updateUser,updateDate,temp1,temp2)");
            strSql.Append(" values (");
            strSql.Append("@name,@type,@unit,@amount,@product,@price,@remark,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,200),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@unit", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@product", SqlDbType.NVarChar,-1),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.type;
            parameters[2].Value = model.unit;
            parameters[3].Value = model.amount;
            parameters[4].Value = model.product;
            parameters[5].Value = model.price;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.createUser;
            parameters[8].Value = model.createDate;
            parameters[9].Value = model.updateUser;
            parameters[10].Value = model.updateDate;
            parameters[11].Value = model.temp1;
            parameters[12].Value = model.temp2;

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
        public bool Update(tb_EasyConsume model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_EasyConsume set ");
            strSql.Append("name=@name,");
            strSql.Append("type=@type,");
            strSql.Append("unit=@unit,");
            strSql.Append("amount=@amount,");
            strSql.Append("product=@product,");
            strSql.Append("price=@price,");
            strSql.Append("remark=@remark,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,200),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@unit", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@product", SqlDbType.NVarChar,-1),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.type;
            parameters[2].Value = model.unit;
            parameters[3].Value = model.amount;
            parameters[4].Value = model.product;
            parameters[5].Value = model.price;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.createUser;
            parameters[8].Value = model.createDate;
            parameters[9].Value = model.updateUser;
            parameters[10].Value = model.updateDate;
            parameters[11].Value = model.temp1;
            parameters[12].Value = model.temp2;
            parameters[13].Value = model.id;

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
            strSql.Append("delete from tb_EasyConsume ");
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
            strSql.Append("delete from tb_EasyConsume ");
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
        public tb_EasyConsume GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,type,unit,amount,product,price,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 from tb_EasyConsume ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_EasyConsume model = new tb_EasyConsume();
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
        public tb_EasyConsume DataRowToModel(DataRow row)
        {
            tb_EasyConsume model = new tb_EasyConsume();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["unit"] != null && row["unit"].ToString() != "")
                {
                    model.unit = int.Parse(row["unit"].ToString());
                }
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = int.Parse(row["amount"].ToString());
                }
                if (row["product"] != null)
                {
                    model.product = row["product"].ToString();
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
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
            strSql.Append("select id,name,type,unit,amount,product,price,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_EasyConsume ");
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
            strSql.Append(" id,name,type,unit,amount,product,price,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_EasyConsume ");
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
            strSql.Append("select count(1) FROM tb_EasyConsume ");
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
            parameters[0].Value = "tb_EasyConsume";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        public DataSet GetEasyConsumeLogListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            string strSql1 = @" SELECT     *, 
(SELECT baseName FROM  dbo.tb_Base WHERE      (id = dbo.tb_EasyConsume.unit)) AS danwei, 
(SELECT SUM(amount) AS Expr1 FROM  dbo.tb_EasyConsumeOUT  ) AS chuku, 
(SELECT SUM(amount) AS Expr1 FROM  dbo.tb_EasyConsumeIN ) AS ruku
 FROM dbo.tb_EasyConsume ";
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
            strSql.Append(")AS Row, T.*  from (" + strSql1 + ") T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            string strSql1 = @"select * from (SELECT     *,(select baseName from dbo.tb_Base where id=tb_EasyConsume.unit)as danwei 
                     FROM         dbo.tb_EasyConsume) a";
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
            strSql.Append(")AS Row, T.*  from (" + strSql1 + ") T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 易耗品总数
        /// </summary>
        public int GetEasyConsumeCount(string strWhere)
        {
            try
            {
                string strSql1 = @"select * from (SELECT     *,(select baseName from dbo.tb_Base where id=tb_EasyConsume.unit)as danwei 
                     FROM         dbo.tb_EasyConsume) a";
                if (!string.IsNullOrEmpty(strWhere.Trim()))
                {
                    strSql1 += " WHERE " + strWhere;
                }
                return DbHelperSQL.Query(strSql1).Tables[0].Rows.Count;
            }
            catch
            {
                return 0;
            }
        }
    }
}

