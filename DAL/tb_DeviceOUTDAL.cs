/**  版本信息模板在安装目录下，可自行修改。
* tb_DeviceOUT.cs
*
* 功 能： N/A
* 类 名： tb_DeviceOUT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/29 14:00:16   N/A    初版
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
    /// 数据访问类:tb_DeviceOUT
    /// </summary>
    public partial class tb_DeviceOUTDAL
    {
        public tb_DeviceOUTDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_DeviceOUT");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_DeviceOUT");
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
        public int Add(tb_DeviceOUT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_DeviceOUT(");
            strSql.Append("deviceId,amount,userId1,useFor,gDate,userId2,bDate,userId3,remark,createUser,createDate,updateUser,updateDate,temp1,temp2)");
            strSql.Append(" values (");
            strSql.Append("@deviceId,@amount,@userId1,@useFor,@gDate,@userId2,@bDate,@userId3,@remark,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@deviceId", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@userId1", SqlDbType.Int,4),
					new SqlParameter("@useFor", SqlDbType.Text),
					new SqlParameter("@gDate", SqlDbType.DateTime),
					new SqlParameter("@userId2", SqlDbType.Int,4),
					new SqlParameter("@bDate", SqlDbType.DateTime),
					new SqlParameter("@userId3", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text)};
            parameters[0].Value = model.deviceId;
            parameters[1].Value = model.amount;
            parameters[2].Value = model.userId1;
            parameters[3].Value = model.useFor;
            parameters[4].Value = model.gDate;
            parameters[5].Value = model.userId2;
            parameters[6].Value = model.bDate;
            parameters[7].Value = model.userId3;
            parameters[8].Value = model.remark;
            parameters[9].Value = model.createUser;
            parameters[10].Value = model.createDate;
            parameters[11].Value = model.updateUser;
            parameters[12].Value = model.updateDate;
            parameters[13].Value = model.temp1;
            parameters[14].Value = model.temp2;

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
        public bool Update(tb_DeviceOUT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_DeviceOUT set ");
            strSql.Append("deviceId=@deviceId,");
            strSql.Append("amount=@amount,");
            strSql.Append("userId1=@userId1,");
            strSql.Append("useFor=@useFor,");
            strSql.Append("gDate=@gDate,");
            strSql.Append("userId2=@userId2,");
            strSql.Append("bDate=@bDate,");
            strSql.Append("userId3=@userId3,");
            strSql.Append("remark=@remark,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@deviceId", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@userId1", SqlDbType.Int,4),
					new SqlParameter("@useFor", SqlDbType.Text),
					new SqlParameter("@gDate", SqlDbType.DateTime),
					new SqlParameter("@userId2", SqlDbType.Int,4),
					new SqlParameter("@bDate", SqlDbType.DateTime),
					new SqlParameter("@userId3", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.deviceId;
            parameters[1].Value = model.amount;
            parameters[2].Value = model.userId1;
            parameters[3].Value = model.useFor;
            parameters[4].Value = model.gDate;
            parameters[5].Value = model.userId2;
            parameters[6].Value = model.bDate;
            parameters[7].Value = model.userId3;
            parameters[8].Value = model.remark;
            parameters[9].Value = model.createUser;
            parameters[10].Value = model.createDate;
            parameters[11].Value = model.updateUser;
            parameters[12].Value = model.updateDate;
            parameters[13].Value = model.temp1;
            parameters[14].Value = model.temp2;
            parameters[15].Value = model.id;

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
            strSql.Append("delete from tb_DeviceOUT ");
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
            strSql.Append("delete from tb_DeviceOUT ");
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
        public tb_DeviceOUT GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,deviceId,amount,userId1,useFor,gDate,userId2,bDate,userId3,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 from tb_DeviceOUT ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_DeviceOUT model = new tb_DeviceOUT();
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
        public tb_DeviceOUT DataRowToModel(DataRow row)
        {
            tb_DeviceOUT model = new tb_DeviceOUT();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["deviceId"] != null && row["deviceId"].ToString() != "")
                {
                    model.deviceId = int.Parse(row["deviceId"].ToString());
                }
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = int.Parse(row["amount"].ToString());
                }
                if (row["userId1"] != null && row["userId1"].ToString() != "")
                {
                    model.userId1 = int.Parse(row["userId1"].ToString());
                }
                if (row["useFor"] != null)
                {
                    model.useFor = row["useFor"].ToString();
                }
                if (row["gDate"] != null && row["gDate"].ToString() != "")
                {
                    model.gDate = DateTime.Parse(row["gDate"].ToString());
                }
                if (row["userId2"] != null && row["userId2"].ToString() != "")
                {
                    model.userId2 = int.Parse(row["userId2"].ToString());
                }
                if (row["bDate"] != null && row["bDate"].ToString() != "")
                {
                    model.bDate = DateTime.Parse(row["bDate"].ToString());
                }
                if (row["userId3"] != null && row["userId3"].ToString() != "")
                {
                    model.userId3 = int.Parse(row["userId3"].ToString());
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
            strSql.Append("select id,deviceId,amount,userId1,useFor,gDate,userId2,bDate,userId3,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_DeviceOUT ");
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
            strSql.Append(" id,deviceId,amount,userId1,useFor,gDate,userId2,bDate,userId3,remark,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
            strSql.Append(" FROM tb_DeviceOUT ");
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
            strSql.Append("select count(1) FROM tb_DeviceOUT ");
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
            strSql.Append(")AS Row, T.*  from View_DeviceOUT T ");
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
            parameters[0].Value = "tb_DeviceOUT";
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
        /// 返回领用总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetDeviceOUTCount(string where)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT id FROM View_DeviceOUT ");
                if (!string.IsNullOrEmpty(where))
                {
                    strSql.Append(" WHERE " + where);
                }
                return DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows.Count;
            }
            catch
            {
                return 0;
            }
        }
        #endregion  ExtensionMethod
    }
}

