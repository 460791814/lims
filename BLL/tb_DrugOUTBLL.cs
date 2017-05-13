using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tb_DrugOUTBLL
    {
        private readonly tb_DrugOUTDAL dal = new tb_DrugOUTDAL();
        public tb_DrugOUTBLL()
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
        public int Add(tb_DrugOUT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(tb_DrugOUT model)
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
        public tb_DrugOUT GetModel(int id)
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
        public List<tb_DrugOUT> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<tb_DrugOUT> DataTableToList(DataTable dt)
        {
            List<tb_DrugOUT> modelList = new List<tb_DrugOUT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                tb_DrugOUT model;
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

        #endregion  ExtensionMethod

        #region 药品统计
        /// <summary>
        /// 药品统计
        /// </summary>
        /// <param name="_date">日期</param>
        /// <param name="_datetype">日期类型（年或月）</param>
        /// <param name="_compayid">单位ID</param>
        /// <param name="_riskid">危险性等级</param>
        /// <returns></returns>
        public Dictionary<string, decimal[]> GetDrugOutForCharReport(DateTime _date, string _datetype, string _compayid, string _riskid, string _drugid)
        {
            try
            {
                Dictionary<string, decimal[]> retVal = new Dictionary<string, decimal[]>();
                DataSet ds = dal.GetDrugOutForReport(_date, _datetype, _compayid, _riskid, _drugid);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    BLL.RoleManage.T_tb_Area _areaDAL = new BLL.RoleManage.T_tb_Area();
                    var __laboratoryList = _areaDAL.GetModelList(" AreaID in (" + _compayid + ")");
                    var _list = (from dt1 in ds.Tables[0].AsEnumerable()
                                 select new
                                 {
                                     amount = dt1.Field<decimal>("amount"),
                                     drugName = dt1.Field<string>("drugName"),
                                     ruku = dt1.Field<decimal>("ruku"),
                                     chuku = dt1.Field<decimal>("chuku"),
                                     LaboratoryName = dt1.Field<string>("AreaName")
                                 }).ToList();

                    decimal[] total = new decimal[_list.Count];
                    decimal[] ruku = new decimal[_list.Count];
                    decimal[] chuku = new decimal[_list.Count];
                    for (int i = 0; i < _list.Count; i++)
                    {
                        var item = _list[i];
                        total[i] = item.amount;
                        ruku[i] = item.ruku;
                        chuku[i] = item.chuku;
                    }
                    retVal.Add("库存", total);
                    retVal.Add("出库", chuku);
                    retVal.Add("入库", ruku);
                }
                return retVal;
            }
            catch
            {
                return new Dictionary<string, decimal[]>();
            }
        }

        /// <summary>
        /// 药品统计（列表）
        /// </summary>
        /// <param name="_sDate"></param>
        /// <param name="_eDate"></param>
        /// <param name="_cids"></param>
        /// <param name="_riskid"></param>
        /// <returns></returns>
        public DataTable GetDrugOutForReport(DateTime _sDate, DateTime _eDate, int _cid, int _riskid)
        {
            try
            {
                return dal.GetDrugOutForReport(_sDate, _eDate, _cid, _riskid).Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }
        #endregion 药品统计

        public System.Collections.ArrayList GetDrugNameChar(DateTime _datetime, string _dateType, string _cids, string _rid, string _drugid)
        {
            try
            {
                System.Collections.ArrayList al = new System.Collections.ArrayList();
                DataSet ds = dal.GetDrugOutForReport(_datetime, _dateType, _cids, _rid, _drugid);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    BLL.RoleManage.T_tb_Area _areaDAL = new BLL.RoleManage.T_tb_Area();
                    var __laboratoryList = _areaDAL.GetModelList(" AreaID in (" + _cids + ")");
                    var _list = (from dt1 in ds.Tables[0].AsEnumerable()
                                 select new
                                 {
                                     drugName = dt1.Field<string>("drugName")
                                 }).ToList();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        al.Add(dr["drugName"].ToString());
                    }

                }
                return al;
            }
            catch
            {
                return new System.Collections.ArrayList();
            }
        }
    }
}