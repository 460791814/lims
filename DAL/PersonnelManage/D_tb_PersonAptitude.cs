using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据访问类:tb_PersonAptitude
    /// </summary>
    public partial class D_tb_PersonAptitude
    {
        public D_tb_PersonAptitude()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_PersonAptitude");
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
        public int Add(E_tb_PersonAptitude model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_PersonAptitude(");
            strSql.Append("Name,Sex,Tel,Post,Phone,BirthDate,Certificate,AreaID,EditPersonnelID)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Sex,@Tel,@Post,@Phone,@BirthDate,@Certificate,@AreaID,@EditPersonnelID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@Post", SqlDbType.Int,4),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@BirthDate", SqlDbType.DateTime),
					new SqlParameter("@Certificate", SqlDbType.NVarChar),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Sex;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Post;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.BirthDate;
            parameters[6].Value = model.Certificate;
            parameters[7].Value = model.AreaID;
            parameters[8].Value = model.EditPersonnelID;

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
        public bool Update(E_tb_PersonAptitude model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_PersonAptitude set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Post=@Post,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("BirthDate=@BirthDate,");
            strSql.Append("Certificate=@Certificate,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("EditPersonnelID=@EditPersonnelID");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@Post", SqlDbType.Int,4),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@BirthDate", SqlDbType.DateTime),
					new SqlParameter("@Certificate", SqlDbType.NVarChar),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@EditPersonnelID", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Sex;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Post;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.BirthDate;
            parameters[6].Value = model.Certificate;
            parameters[7].Value = model.AreaID;
            parameters[8].Value = model.EditPersonnelID;
            parameters[9].Value = model.id;

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
            strSql.Append("delete from tb_PersonAptitude ");
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_PersonAptitude ");
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
        public E_tb_PersonAptitude GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Name,Sex,Tel,Post,Phone,BirthDate,Certificate,AreaID,EditPersonnelID from tb_PersonAptitude ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            E_tb_PersonAptitude model = new E_tb_PersonAptitude();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null)
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null)
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tel"] != null)
                {
                    model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Post"].ToString() != "")
                {
                    model.Post = int.Parse(ds.Tables[0].Rows[0]["Post"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null)
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BirthDate"].ToString() != "")
                {
                    model.BirthDate = DateTime.Parse(ds.Tables[0].Rows[0]["BirthDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Certificate"] != null)
                {
                    model.Certificate = ds.Tables[0].Rows[0]["Certificate"].ToString();
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
            strSql.Append("select id,Name,Sex,Tel,Post,Phone,BirthDate,Certificate,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_PersonAptitude ");
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
            strSql.Append(" id,Name,Sex,Tel,Post,Phone,BirthDate,Certificate,AreaID,EditPersonnelID ");
            strSql.Append(" FROM tb_PersonAptitude ");
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
            parameters[0].Value = "tb_PersonAptitude";
            parameters[1].Value = "id";
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*,B.TypeName as PostName  from tb_PersonAptitude T left join tb_TypeDict as B on T.Post=B.TypeID ");
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
