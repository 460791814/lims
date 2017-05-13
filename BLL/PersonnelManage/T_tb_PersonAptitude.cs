using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    /// <summary>
    /// tb_PersonAptitude
    /// </summary>
    public partial class T_tb_PersonAptitude
    {
        private readonly D_tb_PersonAptitude dal = new D_tb_PersonAptitude();
        public T_tb_PersonAptitude()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_PersonAptitude model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_PersonAptitude model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_PersonAptitude GetModel(int id)
        {

            return dal.GetModel(id);
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
        public List<E_tb_PersonAptitude> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_PersonAptitude> DataTableToList(DataTable dt)
        {
            List<E_tb_PersonAptitude> modelList = new List<E_tb_PersonAptitude>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_PersonAptitude model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_PersonAptitude();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.Sex = dt.Rows[n]["Sex"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
                    if (dt.Rows[n]["Post"].ToString() != "")
                    {
                        model.Post = int.Parse(dt.Rows[n]["Post"].ToString());
                    }
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    if (dt.Rows[n]["BirthDate"].ToString() != "")
                    {
                        model.BirthDate = DateTime.Parse(dt.Rows[n]["BirthDate"].ToString());
                    }
                    model.Certificate = dt.Rows[n]["Certificate"].ToString();
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
