using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.ClientManage;

namespace DAL.ClientManage
{
    /// <summary>
    /// 数据访问类:D_tb_ClientManage
    /// </summary>
    public partial class D_tb_ClientManage
    {
        public D_tb_ClientManage()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ClientID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_ClientManage");
            strSql.Append(" where ClientID=@ClientID");
            SqlParameter[] parameters = {
					new SqlParameter("@ClientID", SqlDbType.Int,4)
};
            parameters[0].Value = ClientID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ClientManage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_ClientManage(");
            strSql.Append("ClientName,Contact,Email,Deputy,Address,Fixed,Tel,Fax,ZipCode,ClientLevel,PrepaidMoney,MainBusiness,YearEntrust,Incentives,ContractNo,ContractImgID,ContractPath,AreaID,EditPersonnelID)");
            strSql.Append(" values (");
            strSql.Append("@ClientName,@Contact,@Email,@Deputy,@Address,@Fixed,@Tel,@Fax,@ZipCode,@ClientLevel,@PrepaidMoney,@MainBusiness,@YearEntrust,@Incentives,@ContractNo,@ContractImgID,@ContractPath,@AreaID,@EditPersonnelID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ClientName", SqlDbType.NVarChar,50),
					new SqlParameter("@Contact", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Deputy", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@Fixed", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ClientLevel", SqlDbType.NVarChar,50),
					new SqlParameter("@PrepaidMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@MainBusiness", SqlDbType.Text),
					new SqlParameter("@YearEntrust", SqlDbType.Text),
					new SqlParameter("@Incentives", SqlDbType.Text),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractImgID", SqlDbType.Int,4),
					new SqlParameter("@ContractPath", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4)};
            parameters[0].Value = model.ClientName;
            parameters[1].Value = model.Contact;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.Deputy;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Fixed;
            parameters[6].Value = model.Tel;
            parameters[7].Value = model.Fax;
            parameters[8].Value = model.ZipCode;
            parameters[9].Value = model.ClientLevel;
            parameters[10].Value = model.PrepaidMoney;
            parameters[11].Value = model.MainBusiness;
            parameters[12].Value = model.YearEntrust;
            parameters[13].Value = model.Incentives;
            parameters[14].Value = model.ContractNo;
            parameters[15].Value = model.ContractImgID;
            parameters[16].Value = model.ContractPath;
            parameters[17].Value = model.AreaID;
            parameters[18].Value = model.EditPersonnelID;

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
        public bool Update(E_tb_ClientManage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_ClientManage set ");
            strSql.Append("ClientName=@ClientName,");
            strSql.Append("Contact=@Contact,");
            strSql.Append("Email=@Email,");
            strSql.Append("Deputy=@Deputy,");
            strSql.Append("Address=@Address,");
            strSql.Append("Fixed=@Fixed,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("ZipCode=@ZipCode,");
            strSql.Append("ClientLevel=@ClientLevel,");
            strSql.Append("PrepaidMoney=@PrepaidMoney,");
            strSql.Append("MainBusiness=@MainBusiness,");
            strSql.Append("YearEntrust=@YearEntrust,");
            strSql.Append("Incentives=@Incentives,");
            strSql.Append("ContractNo=@ContractNo,");
            strSql.Append("ContractImgID=@ContractImgID,");
            strSql.Append("ContractPath=@ContractPath,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID");
            strSql.Append(" where ClientID=@ClientID");
            SqlParameter[] parameters = {
					new SqlParameter("@ClientName", SqlDbType.NVarChar,50),
					new SqlParameter("@Contact", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Deputy", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@Fixed", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ClientLevel", SqlDbType.NVarChar,50),
					new SqlParameter("@PrepaidMoney", SqlDbType.NVarChar,50),
					new SqlParameter("@MainBusiness", SqlDbType.Text),
					new SqlParameter("@YearEntrust", SqlDbType.Text),
					new SqlParameter("@Incentives", SqlDbType.Text),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractImgID", SqlDbType.Int,4),
					new SqlParameter("@ContractPath", SqlDbType.NVarChar,50),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@ClientID", SqlDbType.Int,4)};
            parameters[0].Value = model.ClientName;
            parameters[1].Value = model.Contact;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.Deputy;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Fixed;
            parameters[6].Value = model.Tel;
            parameters[7].Value = model.Fax;
            parameters[8].Value = model.ZipCode;
            parameters[9].Value = model.ClientLevel;
            parameters[10].Value = model.PrepaidMoney;
            parameters[11].Value = model.MainBusiness;
            parameters[12].Value = model.YearEntrust;
            parameters[13].Value = model.Incentives;
            parameters[14].Value = model.ContractNo;
            parameters[15].Value = model.ContractImgID;
            parameters[16].Value = model.ContractPath;
            parameters[17].Value = model.AreaID;
            parameters[18].Value = model.EditPersonnelID;
            parameters[19].Value = model.ClientID;

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
        public bool Delete(int ClientID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_ClientManage ");
            strSql.Append(" where ClientID=@ClientID");
            SqlParameter[] parameters = {
					new SqlParameter("@ClientID", SqlDbType.Int,4)
};
            parameters[0].Value = ClientID;

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
        public bool DeleteList(string ClientIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_ClientManage ");
            strSql.Append(" where ClientID in (" + ClientIDlist + ")  ");
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
        public E_tb_ClientManage GetModel(int ClientID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ClientID,ClientName,Contact,Email,Deputy,Address,Fixed,Tel,Fax,ZipCode,ClientLevel,PrepaidMoney,MainBusiness,YearEntrust,Incentives,ContractNo,ContractImgID,ContractPath,AreaID,EditPersonnelID from tb_ClientManage ");
            strSql.Append(" where ClientID=@ClientID");
            SqlParameter[] parameters = {
					new SqlParameter("@ClientID", SqlDbType.Int,4)
};
            parameters[0].Value = ClientID;

            E_tb_ClientManage model = new E_tb_ClientManage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ClientID"].ToString() != "")
                {
                    model.ClientID = int.Parse(ds.Tables[0].Rows[0]["ClientID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClientName"] != null)
                {
                    model.ClientName = ds.Tables[0].Rows[0]["ClientName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contact"] != null)
                {
                    model.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null)
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Deputy"] != null)
                {
                    model.Deputy = ds.Tables[0].Rows[0]["Deputy"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null)
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Fixed"] != null)
                {
                    model.Fixed = ds.Tables[0].Rows[0]["Fixed"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tel"] != null)
                {
                    model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Fax"] != null)
                {
                    model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZipCode"] != null)
                {
                    model.ZipCode = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClientLevel"] != null)
                {
                    model.ClientLevel = ds.Tables[0].Rows[0]["ClientLevel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PrepaidMoney"] != null)
                {
                    model.PrepaidMoney = ds.Tables[0].Rows[0]["PrepaidMoney"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MainBusiness"] != null)
                {
                    model.MainBusiness = ds.Tables[0].Rows[0]["MainBusiness"].ToString();
                }
                if (ds.Tables[0].Rows[0]["YearEntrust"] != null)
                {
                    model.YearEntrust = ds.Tables[0].Rows[0]["YearEntrust"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Incentives"] != null)
                {
                    model.Incentives = ds.Tables[0].Rows[0]["Incentives"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractNo"] != null)
                {
                    model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractImgID"].ToString() != "")
                {
                    model.ContractImgID = int.Parse(ds.Tables[0].Rows[0]["ContractImgID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractPath"] != null)
                {
                    model.ContractPath = ds.Tables[0].Rows[0]["ContractPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditPersonnelID"].ToString() != "")
                {
                    model.EditPersonnelID = int.Parse(ds.Tables[0].Rows[0]["EditPersonnelID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ClientID,ClientName,Contact,Email,Deputy,Address,Fixed,Tel,Fax,ZipCode,ClientLevel,PrepaidMoney,MainBusiness,YearEntrust,Incentives,ContractNo,ContractImgID,ContractPath,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_ClientManage ");
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
            strSql.Append(" ClientID,ClientName,Contact,Email,Deputy,Address,Fixed,Tel,Fax,ZipCode,ClientLevel,PrepaidMoney,MainBusiness,YearEntrust,Incentives,ContractNo,ContractImgID,ContractPath,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_ClientManage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            parameters[0].Value = "tb_ClientManage";
            parameters[1].Value = "ClientID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        #region 数据接口
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, ref int total)
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
                strSql.Append("order by T.ClientID desc");
            }
            strSql.Append(")AS Row, T.*,B.ImgPath  from tb_ClientManage T left join ContractImg as B on T.ContractImgID=B.ContractImgID ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            total = DbHelperSQL.GetCount(strSql.ToString());
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
    }
}
