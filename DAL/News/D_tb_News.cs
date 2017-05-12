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
    /// 数据访问类:tb_News
    /// </summary>
    public partial class D_tb_News
    {
        public D_tb_News()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NewID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_News");
            strSql.Append(" where NewID=@NewID");
            SqlParameter[] parameters = {
					new SqlParameter("@NewID", SqlDbType.Int,4)
};
            parameters[0].Value = NewID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_News(");
            strSql.Append("NewTypeID,Title,Contents,AreaID,EditPersonnelID,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@NewTypeID,@Title,@Contents,@AreaID,@EditPersonnelID,@UpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@NewTypeID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Contents", SqlDbType.Text),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.NewTypeID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Contents;
            parameters[3].Value = model.AreaID;
            parameters[4].Value = model.EditPersonnelID;
            parameters[5].Value = model.UpdateTime;

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
        public bool Update(E_tb_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_News set ");
            strSql.Append("NewTypeID=@NewTypeID,");
            strSql.Append("Title=@Title,");
            strSql.Append("Contents=@Contents,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where NewID=@NewID");
            SqlParameter[] parameters = {
					new SqlParameter("@NewTypeID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Contents", SqlDbType.Text),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@NewID", SqlDbType.Int,4)};
            parameters[0].Value = model.NewTypeID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Contents;
            parameters[3].Value = model.AreaID;
            parameters[4].Value = model.EditPersonnelID;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.NewID;

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
        public bool Delete(int NewID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_News ");
            strSql.Append(" where NewID=@NewID");
            SqlParameter[] parameters = {
					new SqlParameter("@NewID", SqlDbType.Int,4)
};
            parameters[0].Value = NewID;

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
        public bool DeleteList(string NewIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_News ");
            strSql.Append(" where NewID in (" + NewIDlist + ")  ");
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
        public E_tb_News GetModel(int NewID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NewID,NewTypeID,Title,Contents,AreaID,EditPersonnelID,UpdateTime from tb_News ");
            strSql.Append(" where NewID=@NewID");
            SqlParameter[] parameters = {
					new SqlParameter("@NewID", SqlDbType.Int,4)
};
            parameters[0].Value = NewID;

            E_tb_News model = new E_tb_News();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["NewID"].ToString() != "")
                {
                    model.NewID = int.Parse(ds.Tables[0].Rows[0]["NewID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NewTypeID"].ToString() != "")
                {
                    model.NewTypeID = int.Parse(ds.Tables[0].Rows[0]["NewTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null)
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contents"] != null)
                {
                    model.Contents = ds.Tables[0].Rows[0]["Contents"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditPersonnelID"].ToString() != "")
                {
                    model.EditPersonnelID = int.Parse(ds.Tables[0].Rows[0]["EditPersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
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
            strSql.Append("select NewID,NewTypeID,Title,Contents,AreaID,EditPersonnelID,UpdateTime ");
            strSql.Append(" FROM tb_News ");
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
            strSql.Append(" NewID,NewTypeID,Title,Contents,AreaID,EditPersonnelID,UpdateTime ");
            strSql.Append(" FROM tb_News ");
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
            parameters[0].Value = "tb_News";
            parameters[1].Value = "NewID";
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
                strSql.Append("order by T.NewID desc");
            }
            strSql.Append(")AS Row, T.NewID,T.NewTypeID,T.Title,T.UpdateTime,B.TypeName  from tb_News T left join tb_TypeDict B on T.NewTypeID=B.TypeID");
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
