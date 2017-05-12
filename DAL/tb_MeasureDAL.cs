using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class tb_MeasureDAL
    {
        public tb_MeasureDAL()
        { }

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Measure");
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
        public int Add(tb_Measure model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Measure(");
            strSql.Append("deviceName,standard,assetCode,deviceCode,buyDate,useDate,oValue,deperciation,periodVerification,lastVerification,verification,nextVerification,technologyState,problem,useCompany,usePerson,createUser,createDate,updateUser,updateDate,temp1,temp2,companyName,verificationCompany,phoneNumber,isDevice,measureType,device_Id)");
            strSql.Append(" values (");
            strSql.Append("@deviceName,@standard,@assetCode,@deviceCode,@buyDate,@useDate,@oValue,@deperciation,@periodVerification,@lastVerification,@verification,@nextVerification,@technologyState,@problem,@useCompany,@usePerson,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2,@companyName,@verificationCompany,@phoneNumber,@isDevice,@measureType,@device_Id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@deviceName", SqlDbType.NVarChar,-1),
					new SqlParameter("@standard", SqlDbType.NVarChar,-1),
					new SqlParameter("@assetCode", SqlDbType.NVarChar,50),
					new SqlParameter("@deviceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@buyDate", SqlDbType.DateTime),
					new SqlParameter("@useDate", SqlDbType.DateTime),
					new SqlParameter("@oValue", SqlDbType.Decimal,9),
					new SqlParameter("@deperciation", SqlDbType.Int,4),
					new SqlParameter("@periodVerification", SqlDbType.Int,4),
					new SqlParameter("@lastVerification", SqlDbType.DateTime),
					new SqlParameter("@verification", SqlDbType.NVarChar,-1),
					new SqlParameter("@nextVerification", SqlDbType.DateTime),
					new SqlParameter("@technologyState", SqlDbType.NVarChar,-1),
					new SqlParameter("@problem", SqlDbType.NVarChar,-1),
					new SqlParameter("@useCompany", SqlDbType.NVarChar,-1),
					new SqlParameter("@usePerson", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1),
					new SqlParameter("@companyName", SqlDbType.NVarChar,-1),
					new SqlParameter("@verificationCompany", SqlDbType.NVarChar,-1),
					new SqlParameter("@phoneNumber", SqlDbType.NVarChar,-1),
					new SqlParameter("@isDevice", SqlDbType.NVarChar,-1),
					new SqlParameter("@measureType", SqlDbType.NVarChar,50),
                    new SqlParameter("@device_Id", SqlDbType.Int,4)};
            parameters[0].Value = model.deviceName;
            parameters[1].Value = model.standard;
            parameters[2].Value = model.assetCode;
            parameters[3].Value = model.deviceCode;
            parameters[4].Value = model.buyDate;
            parameters[5].Value = model.useDate;
            parameters[6].Value = model.oValue;
            parameters[7].Value = model.deperciation;
            parameters[8].Value = model.periodVerification;
            parameters[9].Value = model.lastVerification;
            parameters[10].Value = model.verification;
            parameters[11].Value = model.nextVerification;
            parameters[12].Value = model.technologyState;
            parameters[13].Value = model.problem;
            parameters[14].Value = model.useCompany;
            parameters[15].Value = model.usePerson;
            parameters[16].Value = model.createUser;
            parameters[17].Value = model.createDate;
            parameters[18].Value = model.updateUser;
            parameters[19].Value = model.updateDate;
            parameters[20].Value = model.temp1;
            parameters[21].Value = model.temp2;
            parameters[22].Value = model.companyName;
            parameters[23].Value = model.verificationCompany;
            parameters[24].Value = model.phoneNumber;
            parameters[25].Value = model.isDevice;
            parameters[26].Value = model.measureType;
            parameters[27].Value = model.Device_Id;
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
        public bool Update(tb_Measure model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Measure set ");
            strSql.Append("deviceName=@deviceName,");
            strSql.Append("standard=@standard,");
            strSql.Append("assetCode=@assetCode,");
            strSql.Append("deviceCode=@deviceCode,");
            strSql.Append("buyDate=@buyDate,");
            strSql.Append("useDate=@useDate,");
            strSql.Append("oValue=@oValue,");
            strSql.Append("deperciation=@deperciation,");
            strSql.Append("periodVerification=@periodVerification,");
            strSql.Append("lastVerification=@lastVerification,");
            strSql.Append("verification=@verification,");
            strSql.Append("nextVerification=@nextVerification,");
            strSql.Append("technologyState=@technologyState,");
            strSql.Append("problem=@problem,");
            strSql.Append("useCompany=@useCompany,");
            strSql.Append("usePerson=@usePerson,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2,");
            strSql.Append("companyName=@companyName,");
            strSql.Append("verificationCompany=@verificationCompany,");
            strSql.Append("phoneNumber=@phoneNumber,");
            strSql.Append("isDevice=@isDevice,");
            strSql.Append("measureType=@measureType,");
            strSql.Append("deviceId=@deviceId");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@deviceName", SqlDbType.NVarChar,-1),
					new SqlParameter("@standard", SqlDbType.NVarChar,-1),
					new SqlParameter("@assetCode", SqlDbType.NVarChar,50),
					new SqlParameter("@deviceCode", SqlDbType.NVarChar,50),
					new SqlParameter("@buyDate", SqlDbType.DateTime),
					new SqlParameter("@useDate", SqlDbType.DateTime),
					new SqlParameter("@oValue", SqlDbType.Decimal,9),
					new SqlParameter("@deperciation", SqlDbType.Int,4),
					new SqlParameter("@periodVerification", SqlDbType.Int,4),
					new SqlParameter("@lastVerification", SqlDbType.DateTime),
					new SqlParameter("@verification", SqlDbType.NVarChar,-1),
					new SqlParameter("@nextVerification", SqlDbType.DateTime),
					new SqlParameter("@technologyState", SqlDbType.NVarChar,-1),
					new SqlParameter("@problem", SqlDbType.NVarChar,-1),
					new SqlParameter("@useCompany", SqlDbType.NVarChar,-1),
					new SqlParameter("@usePerson", SqlDbType.NVarChar,-1),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
					new SqlParameter("@temp2", SqlDbType.NVarChar,-1),
					new SqlParameter("@companyName", SqlDbType.NVarChar,-1),
					new SqlParameter("@verificationCompany", SqlDbType.NVarChar,-1),
					new SqlParameter("@phoneNumber", SqlDbType.NVarChar,-1),
					new SqlParameter("@isDevice", SqlDbType.NVarChar,-1),
					new SqlParameter("@measureType", SqlDbType.NVarChar,50),
                    new SqlParameter("@deviceId", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.deviceName;
            parameters[1].Value = model.standard;
            parameters[2].Value = model.assetCode;
            parameters[3].Value = model.deviceCode;
            parameters[4].Value = model.buyDate;
            parameters[5].Value = model.useDate;
            parameters[6].Value = model.oValue;
            parameters[7].Value = model.deperciation;
            parameters[8].Value = model.periodVerification;
            parameters[9].Value = model.lastVerification;
            parameters[10].Value = model.verification;
            parameters[11].Value = model.nextVerification;
            parameters[12].Value = model.technologyState;
            parameters[13].Value = model.problem;
            parameters[14].Value = model.useCompany;
            parameters[15].Value = model.usePerson;
            parameters[16].Value = model.createUser;
            parameters[17].Value = model.createDate;
            parameters[18].Value = model.updateUser;
            parameters[19].Value = model.updateDate;
            parameters[20].Value = model.temp1;
            parameters[21].Value = model.temp2;
            parameters[22].Value = model.companyName;
            parameters[23].Value = model.verificationCompany;
            parameters[24].Value = model.phoneNumber;
            parameters[25].Value = model.isDevice;
            parameters[26].Value = model.measureType;
            parameters[27].Value = model.Device_Id;
            parameters[28].Value = model.id;

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
            strSql.Append("delete from tb_Measure ");
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
            strSql.Append("delete from tb_Measure ");
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
        public tb_Measure GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from tb_measure");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            tb_Measure model = new tb_Measure();
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
        public tb_Measure DataRowToModel(DataRow row)
        {
            tb_Measure model = new tb_Measure();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["deviceName"] != null)
                {
                    model.deviceName = row["deviceName"].ToString();
                }
                if (row["standard"] != null)
                {
                    model.standard = row["standard"].ToString();
                }
                if (row["assetCode"] != null)
                {
                    model.assetCode = row["assetCode"].ToString();
                }
                if (row["deviceCode"] != null)
                {
                    model.deviceCode = row["deviceCode"].ToString();
                }
                if (row["buyDate"] != null && row["buyDate"].ToString() != "")
                {
                    model.buyDate = DateTime.Parse(row["buyDate"].ToString());
                }
                if (row["useDate"] != null && row["useDate"].ToString() != "")
                {
                    model.useDate = DateTime.Parse(row["useDate"].ToString());
                }
                if (row["oValue"] != null && row["oValue"].ToString() != "")
                {
                    model.oValue = decimal.Parse(row["oValue"].ToString());
                }
                if (row["deperciation"] != null && row["deperciation"].ToString() != "")
                {
                    model.deperciation = int.Parse(row["deperciation"].ToString());
                }
                if (row["periodVerification"] != null && row["periodVerification"].ToString() != "")
                {
                    model.periodVerification = int.Parse(row["periodVerification"].ToString());
                }
                if (row["lastVerification"] != null && row["lastVerification"].ToString() != "")
                {
                    model.lastVerification = DateTime.Parse(row["lastVerification"].ToString());
                }
                if (row["verification"] != null)
                {
                    model.verification = row["verification"].ToString();
                }
                if (row["nextVerification"] != null && row["nextVerification"].ToString() != "")
                {
                    model.nextVerification = DateTime.Parse(row["nextVerification"].ToString());
                }
                if (row["technologyState"] != null)
                {
                    model.technologyState = row["technologyState"].ToString();
                }
                if (row["problem"] != null)
                {
                    model.problem = row["problem"].ToString();
                }
                if (row["useCompany"] != null)
                {
                    model.useCompany = row["useCompany"].ToString();
                }
                if (row["usePerson"] != null)
                {
                    model.usePerson = row["usePerson"].ToString();
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
                if (row["companyName"] != null)
                {
                    model.companyName = row["companyName"].ToString();
                }
                if (row["verificationCompany"] != null)
                {
                    model.verificationCompany = row["verificationCompany"].ToString();
                }
                if (row["phoneNumber"] != null)
                {
                    model.phoneNumber = row["phoneNumber"].ToString();
                }
                if (row["isDevice"] != null)
                {
                    model.isDevice = row["isDevice"].ToString();
                }
                if (row["measureType"] != null)
                {
                    model.measureType = row["measureType"].ToString();
                }
                if (row["device_Id"] != null && row["device_Id"].ToString() != "")
                {
                    model.Device_Id = int.Parse(row["device_Id"].ToString());
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
            strSql.Append(" FROM tb_Measure ");
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
            strSql.Append(" FROM tb_Measure ");
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
            strSql.Append("select count(1) FROM tb_Measure ");
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
            strSql.Append(")AS Row, T.*  from tb_Measure T ");
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
            parameters[0].Value = "tb_Measure";
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
