using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.OriginalRecord;
using Model.OriginalRecord;
using System.Data;

namespace BLL.OriginalRecord
{
    /// <summary>
    /// tb_RecordSample
    /// </summary>
    public partial class T_tb_RecordSample
    {
        private readonly D_tb_RecordSample dal = new D_tb_RecordSample();
        public T_tb_RecordSample()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RecordSampleID)
        {
            return dal.Exists(RecordSampleID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_RecordSample model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_RecordSample model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RecordSampleID)
        {

            return dal.Delete(RecordSampleID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RecordSampleIDlist)
        {
            return dal.DeleteList(RecordSampleIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_RecordSample GetModel(int RecordSampleID)
        {

            return dal.GetModel(RecordSampleID);
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
        public List<E_tb_RecordSample> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_RecordSample> DataTableToList(DataTable dt)
        {
            List<E_tb_RecordSample> modelList = new List<E_tb_RecordSample>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_RecordSample model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_RecordSample();
                    if (dt.Rows[n]["RecordSampleID"].ToString() != "")
                    {
                        model.RecordSampleID = int.Parse(dt.Rows[n]["RecordSampleID"].ToString());
                    }
                    if (dt.Rows[n]["RecordID"].ToString() != "")
                    {
                        model.RecordID = int.Parse(dt.Rows[n]["RecordID"].ToString());
                    }
                    model.RecordFilePath = dt.Rows[n]["RecordFilePath"].ToString();
                    if (dt.Rows[n]["SampleID"].ToString() != "")
                    {
                        model.SampleID = int.Parse(dt.Rows[n]["SampleID"].ToString());
                    }
                    model.SampleName = dt.Rows[n]["SampleName"].ToString();
                    if (dt.Rows[n]["Result"].ToString() != "")
                    {
                        model.Result = decimal.Parse(dt.Rows[n]["Result"].ToString());
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
        /// 按照条件删除数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool DeleteListByWhere(string strWhere)
        {
            return dal.DeleteListByWhere(strWhere);
        }

        /// <summary>
        /// 关联原始记录对应的样品数据
        /// </summary>
        /// <param name="RecordID">原始记录ID</param>
        /// <param name="FilePath">原始记录文件名称</param>
        /// <returns></returns>
        public bool UpdateRecordIDByFilePath(int RecordID, string FilePath)
        {
            return dal.UpdateRecordIDByFilePath(RecordID, FilePath);
        }

        /// <summary>
        /// 更具项目获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListForProject(string strWhere)
        {
            return dal.GetListForProject(strWhere);
        }

        /// <summary>
        /// 根据项目ID获取符合要求的样品数据列表
        /// </summary>
        /// <param name="ProjectID">项目ID</param>
        /// <returns></returns>
        public DataSet GetSampleByProjectID(int ProjectID)
        {
            return dal.GetSampleByProjectID(ProjectID);
        }
        #endregion
    }
}
