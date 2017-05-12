using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class tb_BookDAL
    {
        public tb_BookDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Book");
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
        public int Add(tb_Book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Book(");
            strSql.Append("code,name,type1,type2,author,price,num,repertory,status,press,remark,createUser,createDate,updateUser,updateDate,temp1,temp2)");
            strSql.Append(" values (");
            strSql.Append("@code,@name,@type1,@type2,@author,@price,@num,@repertory,@status,@press,@remark,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.VarChar,200),
					new SqlParameter("@name", SqlDbType.NVarChar,300),
					new SqlParameter("@type1", SqlDbType.Int,4),
					new SqlParameter("@type2", SqlDbType.Int,4),
					new SqlParameter("@author", SqlDbType.NVarChar,20),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@repertory", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@press", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text)};
            parameters[0].Value = model.code;
            parameters[1].Value = model.name;
            parameters[2].Value = model.type1;
            parameters[3].Value = model.type2;
            parameters[4].Value = model.author;
            parameters[5].Value = model.price;
            parameters[6].Value = model.num;
            parameters[7].Value = model.repertory;
            parameters[8].Value = model.status;
            parameters[9].Value = model.press;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.createUser;
            parameters[12].Value = model.createDate;
            parameters[13].Value = model.updateUser;
            parameters[14].Value = model.updateDate;
            parameters[15].Value = model.temp1;
            parameters[16].Value = model.temp2;

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
        public bool Update(tb_Book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Book set ");
            strSql.Append("code=@code,");
            strSql.Append("name=@name,");
            strSql.Append("type1=@type1,");
            strSql.Append("type2=@type2,");
            strSql.Append("author=@author,");
            strSql.Append("price=@price,");
            strSql.Append("num=@num,");
            strSql.Append("repertory=@repertory,");
            strSql.Append("status=@status,");
            strSql.Append("press=@press,");
            strSql.Append("remark=@remark,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.VarChar,200),
					new SqlParameter("@name", SqlDbType.NVarChar,300),
					new SqlParameter("@type1", SqlDbType.Int,4),
					new SqlParameter("@type2", SqlDbType.Int,4),
					new SqlParameter("@author", SqlDbType.NVarChar,20),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@num", SqlDbType.Int,4),
					new SqlParameter("@repertory", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@press", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.code;
            parameters[1].Value = model.name;
            parameters[2].Value = model.type1;
            parameters[3].Value = model.type2;
            parameters[4].Value = model.author;
            parameters[5].Value = model.price;
            parameters[6].Value = model.num;
            parameters[7].Value = model.repertory;
            parameters[8].Value = model.status;
            parameters[9].Value = model.press;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.createUser;
            parameters[12].Value = model.createDate;
            parameters[13].Value = model.updateUser;
            parameters[14].Value = model.updateDate;
            parameters[15].Value = model.temp1;
            parameters[16].Value = model.temp2;
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
            strSql.Append("delete from tb_Book ");
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
            strSql.Append("delete from tb_Book ");
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
        public tb_Book GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,code,name,type1,type2,author,price,num,repertory,status,press,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 from tb_Book ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_Book model = new tb_Book();
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
        public tb_Book DataRowToModel(DataRow row)
        {
            tb_Book model = new tb_Book();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["type1"] != null && row["type1"].ToString() != "")
                {
                    model.type1 = int.Parse(row["type1"].ToString());
                }
                if (row["type2"] != null && row["type2"].ToString() != "")
                {
                    model.type2 = int.Parse(row["type2"].ToString());
                }
                if (row["author"] != null)
                {
                    model.author = row["author"].ToString();
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["num"] != null && row["num"].ToString() != "")
                {
                    model.num = int.Parse(row["num"].ToString());
                }
                if (row["repertory"] != null && row["repertory"].ToString() != "")
                {
                    model.repertory = int.Parse(row["repertory"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                if (row["press"] != null)
                {
                    model.press = row["press"].ToString();
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
            strSql.Append(" id,code,name,type1,type2,author,price,num,repertory,status,press,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_Book ");
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
            strSql.Append("select count(1) FROM tb_Book ");
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
            parameters[0].Value = "tb_Book";
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

        #endregion  ExtensionMethod

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM View_Book ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(")AS Row, T.*  from View_Book T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public tb_Book DataRowToModel(DataRow row, int num)
        {
            tb_Book model = new tb_Book();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["type1"] != null && row["type1"].ToString() != "")
                {
                    model.type1 = int.Parse(row["type1"].ToString());
                }
                if (row["type2"] != null && row["type2"].ToString() != "")
                {
                    model.type2 = int.Parse(row["type2"].ToString());
                }
                if (row["author"] != null)
                {
                    model.author = row["author"].ToString();
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["num"] != null && row["num"].ToString() != "")
                {
                    model.num = int.Parse(row["num"].ToString());
                }
                if (row["repertory"] != null && row["repertory"].ToString() != "")
                {
                    model.repertory = int.Parse(row["repertory"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                if (row["press"] != null)
                {
                    model.press = row["press"].ToString();
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

                if (row["zhongshu"] != null)
                {
                    model.zhongshu = row["zhongshu"].ToString();
                }
                if (row["leibie"] != null)
                {
                    model.leibie = row["leibie"].ToString();
                }
                if (row["zt"] != null)
                {
                    model.zhuangtai = row["zt"].ToString();
                }
            }
            return model;
        }

        public DataTable GetBookLogList(string where)
        {
            string strsql1 = @" SELECT     dbo.tb_Base.id, dbo.tb_Base.pId, dbo.tb_Base.baseName AS tushuleibie, SUM(dbo.tb_Book.num) AS kucun
FROM         dbo.tb_Book RIGHT OUTER JOIN
                      dbo.tb_Base ON dbo.tb_Book.type2 = dbo.tb_Base.id ";
            strsql1 += " WHERE  (dbo.tb_Base.pId = 13) and ";
            if (!string.IsNullOrEmpty(where))
            {
                strsql1 += where;
            }
            strsql1 += " GROUP BY dbo.tb_Base.id, dbo.tb_Base.pId, dbo.tb_Base.baseName ";
            DataSet ds = DbHelperSQL.Query(strsql1);

            DataTable dt = ds.Tables[0];
            dt.Columns.Add("shuliang");
            dt.Columns.Add("jiechu");
            int kucun = 0;
            int shuliang = 0;
            int jiechu = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int num1 = 0; //临时记录库存
                int num2 = 0;//临时记录借出
                if (dt.Rows[i]["kucun"] != null && !string.IsNullOrEmpty(dt.Rows[i]["kucun"].ToString()))
                {
                    num1 = Convert.ToInt32(dt.Rows[i]["kucun"]);
                    kucun += num1;
                }
                int type2 = Convert.ToInt32(dt.Rows[i]["id"]);
                string strsql2 = @"SELECT     SUM(dbo.tb_BookBorrow.borrowNum) AS jiechu
                        FROM         dbo.tb_Book INNER JOIN
                      dbo.tb_BookBorrow ON dbo.tb_Book.id = dbo.tb_BookBorrow.bookId";
                strsql2 += " where dbo.tb_Book.type2 = " + type2 + " and";
                if (!string.IsNullOrEmpty(where))
                {
                    strsql2 += where;
                }
                ds = DbHelperSQL.Query(strsql2);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row["jiechu"] != null && !string.IsNullOrEmpty(row["jiechu"].ToString()))
                    {
                        dt.Rows[i]["jiechu"] = row["jiechu"].ToString();
                        num2 = Convert.ToInt32(row["jiechu"]);
                        jiechu += num2;
                    }
                }

                shuliang += num1 + num2;
                int num3 = num1 + num2;
                if (num3 > 0)
                {
                    dt.Rows[i]["shuliang"] = num3;
                }
            }
            DataRow dr = dt.NewRow();
            dr["tushuleibie"] = "合计";
            dr["shuliang"] = shuliang;
            dr["kucun"] = kucun;
            dr["jiechu"] = jiechu;
            dt.Rows.Add(dr);
            return dt;
        }
    }
}