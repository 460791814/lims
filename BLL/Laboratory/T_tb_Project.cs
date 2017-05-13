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
	/// T_tb_Project
	/// </summary>
	public partial class T_tb_Project
	{
        private readonly D_tb_Project dal = new D_tb_Project();
		public T_tb_Project()
		{}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ProjectID)
        {
            return dal.Exists(ProjectID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_Project model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_Project model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ProjectID)
        {

            return dal.Delete(ProjectID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ProjectIDlist)
        {
            return dal.DeleteList(ProjectIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_Project GetModel(int ProjectID)
        {

            return dal.GetModel(ProjectID);
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
        public List<E_tb_Project> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_Project> DataTableToList(DataTable dt)
        {
            List<E_tb_Project> modelList = new List<E_tb_Project>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_Project model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_Project();
                    if (dt.Rows[n]["ProjectID"].ToString() != "")
                    {
                        model.ProjectID = int.Parse(dt.Rows[n]["ProjectID"].ToString());
                    }
                    if (dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    if (dt.Rows[n]["LaboratoryID"].ToString() != "")
                    {
                        model.LaboratoryID = int.Parse(dt.Rows[n]["LaboratoryID"].ToString());
                    }
                    if (dt.Rows[n]["ProjectTypeID"].ToString() != "")
                    {
                        model.ProjectTypeID = int.Parse(dt.Rows[n]["ProjectTypeID"].ToString());
                    }
                    model.ProjectName = dt.Rows[n]["ProjectName"].ToString();
                    model.ExpeType = dt.Rows[n]["ExpeType"].ToString();
                    model.ExpeMethod = dt.Rows[n]["ExpeMethod"].ToString();
                    model.ExpRange = dt.Rows[n]["ExpRange"].ToString();
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    model.SampleDataRange = dt.Rows[n]["SampleDataRange"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    model.FileName = dt.Rows[n]["FileName"].ToString();
                    if (dt.Rows[n]["IsPesCheck"].ToString() != "")
                    {
                        model.IsPesCheck = int.Parse(dt.Rows[n]["IsPesCheck"].ToString());
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
        /// 根据原始记录要求获取项目列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable GetListByOriginalRecord(string strWhere)
        {
            return dal.GetListByOriginalRecord(strWhere);
        }
        #endregion
	}
}
