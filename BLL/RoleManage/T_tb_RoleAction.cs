using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.RoleManage;
using Model.RoleManage;
using System.Data;

namespace BLL.RoleManage
{
    /// <summary>
    /// T_tb_RoleAction
    /// </summary>
    public partial class T_tb_RoleAction
    {
        private readonly D_tb_RoleAction dal = new D_tb_RoleAction();
        public T_tb_RoleAction()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleActionID)
        {
            return dal.Exists(RoleActionID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_RoleAction model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_RoleAction model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoleActionID)
        {

            return dal.Delete(RoleActionID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RoleActionIDlist)
        {
            return dal.DeleteList(RoleActionIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_RoleAction GetModel(int RoleActionID)
        {

            return dal.GetModel(RoleActionID);
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
        public List<E_tb_RoleAction> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_RoleAction> DataTableToList(DataTable dt)
        {
            List<E_tb_RoleAction> modelList = new List<E_tb_RoleAction>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_RoleAction model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_RoleAction();
                    if (dt.Rows[n]["RoleActionID"].ToString() != "")
                    {
                        model.RoleActionID = int.Parse(dt.Rows[n]["RoleActionID"].ToString());
                    }
                    if (dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
                    }
                    if (dt.Rows[n]["ActionID"].ToString() != "")
                    {
                        model.ActionID = int.Parse(dt.Rows[n]["ActionID"].ToString());
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

        /// <summary>
        /// 批量删除
        /// </summary>
        public bool DeleteByWhere(string strWhere)
        {
            return dal.DeleteByWhere(strWhere);
        }
        #endregion
    }
}
