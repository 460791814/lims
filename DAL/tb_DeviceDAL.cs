/**  版本信息模板在安装目录下，可自行修改。
* tb_Device.cs
*
* 功 能： N/A
* 类 名： tb_Device
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/29 14:00:14   N/A    初版
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
    /// 数据访问类:tb_Device
    /// </summary>
    public partial class tb_DeviceDAL
    {
        public tb_DeviceDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Device");
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
        public int Add(tb_Device model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Device(");
            strSql.Append("name,type,pCode,eCode,buyDate,useDate,price,depercitionNum,verificationNum,unit,lastVerificationDate,verificationResult,nextVerificationDate,technologyStatus,problem,companyId,userId,createUser,createDate,updateUser,updateDate,temp1,temp2,amount)");
            strSql.Append(" values (");
            strSql.Append("@name,@type,@pCode,@eCode,@buyDate,@useDate,@price,@depercitionNum,@verificationNum,@unit,@lastVerificationDate,@verificationResult,@nextVerificationDate,@technologyStatus,@problem,@companyId,@userId,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2,@amount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@pCode", SqlDbType.VarChar,200),
					new SqlParameter("@eCode", SqlDbType.VarChar,200),
					new SqlParameter("@buyDate", SqlDbType.DateTime),
					new SqlParameter("@useDate", SqlDbType.DateTime),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@depercitionNum", SqlDbType.NVarChar,50),
					new SqlParameter("@verificationNum", SqlDbType.NVarChar,50),
					new SqlParameter("@unit", SqlDbType.Int,4),
					new SqlParameter("@lastVerificationDate", SqlDbType.DateTime),
					new SqlParameter("@verificationResult", SqlDbType.Text),
					new SqlParameter("@nextVerificationDate", SqlDbType.DateTime),
					new SqlParameter("@technologyStatus", SqlDbType.Int,4),
					new SqlParameter("@problem", SqlDbType.Text),
					new SqlParameter("@companyId", SqlDbType.Int,4),
					new SqlParameter("@userId", SqlDbType.NVarChar,50),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@amount", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.type;
            parameters[2].Value = model.pCode;
            parameters[3].Value = model.eCode;
            parameters[4].Value = model.buyDate;
            parameters[5].Value = model.useDate;
            parameters[6].Value = model.price;
            parameters[7].Value = model.depercitionNum;
            parameters[8].Value = model.verificationNum;
            parameters[9].Value = model.unit;
            parameters[10].Value = model.lastVerificationDate;
            parameters[11].Value = model.verificationResult;
            parameters[12].Value = model.nextVerificationDate;
            parameters[13].Value = model.technologyStatus;
            parameters[14].Value = model.problem;
            parameters[15].Value = model.companyId;
            parameters[16].Value = model.userId;
            parameters[17].Value = model.createUser;
            parameters[18].Value = model.createDate;
            parameters[19].Value = model.updateUser;
            parameters[20].Value = model.updateDate;
            parameters[21].Value = model.temp1;
            parameters[22].Value = model.temp2;
            parameters[23].Value = model.amount;

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
        public bool Update(tb_Device model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Device set ");
            strSql.Append("name=@name,");
            strSql.Append("type=@type,");
            strSql.Append("pCode=@pCode,");
            strSql.Append("eCode=@eCode,");
            strSql.Append("buyDate=@buyDate,");
            strSql.Append("useDate=@useDate,");
            strSql.Append("price=@price,");
            strSql.Append("depercitionNum=@depercitionNum,");
            strSql.Append("verificationNum=@verificationNum,");
            strSql.Append("unit=@unit,");
            strSql.Append("lastVerificationDate=@lastVerificationDate,");
            strSql.Append("verificationResult=@verificationResult,");
            strSql.Append("nextVerificationDate=@nextVerificationDate,");
            strSql.Append("technologyStatus=@technologyStatus,");
            strSql.Append("problem=@problem,");
            strSql.Append("companyId=@companyId,");
            strSql.Append("userId=@userId,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2,");
            strSql.Append("amount=@amount");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@pCode", SqlDbType.VarChar,200),
					new SqlParameter("@eCode", SqlDbType.VarChar,200),
					new SqlParameter("@buyDate", SqlDbType.DateTime),
					new SqlParameter("@useDate", SqlDbType.DateTime),
					new SqlParameter("@price", SqlDbType.Decimal,9),
                    new SqlParameter("@depercitionNum", SqlDbType.NVarChar,50),
					new SqlParameter("@verificationNum", SqlDbType.NVarChar,50),
					new SqlParameter("@unit", SqlDbType.Int,4),
					new SqlParameter("@lastVerificationDate", SqlDbType.DateTime),
					new SqlParameter("@verificationResult", SqlDbType.Text),
					new SqlParameter("@nextVerificationDate", SqlDbType.DateTime),
					new SqlParameter("@technologyStatus", SqlDbType.Int,4),
					new SqlParameter("@problem", SqlDbType.Text),
					new SqlParameter("@companyId", SqlDbType.Int,4),
					new SqlParameter("@userId", SqlDbType.NVarChar,50),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.Text),
					new SqlParameter("@temp2", SqlDbType.Text),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.type;
            parameters[2].Value = model.pCode;
            parameters[3].Value = model.eCode;
            parameters[4].Value = model.buyDate;
            parameters[5].Value = model.useDate;
            parameters[6].Value = model.price;
            parameters[7].Value = model.depercitionNum;
            parameters[8].Value = model.verificationNum;
            parameters[9].Value = model.unit;
            parameters[10].Value = model.lastVerificationDate;
            parameters[11].Value = model.verificationResult;
            parameters[12].Value = model.nextVerificationDate;
            parameters[13].Value = model.technologyStatus;
            parameters[14].Value = model.problem;
            parameters[15].Value = model.companyId;
            parameters[16].Value = model.userId;
            parameters[17].Value = model.createUser;
            parameters[18].Value = model.createDate;
            parameters[19].Value = model.updateUser;
            parameters[20].Value = model.updateDate;
            parameters[21].Value = model.temp1;
            parameters[22].Value = model.temp2;
            parameters[23].Value = model.amount;
            parameters[24].Value = model.id;

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
            strSql.Append("delete from tb_Device ");
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
            strSql.Append("delete from tb_Device ");
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
        public tb_Device GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,type,pCode,eCode,buyDate,useDate,price,depercitionNum,verificationNum,unit,lastVerificationDate,verificationResult,nextVerificationDate,technologyStatus,problem,companyId,userId,createUser,createDate,updateUser,updateDate,temp1,temp2,amount from tb_Device ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_Device model = new tb_Device();
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
        public tb_Device DataRowToModel(DataRow row)
        {
            tb_Device model = new tb_Device();
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
                if (row["pCode"] != null)
                {
                    model.pCode = row["pCode"].ToString();
                }
                if (row["eCode"] != null)
                {
                    model.eCode = row["eCode"].ToString();
                }
                if (row["buyDate"] != null && row["buyDate"].ToString() != "")
                {
                    model.buyDate = DateTime.Parse(row["buyDate"].ToString());
                }
                if (row["useDate"] != null && row["useDate"].ToString() != "")
                {
                    model.useDate = DateTime.Parse(row["useDate"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["depercitionNum"] != null && row["depercitionNum"].ToString() != "")
                {
                    model.depercitionNum = row["depercitionNum"].ToString();
                }
                if (row["verificationNum"] != null && row["verificationNum"].ToString() != "")
                {
                    model.verificationNum = row["verificationNum"].ToString();
                }
                if (row["unit"] != null && row["unit"].ToString() != "")
                {
                    model.unit = int.Parse(row["unit"].ToString());
                }
                if (row["lastVerificationDate"] != null && row["lastVerificationDate"].ToString() != "")
                {
                    model.lastVerificationDate = DateTime.Parse(row["lastVerificationDate"].ToString());
                }
                if (row["verificationResult"] != null)
                {
                    model.verificationResult = row["verificationResult"].ToString();
                }
                if (row["nextVerificationDate"] != null && row["nextVerificationDate"].ToString() != "")
                {
                    model.nextVerificationDate = DateTime.Parse(row["nextVerificationDate"].ToString());
                }
                if (row["technologyStatus"] != null && row["technologyStatus"].ToString() != "")
                {
                    model.technologyStatus = int.Parse(row["technologyStatus"].ToString());
                }
                if (row["problem"] != null)
                {
                    model.problem = row["problem"].ToString();
                }
                if (row["companyId"] != null && row["companyId"].ToString() != "")
                {
                    model.companyId = int.Parse(row["companyId"].ToString());
                }
                if (row["userId"] != null && row["userId"].ToString() != "")
                {
                    model.userId = row["userId"].ToString();
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
                if (row["amount"] != null && row["amount"].ToString() != "")
                {
                    model.amount = int.Parse(row["amount"].ToString());
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
            strSql.Append("select id,name,type,pCode,eCode,buyDate,useDate,price,depercitionNum,verificationNum,unit,lastVerificationDate,verificationResult,nextVerificationDate,technologyStatus,problem,companyId,userId,createUser,createDate,updateUser,updateDate,temp1,temp2,amount ");
            strSql.Append(" FROM tb_Device ");
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
            strSql.Append(" id,name,type,pCode,eCode,buyDate,useDate,price,depercitionNum,verificationNum,unit,lastVerificationDate,verificationResult,nextVerificationDate,technologyStatus,problem,companyId,userId,createUser,createDate,updateUser,updateDate,temp1,temp2,amount ");
            strSql.Append(" FROM tb_Device ");
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
            strSql.Append("select count(1) FROM tb_Device ");
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
            parameters[0].Value = "tb_Device";
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            string strsql1 = @"SELECT     *,
                          (SELECT     baseName
                            FROM          dbo.tb_Base
                            WHERE      (id = dbo.tb_Device.companyId)) AS company
FROM         dbo.tb_Device";
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
            strSql.Append(")AS Row, T.*  from (" + strsql1 + ") T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
