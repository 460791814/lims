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
    /// T_tb_Action
    /// </summary>
    public partial class T_tb_Action
    {
        private readonly D_tb_Action dal = new D_tb_Action();
        public T_tb_Action()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ActionID)
        {
            return dal.Exists(ActionID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_Action model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_Action model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ActionID)
        {

            return dal.Delete(ActionID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ActionIDlist)
        {
            return dal.DeleteList(ActionIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_Action GetModel(int ActionID)
        {

            return dal.GetModel(ActionID);
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
        public List<E_tb_Action> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_Action> DataTableToList(DataTable dt)
        {
            List<E_tb_Action> modelList = new List<E_tb_Action>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_Action model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_Action();
                    if (dt.Rows[n]["ActionID"].ToString() != "")
                    {
                        model.ActionID = int.Parse(dt.Rows[n]["ActionID"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    model.ActionName = dt.Rows[n]["ActionName"].ToString();
                    model.ActionCode = dt.Rows[n]["ActionCode"].ToString();
                    model.RequestType = dt.Rows[n]["RequestType"].ToString();
                    model.RequestURL = dt.Rows[n]["RequestURL"].ToString();
                    if (dt.Rows[n]["ActionType"].ToString() != "")
                    {
                        model.ActionType = int.Parse(dt.Rows[n]["ActionType"].ToString());
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
