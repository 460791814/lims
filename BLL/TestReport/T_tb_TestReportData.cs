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
    /// tb_TestReportData
    /// </summary>
    public partial class T_tb_TestReportData
    {
        private readonly D_tb_TestReportData dal = new D_tb_TestReportData();
        public T_tb_TestReportData()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ReportDataID)
        {
            return dal.Exists(ReportDataID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_TestReportData model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_TestReportData model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ReportDataID)
        {

            return dal.Delete(ReportDataID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ReportDataIDlist)
        {
            return dal.DeleteList(ReportDataIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_TestReportData GetModel(int ReportDataID)
        {

            return dal.GetModel(ReportDataID);
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
        public List<E_tb_TestReportData> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_TestReportData> DataTableToList(DataTable dt)
        {
            List<E_tb_TestReportData> modelList = new List<E_tb_TestReportData>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_TestReportData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_TestReportData();
                    if (dt.Rows[n]["ReportDataID"].ToString() != "")
                    {
                        model.ReportDataID = int.Parse(dt.Rows[n]["ReportDataID"].ToString());
                    }
                    if (dt.Rows[n]["RecordID"].ToString() != "")
                    {
                        model.RecordID = int.Parse(dt.Rows[n]["RecordID"].ToString());
                    }
                    model.RecordFilePath = dt.Rows[n]["RecordFilePath"].ToString();
                    if (dt.Rows[n]["ReportID"].ToString() != "")
                    {
                        model.ReportID = int.Parse(dt.Rows[n]["ReportID"].ToString());
                    }
                    model.TestName = dt.Rows[n]["TestName"].ToString();
                    model.TestStandard = dt.Rows[n]["TestStandard"].ToString();
                    model.TestResult = dt.Rows[n]["TestResult"].ToString();
                    model.QualifiedLevel = dt.Rows[n]["QualifiedLevel"].ToString();
                    model.TestPersonnelName = dt.Rows[n]["TestPersonnelName"].ToString();
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
        /// 批量删除
        /// </summary>
        public bool DeleteByWhere(string StrWhere)
        {
            return dal.DeleteByWhere(StrWhere);
        }
        #endregion
    }
}
