using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.FileList;
using Model.FileList;
using System.Data;

namespace BLL.FileList
{
    /// <summary>
    /// tb_FileList
    /// </summary>
    public partial class T_tb_FileList
    {
        private readonly D_tb_FileList dal = new D_tb_FileList();
        public T_tb_FileList()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FileID)
        {
            return dal.Exists(FileID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_FileList model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_FileList model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int FileID)
        {

            return dal.Delete(FileID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string FileIDlist)
        {
            return dal.DeleteList(FileIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_FileList GetModel(int FileID)
        {

            return dal.GetModel(FileID);
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
        public List<E_tb_FileList> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_FileList> DataTableToList(DataTable dt)
        {
            List<E_tb_FileList> modelList = new List<E_tb_FileList>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_FileList model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_FileList();
                    if (dt.Rows[n]["FileID"].ToString() != "")
                    {
                        model.FileID = int.Parse(dt.Rows[n]["FileID"].ToString());
                    }
                    if (dt.Rows[n]["FileType"].ToString() != "")
                    {
                        model.FileType = int.Parse(dt.Rows[n]["FileType"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    model.FileName = dt.Rows[n]["FileName"].ToString();
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
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
