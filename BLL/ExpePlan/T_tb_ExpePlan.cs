using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.ExpePlan;
using Model.ExpePlan;
using System.Data;

namespace BLL.ExpePlan
{
    /// <summary>
    /// 实验计划表
    /// </summary>
    public partial class T_tb_ExpePlan
    {
        private readonly D_tb_ExpePlan dal = new D_tb_ExpePlan();
        public T_tb_ExpePlan()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PlanID)
        {
            return dal.Exists(PlanID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ExpePlan model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_ExpePlan model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PlanID)
        {

            return dal.Delete(PlanID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PlanIDlist)
        {
            return dal.DeleteList(PlanIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_ExpePlan GetModel(int PlanID)
        {

            return dal.GetModel(PlanID);
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
        public List<E_tb_ExpePlan> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_ExpePlan> DataTableToList(DataTable dt)
        {
            List<E_tb_ExpePlan> modelList = new List<E_tb_ExpePlan>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_ExpePlan model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_ExpePlan();
                    if (dt.Rows[n]["PlanID"].ToString() != "")
                    {
                        model.PlanID = int.Parse(dt.Rows[n]["PlanID"].ToString());
                    }
                    if (dt.Rows[n]["PlanTypeID"].ToString() != "")
                    {
                        model.PlanTypeID = int.Parse(dt.Rows[n]["PlanTypeID"].ToString());
                    }
                    if (dt.Rows[n]["ProjectID"].ToString() != "")
                    {
                        model.ProjectID = int.Parse(dt.Rows[n]["ProjectID"].ToString());
                    }
                    if (dt.Rows[n]["SampleID"].ToString() != "")
                    {
                        model.SampleID = int.Parse(dt.Rows[n]["SampleID"].ToString());
                    }
                    if (dt.Rows[n]["InspectTime"].ToString() != "")
                    {
                        model.InspectTime = DateTime.Parse(dt.Rows[n]["InspectTime"].ToString());
                    }
                    model.InspectPlace = dt.Rows[n]["InspectPlace"].ToString();
                    model.InspectMethod = dt.Rows[n]["InspectMethod"].ToString();
                    if (dt.Rows[n]["HeadPersonnelID"].ToString() != "")
                    {
                        model.HeadPersonnelID = int.Parse(dt.Rows[n]["HeadPersonnelID"].ToString());
                    }
                    model.TaskNo = dt.Rows[n]["TaskNo"].ToString();
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
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

        /// <summary>
        /// 根据实验计划ID集合更新计划完成状态
        /// </summary>
        /// <param name="PlanIDS"></param>
        /// <returns></returns>
        public int UpdateStatusByPlanIDS(string PlanIDS, int ReportID)
        {
            return dal.UpdateStatusByPlanIDS(PlanIDS, ReportID);
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

        /// <summary>
        /// 获得实验计划超出检验时间内容
        /// 作者：章建国
        /// </summary>
        public DataSet GetUNFinishList()
        {
            return dal.GetUNFinishList();
        }
        /// <summary>
        /// 获得实验计划超出检验时间及委托检验未完成的内容
        /// 作者：张伟
        /// </summary>
        public DataSet GetAllUNFinishList()
        {
            return dal.GetAllUNFinishList();
        }
        #endregion
    }
}
