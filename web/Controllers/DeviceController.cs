using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DeviceController : BaseController
    {

        tb_DeviceBLL _devicebll = new tb_DeviceBLL();
        tb_DeviceINBLL _deviceinbll = new tb_DeviceINBLL();
        tb_DeviceDetailBLL _devicedetailbll = new tb_DeviceDetailBLL();
        tb_DeviceOUTBLL _deviceoutbll = new tb_DeviceOUTBLL();
        tb_DeviceLogBLL _devicelogbll = new tb_DeviceLogBLL();
        //
        // GET: /Device/

        public ActionResult Index()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }

        #region 设备管理（新增、修改、删除、列表）
        public ActionResult doDeviceInfo(int id)
        {
            ViewData["ddl_company"] = PublicClass.GetDropDownList(20, "请选择");
            ViewData["ddl_unit"] = PublicClass.GetDropDownList(4, "请选择");
            if (id == 0)
            {
                return View();
            }
            var model = _devicebll.GetModel(id);
            return View(model);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDeviceList(int pageNumber, int pageSize, int _cid, string _searchtext, string _searchtype)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1 = 1";
                where += ResultWhere(_searchtext, _searchtype);
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
                dt = _devicebll.GetListByPage(where, "updateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                total = _devicebll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        private string ResultWhere(string _searchtext, string _searchtype)
        {
            switch (_searchtype)
            {
                case "设备名称":
                    _searchtext = string.Format(" and name like '%%{0}%%'", _searchtext);
                    break;
                case "资产编号":
                    _searchtext = string.Format(" and pCode like '%%{0}%%'", _searchtext);
                    break;
                case "设备编号":
                    _searchtext = string.Format(" and eCode like '%%{0}%%'", _searchtext);
                    break;
                case "购置日期":
                    _searchtext = string.Format(" and convert(char(8), buyDate, 112) like '%%{0}%%'", _searchtext);
                    break;
                case "启用日期":
                    _searchtext = string.Format(" and convert(char(8), useDate, 112) like '%%{0}%%'", _searchtext);
                    break;
                case "上次检定日期":
                    _searchtext = string.Format(" and convert(char(8), lastVerificationDate, 112) like '%%{0}%%'", _searchtext);
                    break;
            }
            return _searchtext;
        }

        /// <summary>
        /// 新建数据、更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        public string doDeviceCU(tb_Device model)
        {
            string flag = "0";
            try
            {
                model.updateDate = DateTime.Now;
                model.updateUser = CurrentUserInfo.PersonnelID;
                if (model.id > 0)
                {
                    if (_devicebll.Update(model))
                    {
                        flag = "1";
                    }

                }
                else
                {
                    model.createDate = DateTime.Now;
                    model.createUser = CurrentUserInfo.PersonnelID;
                    model.amount = 0;
                    if (_devicebll.Add(model) > 0)
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
        public JsonResult Delete_DeviceItem(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_devicebll.Delete(id))
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

        #region 设备入库（新增、编辑、删除、列表）
        public ActionResult DeviceIN()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }
        public ActionResult doDeviceINInfo(int id)
        {
            if (id > 0)
            {
                var model = _deviceinbll.GetModel(id);
                return View(model);
            }
            return View();
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDeviceINList(int pageNumber, int pageSize, int _cid, string _searchtext, string _searchtype)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1 = 1";
                where += ResultWhere(_searchtext, _searchtype);
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
                dt = _deviceinbll.GetListByPage(where, "UpdateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                total = _deviceinbll.GetModelList(where).Count;
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
        public string DeviceINCU(tb_DeviceIN model)
        {
            string flag = "0";
            try
            {
                if (model.id > 0)
                {
                    flag = UpdateDeviceIN(model, flag);
                }
                else
                {
                    flag = NewDeviceIN(model, flag);
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
        private string NewDeviceIN(tb_DeviceIN model, string flag)
        {
            model.createDate = DateTime.Now;
            model.createUser = CurrentUserInfo.PersonnelID;
            model.updateDate = DateTime.Now;
            model.updateUser = CurrentUserInfo.PersonnelID;
            var devicemodel = _devicebll.GetModel(model.deviceId.Value);
            if (_deviceinbll.Add(model) > 0)
            {
                devicemodel.amount += model.amount;
                if (_devicebll.Update(devicemodel))
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
        private string UpdateDeviceIN(tb_DeviceIN model, string flag)
        {
            try
            {
                if (model != null && model.id > 0)
                {
                    model.updateDate = DateTime.Now;
                    model.updateUser = CurrentUserInfo.PersonnelID;
                    var tempinmodel = _deviceinbll.GetModel(model.id);
                    var devicemodel = _devicebll.GetModel(model.deviceId.Value);
                    if (_deviceinbll.Update(model))
                    {
                        if (model.amount > tempinmodel.amount)
                        {
                            devicemodel.amount += model.amount - tempinmodel.amount;
                        }
                        else if (model.amount < tempinmodel.amount)
                        {
                            devicemodel.amount -= tempinmodel.amount - model.amount;
                        }
                        if (_devicebll.Update(devicemodel))
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
        public JsonResult Delete_DeviceIN(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_deviceinbll.Delete(id))
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

        #region 运行情况（新增、编辑、删除、列表）
        public ActionResult DeviceDetail(int id)
        {
            var devicemodel = _devicebll.GetModel(id);
            ViewBag.did = devicemodel.id;
            ViewBag.deviceinfo = string.Format("设备名称：{0}    规格型号：{1}    资产编号：{2}    设备编号：{3}    使用单位：{4}    使用人：{5}  ", devicemodel.name, devicemodel.type, devicemodel.pCode, devicemodel.eCode, "admin单位", "admin");
            return View();
        }

        public ActionResult doDeviceDetailInfo(int id, int did)
        {
            tb_DeviceDetail devicedetailmodel = new tb_DeviceDetail();
            devicedetailmodel.deviceId = did;
            if (id > 0)
            {
                devicedetailmodel = _devicedetailbll.GetModel(id);
            }
            return View(devicedetailmodel);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDeviceDetailList(int pageNumber)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                dt = _devicedetailbll.GetListByPage("", "UpdateDate", pageNumber * 8 - 7, pageNumber * 8).Tables[0];
                total = dt.Rows.Count;
                total = _devicedetailbll.GetModelList("").Count;
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
        public string DeviceDetailCU(tb_DeviceDetail model)
        {
            string flag = "0";
            try
            {
                if (model.id > 0)
                {
                    flag = UpdateDeviceDetail(model, flag);
                }
                else
                {
                    flag = NewDeviceDetail(model, flag);
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
        private string NewDeviceDetail(tb_DeviceDetail model, string flag)
        {
            model.createDate = DateTime.Now;
            model.createUser = CurrentUserInfo.PersonnelID;
            model.updateDate = DateTime.Now;
            model.updateUser = CurrentUserInfo.PersonnelID;

            if (_devicedetailbll.Add(model) > 0)
            {
                flag = "1";
            }
            return flag;
        }

        /// <summary>
        /// 更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">需要更新的模型</param>
        /// <returns></returns>
        private string UpdateDeviceDetail(tb_DeviceDetail model, string flag)
        {
            try
            {
                model.updateDate = DateTime.Now;
                model.updateUser = CurrentUserInfo.PersonnelID;
                if (_devicedetailbll.Update(model))
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
        /// 删除数据
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public JsonResult Delete_DeviceDetail(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_devicedetailbll.Delete(id))
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

        #region 设备领用（新增、编辑、删除、列表）
        public ActionResult DeviceOUT()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }
        public ActionResult doDeviceOUTInfo(int id)
        {
            if (id > 0)
            {
                var model = _deviceoutbll.GetModel(id);
                return View(model);
            }
            return View();
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDeviceOUTList(int pageNumber, int pageSize, int _cid, string _searchtext, string _searchtype)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1 = 1";
                where += ResultWhereOUT(_searchtext, _searchtype);
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
                dt.Columns.Add(new DataColumn("lyr"));
                dt.Columns.Add(new DataColumn("jbr"));
                dt.Columns.Add(new DataColumn("ghr"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        int user3 = Convert.ToInt32(dt.Rows[i]["userId3"]);
                        dt.Rows[i]["lyr"] = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(user3).PersonnelName;
                    }
                    catch
                    {
                    }
                    try
                    {
                        int user1 = Convert.ToInt32(dt.Rows[i]["userId1"]);
                        dt.Rows[i]["jbr"] = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(user1).PersonnelName;
                    }
                    catch
                    {
                    }
                    try
                    {
                        int user2 = Convert.ToInt32(dt.Rows[i]["userId2"]);
                        dt.Rows[i]["ghr"] = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(user2).PersonnelName;
                    }
                    catch
                    {
                    }
                }
                dt = _deviceoutbll.GetListByPage(where, "UpdateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                total = _deviceoutbll.GetDeviceOUTCount(where);
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        private string ResultWhereOUT(string _searchtext, string _searchtype)
        {
            switch (_searchtype)
            {
                case "设备名称":
                    _searchtext = string.Format(" and name like '%%{0}%%'", _searchtext);
                    break;
                case "设备编号":
                    _searchtext = string.Format(" and eCode like '%%{0}%%'", _searchtext);
                    break;
                case "领用人":
                    _searchtext = string.Format(" and PersonnelName1 like '%%{0}%%'", _searchtext);
                    break;
                case "归还人":
                    _searchtext = string.Format(" and PersonnelName2 like '%%{0}%%'", _searchtext);
                    break;
                case "领用日期":
                    _searchtext = string.Format(" and convert(char(8), gDate, 112) like '%%{0}%%'", _searchtext);
                    break;
                case "归还日期":
                    _searchtext = string.Format(" and convert(char(8), bDate, 112) like '%%{0}%%'", _searchtext);
                    break;
            }
            return _searchtext;
        }

        /// <summary>
        /// 新建数据或更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        public string DeviceOUTCU(tb_DeviceOUT model)
        {
            string flag = "0";
            try
            {
                if (model.id > 0)
                {
                    flag = UpdateDeviceOUT(model, flag);
                }
                else
                {
                    flag = NewDeviceOUT(model, flag);
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
        private string NewDeviceOUT(tb_DeviceOUT model, string flag)
        {
            model.createDate = DateTime.Now;
            model.createUser = CurrentUserInfo.PersonnelID;
            model.updateDate = DateTime.Now;
            model.updateUser = CurrentUserInfo.PersonnelID;
            var devicemodel = _devicebll.GetModel(model.deviceId.Value);
            if (_deviceoutbll.Add(model) > 0)
            {
                devicemodel.amount -= model.amount;
                if (_devicebll.Update(devicemodel))
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
        private string UpdateDeviceOUT(tb_DeviceOUT model, string flag)
        {
            try
            {
                if (model != null && model.id > 0)
                {
                    model.updateDate = DateTime.Now;
                    model.updateUser = CurrentUserInfo.PersonnelID;
                    var tempinmodel = _deviceoutbll.GetModel(model.id);
                    var devicemodel = _devicebll.GetModel(model.deviceId.Value);
                    if (_deviceoutbll.Update(model))
                    {
                        if (model.amount > tempinmodel.amount)
                        {
                            devicemodel.amount -= model.amount - tempinmodel.amount;
                        }
                        else if (model.amount < tempinmodel.amount)
                        {
                            devicemodel.amount += tempinmodel.amount - model.amount;
                        }
                        if (_devicebll.Update(devicemodel))
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
        public JsonResult Delete_DeviceOUT(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_deviceoutbll.Delete(id))
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

        #region 设备台账
        public ActionResult DeviceLog()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }
        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetDeviceLogList(int pageNumber, int _cid, string _type, string _text)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1=1 ";
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
                    case "设备名称":
                        where += string.Format(" and NAME like '%%{0}%%'", _text);
                        break;
                    case "资产编号":
                        where += string.Format(" and PCODE like '%%{0}%%'", _text);
                        break;
                    case "设备编号":
                        where += string.Format(" and ECODE like '%%{0}%%'", _text);
                        break;
                    case "购置日期":
                        where += string.Format(" and convert(char(8), BUYDATE, 112) like '%%{0}%%'", _text);
                        break;
                    case "启用日期":
                        where += string.Format(" and convert(char(8), USEDATE, 112) like '%%{0}%%'", _text);
                        break;
                    case "上次检定日期":
                        where += string.Format(" and convert(char(8), LASTVERIFICATIONDATE, 112) like '%%{0}%%'", _text);
                        break;
                }
                dt = _devicelogbll.GetListByPage(where, "UpdateDate", pageNumber * 8 - 7, pageNumber * 8).Tables[0];
                total = dt.Rows.Count;
                total = _devicelogbll.GetCount(where);
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }
        #endregion

        #region 公共控件
        public JsonResult GetDeviceListForDropDownList(string q)
        {
            var list = _devicebll.GetModelList(" name like '%%" + q + "%%' or pCode like '%%" + q + "%%' or eCode like '%%" + q + "%%'");
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                list[i].temp2 = new BLL.tb_BaseBLL().GetModel(item.unit.Value).baseName;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
