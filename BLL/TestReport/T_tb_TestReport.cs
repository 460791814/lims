using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.TestReport;
using Model.TestReport;
using System.Data;

namespace BLL.TestReport
{
    /// <summary>
    /// 检验报告
    /// </summary>
    public partial class T_tb_TestReport
    {
        private readonly D_tb_TestReport dal = new D_tb_TestReport();
        public T_tb_TestReport()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ReportID)
        {
            return dal.Exists(ReportID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_TestReport model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_TestReport model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ReportID)
        {

            return dal.Delete(ReportID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ReportIDlist)
        {
            return dal.DeleteList(ReportIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_TestReport GetModel(int ReportID)
        {

            return dal.GetModel(ReportID);
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
        public List<E_tb_TestReport> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_TestReport> DataTableToList(DataTable dt)
        {
            List<E_tb_TestReport> modelList = new List<E_tb_TestReport>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_TestReport model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_TestReport();
                    if (dt.Rows[n]["ReportID"].ToString() != "")
                    {
                        model.ReportID = int.Parse(dt.Rows[n]["ReportID"].ToString());
                    }
                    model.RecordIDS = dt.Rows[n]["RecordIDS"].ToString();
                    model.TaskNoS = dt.Rows[n]["TaskNoS"].ToString();
                    model.ReportNo = dt.Rows[n]["ReportNo"].ToString();
                    model.SampleNum = dt.Rows[n]["SampleNum"].ToString();
                    model.SampleName = dt.Rows[n]["SampleName"].ToString();
                    model.Department = dt.Rows[n]["Department"].ToString();
                    if (dt.Rows[n]["TestType"].ToString() != "")
                    {
                        model.TestType = int.Parse(dt.Rows[n]["TestType"].ToString());
                    }
                    if (dt.Rows[n]["IssuedTime"].ToString() != "")
                    {
                        model.IssuedTime = DateTime.Parse(dt.Rows[n]["IssuedTime"].ToString());
                    }
                    model.TestingCompany = dt.Rows[n]["TestingCompany"].ToString();
                    model.Specifications = dt.Rows[n]["Specifications"].ToString();
                    if (dt.Rows[n]["ProductionTime"].ToString() != "")
                    {
                        model.ProductionTime = DateTime.Parse(dt.Rows[n]["ProductionTime"].ToString());
                    }
                    model.Packing = dt.Rows[n]["Packing"].ToString();
                    model.productNum = dt.Rows[n]["productNum"].ToString();
                    model.ToSampleMode = dt.Rows[n]["ToSampleMode"].ToString();
                    model.SendTestAddress = dt.Rows[n]["SendTestAddress"].ToString();
                    model.SamplingPlace = dt.Rows[n]["SamplingPlace"].ToString();
                    model.SamplingCompany = dt.Rows[n]["SamplingCompany"].ToString();
                    model.SamplingPersonnel = dt.Rows[n]["SamplingPersonnel"].ToString();
                    if (dt.Rows[n]["SamplingTime"].ToString() != "")
                    {
                        model.SamplingTime = DateTime.Parse(dt.Rows[n]["SamplingTime"].ToString());
                    }
                    if (dt.Rows[n]["TestTime"].ToString() != "")
                    {
                        model.TestTime = DateTime.Parse(dt.Rows[n]["TestTime"].ToString());
                    }
                    model.ShelfLife = dt.Rows[n]["ShelfLife"].ToString();
                    model.TestBasis = dt.Rows[n]["TestBasis"].ToString();
                    model.Conclusion = dt.Rows[n]["Conclusion"].ToString();
                    model.Remarks = dt.Rows[n]["Remarks"].ToString();
                    model.Explain = dt.Rows[n]["Explain"].ToString();
                    if (dt.Rows[n]["ApprovalPersonnelID"].ToString() != "")
                    {
                        model.ApprovalPersonnelID = int.Parse(dt.Rows[n]["ApprovalPersonnelID"].ToString());
                    }
                    if (dt.Rows[n]["examinePersonnelID"].ToString() != "")
                    {
                        model.examinePersonnelID = int.Parse(dt.Rows[n]["examinePersonnelID"].ToString());
                    }
                    if (dt.Rows[n]["MainTestPersonnelID"].ToString() != "")
                    {
                        model.MainTestPersonnelID = int.Parse(dt.Rows[n]["MainTestPersonnelID"].ToString());
                    }
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    if (dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    if (dt.Rows[n]["EditPersonnelID"].ToString() != "")
                    {
                        model.EditPersonnelID = int.Parse(dt.Rows[n]["EditPersonnelID"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
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
        /// 根据添加时间获取最大编号值
        /// </summary>
        /// <param name="AddTime"></param>
        /// <returns></returns>
        public int GetMaxNoByAddTime(DateTime AddTime)
        {
            return dal.GetMaxNoByAddTime(AddTime);
        }
        #endregion
    }
}
