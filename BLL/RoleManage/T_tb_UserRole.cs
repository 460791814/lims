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
    /// 用户角色关系表
    /// </summary>
    public partial class T_tb_UserRole
    {
        private readonly D_tb_UserRole dal = new D_tb_UserRole();
        public T_tb_UserRole()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserRoleID)
        {
            return dal.Exists(UserRoleID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_UserRole model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_UserRole model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserRoleID)
        {

            return dal.Delete(UserRoleID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string UserRoleIDlist)
        {
            return dal.DeleteList(UserRoleIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_UserRole GetModel(int UserRoleID)
        {

            return dal.GetModel(UserRoleID);
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
        public List<E_tb_UserRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_UserRole> DataTableToList(DataTable dt)
        {
            List<E_tb_UserRole> modelList = new List<E_tb_UserRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_UserRole model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_UserRole();
                    if (dt.Rows[n]["UserRoleID"].ToString() != "")
                    {
                        model.UserRoleID = int.Parse(dt.Rows[n]["UserRoleID"].ToString());
                    }
                    if (dt.Rows[n]["PersonnelID"].ToString() != "")
                    {
                        model.PersonnelID = int.Parse(dt.Rows[n]["PersonnelID"].ToString());
                    }
                    if (dt.Rows[n]["RoleID"].ToString() != "")
                    {
                        model.RoleID = int.Parse(dt.Rows[n]["RoleID"].ToString());
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteByWhere(string strWhere)
        {
            return dal.DeleteByWhere(strWhere);
        }
        #endregion
    }
}
