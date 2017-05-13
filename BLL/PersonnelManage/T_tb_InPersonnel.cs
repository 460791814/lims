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
    /// 内部员工
    /// </summary>
    public partial class T_tb_InPersonnel
    {
        private readonly D_tb_InPersonnel dal = new D_tb_InPersonnel();
        public T_tb_InPersonnel()
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
        public int Add(E_tb_InPersonnel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_InPersonnel model)
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
        public E_tb_InPersonnel GetModel(int PersonnelID)
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
        public List<E_tb_InPersonnel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_InPersonnel> DataTableToList(DataTable dt)
        {
            List<E_tb_InPersonnel> modelList = new List<E_tb_InPersonnel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_InPersonnel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_InPersonnel();
                    if (dt.Rows[n]["PersonnelID"].ToString() != "")
                    {
                        model.PersonnelID = int.Parse(dt.Rows[n]["PersonnelID"].ToString());
                    }
                    if (dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    model.PersonnelName = dt.Rows[n]["PersonnelName"].ToString();
                    model.Department = dt.Rows[n]["Department"].ToString();
                    model.Sex = dt.Rows[n]["Sex"].ToString();
                    if (dt.Rows[n]["Birthday"].ToString() != "")
                    {
                        model.Birthday = DateTime.Parse(dt.Rows[n]["Birthday"].ToString());
                    }
                    model.Educational = dt.Rows[n]["Educational"].ToString();
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.Post = dt.Rows[n]["Post"].ToString();
                    model.WorkingTime = dt.Rows[n]["WorkingTime"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
                    model.CID = dt.Rows[n]["CID"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.PassWord = dt.Rows[n]["PassWord"].ToString();
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
        public string GetAreaNameByPersonId(string PersonId)
        { 
            return dal.GetAreaNameByPersonId(PersonId);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, ref int total)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex, ref total);
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        public E_tb_InPersonnel Login(string UserName, string PassWord)
        {
            return dal.Login(UserName, PassWord);
        }
        #endregion
    }
}
