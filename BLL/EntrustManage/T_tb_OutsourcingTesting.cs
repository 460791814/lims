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
    /// 外委检验
    /// </summary>
    public partial class T_tb_OutsourcingTesting
    {
        private readonly D_tb_OutsourcingTesting dal = new D_tb_OutsourcingTesting();
        public T_tb_OutsourcingTesting()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int OutsourcingID)
        {
            return dal.Exists(OutsourcingID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_OutsourcingTesting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_OutsourcingTesting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int OutsourcingID)
        {

            return dal.Delete(OutsourcingID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string OutsourcingIDlist)
        {
            return dal.DeleteList(OutsourcingIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_OutsourcingTesting GetModel(int OutsourcingID)
        {

            return dal.GetModel(OutsourcingID);
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
        public List<E_tb_OutsourcingTesting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_OutsourcingTesting> DataTableToList(DataTable dt)
        {
            List<E_tb_OutsourcingTesting> modelList = new List<E_tb_OutsourcingTesting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_OutsourcingTesting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_OutsourcingTesting();
                    if (dt.Rows[n]["OutsourcingID"].ToString() != "")
                    {
                        model.OutsourcingID = int.Parse(dt.Rows[n]["OutsourcingID"].ToString());
                    }
                    model.EntrustCompany = dt.Rows[n]["EntrustCompany"].ToString();
                    if (dt.Rows[n]["SampleID"].ToString() != "")
                    {
                        model.SampleID = int.Parse(dt.Rows[n]["SampleID"].ToString());
                    }
                    if (dt.Rows[n]["SubmissionTime"].ToString() != "")
                    {
                        model.SubmissionTime = DateTime.Parse(dt.Rows[n]["SubmissionTime"].ToString());
                    }
                    model.SubmissionCompany = dt.Rows[n]["SubmissionCompany"].ToString();
                    if (dt.Rows[n]["ProjectID"].ToString() != "")
                    {
                        model.ProjectID = int.Parse(dt.Rows[n]["ProjectID"].ToString());
                    }
                    model.OutsourcingReport = dt.Rows[n]["OutsourcingReport"].ToString();
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
        #endregion
    }
}
