using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    /// <summary>
    /// tb_Limit
    /// </summary>
    public partial class tb_LimitBLL
    {
        private readonly tb_LimitDAL dal = new tb_LimitDAL();
        public tb_LimitBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(tb_Limit model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(tb_Limit model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public tb_Limit GetModel(int id)
        {

            return dal.GetModel(id);
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
        public List<tb_Limit> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<tb_Limit> DataTableToList(DataTable dt)
        {
            List<tb_Limit> modelList = new List<tb_Limit>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                tb_Limit model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
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
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取未选择权限的用户列表
        /// 作者：章建国
        /// </summary>
        /// <param name="_fid"></param>
        /// <returns></returns>
        public DataTable GetUNSelectList(string _fid, int _userid)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("userORgroup"));
                dt.Columns.Add(new DataColumn("id"));
                dt.Columns.Add(new DataColumn("limittype"));
                dt.Columns.Add(new DataColumn("areaid"));
                var limitList = GetModelList(" fileId = " + _fid);
                if (limitList != null && limitList.Count > 0)
                {
                    string userids = "";
                    string areaids = "";
                    foreach (var item in limitList)
                    {
                        switch (item.limitType)
                        {
                            case "用户":
                                userids += item.limitId + ",";

                                break;
                            case "用户组":
                                areaids += item.limitId + ",";

                                break;
                        }
                    }
                    userids = !string.IsNullOrEmpty(userids) ? " PersonnelID not in (" + userids.Substring(0, userids.Length - 1) + "," + _userid + ")" : "PersonnelID <> " + _userid;
                    areaids = !string.IsNullOrEmpty(areaids) ? " AreaID not in (" + areaids.Substring(0, areaids.Length - 1) + ")" : "";
                    var inpersonlist = new BLL.PersonnelManage.T_tb_InPersonnel().GetModelList(userids);
                    var areaList = new BLL.RoleManage.T_tb_Area().GetModelList(areaids);
                    dt = GetUNSelectResultDataTable(dt, inpersonlist, areaList);
                }
                else
                {
                    var inpersonlist = new BLL.PersonnelManage.T_tb_InPersonnel().GetModelList(" PersonnelID <> " + _userid);
                    var areaList = new BLL.RoleManage.T_tb_Area().GetModelList("");
                    dt = GetUNSelectResultDataTable(dt, inpersonlist, areaList);
                }
                return dt;
            }
            catch
            {
                return new DataTable();
            }
        }

        private DataTable GetUNSelectResultDataTable(DataTable dt, List<Model.PersonnelManage.E_tb_InPersonnel> inpersonlist, List<Model.RoleManage.E_tb_Area> areaList)
        {
            foreach (var item in inpersonlist)
            {
                DataRow dr = dt.NewRow();
                dr["userORgroup"] = item.PersonnelName;
                dr["id"] = item.PersonnelID;
                dr["limittype"] = "0";//0为用户
                dr["areaid"] = item.AreaID;
                dt.Rows.Add(dr);
            }
            foreach (var item in areaList)
            {
                DataRow dr = dt.NewRow();
                dr["userORgroup"] = item.AreaName;
                dr["id"] = item.AreaID;
                dr["limittype"] = "00";//00为用户组
                dr["areaid"] = 0;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion  ExtensionMethod


    }
}
