using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tb_DrugCheckBLL
    {
        private readonly tb_DrugCheckDAL dal = new tb_DrugCheckDAL();
        public tb_DrugCheckBLL()
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
        public int Add(tb_DrugCheck model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(tb_DrugCheck model)
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
        public tb_DrugCheck GetModel(int id)
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
        public List<tb_DrugCheck> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<tb_DrugCheck> DataTableToList(DataTable dt)
        {
            List<tb_DrugCheck> modelList = new List<tb_DrugCheck>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                tb_DrugCheck model;
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
        public DataTable GetDrugForCheckByInAndOut(DateTime _sDate, DateTime _eDate, int _cid, string _auditstatus, string whereInPersonnel, Model.PersonnelManage.E_tb_InPersonnel _user, string _searchtext2)
        {
            try
            {
                string sql = "";
                sql += string.Format(@" outDate BETWEEN '{0}' and '{1}' and temp1='通过' ", _sDate.ToShortDateString(), _eDate.ToShortDateString());
                int _userid = _user.PersonnelID;
                if (_user.DataRange == 3)
                {
                    sql += string.Format(" and  createUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", _cid, _userid);
                }
                else if (_cid > 0 || _user.DataRange == 2)
                {
                    sql += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                var outlist = new tb_DrugOUTBLL().GetModelList(sql);
                //DataSet ds = dal.GetDrugForCheckByInAndOut(_sDate, _eDate, _cid, _auditstatus, whereInPersonnel);
                string where = string.Format(" outDate BETWEEN '{0}' and '{1}' ", _sDate.ToShortDateString(), _eDate.ToShortDateString());
                where += whereInPersonnel;
                if (outlist != null && outlist.Count > 0)
                {
                    tb_DrugINBLL _druginbll = new tb_DrugINBLL();
                    tb_DrugBLL _drugbll=new tb_DrugBLL();
                    tb_BaseBLL _basebll = new tb_BaseBLL();
                    List<tb_DrugCheck> listcheck = GetModelList(where);
                    for (int i = 0; i < outlist.Count; i++)
                    {
                        tb_DrugOUT drugout = outlist[i];
                        int druginid = Convert.ToInt32(drugout.temp2);
                        var templist = listcheck.Where(w => w.drugId.Value == drugout.drugId && w.drugInId.Value == druginid && w.drugOutId.Value == drugout.id);
                        if (templist == null || templist.Count() == 0)
                        {
                            try
                            {
                                tb_DrugIN drugin = _druginbll.GetModel(druginid);
                                tb_DrugCheck model = new tb_DrugCheck();
                                model.amount = Convert.ToInt32(drugin.temp2);
                                model.amountIN = Convert.ToInt32(drugin.amount);
                                model.amountOUT = Convert.ToInt32(drugout.amount);
                                model.auditstatus = "未审核";
                                model.drugCode = drugout.drugCode;
                                model.drugId = drugout.drugId;
                                model.drugInId =drugin.id;
                                tb_Drug drug = _drugbll.GetModel(drugout.drugId.Value);
                                model.drugName = drug.drugName;
                                model.drugOutId = drugout.id;
                                model.isDelete = false;
                                model.outDate = drugout.outDate;
                                model.riskLevel = _basebll.GetModel(Convert.ToInt32(drug.riskLevel)).baseName;
                                model.unit = _basebll.GetModel(drug.unit.Value).baseName;

                                model.createUser = _user.PersonnelID;
                                model.createDate = DateTime.Now;
                                model.updateUser = _user.PersonnelID;
                                model.updateDate = DateTime.Now;
                                Add(model);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
                where += "and auditstatus = '" + _auditstatus + "' ";
                if (!String.IsNullOrEmpty(_searchtext2))
                {
                    where += "and drugName like '%%" + _searchtext2 + "%%' ";
                }
                return GetList(where).Tables[0];
            }
            catch
            {
                return new DataTable();
            }
        }

        public Dictionary<string, decimal[]> GetDrugCheckByCount(string where)
        {
            Dictionary<string, decimal[]> retVal = new Dictionary<string, decimal[]>();
            DataTable dt = dal.GetDrugCheckByCount(where);
            if (dt != null && dt.Rows.Count > 0)
            {
                decimal[] total = new decimal[dt.Rows.Count];
                decimal[] ruku = new decimal[dt.Rows.Count];
                decimal[] chuku = new decimal[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    total[i] = Convert.ToDecimal(dr["amount"]);
                    ruku[i] = Convert.ToDecimal(dr["amountIN"]);
                    chuku[i] = Convert.ToDecimal(dr["amountOUT"]);
                }
                retVal.Add("库存", total);
                retVal.Add("出库", chuku);
                retVal.Add("入库", ruku);
            }
            return retVal;
        }

        public System.Collections.ArrayList GetDrugNameChar(string where)
        {
            try
            {
                System.Collections.ArrayList al = new System.Collections.ArrayList();
                DataTable dt = dal.GetDrugCheckByCount(where);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
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
        #endregion  ExtensionMethod
    }
}
