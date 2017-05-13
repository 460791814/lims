/**  版本信息模板在安装目录下，可自行修改。
* tb_EasyConsume.cs
*
* 功 能： N/A
* 类 名： tb_EasyConsume
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/4 21:23:34   N/A    初版
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
using DAL;
using Model;
namespace BLL
{
    /// <summary>
    /// tb_EasyConsume
    /// </summary>
    public partial class tb_EasyConsumeBLL
    {
        private readonly tb_EasyConsumeDAL dal = new tb_EasyConsumeDAL();
        public tb_EasyConsumeBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(tb_EasyConsume model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(tb_EasyConsume model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public tb_EasyConsume GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<tb_EasyConsume> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<tb_EasyConsume> DataTableToList(DataTable dt)
        {
            List<tb_EasyConsume> modelList = new List<tb_EasyConsume>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                tb_EasyConsume model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataTable GetEasyConsumeLogListByPage(Model.PersonnelManage.E_tb_InPersonnel CurrentUserInfo, int _cid, string _searchtext, string orderby, int startIndex, int endIndex, string _searchtext2)
        {
            String where2 = "";
            if (!String.IsNullOrEmpty(_searchtext2))
            {
                where2 = " name like '%%" + _searchtext2 + "%%'";
            }
            DataTable dt = dal.GetListByPage(where2, orderby, startIndex, endIndex).Tables[0];
            tb_EasyConsumeOUTBLL _outbll = new tb_EasyConsumeOUTBLL();
            tb_EasyConsumeINBLL _inbll = new tb_EasyConsumeINBLL();
            dt.Columns.Add("ruku");
            dt.Columns.Add("chuku");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int eid = Convert.ToInt32(dt.Rows[i]["id"]);
                string where = " 1 = 1 ";
                if (!string.IsNullOrEmpty(_searchtext))
                {
                    where += string.Format(" and  (cast(OutDate as datetime)) = '{0}' ", _searchtext);
                }
                if (CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  createUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID.Value, _userid);
                }
                else if (_cid > 0 || CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                where += " and eid=" + eid;
                DataTable dtout = _outbll.GetEasyCOnsumeOUTSUMForLog(where);
                if (dtout != null && dtout.Rows.Count > 0)
                {
                    int inid = Convert.ToInt32(dtout.Rows[0]["temp2"]);
                    tb_EasyConsumeIN inmodel = _inbll.GetModel(inid);
                    dt.Rows[i]["chuku"] = dtout.Rows[0]["chuku"];
                    dt.Rows[i]["ruku"] = inmodel.amount;
                    dt.Rows[i]["amount"] = inmodel.temp2;
                }
            }
            return dt;
        }

        /// <summary>
        /// 易耗品总数
        /// </summary>
        public int GetEasyConsumeCount(string strWhere)
        {
            return dal.GetEasyConsumeCount(strWhere);
        }
        #endregion  ExtensionMethod


    }
}

