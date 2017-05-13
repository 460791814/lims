using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.News;
using Model.News;
using System.Data;

namespace BLL.News
{
    /// <summary>
    /// tb_News
    /// </summary>
    public partial class T_tb_News
    {
        private readonly D_tb_News dal = new D_tb_News();
        public T_tb_News()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int NewID)
        {
            return dal.Exists(NewID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_News model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_News model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int NewID)
        {

            return dal.Delete(NewID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string NewIDlist)
        {
            return dal.DeleteList(NewIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_News GetModel(int NewID)
        {

            return dal.GetModel(NewID);
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
        public List<E_tb_News> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_News> DataTableToList(DataTable dt)
        {
            List<E_tb_News> modelList = new List<E_tb_News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_News();
                    if (dt.Rows[n]["NewID"].ToString() != "")
                    {
                        model.NewID = int.Parse(dt.Rows[n]["NewID"].ToString());
                    }
                    if (dt.Rows[n]["NewTypeID"].ToString() != "")
                    {
                        model.NewTypeID = int.Parse(dt.Rows[n]["NewTypeID"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.Contents = dt.Rows[n]["Contents"].ToString();
                    if (dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    if (dt.Rows[n]["EditPersonnelID"].ToString() != "")
                    {
                        model.EditPersonnelID = int.Parse(dt.Rows[n]["EditPersonnelID"].ToString());
                    }
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
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
