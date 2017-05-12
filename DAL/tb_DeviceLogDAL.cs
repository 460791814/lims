/**  版本信息模板在安装目录下，可自行修改。
* tb_Device.cs
*
* 功 能： N/A
* 类 名： tb_Device
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/29 14:00:14   N/A    初版
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
	/// 数据访问类:tb_Device
	/// </summary>
	public partial class tb_DeviceLogDAL
	{
        public tb_DeviceLogDAL()
		{}
        #region  BasicMethod
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
            strSql.Append(")AS Row, T.*  from View_DeviceLog T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        public int GetCount(string where)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM View_DeviceLog  ");
                if (!string.IsNullOrEmpty(where))
                {
                    strSql.Append("where " + where); 
                }
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                return ds.Tables[0].Rows.Count;
            }
            catch
            {
                return 0;
            }
        }
        #endregion  BasicMethod
    }
}
