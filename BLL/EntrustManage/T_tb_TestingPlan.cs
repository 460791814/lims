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
    /// tb_TestingPlan
    /// </summary>
    public partial class T_tb_TestingPlan
    {
        private readonly D_tb_TestingPlan dal = new D_tb_TestingPlan();
        public T_tb_TestingPlan()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TestID)
        {
            return dal.Exists(TestID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_TestingPlan model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_TestingPlan model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int TestID)
        {

            return dal.Delete(TestID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TestIDlist)
        {
            return dal.DeleteList(TestIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_TestingPlan GetModel(int TestID)
        {

            return dal.GetModel(TestID);
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
        public List<E_tb_TestingPlan> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_TestingPlan> DataTableToList(DataTable dt)
        {
            List<E_tb_TestingPlan> modelList = new List<E_tb_TestingPlan>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_TestingPlan model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_TestingPlan();
                    if (dt.Rows[n]["TestID"].ToString() != "")
                    {
                        model.TestID = int.Parse(dt.Rows[n]["TestID"].ToString());
                    }
                    model.PlanName = dt.Rows[n]["PlanName"].ToString();
                    model.Version = dt.Rows[n]["Version"].ToString();
                    model.ControlledNum = dt.Rows[n]["ControlledNum"].ToString();
                    model.Department = dt.Rows[n]["Department"].ToString();
                    model.WeavePersonnel = dt.Rows[n]["WeavePersonnel"].ToString();
                    if (dt.Rows[n]["WeaveTime"].ToString() != "")
                    {
                        model.WeaveTime = DateTime.Parse(dt.Rows[n]["WeaveTime"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
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
