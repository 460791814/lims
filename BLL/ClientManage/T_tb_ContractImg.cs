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
    /// 合同图标
    /// </summary>
    public partial class T_tb_ContractImg
    {
        private readonly D_tb_ContractImg dal = new D_tb_ContractImg();
        public T_tb_ContractImg()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ContractImgID)
        {
            return dal.Exists(ContractImgID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ContractImg model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_ContractImg model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ContractImgID)
        {

            return dal.Delete(ContractImgID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ContractImgIDlist)
        {
            return dal.DeleteList(ContractImgIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_ContractImg GetModel(int ContractImgID)
        {

            return dal.GetModel(ContractImgID);
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
        public List<E_tb_ContractImg> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_ContractImg> DataTableToList(DataTable dt)
        {
            List<E_tb_ContractImg> modelList = new List<E_tb_ContractImg>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_ContractImg model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_ContractImg();
                    if (dt.Rows[n]["ContractImgID"].ToString() != "")
                    {
                        model.ContractImgID = int.Parse(dt.Rows[n]["ContractImgID"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.ImgPath = dt.Rows[n]["ImgPath"].ToString();
                    model.Contents = dt.Rows[n]["Contents"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
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
