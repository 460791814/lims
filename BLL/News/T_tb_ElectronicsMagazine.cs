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
    /// tb_ElectronicsMagazine
    /// </summary>
    public partial class T_tb_ElectronicsMagazine
    {
        private readonly D_tb_ElectronicsMagazine dal = new D_tb_ElectronicsMagazine();
        public T_tb_ElectronicsMagazine()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MagazineID)
        {
            return dal.Exists(MagazineID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ElectronicsMagazine model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_ElectronicsMagazine model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MagazineID)
        {

            return dal.Delete(MagazineID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string MagazineIDlist)
        {
            return dal.DeleteList(MagazineIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_ElectronicsMagazine GetModel(int MagazineID)
        {

            return dal.GetModel(MagazineID);
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
        public List<E_tb_ElectronicsMagazine> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_ElectronicsMagazine> DataTableToList(DataTable dt)
        {
            List<E_tb_ElectronicsMagazine> modelList = new List<E_tb_ElectronicsMagazine>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_ElectronicsMagazine model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_ElectronicsMagazine();
                    if (dt.Rows[n]["MagazineID"].ToString() != "")
                    {
                        model.MagazineID = int.Parse(dt.Rows[n]["MagazineID"].ToString());
                    }
                    model.MagazineName = dt.Rows[n]["MagazineName"].ToString();
                    model.ImgPath = dt.Rows[n]["ImgPath"].ToString();
                    model.FliePath = dt.Rows[n]["FliePath"].ToString();
                    if (dt.Rows[n]["MagazineTypeID"].ToString() != "")
                    {
                        model.MagazineTypeID = int.Parse(dt.Rows[n]["MagazineTypeID"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
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
