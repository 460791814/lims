/**  版本信息模板在安装目录下，可自行修改。
* tb_Sample.cs
*
* 功 能： N/A
* 类 名： tb_Sample
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/9 14:32:57   N/A    初版
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
	/// 数据访问类:tb_Sample
	/// </summary>
	public partial class tb_SampleDAL
	{
        public tb_SampleDAL()
		{}
        #region  BasicMethod  备份

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "tb_Sample");
        }

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int id)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from tb_Sample");
        //    strSql.Append(" where id=@id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = id;

        //    return DbHelperSQL.Exists(strSql.ToString(),parameters);
        //}


        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(tb_Sample model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into tb_Sample(");
        //    strSql.Append("name,standard,batch,productDate,modelType,expirationDate,packaging,isDetection,detectionUser,detectionDate,createUser,createDate,updateUser,updateDate,temp1,temp2)");
        //    strSql.Append(" values (");
        //    strSql.Append("@name,@standard,@batch,@productDate,@modelType,@expirationDate,@packaging,@isDetection,@detectionUser,@detectionDate,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2)");
        //    strSql.Append(";select @@IDENTITY");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@name", SqlDbType.NVarChar,200),
        //            new SqlParameter("@standard", SqlDbType.NVarChar,200),
        //            new SqlParameter("@batch", SqlDbType.VarChar,200),
        //            new SqlParameter("@productDate", SqlDbType.DateTime),
        //            new SqlParameter("@modelType", SqlDbType.VarChar,200),
        //            new SqlParameter("@expirationDate", SqlDbType.NVarChar,200),
        //            new SqlParameter("@packaging", SqlDbType.NVarChar,50),
        //            new SqlParameter("@isDetection", SqlDbType.Bit,1),
        //            new SqlParameter("@detectionUser", SqlDbType.NVarChar,200),
        //            new SqlParameter("@detectionDate", SqlDbType.DateTime),
        //            new SqlParameter("@createUser", SqlDbType.Int,4),
        //            new SqlParameter("@createDate", SqlDbType.DateTime),
        //            new SqlParameter("@updateUser", SqlDbType.Int,4),
        //            new SqlParameter("@updateDate", SqlDbType.DateTime),
        //            new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
        //            new SqlParameter("@temp2", SqlDbType.NVarChar,-1)};
        //    parameters[0].Value = model.name;
        //    parameters[1].Value = model.standard;
        //    parameters[2].Value = model.batch;
        //    parameters[3].Value = model.productDate;
        //    parameters[4].Value = model.modelType;
        //    parameters[5].Value = model.expirationDate;
        //    parameters[6].Value = model.packaging;
        //    parameters[7].Value = model.isDetection;
        //    parameters[8].Value = model.detectionUser;
        //    parameters[9].Value = model.detectionDate;
        //    parameters[10].Value = model.createUser;
        //    parameters[11].Value = model.createDate;
        //    parameters[12].Value = model.updateUser;
        //    parameters[13].Value = model.updateDate;
        //    parameters[14].Value = model.temp1;
        //    parameters[15].Value = model.temp2;

        //    object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(tb_Sample model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("update tb_Sample set ");
        //    strSql.Append("name=@name,");
        //    strSql.Append("standard=@standard,");
        //    strSql.Append("batch=@batch,");
        //    strSql.Append("productDate=@productDate,");
        //    strSql.Append("modelType=@modelType,");
        //    strSql.Append("expirationDate=@expirationDate,");
        //    strSql.Append("packaging=@packaging,");
        //    strSql.Append("isDetection=@isDetection,");
        //    strSql.Append("detectionUser=@detectionUser,");
        //    strSql.Append("detectionDate=@detectionDate,");
        //    strSql.Append("createUser=@createUser,");
        //    strSql.Append("createDate=@createDate,");
        //    strSql.Append("updateUser=@updateUser,");
        //    strSql.Append("updateDate=@updateDate,");
        //    strSql.Append("temp1=@temp1,");
        //    strSql.Append("temp2=@temp2");
        //    strSql.Append(" where id=@id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@name", SqlDbType.NVarChar,200),
        //            new SqlParameter("@standard", SqlDbType.NVarChar,200),
        //            new SqlParameter("@batch", SqlDbType.VarChar,200),
        //            new SqlParameter("@productDate", SqlDbType.DateTime),
        //            new SqlParameter("@modelType", SqlDbType.VarChar,200),
        //            new SqlParameter("@expirationDate", SqlDbType.NVarChar,200),
        //            new SqlParameter("@packaging", SqlDbType.NVarChar,50),
        //            new SqlParameter("@isDetection", SqlDbType.Bit,1),
        //            new SqlParameter("@detectionUser", SqlDbType.NVarChar,200),
        //            new SqlParameter("@detectionDate", SqlDbType.DateTime),
        //            new SqlParameter("@createUser", SqlDbType.Int,4),
        //            new SqlParameter("@createDate", SqlDbType.DateTime),
        //            new SqlParameter("@updateUser", SqlDbType.Int,4),
        //            new SqlParameter("@updateDate", SqlDbType.DateTime),
        //            new SqlParameter("@temp1", SqlDbType.NVarChar,-1),
        //            new SqlParameter("@temp2", SqlDbType.NVarChar,-1),
        //            new SqlParameter("@id", SqlDbType.Int,4)};
        //    parameters[0].Value = model.name;
        //    parameters[1].Value = model.standard;
        //    parameters[2].Value = model.batch;
        //    parameters[3].Value = model.productDate;
        //    parameters[4].Value = model.modelType;
        //    parameters[5].Value = model.expirationDate;
        //    parameters[6].Value = model.packaging;
        //    parameters[7].Value = model.isDetection;
        //    parameters[8].Value = model.detectionUser;
        //    parameters[9].Value = model.detectionDate;
        //    parameters[10].Value = model.createUser;
        //    parameters[11].Value = model.createDate;
        //    parameters[12].Value = model.updateUser;
        //    parameters[13].Value = model.updateDate;
        //    parameters[14].Value = model.temp1;
        //    parameters[15].Value = model.temp2;
        //    parameters[16].Value = model.id;

        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(int id)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from tb_Sample ");
        //    strSql.Append(" where id=@id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = id;

        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        ///// <summary>
        ///// 批量删除数据
        ///// </summary>
        //public bool DeleteList(string idlist )
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from tb_Sample ");
        //    strSql.Append(" where id in ("+idlist + ")  ");
        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public tb_Sample GetModel(int id)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select  top 1 id,name,standard,batch,productDate,modelType,expirationDate,packaging,isDetection,detectionUser,detectionDate,createUser,createDate,updateUser,updateDate,temp1,temp2 from tb_Sample ");
        //    strSql.Append(" where id=@id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = id;

        //    tb_Sample model=new tb_Sample();
        //    DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
        //    if(ds.Tables[0].Rows.Count>0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public tb_Sample DataRowToModel(DataRow row)
        //{
        //    tb_Sample model=new tb_Sample();
        //    if (row != null)
        //    {
        //        if(row["id"]!=null && row["id"].ToString()!="")
        //        {
        //            model.id=int.Parse(row["id"].ToString());
        //        }
        //        if(row["name"]!=null)
        //        {
        //            model.name=row["name"].ToString();
        //        }
        //        if(row["standard"]!=null)
        //        {
        //            model.standard=row["standard"].ToString();
        //        }
        //        if(row["batch"]!=null)
        //        {
        //            model.batch=row["batch"].ToString();
        //        }
        //        if(row["productDate"]!=null && row["productDate"].ToString()!="")
        //        {
        //            model.productDate=DateTime.Parse(row["productDate"].ToString());
        //        }
        //        if(row["modelType"]!=null)
        //        {
        //            model.modelType=row["modelType"].ToString();
        //        }
        //        if(row["expirationDate"]!=null && row["expirationDate"].ToString()!="")
        //        {
        //            model.expirationDate=row["expirationDate"].ToString();
        //        }
        //        if(row["packaging"]!=null)
        //        {
        //            model.packaging=row["packaging"].ToString();
        //        }
        //        if(row["isDetection"]!=null && row["isDetection"].ToString()!="")
        //        {
        //            if((row["isDetection"].ToString()=="1")||(row["isDetection"].ToString().ToLower()=="true"))
        //            {
        //                model.isDetection=true;
        //            }
        //            else
        //            {
        //                model.isDetection=false;
        //            }
        //        }
        //        if(row["detectionUser"]!=null)
        //        {
        //            model.detectionUser=row["detectionUser"].ToString();
        //        }
        //        if(row["detectionDate"]!=null && row["detectionDate"].ToString()!="")
        //        {
        //            model.detectionDate=DateTime.Parse(row["detectionDate"].ToString());
        //        }
        //        if(row["createUser"]!=null && row["createUser"].ToString()!="")
        //        {
        //            model.createUser=int.Parse(row["createUser"].ToString());
        //        }
        //        if(row["createDate"]!=null && row["createDate"].ToString()!="")
        //        {
        //            model.createDate=DateTime.Parse(row["createDate"].ToString());
        //        }
        //        if(row["updateUser"]!=null && row["updateUser"].ToString()!="")
        //        {
        //            model.updateUser=int.Parse(row["updateUser"].ToString());
        //        }
        //        if(row["updateDate"]!=null && row["updateDate"].ToString()!="")
        //        {
        //            model.updateDate=DateTime.Parse(row["updateDate"].ToString());
        //        }
        //        if(row["temp1"]!=null)
        //        {
        //            model.temp1=row["temp1"].ToString();
        //        }
        //        if(row["temp2"]!=null)
        //        {
        //            model.temp2=row["temp2"].ToString();
        //        }
        //    }
        //    return model;
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select id,name,standard,batch,productDate,modelType,expirationDate,packaging,isDetection,detectionUser,detectionDate,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
        //    strSql.Append(" FROM tb_Sample ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataSet GetList(int Top,string strWhere,string filedOrder)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select ");
        //    if(Top>0)
        //    {
        //        strSql.Append(" top "+Top.ToString());
        //    }
        //    strSql.Append(" id,name,standard,batch,productDate,modelType,expirationDate,packaging,isDetection,detectionUser,detectionDate,createUser,createDate,updateUser,updateDate,temp1,temp2 ");
        //    strSql.Append(" FROM tb_Sample ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///// <summary>
        ///// 获取记录总数
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) FROM tb_Sample ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    object obj = DbHelperSQL.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby );
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.id desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from tb_Sample T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

		#endregion  BasicMethod  备份

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Sample");
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
        public int Add(tb_Sample model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Sample(");
            strSql.Append("name,standard,batch,productDate,modelType,expirationDate,packaging,isDetection,detectionUser,detectionDate,createUser,createDate,updateUser,updateDate,temp1,temp2,putArea,sampleHandle,handleUser,handleDate,sampleAdmin,detectionGist,detectionMethod,InspectCompany,detectionAdress,detectionCompany,InspectAddress,projectName,testMethod,sampleNum,protNum)");
            strSql.Append(" values (");
            strSql.Append("@name,@standard,@batch,@productDate,@modelType,@expirationDate,@packaging,@isDetection,@detectionUser,@detectionDate,@createUser,@createDate,@updateUser,@updateDate,@temp1,@temp2,@putArea,@sampleHandle,@handleUser,@handleDate,@sampleAdmin,@detectionGist,@detectionMethod,@InspectCompany,@detectionAdress,@detectionCompany,@InspectAddress,@projectName,@testMethod,@sampleNum,@protNum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,200),
					new SqlParameter("@standard", SqlDbType.NVarChar,200),
					new SqlParameter("@batch", SqlDbType.VarChar,200),
					new SqlParameter("@productDate", SqlDbType.DateTime),
					new SqlParameter("@modelType", SqlDbType.VarChar,200),
					new SqlParameter("@expirationDate", SqlDbType.NVarChar,200),
					new SqlParameter("@packaging", SqlDbType.NVarChar,50),
					new SqlParameter("@isDetection", SqlDbType.Bit,1),
					new SqlParameter("@detectionUser", SqlDbType.NVarChar,200),
					new SqlParameter("@detectionDate", SqlDbType.DateTime),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar),
					new SqlParameter("@temp2", SqlDbType.NVarChar),
					new SqlParameter("@putArea", SqlDbType.NVarChar),
					new SqlParameter("@sampleHandle", SqlDbType.NVarChar),
					new SqlParameter("@handleUser", SqlDbType.NVarChar,50),
					new SqlParameter("@handleDate", SqlDbType.DateTime),
					new SqlParameter("@sampleAdmin", SqlDbType.NVarChar),
					new SqlParameter("@detectionGist", SqlDbType.NVarChar,200),
					new SqlParameter("@detectionMethod", SqlDbType.NVarChar),
					new SqlParameter("@InspectCompany", SqlDbType.NVarChar),
					new SqlParameter("@detectionAdress", SqlDbType.NVarChar),
					new SqlParameter("@detectionCompany", SqlDbType.NVarChar),
					new SqlParameter("@InspectAddress", SqlDbType.NVarChar),
					new SqlParameter("@projectName", SqlDbType.NVarChar),
					new SqlParameter("@testMethod", SqlDbType.NVarChar),
					new SqlParameter("@sampleNum", SqlDbType.NVarChar),
					new SqlParameter("@protNum", SqlDbType.NVarChar)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.standard;
            parameters[2].Value = model.batch;
            parameters[3].Value = model.productDate;
            parameters[4].Value = model.modelType;
            parameters[5].Value = model.expirationDate;
            parameters[6].Value = model.packaging;
            parameters[7].Value = model.isDetection;
            parameters[8].Value = model.detectionUser;
            parameters[9].Value = model.detectionDate;
            parameters[10].Value = model.createUser;
            parameters[11].Value = model.createDate;
            parameters[12].Value = model.updateUser;
            parameters[13].Value = model.updateDate;
            parameters[14].Value = model.temp1;
            parameters[15].Value = model.temp2;
            parameters[16].Value = model.putArea;
            parameters[17].Value = model.sampleHandle;
            parameters[18].Value = model.handleUser;
            parameters[19].Value = model.handleDate;
            parameters[20].Value = model.sampleAdmin;
            parameters[21].Value = model.detectionGist;
            parameters[22].Value = model.detectionMethod;
            parameters[23].Value = model.InspectCompany;
            parameters[24].Value = model.detectionAdress;
            parameters[25].Value = model.detectionCompany;
            parameters[26].Value = model.InspectAddress;
            parameters[27].Value = model.projectName;
            parameters[28].Value = model.testMethod;
            parameters[29].Value = model.sampleNum;
            parameters[30].Value = model.protNum;

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
        public bool Update(tb_Sample model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Sample set ");
            strSql.Append("name=@name,");
            strSql.Append("standard=@standard,");
            strSql.Append("batch=@batch,");
            strSql.Append("productDate=@productDate,");
            strSql.Append("modelType=@modelType,");
            strSql.Append("expirationDate=@expirationDate,");
            strSql.Append("packaging=@packaging,");
            strSql.Append("isDetection=@isDetection,");
            strSql.Append("detectionUser=@detectionUser,");
            strSql.Append("detectionDate=@detectionDate,");
            strSql.Append("createUser=@createUser,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("updateUser=@updateUser,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("temp1=@temp1,");
            strSql.Append("temp2=@temp2,");
            strSql.Append("putArea=@putArea,");
            strSql.Append("sampleHandle=@sampleHandle,");
            strSql.Append("handleUser=@handleUser,");
            strSql.Append("handleDate=@handleDate,");
            strSql.Append("sampleAdmin=@sampleAdmin,");
            strSql.Append("detectionGist=@detectionGist,");
            strSql.Append("detectionMethod=@detectionMethod,");
            strSql.Append("InspectCompany=@InspectCompany,");
            strSql.Append("detectionAdress=@detectionAdress,");
            strSql.Append("detectionCompany=@detectionCompany,");
            strSql.Append("InspectAddress=@InspectAddress,");
            strSql.Append("projectName=@projectName,");
            strSql.Append("testMethod=@testMethod,");
            strSql.Append("sampleNum=@sampleNum,");
            strSql.Append("protNum=@protNum");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,200),
					new SqlParameter("@standard", SqlDbType.NVarChar,200),
					new SqlParameter("@batch", SqlDbType.VarChar,200),
					new SqlParameter("@productDate", SqlDbType.DateTime),
					new SqlParameter("@modelType", SqlDbType.VarChar,200),
					new SqlParameter("@expirationDate", SqlDbType.NVarChar,200),
					new SqlParameter("@packaging", SqlDbType.NVarChar,50),
					new SqlParameter("@isDetection", SqlDbType.Bit,1),
					new SqlParameter("@detectionUser", SqlDbType.NVarChar,200),
					new SqlParameter("@detectionDate", SqlDbType.DateTime),
					new SqlParameter("@createUser", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@updateUser", SqlDbType.Int,4),
					new SqlParameter("@updateDate", SqlDbType.DateTime),
					new SqlParameter("@temp1", SqlDbType.NVarChar),
					new SqlParameter("@temp2", SqlDbType.NVarChar),
					new SqlParameter("@putArea", SqlDbType.NVarChar),
					new SqlParameter("@sampleHandle", SqlDbType.NVarChar),
					new SqlParameter("@handleUser", SqlDbType.NVarChar,50),
					new SqlParameter("@handleDate", SqlDbType.DateTime),
					new SqlParameter("@sampleAdmin", SqlDbType.NVarChar),
					new SqlParameter("@detectionGist", SqlDbType.NVarChar,200),
					new SqlParameter("@detectionMethod", SqlDbType.NVarChar),
					new SqlParameter("@InspectCompany", SqlDbType.NVarChar),
					new SqlParameter("@detectionAdress", SqlDbType.NVarChar),
					new SqlParameter("@detectionCompany", SqlDbType.NVarChar),
					new SqlParameter("@InspectAddress", SqlDbType.NVarChar),
					new SqlParameter("@projectName", SqlDbType.NVarChar),
					new SqlParameter("@testMethod", SqlDbType.NVarChar),
					new SqlParameter("@sampleNum", SqlDbType.NVarChar),
					new SqlParameter("@protNum", SqlDbType.NVarChar),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.standard;
            parameters[2].Value = model.batch;
            parameters[3].Value = model.productDate;
            parameters[4].Value = model.modelType;
            parameters[5].Value = model.expirationDate;
            parameters[6].Value = model.packaging;
            parameters[7].Value = model.isDetection;
            parameters[8].Value = model.detectionUser;
            parameters[9].Value = model.detectionDate;
            parameters[10].Value = model.createUser;
            parameters[11].Value = model.createDate;
            parameters[12].Value = model.updateUser;
            parameters[13].Value = model.updateDate;
            parameters[14].Value = model.temp1;
            parameters[15].Value = model.temp2;
            parameters[16].Value = model.putArea;
            parameters[17].Value = model.sampleHandle;
            parameters[18].Value = model.handleUser;
            parameters[19].Value = model.handleDate;
            parameters[20].Value = model.sampleAdmin;
            parameters[21].Value = model.detectionGist;
            parameters[22].Value = model.detectionMethod;
            parameters[23].Value = model.InspectCompany;
            parameters[24].Value = model.detectionAdress;
            parameters[25].Value = model.detectionCompany;
            parameters[26].Value = model.InspectAddress;
            parameters[27].Value = model.projectName;
            parameters[28].Value = model.testMethod;
            parameters[29].Value = model.sampleNum;
            parameters[30].Value = model.protNum;
            parameters[31].Value = model.id;

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
            strSql.Append("delete from tb_Sample ");
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
            strSql.Append("delete from tb_Sample ");
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
        public tb_Sample GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,standard,batch,productDate,modelType,expirationDate,packaging,isDetection,detectionUser,detectionDate,createUser,createDate,updateUser,updateDate,temp1,temp2,putArea,sampleHandle,handleUser,handleDate,sampleAdmin,detectionGist,detectionMethod,InspectCompany,detectionAdress,detectionCompany,InspectAddress,projectName,testMethod,sampleNum,protNum from tb_Sample ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            tb_Sample model = new tb_Sample();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["name"] != null)
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["standard"] != null)
                {
                    model.standard = ds.Tables[0].Rows[0]["standard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["batch"] != null)
                {
                    model.batch = ds.Tables[0].Rows[0]["batch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["productDate"].ToString() != "")
                {
                    model.productDate = DateTime.Parse(ds.Tables[0].Rows[0]["productDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["modelType"] != null)
                {
                    model.modelType = ds.Tables[0].Rows[0]["modelType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["expirationDate"] != null)
                {
                    model.expirationDate = ds.Tables[0].Rows[0]["expirationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["packaging"] != null)
                {
                    model.packaging = ds.Tables[0].Rows[0]["packaging"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isDetection"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["isDetection"].ToString() == "1") || (ds.Tables[0].Rows[0]["isDetection"].ToString().ToLower() == "true"))
                    {
                        model.isDetection = true;
                    }
                    else
                    {
                        model.isDetection = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["detectionUser"] != null)
                {
                    model.detectionUser = ds.Tables[0].Rows[0]["detectionUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["detectionDate"].ToString() != "")
                {
                    model.detectionDate = DateTime.Parse(ds.Tables[0].Rows[0]["detectionDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["createUser"].ToString() != "")
                {
                    model.createUser = int.Parse(ds.Tables[0].Rows[0]["createUser"].ToString());
                }
                if (ds.Tables[0].Rows[0]["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(ds.Tables[0].Rows[0]["createDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["updateUser"].ToString() != "")
                {
                    model.updateUser = int.Parse(ds.Tables[0].Rows[0]["updateUser"].ToString());
                }
                if (ds.Tables[0].Rows[0]["updateDate"].ToString() != "")
                {
                    model.updateDate = DateTime.Parse(ds.Tables[0].Rows[0]["updateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["temp1"] != null)
                {
                    model.temp1 = ds.Tables[0].Rows[0]["temp1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["temp2"] != null)
                {
                    model.temp2 = ds.Tables[0].Rows[0]["temp2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["putArea"] != null)
                {
                    model.putArea = ds.Tables[0].Rows[0]["putArea"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sampleHandle"] != null)
                {
                    model.sampleHandle = ds.Tables[0].Rows[0]["sampleHandle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["handleUser"] != null)
                {
                    model.handleUser = ds.Tables[0].Rows[0]["handleUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["handleDate"].ToString() != "")
                {
                    model.handleDate = DateTime.Parse(ds.Tables[0].Rows[0]["handleDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sampleAdmin"] != null)
                {
                    model.sampleAdmin = ds.Tables[0].Rows[0]["sampleAdmin"].ToString();
                }
                if (ds.Tables[0].Rows[0]["detectionGist"] != null)
                {
                    model.detectionGist = ds.Tables[0].Rows[0]["detectionGist"].ToString();
                }
                if (ds.Tables[0].Rows[0]["detectionMethod"] != null)
                {
                    model.detectionMethod = ds.Tables[0].Rows[0]["detectionMethod"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InspectCompany"] != null)
                {
                    model.InspectCompany = ds.Tables[0].Rows[0]["InspectCompany"].ToString();
                }
                if (ds.Tables[0].Rows[0]["detectionAdress"] != null)
                {
                    model.detectionAdress = ds.Tables[0].Rows[0]["detectionAdress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["detectionCompany"] != null)
                {
                    model.detectionCompany = ds.Tables[0].Rows[0]["detectionCompany"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InspectAddress"] != null)
                {
                    model.InspectAddress = ds.Tables[0].Rows[0]["InspectAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["projectName"] != null)
                {
                    model.projectName = ds.Tables[0].Rows[0]["projectName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["testMethod"] != null)
                {
                    model.testMethod = ds.Tables[0].Rows[0]["testMethod"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sampleNum"] != null)
                {
                    model.sampleNum = ds.Tables[0].Rows[0]["sampleNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["protNum"] != null)
                {
                    model.protNum = ds.Tables[0].Rows[0]["protNum"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM tb_Sample ");
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
            strSql.Append(" id,name,standard,batch,productDate,modelType,expirationDate,packaging,isDetection,detectionUser,detectionDate,createUser,createDate,updateUser,updateDate,temp1,temp2,putArea,sampleHandle,handleUser,handleDate,sampleAdmin,detectionGist,detectionMethod,InspectCompany,detectionAdress,detectionCompany,InspectAddress,projectName,testMethod,sampleNum,protNum ");
            strSql.Append(" FROM tb_Sample ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public tb_Sample DataRowToModel(DataRow row)
        {
            tb_Sample model = new tb_Sample();
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
                if (row["standard"] != null)
                {
                    model.standard = row["standard"].ToString();
                }
                if (row["batch"] != null)
                {
                    model.batch = row["batch"].ToString();
                }
                if (row["productDate"] != null && row["productDate"].ToString() != "")
                {
                    model.productDate = DateTime.Parse(row["productDate"].ToString());
                }
                if (row["modelType"] != null)
                {
                    model.modelType = row["modelType"].ToString();
                }
                if (row["expirationDate"] != null)
                {
                    model.expirationDate = row["expirationDate"].ToString();
                }
                if (row["packaging"] != null)
                {
                    model.packaging = row["packaging"].ToString();
                }
                if (row["isDetection"] != null && row["isDetection"].ToString() != "")
                {
                    if ((row["isDetection"].ToString() == "1") || (row["isDetection"].ToString().ToLower() == "true"))
                    {
                        model.isDetection = true;
                    }
                    else
                    {
                        model.isDetection = false;
                    }
                }
                if (row["detectionUser"] != null)
                {
                    model.detectionUser = row["detectionUser"].ToString();
                }
                if (row["detectionDate"] != null && row["detectionDate"].ToString() != "")
                {
                    model.detectionDate = DateTime.Parse(row["detectionDate"].ToString());
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
                if (row["putArea"] != null)
                {
                    model.putArea = row["putArea"].ToString();
                }
                if (row["sampleHandle"] != null)
                {
                    model.sampleHandle = row["sampleHandle"].ToString();
                }
                if (row["handleUser"] != null)
                {
                    model.handleUser = row["handleUser"].ToString();
                }
                if (row["handleDate"] != null && row["handleDate"].ToString() != "")
                {
                    model.handleDate = DateTime.Parse(row["handleDate"].ToString());
                }
                if (row["sampleAdmin"] != null)
                {
                    model.sampleAdmin = row["sampleAdmin"].ToString();
                }
                if (row["detectionGist"] != null)
                {
                    model.detectionGist = row["detectionGist"].ToString();
                }
                if (row["detectionMethod"] != null)
                {
                    model.detectionMethod = row["detectionMethod"].ToString();
                }
                if (row["InspectCompany"] != null)
                {
                    model.InspectCompany = row["InspectCompany"].ToString();
                }
                if (row["detectionAdress"] != null)
                {
                    model.detectionAdress = row["detectionAdress"].ToString();
                }
                if (row["detectionCompany"] != null)
                {
                    model.detectionCompany = row["detectionCompany"].ToString();
                }
                if (row["InspectAddress"] != null)
                {
                    model.InspectAddress = row["InspectAddress"].ToString();
                }
                if (row["projectName"] != null)
                {
                    model.projectName = row["projectName"].ToString();
                }
                if (row["testMethod"] != null)
                {
                    model.testMethod = row["testMethod"].ToString();
                }
                if (row["sampleNum"] != null)
                {
                    model.sampleNum = row["sampleNum"].ToString();
                }
                if (row["protNum"] != null)
                {
                    model.protNum = row["protNum"].ToString();
                }
            }
            return model;
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
            parameters[0].Value = "tb_Sample";
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
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_Sample ");
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
            strSql.Append(")AS Row, T.*  from tb_Sample T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

