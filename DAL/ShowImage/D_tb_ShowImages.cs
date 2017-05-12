using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.ShowImage;

namespace DAL.ShowImage
{
    /// <summary>
    /// 数据访问类:tb_ShowImages
    /// </summary>
    public partial class D_tb_ShowImages
    {
        public D_tb_ShowImages()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ImgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_ShowImages");
            strSql.Append(" where ImgID=@ImgID");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgID", SqlDbType.Int,4)
};
            parameters[0].Value = ImgID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ShowImages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_ShowImages(");
            strSql.Append("ImgTypeID,ImgName,ImgPath,FilePath,OrderID,AreaID,EditPersonnelID)");
            strSql.Append(" values (");
            strSql.Append("@ImgTypeID,@ImgName,@ImgPath,@FilePath,@OrderID,@AreaID,@EditPersonnelID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgTypeID", SqlDbType.Int,4),
					new SqlParameter("@ImgName", SqlDbType.NVarChar,50),
					new SqlParameter("@ImgPath", SqlDbType.NVarChar,50),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4)};
            parameters[0].Value = model.ImgTypeID;
            parameters[1].Value = model.ImgName;
            parameters[2].Value = model.ImgPath;
            parameters[3].Value = model.FilePath;
            parameters[4].Value = model.OrderID;
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
        public bool Update(E_tb_ShowImages model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_ShowImages set ");
            strSql.Append("ImgTypeID=@ImgTypeID,");
            strSql.Append("ImgName=@ImgName,");
            strSql.Append("ImgPath=@ImgPath,");
            strSql.Append("FilePath=@FilePath,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID");
            strSql.Append(" where ImgID=@ImgID");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgTypeID", SqlDbType.Int,4),
					new SqlParameter("@ImgName", SqlDbType.NVarChar,50),
					new SqlParameter("@ImgPath", SqlDbType.NVarChar,50),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@ImgID", SqlDbType.Int,4)};
            parameters[0].Value = model.ImgTypeID;
            parameters[1].Value = model.ImgName;
            parameters[2].Value = model.ImgPath;
            parameters[3].Value = model.FilePath;
            parameters[4].Value = model.OrderID;
            parameters[5].Value = model.AreaID;
            parameters[6].Value = model.EditPersonnelID;
            parameters[7].Value = model.ImgID;

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
        public bool Delete(int ImgID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_ShowImages ");
            strSql.Append(" where ImgID=@ImgID");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgID", SqlDbType.Int,4)
};
            parameters[0].Value = ImgID;

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
        public bool DeleteList(string ImgIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_ShowImages ");
            strSql.Append(" where ImgID in (" + ImgIDlist + ")  ");
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
        public E_tb_ShowImages GetModel(int ImgID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ImgID,ImgTypeID,ImgName,ImgPath,FilePath,OrderID,AreaID,EditPersonnelID from tb_ShowImages ");
            strSql.Append(" where ImgID=@ImgID");
            SqlParameter[] parameters = {
					new SqlParameter("@ImgID", SqlDbType.Int,4)
};
            parameters[0].Value = ImgID;

            E_tb_ShowImages model = new E_tb_ShowImages();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ImgID"].ToString() != "")
                {
                    model.ImgID = int.Parse(ds.Tables[0].Rows[0]["ImgID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ImgTypeID"].ToString() != "")
                {
                    model.ImgTypeID = int.Parse(ds.Tables[0].Rows[0]["ImgTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ImgName"] != null)
                {
                    model.ImgName = ds.Tables[0].Rows[0]["ImgName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImgPath"] != null)
                {
                    model.ImgPath = ds.Tables[0].Rows[0]["ImgPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FilePath"] != null)
                {
                    model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
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
            strSql.Append("select ImgID,ImgTypeID,ImgName,ImgPath,FilePath,OrderID,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_ShowImages ");
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
            strSql.Append(" ImgID,ImgTypeID,ImgName,ImgPath,FilePath,OrderID,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_ShowImages ");
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
            parameters[0].Value = "tb_ShowImages";
            parameters[1].Value = "ImgID";
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
                strSql.Append("order by T.ImgID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_ShowImages T ");
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
