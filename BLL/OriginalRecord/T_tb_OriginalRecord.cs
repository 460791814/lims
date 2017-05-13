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
    /// 原始记录
    /// </summary>
    public partial class T_tb_OriginalRecord
    {
        private readonly D_tb_OriginalRecord dal = new D_tb_OriginalRecord();
        public T_tb_OriginalRecord()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RecordID)
        {
            return dal.Exists(RecordID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_OriginalRecord model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_OriginalRecord model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RecordID)
        {

            return dal.Delete(RecordID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RecordIDlist)
        {
            return dal.DeleteList(RecordIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_OriginalRecord GetModel(int RecordID)
        {

            return dal.GetModel(RecordID);
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
        public List<E_tb_OriginalRecord> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_OriginalRecord> DataTableToList(DataTable dt)
        {
            List<E_tb_OriginalRecord> modelList = new List<E_tb_OriginalRecord>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_OriginalRecord model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_OriginalRecord();
                    if (dt.Rows[n]["RecordID"].ToString() != "")
                    {
                        model.RecordID = int.Parse(dt.Rows[n]["RecordID"].ToString());
                    }
                    if (dt.Rows[n]["ProjectID"].ToString() != "")
                    {
                        model.ProjectID = int.Parse(dt.Rows[n]["ProjectID"].ToString());
                    }
                    model.TaskNo = dt.Rows[n]["TaskNo"].ToString();
                    if (dt.Rows[n]["DetectTime"].ToString() != "")
                    {
                        model.DetectTime = DateTime.Parse(dt.Rows[n]["DetectTime"].ToString());
                    }
                    if (dt.Rows[n]["DetectPersonnelID"].ToString() != "")
                    {
                        model.DetectPersonnelID = int.Parse(dt.Rows[n]["DetectPersonnelID"].ToString());
                    }
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    model.Contents = dt.Rows[n]["Contents"].ToString();
                    if (dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    if (dt.Rows[n]["EditPersonnelID"].ToString() != "")
                    {
                        model.EditPersonnelID = int.Parse(dt.Rows[n]["EditPersonnelID"].ToString());
                    }
                    if (dt.Rows[n]["SampleID"].ToString() != "")
                    {
                        model.SampleID = int.Parse(dt.Rows[n]["SampleID"].ToString());
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
        /// 根据样品名称获取对应的原始记录ID集合
        /// </summary>
        /// <param name="SampleID">样品ID</param>
        /// <returns></returns>
        public DataTable GetRecordIDListBySampleID(int SampleID)
        {
            return dal.GetRecordIDListBySampleID(SampleID);
        }
        #endregion
    }
}
