using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.EntrustManage;
using Model.EntrustManage;
using System.Data;

namespace BLL.EntrustManage
{
    /// <summary>
    /// T_tb_EntrustTesting
    /// </summary>
    public partial class T_tb_EntrustTesting
    {
        private readonly D_tb_EntrustTesting dal = new D_tb_EntrustTesting();
        public T_tb_EntrustTesting()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int EntrustID)
        {
            return dal.Exists(EntrustID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_EntrustTesting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_EntrustTesting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int EntrustID)
        {

            return dal.Delete(EntrustID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string EntrustIDlist)
        {
            return dal.DeleteList(EntrustIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_EntrustTesting GetModel(int EntrustID)
        {

            return dal.GetModel(EntrustID);
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
        public List<E_tb_EntrustTesting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_EntrustTesting> DataTableToList(DataTable dt)
        {
            List<E_tb_EntrustTesting> modelList = new List<E_tb_EntrustTesting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_EntrustTesting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_EntrustTesting();
                    if (dt.Rows[n]["EntrustID"].ToString() != "")
                    {
                        model.EntrustID = int.Parse(dt.Rows[n]["EntrustID"].ToString());
                    }
                    model.TaskNo = dt.Rows[n]["TaskNo"].ToString();
                    model.EntrustCompany = dt.Rows[n]["EntrustCompany"].ToString();
                    if (dt.Rows[n]["SampleID"].ToString() != "")
                    {
                        model.SampleID = int.Parse(dt.Rows[n]["SampleID"].ToString());
                    }
                    if (dt.Rows[n]["ProjectID"].ToString() != "")
                    {
                        model.ProjectID = int.Parse(dt.Rows[n]["ProjectID"].ToString());
                    }
                    if (dt.Rows[n]["TestPersonnelID"].ToString() != "")
                    {
                        model.TestPersonnelID = int.Parse(dt.Rows[n]["TestPersonnelID"].ToString());
                    }
                    if (dt.Rows[n]["SubmissionTime"].ToString() != "")
                    {
                        model.SubmissionTime = DateTime.Parse(dt.Rows[n]["SubmissionTime"].ToString());
                    }
                    if (dt.Rows[n]["ReportID"].ToString() != "")
                    {
                        model.ReportID = int.Parse(dt.Rows[n]["ReportID"].ToString());
                    }
                    if (dt.Rows[n]["IsComplete"].ToString() != "")
                    {
                        model.IsComplete = int.Parse(dt.Rows[n]["IsComplete"].ToString());
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

        /// <summary>
        /// 检查是已存在该任务单号
        /// </summary>
        /// <param name="TaskNo"></param>
        /// <returns></returns>
        public int IsExistsTaskNo(string TaskNo)
        {
            return dal.IsExistsTaskNo(TaskNo);
        }
        #endregion
    }
}
