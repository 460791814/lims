using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class tb_BookBorrowDAL
    {
        public tb_BookBorrowDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_BookBorrow");
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
        public int Add(tb_BookBorrow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_BookBorrow(");
            strSql.Append("bookId,name,dayNum,company,phone,idCard,borrowNum,backNum,borrowDate,backDate,status,remark,createUser,createDate,updateUser,updateDate,temp1,temp2)");
            strSql.Append(" values (");
            strSql.Append("@bookId,@name,@dayNum,@company,@phone,@idCard,@borrowNum,@backNum,@borrowDate,@backDate,@status,@remark,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@bookId", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@dayNum", SqlDbType.Int,4),
					new SqlParameter("@company", SqlDbType.NVarChar,500),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@idCard", SqlDbType.VarChar,50),
					new SqlParameter("@borrowNum", SqlDbType.Int,4),
					new SqlParameter("@backNum", SqlDbType.Int,4),
					new SqlParameter("@borrowDate", SqlDbType.DateTime),
					new SqlParameter("@backDate", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text)};
            parameters[0].Value = model.bookId;
            parameters[1].Value = model.name;
            parameters[2].Value = model.dayNum;
            parameters[3].Value = model.company;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.idCard;
            parameters[6].Value = model.borrowNum;
            parameters[7].Value = model.backNum;
            parameters[8].Value = model.borrowDate;
            parameters[9].Value = model.backDate;
            parameters[10].Value = model.status;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.createUser;
            parameters[13].Value = model.createDate;
            parameters[14].Value = model.updateUser;
            parameters[15].Value = model.updateDate;
            parameters[16].Value = model.temp1;
            parameters[17].Value = model.temp2;

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
        public bool Update(tb_BookBorrow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_BookBorrow set ");
            strSql.Append("bookId=@bookId,");
            strSql.Append("name=@name,");
            strSql.Append("dayNum=@dayNum,");
            strSql.Append("company=@company,");
            strSql.Append("phone=@phone,");
            strSql.Append("idCard=@idCard,");
            strSql.Append("borrowNum=@borrowNum,");
            strSql.Append("backNum=@backNum,");
            strSql.Append("borrowDate=@borrowDate,");
            strSql.Append("backDate=@backDate,");
            strSql.Append("status=@status,");
            strSql.Append("remark=@remark,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@bookId", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@dayNum", SqlDbType.Int,4),
					new SqlParameter("@company", SqlDbType.NVarChar,500),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@idCard", SqlDbType.VarChar,50),
					new SqlParameter("@borrowNum", SqlDbType.Int,4),
					new SqlParameter("@backNum", SqlDbType.Int,4),
					new SqlParameter("@borrowDate", SqlDbType.DateTime),
					new SqlParameter("@backDate", SqlDbType.DateTime),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.bookId;
            parameters[1].Value = model.name;
            parameters[2].Value = model.dayNum;
            parameters[3].Value = model.company;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.idCard;
            parameters[6].Value = model.borrowNum;
            parameters[7].Value = model.backNum;
            parameters[8].Value = model.borrowDate;
            parameters[9].Value = model.backDate;
            parameters[10].Value = model.status;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.createUser;
            parameters[13].Value = model.createDate;
            parameters[14].Value = model.updateUser;
            parameters[15].Value = model.updateDate;
            parameters[16].Value = model.temp1;
            parameters[17].Value = model.temp2;
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
            strSql.Append("delete from tb_BookBorrow ");
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
            strSql.Append("delete from tb_BookBorrow ");
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
        public tb_BookBorrow GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,bookId,name,dayNum,company,phone,idCard,borrowNum,backNum,borrowDate,backDate,status,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 from tb_BookBorrow ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_BookBorrow model = new tb_BookBorrow();
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
        public tb_BookBorrow DataRowToModel(DataRow row)
        {
            tb_BookBorrow model = new tb_BookBorrow();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["bookId"] != null && row["bookId"].ToString() != "")
                {
                    model.bookId = int.Parse(row["bookId"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["dayNum"] != null && row["dayNum"].ToString() != "")
                {
                    model.dayNum = int.Parse(row["dayNum"].ToString());
                }
                if (row["company"] != null)
                {
                    model.company = row["company"].ToString();
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["idCard"] != null)
                {
                    model.idCard = row["idCard"].ToString();
                }
                if (row["borrowNum"] != null && row["borrowNum"].ToString() != "")
                {
                    model.borrowNum = int.Parse(row["borrowNum"].ToString());
                }
                if (row["backNum"] != null && row["backNum"].ToString() != "")
                {
                    model.backNum = int.Parse(row["backNum"].ToString());
                }
                if (row["borrowDate"] != null && row["borrowDate"].ToString() != "")
                {
                    model.borrowDate = DateTime.Parse(row["borrowDate"].ToString());
                }
                if (row["backDate"] != null && row["backDate"].ToString() != "")
                {
                    model.backDate = DateTime.Parse(row["backDate"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
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
            strSql.Append("select id,bookId,name,dayNum,company,phone,idCard,borrowNum,backNum,borrowDate,backDate,status,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_BookBorrow ");
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
            strSql.Append(" id,bookId,name,dayNum,company,phone,idCard,borrowNum,backNum,borrowDate,backDate,status,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_BookBorrow ");
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
            strSql.Append("select count(1) FROM tb_BookBorrow ");
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
            strSql.Append(")AS Row, T.*  from View_BookBorrow T ");
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
            parameters[0].Value = "tb_BookBorrow";
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
    }
}