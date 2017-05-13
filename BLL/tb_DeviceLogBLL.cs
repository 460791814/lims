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
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;

using Model;
using DAL;
namespace BLL
{
	/// <summary>
	/// tb_Device
	/// </summary>
	public partial class tb_DeviceLogBLL
	{
        private readonly tb_DeviceLogDAL dal = new tb_DeviceLogDAL();
        public tb_DeviceLogBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        public int GetCount(string where)
        {
            return dal.GetCount(where);
        }
		#endregion  BasicMethod


	}
}

