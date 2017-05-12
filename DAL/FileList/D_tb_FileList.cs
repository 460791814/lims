using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.FileList;

namespace DAL.FileList
{
    /// <summary>
    /// 数据访问类:tb_FileList
    /// </summary>
    public partial class D_tb_FileList
    {
        public D_tb_FileList()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FileID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_FileList");
            strSql.Append(" where FileID=@FileID");
            SqlParameter[] parameters = {
					new SqlParameter("@FileID", SqlDbType.Int,4)
};
            parameters[0].Value = FileID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_FileList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_FileList(");
            strSql.Append("FileType,ParentID,FileName,FilePath)");
            strSql.Append(" values (");
            strSql.Append("@FileType,@ParentID,@FileName,@FilePath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FileType", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.FileType;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.FileName;
            parameters[3].Value = model.FilePath;

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
        public bool Update(E_tb_FileList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_FileList set ");
            strSql.Append("FileType=@FileType,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("FilePath=@FilePath");
            strSql.Append(" where FileID=@FileID");
            SqlParameter[] parameters = {
					new SqlParameter("@FileType", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@FileName", SqlDbType.NVarChar,100),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,100),
					new SqlParameter("@FileID", SqlDbType.Int,4)};
            parameters[0].Value = model.FileType;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.FileName;
            parameters[3].Value = model.FilePath;
            parameters[4].Value = model.FileID;

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
        public bool Delete(int FileID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_FileList ");
            strSql.Append(" where FileID=@FileID");
            SqlParameter[] parameters = {
					new SqlParameter("@FileID", SqlDbType.Int,4)
};
            parameters[0].Value = FileID;

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
        public bool DeleteList(string FileIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_FileList ");
            strSql.Append(" where FileID in (" + FileIDlist + ")  ");
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
        public E_tb_FileList GetModel(int FileID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FileID,FileType,ParentID,FileName,FilePath from tb_FileList ");
            strSql.Append(" where FileID=@FileID");
            SqlParameter[] parameters = {
					new SqlParameter("@FileID", SqlDbType.Int,4)
};
            parameters[0].Value = FileID;

            E_tb_FileList model = new E_tb_FileList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FileID"].ToString() != "")
                {
                    model.FileID = int.Parse(ds.Tables[0].Rows[0]["FileID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FileType"].ToString() != "")
                {
                    model.FileType = int.Parse(ds.Tables[0].Rows[0]["FileType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FileName"] != null)
                {
                    model.FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FilePath"] != null)
                {
                    model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
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
            strSql.Append("select FileID,FileType,ParentID,FileName,FilePath ");
            strSql.Append(" FROM tb_FileList ");
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
            strSql.Append(" FileID,FileType,ParentID,FileName,FilePath ");
            strSql.Append(" FROM tb_FileList ");
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
            parameters[0].Value = "tb_FileList";
            parameters[1].Value = "FileID";
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
                strSql.Append("order by T.FileID desc");
            }
            strSql.Append(")AS Row, *  from tb_FileList as T");
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
