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
    /// 角色表
    /// </summary>
    public partial class T_tb_Role
    {
        private readonly D_tb_Role dal = new D_tb_Role();
        public T_tb_Role()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleID)
        {
            return dal.Exists(RoleID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_Role model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_Role model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoleID)
        {

            return dal.Delete(RoleID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RoleIDlist)
        {
            return dal.DeleteList(RoleIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_Role GetModel(int RoleID)
        {

            return dal.GetModel(RoleID);
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
        public List<E_tb_Role> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_Role> DataTableToList(DataTable dt)
        {
            List<E_tb_Role> modelList = new List<E_tb_Role>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_Role model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_Role();
                    if (dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
                    }
                    model.RoleName = dt.Rows[n]["RoleName"].ToString();
                    if (dt.Rows[n]["DataRange"].ToString() != "")
                    {
                        model.DataRange = int.Parse(dt.Rows[n]["DataRange"].ToString());
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
