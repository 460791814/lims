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
    /// 区域表
    /// </summary>
    public partial class T_tb_Area
    {
        private readonly D_tb_Area dal = new D_tb_Area();
        public T_tb_Area()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AreaID)
        {
            return dal.Exists(AreaID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_Area model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_Area model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AreaID)
        {

            return dal.Delete(AreaID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string AreaIDlist)
        {
            return dal.DeleteList(AreaIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_Area GetModel(int AreaID)
        {

            return dal.GetModel(AreaID);
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
        public List<E_tb_Area> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_Area> DataTableToList(DataTable dt)
        {
            List<E_tb_Area> modelList = new List<E_tb_Area>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_Area model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_Area();
                    if (dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    model.AreaName = dt.Rows[n]["AreaName"].ToString();
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
