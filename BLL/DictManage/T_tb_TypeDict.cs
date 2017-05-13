using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DictManage;
using Model.DictManage;
using System.Data;

namespace BLL.DictManage
{
    /// <summary>
	/// tb_TypeDict
	/// </summary>
	public partial class T_tb_TypeDict
	{
        private readonly D_tb_TypeDict dal = new D_tb_TypeDict();
		public T_tb_TypeDict()
		{}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TypeID)
        {
            return dal.Exists(TypeID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_TypeDict model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_TypeDict model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int TypeID)
        {

            return dal.Delete(TypeID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TypeIDlist)
        {
            return dal.DeleteList(TypeIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_TypeDict GetModel(int TypeID)
        {

            return dal.GetModel(TypeID);
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
        public List<E_tb_TypeDict> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_TypeDict> DataTableToList(DataTable dt)
        {
            List<E_tb_TypeDict> modelList = new List<E_tb_TypeDict>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_TypeDict model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_TypeDict();
                    if (dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
                    }
                    if (dt.Rows[n]["SubjectID"].ToString() != "")
                    {
                        model.SubjectID = int.Parse(dt.Rows[n]["SubjectID"].ToString());
                    }
                    model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    if (dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    if (dt.Rows[n]["TypeLevel"].ToString() != "")
                    {
                        model.TypeLevel = int.Parse(dt.Rows[n]["TypeLevel"].ToString());
                    }
                    model.Directions = dt.Rows[n]["Directions"].ToString();
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
	}
}
