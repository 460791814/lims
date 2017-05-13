using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Data;
using Model;
using Model.RoleManage;
using BLL.RoleManage;

namespace Web.Controllers
{
    public class EasyConsumeController : BaseController
    {
        tb_EasyConsumeBLL _easyconsumebll = new tb_EasyConsumeBLL();
        tb_EasyConsumeINBLL _easyconsumeinbll = new tb_EasyConsumeINBLL();
        tb_EasyConsumeOUTBLL _easyconsumeoutbll = new tb_EasyConsumeOUTBLL();
        tb_EasyConsumeLockBLL _easyConsumelockbll = new tb_EasyConsumeLockBLL();
        tb_EasyConsumeRegionBLL _easyConsumeregionbll = new tb_EasyConsumeRegionBLL();
        
        //
        // GET: /EasyConsume/

        public ActionResult Index()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }

        #region 易耗品管理（新增、修改、删除、列表）
        public ActionResult doEasyConsumeInfo(int id)
        {
            ViewData["ddl_unit"] = PublicClass.GetDropDownList(4, "请选择");

            if (id == 0)
            {
                return View();
            }
            var model = _easyconsumebll.GetModel(id);
            return View(model);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetEasyConsumeList(int pageNumber, int pageSize, int _cid, string _searchtext, string _searchtype)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1 = 1 ";
                switch (_searchtype)
                {
                    case "名称":
                        where += string.Format(" and name like '%%{0}%%' ", _searchtext);
                        break;
                    case "规格型号":
                        where += string.Format(" and type like '%%{0}%%' ", _searchtext);
                        break;
                    case "单位":
                        where += string.Format(" and danwei like '%%{0}%%' ", _searchtext);
                        break;
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
                
                dt = _easyconsumebll.GetListByPage(where, "updateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                total = _easyconsumebll.GetEasyConsumeCount(where);
            }
            catch { }
            dt.Columns.Add(new DataColumn("djr"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    int userid = Convert.ToInt32(dt.Rows[i]["createUser"]);
                    dt.Rows[i]["djr"] = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(userid).PersonnelName;
                }
                catch
                {
                    continue;
                }
            }
            return PublicClass.ToJson(dt, total);
        }



        /// <summary>
        /// 新建数据、更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        public string doEasyConsumeCU(tb_EasyConsume model)
        {
            string flag = "0";
            try
            {
                model.updateDate = DateTime.Now;
                model.updateUser = CurrentUserInfo.PersonnelID;
                if (model.id > 0)
                {
                    if (_easyconsumebll.Update(model))
                    {
                        flag = "1";
                    }

                }
                else
                {
                    model.createDate = DateTime.Now;
                    model.createUser = CurrentUserInfo.PersonnelID;
                    model.amount = 0;
                    if (_easyconsumebll.Add(model) > 0)
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
        public JsonResult Delete_EasyConsumeItem(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_easyconsumebll.Delete(id))
                {
                    str = "删除成功！";
                }
            }
            catch
            {
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region  易耗品入库（新增、编辑、删除、列表）
        public ActionResult EasyConsumeIN()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }

        public ActionResult doEasyConsumeINInfo(int id)
        {
            if (id > 0)
            {
                var model = _easyconsumeinbll.GetModel(id);
                return View(model);
            }
            List<SelectListItem> list = new List<SelectListItem>();

            var easyconsumelocklist = _easyConsumelockbll.GetModelList(CurrentUserInfo.AreaID.Value);
            if (easyconsumelocklist != null && easyconsumelocklist.Count > 0)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1" });
                for (int i = 0; i < easyconsumelocklist.Count; i++)
                {
                    var item = easyconsumelocklist[i];
                    list.Add(new SelectListItem() { Text = item.lockName, Value = item.id.ToString() });
                }
            }
            ViewData["easyConsumelocklist"] = list;
            return View();
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetEasyConsumeINList(int pageNumber, int pageSize, int _cid, string _searchtext, string _searchtype, string _datetype, string _txtdate)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1 = 1 ";
                switch (_searchtype)
                {
                    case "名称":
                        where += string.Format(" and name like '%%{0}%%' ", _searchtext);
                        break;
                    case "厂家与场地":
                        where += string.Format(" and manufacturers like '%%{0}%%' ", _searchtext);
                        break;
                    case "经手人":
                        var listperson = new BLL.PersonnelManage.T_tb_InPersonnel().GetModelList(" PersonnelName like '%%" + _searchtext + "%%'");
                        string personids = "";
                        foreach (var item in listperson)
                        {
                            personids += item.PersonnelID + ",";
                        }
                        if (!string.IsNullOrEmpty(personids))
                        {
                            where += string.Format(" and user1 in({0}) ", personids.Substring(0, personids.Length - 1));
                        }
                        break;
                }
                switch (_datetype)
                {
                    case "年":
                        where += string.Format(" and year(inDate) ={0} ", _txtdate);
                        break;
                    case "月":
                        DateTime _dtime = DateTime.Parse("1949-10-01"); DateTime.TryParse(_txtdate, out _dtime);
                        where += _dtime.Year > 1949 ? string.Format(" and year(inDate) = {0} and month(inDate) = {1} ", _dtime.Year, _dtime.Month) : "";
                        break;
                }
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
                dt = _easyconsumeinbll.GetListByPage(where, "updateDate desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                dt.Columns.Add("name");
                dt.Columns.Add("type");
                dt.Columns.Add("danwei");
                dt.Columns.Add("PersonnelName");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    int eid = Convert.ToInt32(dr["eId"]);
                    tb_EasyConsume _easyconsume = _easyconsumebll.GetModel(eid);
                    dt.Rows[i]["name"] = _easyconsume.name;
                    dt.Rows[i]["type"] = _easyconsume.type;
                    dt.Rows[i]["danwei"] = new tb_BaseBLL().GetModel(_easyconsume.unit.Value).baseName;
                    dt.Rows[i]["PersonnelName"] = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(Convert.ToInt32(dr["user1"])).PersonnelName;
                }

                total = dt.Rows.Count;
                total = _easyconsumeinbll.GetEasyConsumeINCount(where);
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        /// <summary>
        /// 新建数据或更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        public string EasyConsumeINCU(tb_EasyConsumeIN model)
        {
            string flag = "0";
            try
            {
                if (model.id > 0)
                {
                    flag = UpdateEasyConsumeIN(model, flag);
                }
                else
                {
                    model.temp2 = model.amount.Value.ToString();
                    flag = NewEasyConsumeIN(model, flag);
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
        /// <param name="model"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private string NewEasyConsumeIN(tb_EasyConsumeIN model, string flag)
        {
            model.createDate = DateTime.Now;
            model.createUser = CurrentUserInfo.PersonnelID;
            model.updateDate = DateTime.Now;
            model.updateUser = CurrentUserInfo.PersonnelID;
            var devicemodel = _easyconsumebll.GetModel(model.eId.Value);
            if (_easyconsumeinbll.Add(model) > 0)
            {
                devicemodel.amount += model.amount;
                if (_easyconsumebll.Update(devicemodel))
                {
                    flag = "1";
                }
            }
            return flag;
        }

        /// <summary>
        /// 更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">需要更新的模型</param>
        /// <returns></returns>
        private string UpdateEasyConsumeIN(tb_EasyConsumeIN model, string flag)
        {
            try
            {
                if (model != null && model.id > 0)
                {
                    model.updateDate = DateTime.Now;
                    model.updateUser = CurrentUserInfo.PersonnelID;
                    var tempinmodel = _easyconsumeinbll.GetModel(model.id);
                    var devicemodel = _easyconsumebll.GetModel(model.eId.Value);
                    if (_easyconsumeinbll.Update(model))
                    {
                        if (model.amount > tempinmodel.amount)
                        {
                            devicemodel.amount += model.amount - tempinmodel.amount;
                        }
                        else if (model.amount < tempinmodel.amount)
                        {
                            devicemodel.amount -= tempinmodel.amount - model.amount;
                        }
                        if (_easyconsumebll.Update(devicemodel))
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
        public JsonResult Delete_EasyConsumeIN(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_easyconsumeinbll.Delete(id))
                {
                    str = "删除成功！";
                }
            }
            catch
            {
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRegionByLockID(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (id > 0)
            {
                var easyconsumeregionlist = _easyConsumeregionbll.GetModelList(" lockid = " + id);
                if (easyconsumeregionlist != null && easyconsumeregionlist.Count > 0)
                {
                    list.Add(new SelectListItem() { Text = "请选择", Value = "-1" });
                    for (int i = 0; i < easyconsumeregionlist.Count; i++)
                    {
                        var item = easyconsumeregionlist[i];
                        list.Add(new SelectListItem() { Text = item.regionName, Value = item.id.ToString() });
                    }
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 易耗品出库（新增、编辑、删除、列表）
        public ActionResult EasyConsumeOUT()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }
        public ActionResult doEasyConsumeOUTInfo(int id)
        {
            if (id > 0)
            {
                var model = _easyconsumeoutbll.GetModel(id);
                return View(model);
            }
            return View();
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetEasyConsumeOUTList(int pageNumber, int pageSize, int _cid, string _searchtext, string _searchtype, string _datetype, string _txtdate)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1 = 1 ";
                switch (_searchtype)
                {
                    case "名称":
                        where += string.Format(" and name like '%%{0}%%' ", _searchtext);
                        break;
                    case "厂家与场地":
                        where += string.Format(" and product like '%%{0}%%' ", _searchtext);
                        break;
                    case "经手人":
                        var listperson = new BLL.PersonnelManage.T_tb_InPersonnel().GetModelList(" PersonnelName like '%%" + _searchtext + "%%'");
                        string personids = "";
                        foreach (var item in listperson)
                        {
                            personids += item.PersonnelID + ",";
                        }
                        if (!string.IsNullOrEmpty(personids))
                        {
                            where += string.Format(" and user1 in({0}) ", personids.Substring(0, personids.Length - 1));
                        }
                        break;
                }
                switch (_datetype)
                {
                    case "年":
                        where += string.Format(" and year(createDate) ={0} ", _txtdate);
                        break;
                    case "月":
                        DateTime _dtime = DateTime.Parse("1949-10-01"); DateTime.TryParse(_txtdate, out _dtime);
                        where += _dtime.Year > 1949 ? string.Format(" and year(createDate) = {0} and month(createDate) = {1} ", _dtime.Year, _dtime.Month) : "";
                        break;
                }
                if (CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", CurrentUserInfo.AreaID.Value, _userid);
                }
                else if (_cid > 0 || CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                dt = _easyconsumeoutbll.GetListByPage(where, "updateDate desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                dt.Columns.Add("name");
                dt.Columns.Add("type");
                dt.Columns.Add("danwei");
                dt.Columns.Add("PersonnelName");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    int eid = Convert.ToInt32(dr["eId"]);
                    tb_EasyConsume _easyconsume = _easyconsumebll.GetModel(eid);
                    dt.Rows[i]["name"] = _easyconsume.name;
                    dt.Rows[i]["type"] = _easyconsume.type;
                    dt.Rows[i]["danwei"] = new tb_BaseBLL().GetModel(_easyconsume.unit.Value).baseName;
                    dt.Rows[i]["PersonnelName"] = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(Convert.ToInt32(dr["user1"])).PersonnelName;
                }
                total = dt.Rows.Count;
                total = _easyconsumeoutbll.GetEasyConsumeOUTCount(where);
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        /// <summary>
        /// 新建数据或更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        public string EasyConsumeOUTCU(tb_EasyConsumeOUT model)
        {
            string flag = "0";
            try
            {
                if (model.id > 0)
                {
                    flag = UpdateEasyConsumeOUT(model, flag);
                }
                else
                {
                    flag = NewEasyConsumeOUT(model, flag);
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
        /// <param name="model"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private string NewEasyConsumeOUT(tb_EasyConsumeOUT model, string flag)
        {
            model.createDate = DateTime.Now;
            model.createUser = CurrentUserInfo.PersonnelID;
            model.updateDate = DateTime.Now;
            model.updateUser = CurrentUserInfo.PersonnelID;
            model.temp1 = "待审批";//待审批、通过、未通过
            var _easyconsumeinmodel = _easyconsumeinbll.GetModel(Convert.ToInt32(model.temp2));
            var devicemodel = _easyconsumebll.GetModel(model.eId.Value);
            if (_easyconsumeoutbll.Add(model) > 0)
            {
                _easyconsumeinmodel.temp2 = (Convert.ToInt32(_easyconsumeinmodel.temp2) - model.amount).ToString();
                _easyconsumeinbll.Update(_easyconsumeinmodel);
                devicemodel.amount = devicemodel.amount - model.amount;
                if (_easyconsumebll.Update(devicemodel))
                {
                    flag = "1";
                }
            }
            return flag;
        }

        /// <summary>
        /// 更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">需要更新的模型</param>
        /// <returns></returns>
        private string UpdateEasyConsumeOUT(tb_EasyConsumeOUT model, string flag)
        {
            try
            {
                if (model != null && model.id > 0)
                {
                    model.updateDate = DateTime.Now;
                    model.updateUser = CurrentUserInfo.PersonnelID;
                    var tempinmodel = _easyconsumeoutbll.GetModel(model.id);
                    var devicemodel = _easyconsumebll.GetModel(model.eId.Value);
                    if (_easyconsumeoutbll.Update(model))
                    {
                        if (model.amount > tempinmodel.amount)
                        {
                            devicemodel.amount -= model.amount - tempinmodel.amount;
                        }
                        else if (model.amount < tempinmodel.amount)
                        {
                            devicemodel.amount += tempinmodel.amount - model.amount;
                        }
                        if (_easyconsumebll.Update(devicemodel))
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
        public JsonResult Delete_EasyConsumeOUT(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_easyconsumeoutbll.Delete(id))
                {
                    str = "删除成功！";
                }
            }
            catch
            {
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEasyConsumeInForOut(int _eid)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var durgInList = _easyconsumeinbll.GetModelList(string.Format(" eId = {0} and temp2 is not null and convert(int,temp2) > 0 ", _eid));
            for (int i = 0; i < durgInList.Count; i++)
            {
                var item = durgInList[i];
                string _text = "有效期" + item.validDate.Value.ToShortDateString() + "  生产日期" + item.productDate.Value.ToShortDateString();
                list.Add(new SelectListItem() { Text = _text, Value = item.id.ToString() });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEasyConsumeINModel(int _id)
        {
            tb_EasyConsumeIN model = _easyconsumeinbll.GetModel(_id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 易耗品台账
        public ActionResult EasyConsumeLog()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }
        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetEasyConsumeLogList(int pageNumber, int pageSize, int _cid, string _searchtext, string _searchtext2)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                dt = _easyconsumebll.GetEasyConsumeLogListByPage(CurrentUserInfo, _cid, _searchtext, "UpdateDate desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, _searchtext2);
                total = dt.Rows.Count;
                total = _easyconsumebll.GetModelList("").Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }
        #endregion

        #region 易耗品柜
        public ActionResult EasyConsumeLock()
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

        public ActionResult doEasyConsumeLockInfo(int id)
        {
            tb_EasyConsumeLock model = new tb_EasyConsumeLock();
            if (id > 0)
            {
                
                model = _easyConsumelockbll.GetModel(id);
            }
            return View(model);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetEasyConsumeRegionList(int pageNumber, int pageSize, string _regionName, int _lockId)
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
                        tb_EasyConsumeRegion model = _easyConsumeregionbll.GetModelList(string.Format(" regionName = '{0}' and lockId = {1}", _regionName, _lockId)).First();
                        where += " and regionId = " + model.id;
                    }
                    catch
                    { }
                }
                if (_lockId > 0)
                {
                    where += " and lockId = " + _lockId;
                    dt = _easyConsumeregionbll.GetListByPage(where, "UpdateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                    total = dt.Rows.Count;
                    total = _easyConsumeregionbll.GetListCount(where);
                }
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        public JsonResult Update_EasyConsumeLock(int id, string _lockName, bool _wxp, bool _hxp, string _locktype)
        {
            string str = "保存失败！";
            try
            {
                tb_EasyConsumeLock model = new tb_EasyConsumeLock();
                if (id > 0)
                {
                    model = _easyConsumelockbll.GetModel(id);
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
                    if (_easyConsumelockbll.Update(model))
                    {
                        str = "保存成功！";
                    }
                }
                else
                {
                    model.createDate = DateTime.Now;
                    model.createUser = CurrentUserInfo.PersonnelID;
                    var easyConsumelocklist = _easyConsumelockbll.GetModelList("").Where(w => w.lockName.Equals(model.lockName) && w.createUser == model.createUser);
                    if (easyConsumelocklist == null || easyConsumelocklist.Count() == 0)
                    {
                        if (_easyConsumelockbll.Add(model) > 0)
                        {
                            easyConsumelocklist = _easyConsumelockbll.GetModelList("").Where(w => w.lockName.Equals(model.lockName) && w.createUser == model.createUser);
                            if (easyConsumelocklist != null && easyConsumelocklist.Count() > 0)
                            {
                                model = easyConsumelocklist.First();
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
                                        tb_EasyConsumeRegion easyConsumeregionmodel = new tb_EasyConsumeRegion();

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
                                        easyConsumeregionmodel.createDate = DateTime.Now;
                                        easyConsumeregionmodel.createUser = CurrentUserInfo.PersonnelID;
                                        easyConsumeregionmodel.lockId = model.id;
                                        easyConsumeregionmodel.regionName = imgname;
                                        easyConsumeregionmodel.updateDate = DateTime.Now;
                                        easyConsumeregionmodel.updateUser = CurrentUserInfo.PersonnelID;
                                        _easyConsumeregionbll.Add(easyConsumeregionmodel);
                                    }
                                }
                                for (int i = 1; i <= fornum; i++)
                                {
                                    tb_EasyConsumeRegion easyConsumeregionmodel = new tb_EasyConsumeRegion();

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
                                    easyConsumeregionmodel.createDate = DateTime.Now;
                                    easyConsumeregionmodel.createUser = CurrentUserInfo.PersonnelID;
                                    easyConsumeregionmodel.lockId = model.id;
                                    easyConsumeregionmodel.regionName = imgname;
                                    easyConsumeregionmodel.updateDate = DateTime.Now;
                                    easyConsumeregionmodel.updateUser = CurrentUserInfo.PersonnelID;
                                    _easyConsumeregionbll.Add(easyConsumeregionmodel);
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

        public JsonResult Delete_EasyConsumeLock(string ids)
        {
            string str = "删除失败！";
            if (_easyConsumelockbll.DeleteList(ids))
            {
                str = "删除成功！";
                var easyConsumeregionlist = _easyConsumeregionbll.GetModelList(" lockId in (" + ids + ")");
                ids = "";
                if (easyConsumeregionlist != null && easyConsumeregionlist.Count > 0)
                {
                    for (int i = 0; i < easyConsumeregionlist.Count; i++)
                    {
                        if (i == 0)
                        {
                            ids += easyConsumeregionlist[i].id.ToString();
                        }
                        else
                        {
                            ids += "," + easyConsumeregionlist[i].id.ToString();
                        }
                    }
                    _easyConsumeregionbll.DeleteList(ids);
                    var easyConsumeinlist = _easyconsumeinbll.GetModelList(" GPS in (" + ids + ")");
                    if (easyConsumeinlist != null && easyConsumeinlist.Count > 0)
                    {
                        for (int i = 0; i < easyConsumeinlist.Count; i++)
                        {
                            var model = easyConsumeinlist[i];
                            model.GPS = "";
                            _easyconsumeinbll.Update(model);
                        }
                    }
                }
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 公共控件
        public JsonResult GetEasyConsumeListForDropDownList(string q)
        {
            var list = _easyconsumebll.GetModelList(" name like '%%" + q + "%%' or type like '%%" + q + "%%' ");
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
