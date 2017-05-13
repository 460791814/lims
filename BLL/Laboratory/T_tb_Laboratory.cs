using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Laboratory;
using Model.Laboratory;
using System.Data;

namespace BLL.Laboratory
{
    /// <summary>
    /// 实验室表
    /// </summary>
    public partial class T_tb_Laboratory
    {
        private readonly D_tb_Laboratory dal = new D_tb_Laboratory();
        public T_tb_Laboratory()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LaboratoryID)
        {
            return dal.Exists(LaboratoryID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_Laboratory model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_Laboratory model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int LaboratoryID)
        {

            return dal.Delete(LaboratoryID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string LaboratoryIDlist)
        {
            return dal.DeleteList(LaboratoryIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_Laboratory GetModel(int LaboratoryID)
        {

            return dal.GetModel(LaboratoryID);
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
        public List<E_tb_Laboratory> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_Laboratory> DataTableToList(DataTable dt)
        {
            List<E_tb_Laboratory> modelList = new List<E_tb_Laboratory>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_Laboratory model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_Laboratory();
                    if (dt.Rows[n]["LaboratoryID"].ToString() != "")
                    {
                        model.LaboratoryID = int.Parse(dt.Rows[n]["LaboratoryID"].ToString());
                    }
                    if (dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    model.LaboratoryName = dt.Rows[n]["LaboratoryName"].ToString();
                    if (dt.Rows[n]["LaboratoryTypeID"].ToString() != "")
                    {
                        model.LaboratoryTypeID = int.Parse(dt.Rows[n]["LaboratoryTypeID"].ToString());
                    }
                    model.Directions = dt.Rows[n]["Directions"].ToString();
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    if (dt.Rows[n]["IsUse"].ToString() != "")
                    {
                        model.IsUse = int.Parse(dt.Rows[n]["IsUse"].ToString());
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
