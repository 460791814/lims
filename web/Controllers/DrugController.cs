using BLL;
using Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using System.Text;
using Model.RoleManage;
using BLL.RoleManage;

namespace Web.Controllers
{
    public class DrugController : BaseController
    {
        tb_DrugBLL _drugbll = new tb_DrugBLL();
        tb_DrugINBLL _druginbll = new tb_DrugINBLL();
        tb_DrugOUTBLL _drugoutbll = new tb_DrugOUTBLL();
        tb_DrugCheckBLL _drugcheckbll = new tb_DrugCheckBLL();
        tb_MSDSBLL _msdsbll = new tb_MSDSBLL();
        tb_DrugLockBLL _druglockbll = new tb_DrugLockBLL();
        tb_DrugRegionBLL _drugregionbll = new tb_DrugRegionBLL();
        //
        // GET: /Drug/

        public ActionResult Index()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            return View();
        }

        #region 药品管理（新增、修改、删除、列表）
        /// <summary>
        /// 作者：章建国
        /// 导出excel
        /// </summary>
        /// <param name="_search"></param>
        /// <param name="_searchtype"></param>
        /// <param name="_yzd"></param>
        /// <param name="_companyid"></param>
        /// <returns></returns>
        public FileResult ExportDrug(string _search, string _searchtype, string _yzd, int _companyid)
        {
            DataTable dt = new DataTable();
            System.IO.MemoryStream stream = new MemoryStream();
            #region 获取数据
            int total = 0;
            try
            {
                string where = " 1 = 1";
                if (!string.IsNullOrEmpty(_search))
                {
                    switch (_searchtype)
                    {
                        case "ypmc":
                            where = " drugName like '%%" + _search + "%%'";
                            break;
                        case "药品编码":
                            where = " drugCode like '%%" + _search + "%%'";
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(_yzd) && !_yzd.Equals("请选择"))
                {
                    where += " and temp1 like '%%" + _yzd + "%%'";
                }
                if (_companyid > 0)
                {
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _companyid);
                }
                else
                {
                    if (CurrentUserInfo.AreaID > 0 && CurrentUserInfo.DataRange == 3)
                    {
                        int _userid = CurrentUserInfo.PersonnelID;
                        where += string.Format(" and  CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID, _userid);
                    }
                    else if (CurrentUserInfo.AreaID > 0 && CurrentUserInfo.DataRange == 2)
                    {
                        int _userid = CurrentUserInfo.PersonnelID;
                        where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", CurrentUserInfo.AreaID);
                    }
                }
                dt = _drugbll.GetAllView_Drug(where).Tables[0];
                dt.Columns.Add(new DataColumn("dengjiren"));
                BLL.PersonnelManage.T_tb_InPersonnel _inpersonnelbll = new BLL.PersonnelManage.T_tb_InPersonnel();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        int registrantid = Convert.ToInt32(dt.Rows[i]["registrant"]);
                        var inpersonnel = _inpersonnelbll.GetModel(registrantid);
                        dt.Rows[i]["dengjiren"] = inpersonnel.PersonnelName;
                    }
                    catch
                    {
                        continue;
                    }
                }
                stream = PublicClass.ExportDrugToExcel(dt);
            }
            catch { }
            #endregion

            string filename = "药品列表" + DateTime.Now.ToFileTime() + ".xls";
            return File(stream, "application/vnd.ms-excel", filename);
        }

        /// <summary>
        /// 跳转页面
        /// 作者：章建国
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult doDrugInfo(int id)
        {
            tb_Drug model = new tb_Drug();
            ViewData["ddl_type"] = PublicClass.GetDropDownList(1, "请选择");
            ViewData["ddl_unit"] = PublicClass.GetDropDownList(4, "请选择");
            ViewData["ddl_riskLevel"] = PublicClass.GetDropDownList(7, "请选择");
            ViewData["ddl_cabinet"] = PublicClass.GetDropDownList(27, "请选择");
            if (id > 0)
            {
                model = _drugbll.GetModel(id);
            }
            return View(model);
        }

        /// <summary>
        /// 获取药品单位
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUNIT(int id)
        {
            string _unit = _drugbll.GetUNIT(id);
            return Json(_unit, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDrugList(int pageNumber, int pageSize, string _search, string _searchtype, string _yzd, int _companyid)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1 = 1";
                if (!string.IsNullOrEmpty(_search))
                {
                    switch (_searchtype)
                    {
                        case "ypmc":
                            where = " drugName like '%%" + _search + "%%'";
                            break;
                        case "药品编码":
                            where = " drugCode like '%%" + _search + "%%'";
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(_yzd) && !_yzd.Equals("请选择"))
                {
                    where += " and temp1 like '%%" + _yzd + "%%'";
                }
                if (_companyid > 0)
                {
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _companyid);
                }
                else
                {
                    if (CurrentUserInfo.AreaID > 0 && CurrentUserInfo.DataRange == 3)
                    {
                        int _userid = CurrentUserInfo.PersonnelID;
                        where += string.Format(" and  CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID, _userid);
                    }
                    else if (CurrentUserInfo.AreaID > 0 && CurrentUserInfo.DataRange == 2)
                    {
                        int _userid = CurrentUserInfo.PersonnelID;
                        where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", CurrentUserInfo.AreaID);
                    }
                }
                dt = _drugbll.GetListByPage(where, "updateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                total = _drugbll.GetModelList(where).Count;
                dt.Columns.Add(new DataColumn("dengjiren"));
                BLL.PersonnelManage.T_tb_InPersonnel _inpersonnelbll = new BLL.PersonnelManage.T_tb_InPersonnel();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        int registrantid = Convert.ToInt32(dt.Rows[i]["registrant"]);
                        var inpersonnel = _inpersonnelbll.GetModel(registrantid);
                        dt.Rows[i]["dengjiren"] = inpersonnel.PersonnelName;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        /// <summary>
        /// 新增或编辑
        /// 作者：章建国
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string doDrugInfoCU(tb_Drug model)
        {
            string flag = "0";
            try
            {
                if (model.id > 0)
                {
                    flag = UpdateDrug(model);
                }
                else
                {
                    flag = NewDrug(model);
                }
                if (flag.Equals("1"))
                {
                    if (model.isMSDS)
                    {
                        model = _drugbll.GetModelList(" drugName='" + model.drugName + "' and drugCode='" + model.drugCode + "'").First();
                        string filename = Request.Form["fileName"];
                        string fileurl = Request.Form["fileUrl"];
                        tb_MSDS msdsmodel = new tb_MSDS();
                        msdsmodel.fileName = filename;
                        msdsmodel.fileUrl = fileurl;
                        msdsmodel.wId = model.id;
                        msdsmodel.fileType = "药品";
                        msdsmodel.createDate = model.createDate;
                        msdsmodel.createUser = model.createUser;
                        if (_msdsbll.Add(msdsmodel) > 0)
                        {
                            flag = "1";
                        }
                    }
                    else
                    {
                        flag = "1";
                    }
                }
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        /// <summary>
        /// 新建数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        private string NewDrug(tb_Drug model)
        {
            string flag = "0";
            try
            {
                model.createDate = DateTime.Now;
                model.createUser = CurrentUserInfo.PersonnelID;
                model.updateDate = DateTime.Now;
                model.updateUser = CurrentUserInfo.PersonnelID;
                model.registrant = CurrentUserInfo.PersonnelID;
                model.amount = 0;
                if (_drugbll.Add(model) > 0)
                {
                    flag = "1";
                }
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        /// <summary>
        /// 更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">需要更新的模型</param>
        /// <returns></returns>
        private string UpdateDrug(tb_Drug model)
        {
            string flag = "0";
            try
            {
                if (model != null && model.id > 0)
                {
                    model.updateDate = DateTime.Now;
                    model.updateUser = CurrentUserInfo.PersonnelID;
                    if (_drugbll.Update(model))
                    {
                        flag = "1";
                    }
                }
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        /// <summary>
        /// 删除数据
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public JsonResult Delete_Item(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_drugbll.Delete(id))
                {
                    str = "删除成功！";
                }
            }
            catch
            {
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsDrugCodeHave(String code)
        {
            String str = "";
            if (_drugbll.GetModelList(" drugCode = '" + code + "'").Count > 0)
            {
                str = "药品编号重复！";
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 药品入库（新增、编辑、删除、上次MSDS）
        public ActionResult doDrugInAdd()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var druglocklist = _druglockbll.GetModelList(CurrentUserInfo.AreaID.Value);
            if (druglocklist != null && druglocklist.Count > 0)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1" });
                for (int i = 0; i < druglocklist.Count; i++)
                {
                    var item = druglocklist[i];
                    list.Add(new SelectListItem() { Text = item.lockName, Value = item.id.ToString() });
                }
            }
            ViewData["druglocklist"] = list;
            return View();
        }

        public ActionResult doDrugInUpdate(int id)
        {
            tb_DrugIN model = new tb_DrugIN();
            List<SelectListItem> locklist = new List<SelectListItem>();
            List<SelectListItem> regionlist = new List<SelectListItem>();
            if (id > 0)
            {
                model = _druginbll.GetModel(id);
                ViewBag._drugName = _drugbll.GetModel(model.drugId.Value).drugName;
                var druglocklist = _druglockbll.GetModelList(CurrentUserInfo.AreaID.Value);
                tb_DrugRegion drugregionmodel = new tb_DrugRegion();
                if (!string.IsNullOrEmpty(model.GPS))
                {
                    drugregionmodel = _drugregionbll.GetModel(Convert.ToInt32(model.GPS));
                }
                if (druglocklist != null && druglocklist.Count > 0)
                {
                    locklist.Add(new SelectListItem() { Text = "请选择", Value = "-1" });
                    for (int i = 0; i < druglocklist.Count; i++)
                    {
                        bool lockchecked = false;
                        var item = druglocklist[i];
                        if (drugregionmodel.id > 0 && item.id == drugregionmodel.lockId)
                        {
                            lockchecked = true;
                            var drugregionlist = _drugregionbll.GetModelList(" lockid = " + item.id);
                            bool regionchecked = false;
                            foreach (var regionitem in drugregionlist)
                            {
                                if (drugregionmodel.id > 0 && drugregionmodel.id == regionitem.id)
                                {
                                    regionchecked = true;
                                }
                                regionlist.Add(new SelectListItem() { Text = regionitem.regionName, Value = regionitem.id.ToString(), Selected = regionchecked });
                            }
                        }
                        locklist.Add(new SelectListItem() { Text = item.lockName, Value = item.id.ToString(), Selected = lockchecked });
                    }
                }
            }

            ViewData["druglocklist"] = locklist;
            ViewData["drugregionlist"] = regionlist;
            return View(model);
        }

        public ActionResult DrugIn()
        {
            ViewData["ddl_drug"] = GetDropDownListForDrug();
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }
        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDrugINList(int pageNumber, int pageSize, int _cid, string _datetext, string _type, string _text)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1=1 ";
                if (!string.IsNullOrEmpty(_datetext))
                {
                    where += string.Format(" and convert(char(8), ENTERDATE, 112) like '%%{0}%%'", _datetext);
                }
                if (_cid > 0 && CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", _cid, _userid);
                }
                else if (_cid > 0 && CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                switch (_type)
                {
                    case "编号":
                        where += string.Format(" and DRUGCODE like '%%{0}%%'", _text);
                        break;
                    case "名称":
                        where += string.Format(" and drugName like '%%{0}%%'", _text);
                        break;
                    case "存放、使用地点":
                        where += string.Format(" and PUTAREA like '%%{0}%%'", _text);
                        break;
                    case "危险性等级":
                        where += string.Format(" and weixiandengji like '%%{0}%%'", _text);
                        break;
                }
                dt = _druginbll.GetListByPage(where, "UpdateDate desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                dt.Columns.Add("admin");
                dt.Columns.Add("dingwei");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        dt.Rows[i]["admin"] = GetUserName(dt.Rows[i]["CreateUser"].ToString());
                        string gps = dt.Rows[i]["GPS"].ToString();
                        if (!string.IsNullOrEmpty(gps))
                        {
                            int regionid = Convert.ToInt32(gps);
                            var region = _drugregionbll.GetModel(regionid);
                            var lockmodel = _druglockbll.GetModel(region.lockId.Value);
                            dt.Rows[i]["dingwei"] = lockmodel.lockName + "-" + region.regionName;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                total = _druginbll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        /// <summary>
        /// 新建数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        public string NewDrugIN(tb_DrugIN model)
        {
            string flag = "0";
            try
            {
                model.CreateDate = DateTime.Now;
                model.CreateUser = CurrentUserInfo.PersonnelID;
                model.UpdateDate = DateTime.Now;
                model.UpdateUser = CurrentUserInfo.PersonnelID;
                model.temp2 = model.amount.ToString();
                var drugmodel = _drugbll.GetModel(model.drugId.Value);
                if (_druginbll.Add(model) > 0)
                {
                    drugmodel.amount += model.amount;
                    if (_drugbll.Update(drugmodel))
                    {
                        flag = "1";
                    }
                }
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        /// <summary>
        /// 更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">需要更新的模型</param>
        /// <returns></returns>
        public string UpdateDrugIN(tb_DrugIN model)
        {
            string flag = "0";
            try
            {
                if (model != null && model.id > 0)
                {
                    model.UpdateDate = DateTime.Now;
                    model.UpdateUser = 1;
                    model.temp2 = model.amount.ToString();
                    var tempinmodel = _druginbll.GetModel(model.id);
                    var drugmodel = _drugbll.GetModel(model.drugId.Value);
                    if (_druginbll.Update(model))
                    {
                        if (model.amount > tempinmodel.amount)
                        {
                            drugmodel.amount += model.amount - tempinmodel.amount;
                        }
                        else if (model.amount < tempinmodel.amount)
                        {
                            drugmodel.amount -= tempinmodel.amount - model.amount;
                        }
                        if (_drugbll.Update(drugmodel))
                        {
                            flag = "1";
                        }
                    }
                }
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        /// <summary>
        /// 删除数据
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public JsonResult Delete_DrugIN(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_druginbll.Delete(id))
                {
                    str = "删除成功！";
                }
            }
            catch
            {
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 导出药品入库
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public JsonResult Export_DrugIN()
        {
            MemoryStream mstest = new MemoryStream();
            try
            {
                IWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("药品入库");
                IRow header = sheet.CreateRow(0);
                DataTable dt = _druginbll.GetList("").Tables[0];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = header.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow rowitem = sheet.CreateRow(i + 1);
                    for (int ii = 0; ii < dt.Columns.Count; ii++)
                    {
                        rowitem.CreateCell(ii).SetCellValue(dt.Rows[i][ii].ToString());
                    }
                }
                workbook.Write(mstest);
                mstest.Flush();
                mstest.Position = 0;
            }
            catch
            {

            }
            string fileName = "DrugIN_" + string.Format("{0}_{1}_{2}_{3}_{4}_{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) + ".xls";
            if (HttpContext.Request.Browser.Browser == "IE")
                fileName = HttpUtility.UrlEncode(fileName);
            HttpContext.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            HttpContext.Response.BinaryWrite(mstest.ToArray());
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRegionByLockID(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (id > 0)
            {
                var drugregionlist = _drugregionbll.GetModelList(" lockid = " + id);
                if (drugregionlist != null && drugregionlist.Count > 0)
                {
                    list.Add(new SelectListItem() { Text = "请选择", Value = "-1" });
                    for (int i = 0; i < drugregionlist.Count; i++)
                    {
                        var item = drugregionlist[i];
                        list.Add(new SelectListItem() { Text = item.regionName, Value = item.id.ToString() });
                    }
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 药品出库（新增、编辑、删除、上次MSDS）
        public ActionResult doDrugOutCheck(int id)
        {
            tb_DrugOUT model = new tb_DrugOUT();
            if (id > 0)
            {
                model = _drugoutbll.GetModel(id);
                ViewBag._drugName = _drugbll.GetModel(model.drugId.Value).drugName;
            }
            return View(model);
        }

        public ActionResult doDrugOutAdd()
        {
            return View();
        }

        public ActionResult doDrugOutUpdate(int id)
        {
            tb_DrugOUT model = new tb_DrugOUT();
            if (id > 0)
            {
                model = _drugoutbll.GetModel(id);
                ViewBag._drugName = _drugbll.GetModel(model.drugId.Value).drugName;
            }
            return View(model);
        }

        public ActionResult DrugOut()
        {
            ViewData["ddl_drug"] = GetDropDownListForDrug();
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }
        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDrugOUTList(int pageNumber, int pageSize, int _cid, string _datetext, string _type, string _text)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1=1 ";
                if (!string.IsNullOrEmpty(_datetext))
                {
                    where += string.Format(" and convert(char(8), OUTDATE, 112) like '%%{0}%%'", _datetext);
                }
                switch (_type)
                {
                    case "编号":
                        where += string.Format(" and DRUGCODE like '%%{0}%%'", _text);
                        break;
                    case "名称":
                        where += string.Format(" and drugName like '%%{0}%%'", _text);
                        break;
                    case "存放、使用地点":
                        where += string.Format(" and PUTAREA like '%%{0}%%'", _text);
                        break;
                    case "危险性等级":
                        where += string.Format(" and weixiandengji like '%%{0}%%'", _text);
                        break;
                    case "审批状态":
                        where += string.Format(" and temp1 like '%%{0}%%'", _text);
                        break;
                }
                if (CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", _cid, _userid);
                }
                else if (_cid > 0 || CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                dt = _drugoutbll.GetListByPage(where, "temp1", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                dt.Columns.Add("admin");
                dt.Columns.Add("dingwei");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        dt.Rows[i]["admin"] = GetUserName(dt.Rows[i]["CreateUser"].ToString());
                        string gps = dt.Rows[i]["GPS"].ToString();
                        if (!string.IsNullOrEmpty(gps))
                        {
                            int regionid = Convert.ToInt32(gps);
                            var region = _drugregionbll.GetModel(regionid);
                            var lockmodel = _druglockbll.GetModel(region.lockId.Value);
                            dt.Rows[i]["dingwei"] = lockmodel.lockName + "-" + region.regionName;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                total = _drugoutbll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        /// <summary>
        /// 新建数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        public string NewDrugOUT(tb_DrugOUT model)
        {
            string flag = "0";
            try
            {
                model.CreateDate = DateTime.Now;
                model.CreateUser = CurrentUserInfo.PersonnelID;
                model.UpdateDate = DateTime.Now;
                model.UpdateUser = CurrentUserInfo.PersonnelID;
                model.temp1 = "待审批";//待审批、通过、未通过
                var durginmodel = _druginbll.GetModel(Convert.ToInt32(model.temp2));
                var drugmodel = _drugbll.GetModel(model.drugId.Value);
                if (_drugoutbll.Add(model) > 0)
                {
                    durginmodel.temp2 = (Convert.ToInt32(durginmodel.temp2) - model.amount).ToString();
                    _druginbll.Update(durginmodel);
                    drugmodel.amount -= model.amount;
                    if (_drugbll.Update(drugmodel))
                    {
                        flag = "1";
                    }
                }
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        /// <summary>
        /// 更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">需要更新的模型</param>
        /// <returns></returns>
        public string UpdateDrugOUT(tb_DrugOUT model)
        {
            string flag = "0";
            try
            {
                if (model != null && model.id > 0)
                {
                    model.UpdateDate = DateTime.Now;
                    model.UpdateUser = CurrentUserInfo.PersonnelID;
                    var tempinmodel = _drugoutbll.GetModel(model.id);
                    var drugmodel = _drugbll.GetModel(model.drugId.Value);
                    if (_drugoutbll.Update(model))
                    {
                        if (model.amount > tempinmodel.amount)
                        {
                            drugmodel.amount -= model.amount - tempinmodel.amount;
                        }
                        else if (model.amount < tempinmodel.amount)
                        {
                            drugmodel.amount += tempinmodel.amount - model.amount;
                        }
                        if (_drugbll.Update(drugmodel))
                        {
                            flag = "1";
                        }
                    }
                }
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        public string UpdateDrugOUTtemp1(tb_DrugOUT model)
        {
            string flag = "0";
            try
            {
                if (model != null && model.id > 0)
                {
                    string temp1 = model.temp1;
                    model = _drugoutbll.GetModel(model.id);
                    model.UpdateDate = DateTime.Now;
                    model.UpdateUser = CurrentUserInfo.PersonnelID;
                    model.temp1 = temp1;
                    if (_drugoutbll.Update(model))
                    {
                        if (temp1.Equals("未通过"))
                        {
                            var durginmodel = _druginbll.GetModel(Convert.ToInt32(model.temp2));
                            durginmodel.temp2 = (Convert.ToInt32(durginmodel.temp2) + model.amount).ToString();
                            _druginbll.Update(durginmodel);
                        }
                    }
                }
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        public JsonResult Update_DrugOutByID(int id, int zhuangtai)
        {
            string str = "审批失败！";
            if (id > 0)
            {
                var tempinmodel = _drugoutbll.GetModel(id);
                tempinmodel.temp1 = zhuangtai == 1 ? "通过" : "未通过";
                if (_drugoutbll.Update(tempinmodel))
                {
                    str = "审批成功！";
                }
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public JsonResult Delete_DrugOUT(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_drugoutbll.Delete(id))
                {
                    str = "删除成功！";
                }
            }
            catch
            {
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDrugINForDrugOut(int _drugId, string _drugCode)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var durgInList = _druginbll.GetModelList(string.Format(" drugId = {0} and drugCode = '{1}' and temp2 is not null and convert(int,temp2) > 0 ", _drugId, _drugCode));
            for (int i = 0; i < durgInList.Count; i++)
            {
                var item = durgInList[i];
                string _text = "有效期" + item.validDate.Value.ToShortDateString() + "  生产日期" + item.productDate.Value.ToShortDateString();
                list.Add(new SelectListItem() { Text = _text, Value = item.id.ToString() });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDrugINModel(int _id)
        {
            tb_DrugIN model = _druginbll.GetModel(_id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 药品盘点（盘点、导出Excel）
        public ActionResult DrugCheck()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            ViewData["ddl_risklevel"] = PublicClass.GetDropDownList(7, "全部");
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }

        public ActionResult doDrugCheck(int id)
        {
            tb_DrugCheck model = new tb_DrugCheck();
            if (id > 0)
            {
                model = _drugcheckbll.GetModel(id);
            }
            return View("", model);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDrugCheckList(int _cid, DateTime _sdate, DateTime _edate, string _auditstatus, string _search2)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = "";
                if (CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  createUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID, _userid);
                }
                else if (_cid > 0 || CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                dt = _drugcheckbll.GetDrugForCheckByInAndOut(_sdate, _edate, _cid, _auditstatus, where, CurrentUserInfo, _search2);
                total = dt.Rows.Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        /// <summary>
        /// 新建盘点
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public JsonResult click_DrugCheck(int _cid, DateTime _sdate, DateTime _edate, string _auditstatus)
        {
            string mes = "没有异常";
            try
            {
                string where = string.Format(" outDate BETWEEN '{0}' and '{1}' and auditstatus = '{2}' ", _sdate.ToShortDateString(), _edate.ToShortDateString(), _auditstatus);
                if (CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  createUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID, _userid);
                }
                else if (_cid > 0 || CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                List<tb_DrugCheck> listcheck = _drugcheckbll.GetModelList(where);
                foreach (var item in listcheck)
                {
                    if (item.checkUserId > 0)
                    {
                        continue;
                    }
                    item.checkDate = DateTime.Now;
                    item.checkUser = CurrentUserInfo.PersonnelName;
                    item.checkUserId = CurrentUserInfo.PersonnelID;
                    item.updateDate = DateTime.Now;
                    item.updateUser = CurrentUserInfo.PersonnelID;
                    _drugcheckbll.Update(item);
                }
            }
            catch (Exception)
            {
                mes = "出现异常";
            }
            return Json(mes, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 批量审核
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public JsonResult click_DrugAudit(int _cid, DateTime _sdate, DateTime _edate, string _auditstatus)
        {
            string mes = "没有异常";
            try
            {
                string where = string.Format(" outDate BETWEEN '{0}' and '{1}' and auditstatus = '{2}' ", _sdate.ToShortDateString(), _edate.ToShortDateString(), _auditstatus);
                if (CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  createUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID.Value, _userid);
                }
                else if (_cid > 0 || CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                List<tb_DrugCheck> listcheck = _drugcheckbll.GetModelList(where);
                foreach (var item in listcheck)
                {
                    if (item.checkUserId > 0)
                    {
                        if (!string.IsNullOrEmpty(item.auditUserId))
                        {
                            int auditUserId = Convert.ToInt32(item.auditUserId);
                            if (auditUserId > 0)
                            {
                                continue;
                            }
                        }

                        item.auditstatus = "通过";
                        item.auditUser = CurrentUserInfo.PersonnelName;
                        item.auditUserId = CurrentUserInfo.PersonnelID.ToString();
                        _drugcheckbll.Update(item);
                    }

                }
            }
            catch (Exception)
            {
                mes = "出现异常";
            }
            return Json(mes, JsonRequestBehavior.AllowGet);
        }

        public string doDrugCheckU(tb_DrugCheck model)
        {
            string flag = "0";
            try
            {

                string _auditstatus = model.auditstatus;
                model = _drugcheckbll.GetModel(model.id);
                if (!string.IsNullOrEmpty(_auditstatus))
                {
                    if (!_auditstatus.Equals(model.auditstatus))
                    {
                        model.auditstatus = _auditstatus;
                        model.auditUser = CurrentUserInfo.PersonnelName;
                        model.auditUserId = CurrentUserInfo.PersonnelID.ToString();
                        if (_drugcheckbll.Update(model))
                        {
                            flag = "1";
                        }
                    }
                }
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        public JsonResult exportExcel()
        {
            return Json("");
        }
        #endregion

        #region 药品统计
        public ActionResult DrugReport()
        {
            return View();
        }

        public ActionResult DrugDataReport()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("全部", CurrentUserInfo.AreaID.Value);
            ViewData["ddl_risklevel"] = PublicClass.GetDropDownList(7, "请选择");
            return View();
        }

        public ActionResult DrugCharReport()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("全部", CurrentUserInfo.AreaID.Value);
            ViewData["ddl_risklevel"] = PublicClass.GetDropDownList(7, "请选择");
            return View();
        }

        public string GetDrugReportList(int _pageNumber, int _cId, string _risklevel, string _sDate, string _eDate)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                E_tb_Area areamodel = new E_tb_Area();
                string where = " auditUser <> '未通过' ";
                where += string.Format(" and outDate BETWEEN '{0}' and '{1}' ", _sDate, _eDate);
                if (!string.IsNullOrEmpty(_risklevel) && !_risklevel.Equals("请选择"))
                {
                    where += string.Format(" and riskLevel = '{0}'", _risklevel);
                }
                if (CurrentUserInfo.DataRange == 3)
                {
                    areamodel = new BLL.RoleManage.T_tb_Area().GetModel(CurrentUserInfo.AreaID.Value);
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  createUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID.Value, _userid);
                }
                else if (_cId > 0 || CurrentUserInfo.DataRange == 2)
                {
                    areamodel = new BLL.RoleManage.T_tb_Area().GetModel(_cId);
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cId);
                }
                //dt = _drugoutbll.GetDrugOutForReport(DateTime.Parse(_sDate), DateTime.Parse(_eDate), _cId, _rId);
                dt = _drugcheckbll.GetList(where).Tables[0];
                dt.Columns.Add("AreaName");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["AreaName"] = areamodel.AreaName;
                }
            }
            catch
            {

            }
            return PublicClass.ToJson(dt, total);
        }
        /// <summary>
        /// 获取药品统计图表数据
        /// 作者：章建国
        /// </summary>
        /// <param name="_cids">单位ID列表，用逗号分隔</param>
        /// <param name="_dateType">查询条件的日期类型，年或月</param>
        /// <param name="_date">查询条件的日期</param>
        /// <param name="_rid">危险性ID</param>
        /// <param name="_drugid">药品ID</param>
        /// <returns></returns>
        public JsonResult GetDrugINListForLineChar(string _cids, string _dateType, string _date, string _rid, string _drugid)
        {
            Dictionary<string, decimal[]> retVal = new Dictionary<string, decimal[]>();
            DateTime _datetime = new DateTime();
            E_tb_Area areamodel = new E_tb_Area();
            int _cId = Convert.ToInt32(_cids);
            string where = " auditUser <> '未通过' and drugId in (" + _drugid.Substring(0, _drugid.Length - 1) + ")";
            if (_dateType.Equals("nian"))
            {
                where += string.Format(" and year(outDate) = {0}", _date);
            }
            else if (_dateType.Equals("yue"))
            {
                var strs = _date.Split('-');
                where += string.Format(" and year(outDate) = {0} and month(outDate) = {1}", strs[0], strs[1]);
            }
            if (!string.IsNullOrEmpty(_rid) && !_rid.Equals("请选择"))
            {
                where += string.Format(" and riskLevel = '{0}'", _rid);
            }
            if (CurrentUserInfo.DataRange == 3)
            {
                areamodel = new BLL.RoleManage.T_tb_Area().GetModel(CurrentUserInfo.AreaID.Value);
                int _userid = CurrentUserInfo.PersonnelID;
                where += string.Format(" and  createUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID.Value, _userid);
            }
            else if (_cId > 0 || CurrentUserInfo.DataRange == 2)
            {
                areamodel = new BLL.RoleManage.T_tb_Area().GetModel(_cId);
                int _userid = CurrentUserInfo.PersonnelID;
                where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cId);
            }

            retVal = _drugcheckbll.GetDrugCheckByCount(where);
            return Json(retVal.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDrugNameChar(string _cids, string _dateType, string _date, string _rid, string _drugid)
        {
            System.Collections.ArrayList al = new System.Collections.ArrayList();
            int _cId = Convert.ToInt32(_cids);
            string where = " auditUser <> '未通过' and drugId in (" + _drugid.Substring(0, _drugid.Length - 1) + ")";
            if (_dateType.Equals("nian"))
            {
                where += string.Format(" and year(outDate) = {0}", _date);
            }
            else if (_dateType.Equals("yue"))
            {
                var strs = _date.Split('-');
                where += string.Format(" and year(outDate) = {0} and month(outDate) = {1}", strs[0], strs[1]);
            }
            if (!string.IsNullOrEmpty(_rid) && !_rid.Equals("请选择"))
            {
                where += string.Format(" and riskLevel = '{0}'", _rid);
            }
            if (CurrentUserInfo.DataRange == 3)
            {
                int _userid = CurrentUserInfo.PersonnelID;
                where += string.Format(" and  createUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID.Value, _userid);
            }
            else if (_cId > 0 || CurrentUserInfo.DataRange == 2)
            {
                int _userid = CurrentUserInfo.PersonnelID;
                where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cId);
            }

            al = _drugcheckbll.GetDrugNameChar(where);
            return Json(al, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDirList()
        {
            List<TreeModel> list = new List<TreeModel>();
            var listdir = _drugbll.GetModelList("");
            string[] strjson = new string[listdir.Count];
            var listbase = new tb_BaseBLL().GetModelList(" pId=1");
            foreach (var item in listbase)
            {
                list.Add(new TreeModel() { Id = item.id, Text = item.baseName, Pid = 0 });
            }
            foreach (var item in listdir)
            {
                list.Add(new TreeModel() { Id = item.id, Text = item.drugName, Pid = item.drugType.Value });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 药品柜
        public ActionResult DrugLock()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            List<E_tb_Area> _Arealist = new List<E_tb_Area>();
            T_tb_Area tArea = new T_tb_Area();
            if (CurrentUserInfo.RoleID == 3)
            {
                _Arealist = tArea.GetModelList("");
            }
            else
            {
                _Arealist = tArea.GetModelList(" AreaID = " + CurrentUserInfo.AreaID.Value);
            }
            ViewData["Arealist"] = _Arealist;
            return View();
        }

        public ActionResult doDrugLockInfo(int id)
        {
            tb_DrugLock model = new tb_DrugLock();
            if (id > 0)
            {
                model = _druglockbll.GetModel(id);
            }
            return View(model);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDrugRegionList(int pageNumber, int pageSize, string _regionName, int _lockId)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1 = 1 ";
                if (!string.IsNullOrEmpty(_regionName) && _lockId > 0)
                {
                    try
                    {
                        tb_DrugRegion model = _drugregionbll.GetModelList(string.Format(" regionName = '{0}' and lockId = {1}", _regionName, _lockId)).First();
                        where += " and regionId = " + model.id;
                    }
                    catch
                    { }
                }
                if (_lockId > 0)
                {
                    where += " and lockId = " + _lockId;
                    dt = _drugregionbll.GetListByPage(where, "UpdateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                    total = dt.Rows.Count;
                    total = _drugregionbll.GetListCount(where);
                }
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        public JsonResult Update_DrugLock(int id, string _lockName, bool _wxp, bool _hxp, string _locktype)
        {
            string str = "保存失败！";
            try
            {
                tb_DrugLock model = new tb_DrugLock();
                if (id > 0)
                {
                    model = _druglockbll.GetModel(id);
                }
                model.lockName = _lockName;
                model.lockType = _locktype;

                if (_wxp && _hxp)
                {
                    model.mark = "都是";
                }
                else if (!_wxp && !_hxp)
                {
                    model.mark = "都不是";
                }
                else if (_wxp)
                {
                    model.mark = "危险品";
                }
                else if (_hxp)
                {
                    model.mark = "化学品";
                }
                if (model.lockType.Equals("冷藏柜"))
                {
                    model.mark = "都是";
                }
                model.updateDate = DateTime.Now;
                model.updateUser = CurrentUserInfo.PersonnelID;
                if (id > 0)
                {
                    if (_druglockbll.Update(model))
                    {
                        str = "保存成功！";
                    }
                }
                else
                {
                    model.createDate = DateTime.Now;
                    model.createUser = CurrentUserInfo.PersonnelID;
                    var druglocklist = _druglockbll.GetModelList("").Where(w => w.lockName.Equals(model.lockName) && w.createUser == model.createUser);
                    if (druglocklist == null || druglocklist.Count() == 0)
                    {
                        if (_druglockbll.Add(model) > 0)
                        {
                            druglocklist = _druglockbll.GetModelList("").Where(w => w.lockName.Equals(model.lockName) && w.createUser == model.createUser);
                            if (druglocklist != null && druglocklist.Count() > 0)
                            {
                                model = druglocklist.First();
                                int fornum = 12;
                                string imgname = "";
                                if (model.lockType.Equals("不透明柜2_4"))
                                {
                                    fornum = 8;
                                }
                                else if (model.lockType.Equals("冷藏柜"))
                                {
                                    imgname = "冷藏柜";
                                    fornum = 0;
                                    for (int i = 1; i <= 5; i++)
                                    {
                                        tb_DrugRegion drugregionmodel = new tb_DrugRegion();

                                        switch (i)
                                        {
                                            case 1:
                                                imgname = "A";
                                                break;
                                            case 2:
                                                imgname = "B";
                                                break;
                                            case 3:
                                                imgname = "C";
                                                break;
                                            case 4:
                                                imgname = "D";
                                                break;
                                            case 5:
                                                imgname = "E";
                                                break;
                                        }
                                        drugregionmodel.createDate = DateTime.Now;
                                        drugregionmodel.createUser = CurrentUserInfo.PersonnelID;
                                        drugregionmodel.lockId = model.id;
                                        drugregionmodel.regionName = imgname;
                                        drugregionmodel.updateDate = DateTime.Now;
                                        drugregionmodel.updateUser = CurrentUserInfo.PersonnelID;
                                        _drugregionbll.Add(drugregionmodel);
                                    }
                                }
                                for (int i = 1; i <= fornum; i++)
                                {
                                    tb_DrugRegion drugregionmodel = new tb_DrugRegion();

                                    switch (i)
                                    {
                                        case 1:
                                            imgname = "A1";
                                            break;
                                        case 2:
                                            imgname = "A2";
                                            break;
                                        case 3:
                                            imgname = "A3";
                                            break;
                                        case 4:
                                            imgname = "A4";
                                            break;
                                        case 5:
                                            imgname = "B1";
                                            break;
                                        case 6:
                                            imgname = "B2";
                                            break;
                                        case 7:
                                            imgname = "B3";
                                            break;
                                        case 8:
                                            imgname = "B4";
                                            break;
                                        case 9:
                                            imgname = "C1";
                                            break;
                                        case 10:
                                            imgname = "C2";
                                            break;
                                        case 11:
                                            imgname = "C3";
                                            break;
                                        case 12:
                                            imgname = "C4";
                                            break;
                                    }
                                    drugregionmodel.createDate = DateTime.Now;
                                    drugregionmodel.createUser = CurrentUserInfo.PersonnelID;
                                    drugregionmodel.lockId = model.id;
                                    drugregionmodel.regionName = imgname;
                                    drugregionmodel.updateDate = DateTime.Now;
                                    drugregionmodel.updateUser = CurrentUserInfo.PersonnelID;
                                    _drugregionbll.Add(drugregionmodel);
                                }
                            }
                            str = "保存成功！";
                        }
                    }
                    else
                    {
                        str = "重复的药品柜名称！";
                    }
                }
            }
            catch
            {
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete_DrugLock(string ids)
        {
            string str = "删除失败！";
            if (_druglockbll.DeleteList(ids))
            {
                str = "删除成功！";
                var drugregionlist = _drugregionbll.GetModelList(" lockId in (" + ids + ")");
                ids = "";
                if (drugregionlist != null && drugregionlist.Count > 0)
                {
                    for (int i = 0; i < drugregionlist.Count; i++)
                    {
                        if (i == 0)
                        {
                            ids += drugregionlist[i].id.ToString();
                        }
                        else
                        {
                            ids += "," + drugregionlist[i].id.ToString();
                        }
                    }
                    _drugregionbll.DeleteList(ids);

                    var druginlist = _druginbll.GetModelList(" GPS in (" + ids + ")");
                    if (druginlist != null && druginlist.Count > 0)
                    {
                        for (int i = 0; i < druginlist.Count; i++)
                        {
                            var model = druginlist[i];
                            model.GPS = "";
                            _druginbll.Update(model);
                        }
                    }
                }
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 上传文件
        [AcceptVerbs(HttpVerbs.Post)]
        public string Import(HttpPostedFileBase FileData, string folder)
        {
            string result = "false";
            if (null != FileData)
            {
                try
                {
                    result = Path.GetFileName(FileData.FileName);//获得文件名
                    string ext = Path.GetExtension(FileData.FileName);//获得文件扩展名
                    string strdate = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                    string saveName = "uploadfile" + strdate + ext;//实际保存文件名
                    result = saveName;
                    saveFile(FileData, "UpFile/MSDS", saveName);//保存文件

                }
                catch
                {
                    result = "false";
                }
            }
            return result;
        }

        [NonAction]
        private string saveFile(HttpPostedFileBase postedFile, string filepath, string saveName)
        {
            string phyPath = Request.MapPath("../" + filepath + "/");
            if (!Directory.Exists(phyPath))
            {
                Directory.CreateDirectory(phyPath);
            }
            try
            {
                postedFile.SaveAs(phyPath + saveName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);

            }
            return phyPath + saveName;
        }
        #endregion

        #region 下载文件、阅览
        /// <summary>
        /// 下载文件
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public FilePathResult GetFileFromDisk(int wid, string filetype)
        {
            var model = _msdsbll.GetModelList(" wId = " + wid + " and fileType='" + filetype + "'").First();
            string iFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile/MSDS//" + model.fileUrl;
            var strs = model.fileName.Split('.');
            string oFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//DownLoads//" + strs[0] + ".zip";
            string fileName = model.fileName;
            PublicClass.CompressFile(iFile, oFile);
            return File(oFile, "application/octet-stream", strs[0] + ".zip");
        }

        /// <summary>
        /// 阅览文件
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public JsonResult GetFileURLForView(int wid)
        {
            var model = _msdsbll.GetModelList(" wId = " + wid + " and fileType='药品'").First();
            string iFile = "MSDS/" + (model.fileUrl.Contains("pdf") ? model.fileUrl.Substring(0, model.fileUrl.Length - 3) + "swf" : model.fileUrl);
            return Json(iFile, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 其他控件绑定
        private SelectList GetDropDownListForDrug()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
                foreach (var item in _drugbll.GetModelList(""))
                {
                    list.Add(new SelectListItem() { Text = item.drugName, Value = item.id.ToString() });
                }
            }
            catch
            {

            }
            return new SelectList(list, "Value", "Text"); ;
        }

        public JsonResult GetDrugListForDropDownList(string q)
        {
            var list = _drugbll.GetModelList(" drugName like '%%" + q + "%%' or drugCode like '%%" + q + "%%'");
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public string GetUserName(string _createuser)
        {
            string _name = "";
            try
            {
                if (!string.IsNullOrEmpty(_createuser))
                {
                    int _userId = Convert.ToInt32(_createuser);
                    if (_userId > 0)
                    {
                        var model = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(_userId);
                        if (model != null)
                        {
                            _name = model.PersonnelName;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return _name;
        }
    }
}
