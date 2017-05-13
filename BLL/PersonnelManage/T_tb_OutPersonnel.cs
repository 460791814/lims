using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.PersonnelManage;
using Model.PersonnelManage;
using System.Data;

namespace BLL.PersonnelManage
{
    /// <summary>
    /// T_tb_OutPersonnel
    /// </summary>
    public partial class T_tb_OutPersonnel
    {
        private readonly D_tb_OutPersonnel dal = new D_tb_OutPersonnel();
        public T_tb_OutPersonnel()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PersonnelID)
        {
            return dal.Exists(PersonnelID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_OutPersonnel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_OutPersonnel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PersonnelID)
        {

            return dal.Delete(PersonnelID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PersonnelIDlist)
        {
            return dal.DeleteList(PersonnelIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_OutPersonnel GetModel(int PersonnelID)
        {

            return dal.GetModel(PersonnelID);
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
        public List<E_tb_OutPersonnel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_OutPersonnel> DataTableToList(DataTable dt)
        {
            List<E_tb_OutPersonnel> modelList = new List<E_tb_OutPersonnel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_OutPersonnel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_OutPersonnel();
                    if (dt.Rows[n]["PersonnelID"].ToString() != "")
                    {
                        model.PersonnelID = int.Parse(dt.Rows[n]["PersonnelID"].ToString());
                    }
                    model.PersonnelName = dt.Rows[n]["PersonnelName"].ToString();
                    model.Department = dt.Rows[n]["Department"].ToString();
                    model.Sex = dt.Rows[n]["Sex"].ToString();
                    model.Reason = dt.Rows[n]["Reason"].ToString();
                    if (dt.Rows[n]["StartTime"].ToString() != "")
                    {
                        model.StartTime = DateTime.Parse(dt.Rows[n]["StartTime"].ToString());
                    }
                    if (dt.Rows[n]["EndTime"].ToString() != "")
                    {
                        model.EndTime = DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
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
