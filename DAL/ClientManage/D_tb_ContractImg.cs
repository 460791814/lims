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
    /// 数据访问类:ContractImg
    /// </summary>
    public partial class D_tb_ContractImg
    {
        public D_tb_ContractImg()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ContractImgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ContractImg");
            strSql.Append(" where ContractImgID=@ContractImgID");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractImgID", SqlDbType.Int,4)
};
            parameters[0].Value = ContractImgID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ContractImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ContractImg(");
            strSql.Append("Title,ImgPath,Contents,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@Title,@ImgPath,@Contents,@AddTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ImgPath", SqlDbType.NVarChar,50),
					new SqlParameter("@Contents", SqlDbType.NVarChar,200),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.ImgPath;
            parameters[2].Value = model.Contents;
            parameters[3].Value = model.AddTime;

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
        public bool Update(E_tb_ContractImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ContractImg set ");
            strSql.Append("Title=@Title,");
            strSql.Append("ImgPath=@ImgPath,");
            strSql.Append("Contents=@Contents,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" where ContractImgID=@ContractImgID");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ImgPath", SqlDbType.NVarChar,50),
					new SqlParameter("@Contents", SqlDbType.NVarChar,200),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@ContractImgID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.ImgPath;
            parameters[2].Value = model.Contents;
            parameters[3].Value = model.AddTime;
            parameters[4].Value = model.ContractImgID;

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
        public bool Delete(int ContractImgID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ContractImg ");
            strSql.Append(" where ContractImgID=@ContractImgID");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractImgID", SqlDbType.Int,4)
};
            parameters[0].Value = ContractImgID;

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
        public bool DeleteList(string ContractImgIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ContractImg ");
            strSql.Append(" where ContractImgID in (" + ContractImgIDlist + ")  ");
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
        public E_tb_ContractImg GetModel(int ContractImgID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ContractImgID,Title,ImgPath,Contents,AddTime from ContractImg ");
            strSql.Append(" where ContractImgID=@ContractImgID");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractImgID", SqlDbType.Int,4)
};
            parameters[0].Value = ContractImgID;

            E_tb_ContractImg model = new E_tb_ContractImg();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ContractImgID"].ToString() != "")
                {
                    model.ContractImgID = int.Parse(ds.Tables[0].Rows[0]["ContractImgID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null)
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImgPath"] != null)
                {
                    model.ImgPath = ds.Tables[0].Rows[0]["ImgPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contents"] != null)
                {
                    model.Contents = ds.Tables[0].Rows[0]["Contents"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
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
            strSql.Append("select ContractImgID,Title,ImgPath,Contents,AddTime ");
            strSql.Append(" FROM ContractImg ");
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
            strSql.Append(" ContractImgID,Title,ImgPath,Contents,AddTime ");
            strSql.Append(" FROM ContractImg ");
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
            parameters[0].Value = "ContractImg";
            parameters[1].Value = "ContractImgID";
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
                strSql.Append("order by T.ContractImgID desc");
            }
            strSql.Append(")AS Row, T.*  from ContractImg T ");
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
