using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.ClientManage;
using Model.ClientManage;
using System.Data;

namespace BLL.ClientManage
{
    /// <summary>
    /// 客户管理
    /// </summary>
    public partial class T_tb_ClientManage
    {
        private readonly D_tb_ClientManage dal = new D_tb_ClientManage();
        public T_tb_ClientManage()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ClientID)
        {
            return dal.Exists(ClientID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ClientManage model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_ClientManage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ClientID)
        {

            return dal.Delete(ClientID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ClientIDlist)
        {
            return dal.DeleteList(ClientIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_ClientManage GetModel(int ClientID)
        {

            return dal.GetModel(ClientID);
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
        public List<E_tb_ClientManage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_ClientManage> DataTableToList(DataTable dt)
        {
            List<E_tb_ClientManage> modelList = new List<E_tb_ClientManage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_ClientManage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_ClientManage();
                    if (dt.Rows[n]["ClientID"].ToString() != "")
                    {
                        model.ClientID = int.Parse(dt.Rows[n]["ClientID"].ToString());
                    }
                    model.ClientName = dt.Rows[n]["ClientName"].ToString();
                    model.Contact = dt.Rows[n]["Contact"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.Deputy = dt.Rows[n]["Deputy"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.Fixed = dt.Rows[n]["Fixed"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
                    model.Fax = dt.Rows[n]["Fax"].ToString();
                    model.ZipCode = dt.Rows[n]["ZipCode"].ToString();
                    model.ClientLevel = dt.Rows[n]["ClientLevel"].ToString();
                    model.PrepaidMoney = dt.Rows[n]["PrepaidMoney"].ToString();
                    model.MainBusiness = dt.Rows[n]["MainBusiness"].ToString();
                    model.YearEntrust = dt.Rows[n]["YearEntrust"].ToString();
                    model.Incentives = dt.Rows[n]["Incentives"].ToString();
                    model.ContractNo = dt.Rows[n]["ContractNo"].ToString();
                    if (dt.Rows[n]["ContractImgID"].ToString() != "")
                    {
                        model.ContractImgID = int.Parse(dt.Rows[n]["ContractImgID"].ToString());
                    }
                    model.ContractPath = dt.Rows[n]["ContractPath"].ToString();
                    if (dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    if (dt.Rows[n]["EditPersonnelID"].ToString() != "")
                    {
                        model.EditPersonnelID = int.Parse(dt.Rows[n]["EditPersonnelID"].ToString());
                    }
                    modelList.Add(model);
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
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method

        #region 扩展方法
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, ref int total)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex, ref total);
        }
        #endregion
    }
}
