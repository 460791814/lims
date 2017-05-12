using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.News;

namespace DAL.News
{
    /// <summary>
    /// 数据访问类:D_tb_ElectronicsMagazine
    /// </summary>
    public partial class D_tb_ElectronicsMagazine
    {
        public D_tb_ElectronicsMagazine()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MagazineID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_ElectronicsMagazine");
            strSql.Append(" where MagazineID=@MagazineID");
            SqlParameter[] parameters = {
					new SqlParameter("@MagazineID", SqlDbType.Int,4)
};
            parameters[0].Value = MagazineID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ElectronicsMagazine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_ElectronicsMagazine(");
            strSql.Append("MagazineName,ImgPath,FliePath,MagazineTypeID,AddTime,AreaID,EditPersonnelID)");
            strSql.Append(" values (");
            strSql.Append("@MagazineName,@ImgPath,@FliePath,@MagazineTypeID,@AddTime,@AreaID,@EditPersonnelID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MagazineName", SqlDbType.NVarChar,50),
					new SqlParameter("@ImgPath", SqlDbType.NVarChar,50),
					new SqlParameter("@FliePath", SqlDbType.NVarChar,50),
					new SqlParameter("@MagazineTypeID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4)};
            parameters[0].Value = model.MagazineName;
            parameters[1].Value = model.ImgPath;
            parameters[2].Value = model.FliePath;
            parameters[3].Value = model.MagazineTypeID;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.AreaID;
            parameters[6].Value = model.EditPersonnelID;

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
        public bool Update(E_tb_ElectronicsMagazine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_ElectronicsMagazine set ");
            strSql.Append("MagazineName=@MagazineName,");
            strSql.Append("ImgPath=@ImgPath,");
            strSql.Append("FliePath=@FliePath,");
            strSql.Append("MagazineTypeID=@MagazineTypeID,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID");
            strSql.Append(" where MagazineID=@MagazineID");
            SqlParameter[] parameters = {
					new SqlParameter("@MagazineName", SqlDbType.NVarChar,50),
					new SqlParameter("@ImgPath", SqlDbType.NVarChar,50),
					new SqlParameter("@FliePath", SqlDbType.NVarChar,50),
					new SqlParameter("@MagazineTypeID", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@MagazineID", SqlDbType.Int,4)};
            parameters[0].Value = model.MagazineName;
            parameters[1].Value = model.ImgPath;
            parameters[2].Value = model.FliePath;
            parameters[3].Value = model.MagazineTypeID;
            parameters[4].Value = model.AddTime;
            parameters[5].Value = model.AreaID;
            parameters[6].Value = model.EditPersonnelID;
            parameters[7].Value = model.MagazineID;

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
        public bool Delete(int MagazineID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_ElectronicsMagazine ");
            strSql.Append(" where MagazineID=@MagazineID");
            SqlParameter[] parameters = {
					new SqlParameter("@MagazineID", SqlDbType.Int,4)
};
            parameters[0].Value = MagazineID;

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
        public bool DeleteList(string MagazineIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_ElectronicsMagazine ");
            strSql.Append(" where MagazineID in (" + MagazineIDlist + ")  ");
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
        public E_tb_ElectronicsMagazine GetModel(int MagazineID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MagazineID,MagazineName,ImgPath,FliePath,MagazineTypeID,AddTime,AreaID,EditPersonnelID from tb_ElectronicsMagazine ");
            strSql.Append(" where MagazineID=@MagazineID");
            SqlParameter[] parameters = {
					new SqlParameter("@MagazineID", SqlDbType.Int,4)
};
            parameters[0].Value = MagazineID;

            E_tb_ElectronicsMagazine model = new E_tb_ElectronicsMagazine();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MagazineID"].ToString() != "")
                {
                    model.MagazineID = int.Parse(ds.Tables[0].Rows[0]["MagazineID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MagazineName"] != null)
                {
                    model.MagazineName = ds.Tables[0].Rows[0]["MagazineName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImgPath"] != null)
                {
                    model.ImgPath = ds.Tables[0].Rows[0]["ImgPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FliePath"] != null)
                {
                    model.FliePath = ds.Tables[0].Rows[0]["FliePath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MagazineTypeID"].ToString() != "")
                {
                    model.MagazineTypeID = int.Parse(ds.Tables[0].Rows[0]["MagazineTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
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
            strSql.Append("select MagazineID,MagazineName,ImgPath,FliePath,MagazineTypeID,AddTime,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_ElectronicsMagazine ");
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
            strSql.Append(" MagazineID,MagazineName,ImgPath,FliePath,MagazineTypeID,AddTime,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_ElectronicsMagazine ");
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
            parameters[0].Value = "tb_ElectronicsMagazine";
            parameters[1].Value = "MagazineID";
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
                strSql.Append("order by T.MagazineID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_ElectronicsMagazine T");
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
