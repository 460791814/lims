using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.ShowImage;
using Model.ShowImage;
using System.Data;

namespace BLL.ShowImage
{
    /// <summary>
    /// tb_ShowImages
    /// </summary>
    public partial class T_tb_ShowImages
    {
        private readonly D_tb_ShowImages dal = new D_tb_ShowImages();
        public T_tb_ShowImages()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ImgID)
        {
            return dal.Exists(ImgID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(E_tb_ShowImages model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(E_tb_ShowImages model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ImgID)
        {

            return dal.Delete(ImgID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ImgIDlist)
        {
            return dal.DeleteList(ImgIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public E_tb_ShowImages GetModel(int ImgID)
        {

            return dal.GetModel(ImgID);
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
        public List<E_tb_ShowImages> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<E_tb_ShowImages> DataTableToList(DataTable dt)
        {
            List<E_tb_ShowImages> modelList = new List<E_tb_ShowImages>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                E_tb_ShowImages model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new E_tb_ShowImages();
                    if (dt.Rows[n]["ImgID"].ToString() != "")
                    {
                        model.ImgID = int.Parse(dt.Rows[n]["ImgID"].ToString());
                    }
                    if (dt.Rows[n]["ImgTypeID"].ToString() != "")
                    {
                        model.ImgTypeID = int.Parse(dt.Rows[n]["ImgTypeID"].ToString());
                    }
                    model.ImgName = dt.Rows[n]["ImgName"].ToString();
                    model.ImgPath = dt.Rows[n]["ImgPath"].ToString();
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    if (dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
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
