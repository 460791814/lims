using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model.PersonnelManage;

namespace DAL.PersonnelManage
{
    /// <summary>
    /// 数据访问类:D_tb_InPersonnel
    /// </summary>
    public partial class D_tb_InPersonnel
    {
        public D_tb_InPersonnel()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PersonnelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_InPersonnel");
            strSql.Append(" where PersonnelID=@PersonnelID");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelID", SqlDbType.Int,4)
};
            parameters[0].Value = PersonnelID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_InPersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_InPersonnel(");
            strSql.Append("AreaID,PersonnelName,Department,Sex,Birthday,Educational,Title,Post,WorkingTime,Description,Tel,CID,UserName,PassWord)");
            strSql.Append(" values (");
            strSql.Append("@AreaID,@PersonnelName,@Department,@Sex,@Birthday,@Educational,@Title,@Post,@WorkingTime,@Description,@Tel,@CID,@UserName,@PassWord)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@PersonnelName", SqlDbType.NVarChar,50),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Educational", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Post", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.Text),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@CID", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AreaID;
            parameters[1].Value = model.PersonnelName;
            parameters[2].Value = model.Department;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.Educational;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.Post;
            parameters[8].Value = model.WorkingTime;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.Tel;
            parameters[11].Value = model.CID;
            parameters[12].Value = model.UserName;
            parameters[13].Value = model.PassWord;

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
        public bool Update(E_tb_InPersonnel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_InPersonnel set ");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("PersonnelName=@PersonnelName,");
            strSql.Append("Department=@Department,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Educational=@Educational,");
            strSql.Append("Title=@Title,");
            strSql.Append("Post=@Post,");
            strSql.Append("WorkingTime=@WorkingTime,");
            strSql.Append("Description=@Description,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("CID=@CID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PassWord=@PassWord");
            strSql.Append(" where PersonnelID=@PersonnelID");
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@PersonnelName", SqlDbType.NVarChar,50),
					new SqlParameter("@Department", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@Educational", SqlDbType.NVarChar,50),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Post", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkingTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.Text),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@CID", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@PersonnelID", SqlDbType.Int,4)};
            parameters[0].Value = model.AreaID;
            parameters[1].Value = model.PersonnelName;
            parameters[2].Value = model.Department;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.Educational;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.Post;
            parameters[8].Value = model.WorkingTime;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.Tel;
            parameters[11].Value = model.CID;
            parameters[12].Value = model.UserName;
            parameters[13].Value = model.PassWord;
            parameters[14].Value = model.PersonnelID;

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
        public bool Delete(int PersonnelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_InPersonnel ");
            strSql.Append(" where PersonnelID=@PersonnelID");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelID", SqlDbType.Int,4)
};
            parameters[0].Value = PersonnelID;

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
        public bool DeleteList(string PersonnelIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_InPersonnel ");
            strSql.Append(" where PersonnelID in (" + PersonnelIDlist + ")  ");
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
        public E_tb_InPersonnel GetModel(int PersonnelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PersonnelID,AreaID,PersonnelName,Department,Sex,Birthday,Educational,Title,Post,WorkingTime,Description,Tel,CID,UserName,PassWord from tb_InPersonnel ");
            strSql.Append(" where PersonnelID=@PersonnelID");
            SqlParameter[] parameters = {
					new SqlParameter("@PersonnelID", SqlDbType.Int,4)
};
            parameters[0].Value = PersonnelID;

            E_tb_InPersonnel model = new E_tb_InPersonnel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PersonnelID"].ToString() != "")
                {
                    model.PersonnelID = int.Parse(ds.Tables[0].Rows[0]["PersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PersonnelName"] != null)
                {
                    model.PersonnelName = ds.Tables[0].Rows[0]["PersonnelName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Department"] != null)
                {
                    model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null)
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Educational"] != null)
                {
                    model.Educational = ds.Tables[0].Rows[0]["Educational"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Title"] != null)
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Post"] != null)
                {
                    model.Post = ds.Tables[0].Rows[0]["Post"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WorkingTime"] != null)
                {
                    model.WorkingTime = ds.Tables[0].Rows[0]["WorkingTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null)
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tel"] != null)
                {
                    model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CID"] != null)
                {
                    model.CID = ds.Tables[0].Rows[0]["CID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null)
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PassWord"] != null)
                {
                    model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
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
            strSql.Append("select PersonnelID,AreaID,PersonnelName,Department,Sex,Birthday,Educational,Title,Post,WorkingTime,Description,Tel,CID,UserName,PassWord ");
            strSql.Append(" FROM tb_InPersonnel ");
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
            strSql.Append(" PersonnelID,AreaID,PersonnelName,Department,Sex,Birthday,Educational,Title,Post,WorkingTime,Description,Tel,CID,UserName,PassWord ");
            strSql.Append(" FROM tb_InPersonnel ");
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
            parameters[0].Value = "tb_InPersonnel";
            parameters[1].Value = "PersonnelID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        #region 数据接口

        public string GetAreaNameByPersonId(string PersonId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT AreaName FROM tb_InPersonnel A left join tb_Area B on A.AreaID=B.AreaID where PersonnelID=" + PersonId);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                    return dt.Rows[0][0].ToString();
                else
                    return "";
            }
            else
                return "";
        }

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
                strSql.Append("order by T.PersonnelID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_InPersonnel T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            total = DbHelperSQL.GetCount(strSql.ToString());
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 用户登录验证
        /// </summary>
        public E_tb_InPersonnel Login(string UserName, string PassWord)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 A.*,C.DataRange from tb_InPersonnel as A join tb_UserRole as B  on A.PersonnelID=B.PersonnelID join tb_Role as C on B.RoleID=C.RoleID");
            strSql.Append(" where A.UserName=@UserName and A.PassWord=@PassWord");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@PassWord", SqlDbType.NVarChar,50)
};
            parameters[0].Value = UserName;
            parameters[1].Value = PassWord;

            E_tb_InPersonnel model = new E_tb_InPersonnel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PersonnelID"].ToString() != "")
                {
                    model.PersonnelID = int.Parse(ds.Tables[0].Rows[0]["PersonnelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PersonnelName"] != null)
                {
                    model.PersonnelName = ds.Tables[0].Rows[0]["PersonnelName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Department"] != null)
                {
                    model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null)
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Educational"] != null)
                {
                    model.Educational = ds.Tables[0].Rows[0]["Educational"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Title"] != null)
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Post"] != null)
                {
                    model.Post = ds.Tables[0].Rows[0]["Post"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WorkingTime"] != null)
                {
                    model.WorkingTime = ds.Tables[0].Rows[0]["WorkingTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null)
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tel"] != null)
                {
                    model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CID"] != null)
                {
                    model.CID = ds.Tables[0].Rows[0]["CID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null)
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PassWord"] != null)
                {
                    model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DataRange"].ToString() != "")
                {
                    model.DataRange = int.Parse(ds.Tables[0].Rows[0]["DataRange"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
