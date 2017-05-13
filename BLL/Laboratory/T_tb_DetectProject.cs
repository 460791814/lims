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
    /// 检测项目表
    /// </summary>
    public partial class T_tb_DetectProject
    {
        private readonly D_tb_DetectProject dal = new D_tb_DetectProject();
        public T_tb_DetectProject()
        { }
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
        public int Add(E_tb_DetectProject model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_DetectProject model)
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
        public E_tb_DetectProject GetModel(int ProjectID)
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
        public List<E_tb_DetectProject> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_DetectProject> DataTableToList(DataTable dt)
        {
            List<E_tb_DetectProject> modelList = new List<E_tb_DetectProject>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_DetectProject model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_DetectProject();
                    if (dt.Rows[n]["ProjectID"].ToString() != "")
                    {
                        model.ProjectID = int.Parse(dt.Rows[n]["ProjectID"].ToString());
                    }
                    if (dt.Rows[n]["LaboratoryID"].ToString() != "")
                    {
                        model.LaboratoryID = int.Parse(dt.Rows[n]["LaboratoryID"].ToString());
                    }
                    if (dt.Rows[n]["RelationProjectID"].ToString() != "")
                    {
                        model.RelationProjectID = int.Parse(dt.Rows[n]["RelationProjectID"].ToString());
                    }
                    model.TaskNo = dt.Rows[n]["TaskNo"].ToString();
                    model.ProjectName = dt.Rows[n]["ProjectName"].ToString();
                    if (dt.Rows[n]["DetectTime"].ToString() != "")
                    {
                        model.DetectTime = DateTime.Parse(dt.Rows[n]["DetectTime"].ToString());
                    }
                    if (dt.Rows[n]["HeadPersonnelID"].ToString() != "")
                    {
                        model.HeadPersonnelID = int.Parse(dt.Rows[n]["HeadPersonnelID"].ToString());
                    }
                    model.MainPerson = dt.Rows[n]["MainPerson"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
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

        public DataSet GetListByReport(string strWhere, string orderby, int startIndex, int endIndex, ref int total)
        {
            return dal.GetListByReport(strWhere, orderby, startIndex, endIndex, ref total);
        }

        public int GetListCountForReport(DataRow dr,string isPass)
        {
            return dal.GetListCountForReport(dr, isPass);
        }

        public int GetAllListCountForReport(string strWhere, string isPass)
        {
            return dal.GetAllListCountForReport(strWhere, isPass);
        }
        public DataSet GetExportListByReport(string strWhere, string orderby)
        {
            return dal.GetExportListByReport(strWhere, orderby);
        }
        #endregion

       
    }
}
