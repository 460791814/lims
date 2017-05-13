using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BLL.PersonnelManage;
using Model;

namespace Web.Controllers
{
    public class BookController : BaseController
    {
        tb_BookBLL _bookbll = new tb_BookBLL();
        tb_BookBorrowBLL _bookborrowbll = new tb_BookBorrowBLL();
        tb_BaseBLL _basebll = new tb_BaseBLL();
        T_tb_InPersonnel _inpersonnel = new T_tb_InPersonnel();
        //
        // GET: /Book/

        public ActionResult Index()
        {
            try
            {
                ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
                ViewBag._lid = CurrentUserInfo.AreaID;
            }
            catch
            {
            }
            return View();
        }
        public ActionResult BorrowManage()
        {
            try
            {
                ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
                ViewBag._lid = CurrentUserInfo.AreaID;
            }
            catch
            {

            }
            return View();
        }

        #region 图书管理（新增、修改、删除、列表）
        public ActionResult doBookInfo(int id)
        {
            ViewData["ddl_type1"] = PublicClass.GetDropDownList(10, "请选择");
            ViewData["ddl_type2"] = PublicClass.GetDropDownList(13, "请选择");
            ViewData["ddl_status"] = PublicClass.GetDropDownList(17, "请选择");
            tb_Book model = new tb_Book();
            if (id > 0)
            {
                model = _bookbll.GetModel(id);
            }
            return View(model);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string _search, string _searchtype, int _cid)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1=1 ";
                if (!string.IsNullOrEmpty(_search))
                {
                    switch (_searchtype)
                    {
                        case "bianhao":
                            where = " code like '%%" + _search + "%%'";
                            break;
                        case "mingchen":
                            where = " name like '%%" + _search + "%%'";
                            break;
                        case "zhongshu":
                            where = " zhongshu like '%%" + _search + "%%'";
                            break;
                        case "leibie":
                            where = " leibie like '%%" + _search + "%%'";
                            break;
                        case "zuozhe":
                            where = " author like '%%" + _search + "%%'";
                            break;
                        case "zhuangtai":
                            where = " zhuangtai like '%%" + _search + "%%'";
                            break;
                        case "chubanshe":
                            where = " press like '%%" + _search + "%%'";
                            break;
                    }
                }
                if (_cid > 0 && CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", _cid, _userid);
                }
                else if (_cid > 0 && CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and CreateUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                dt = _bookbll.GetListByPage(where, "updateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                total = _bookbll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        /// <summary>
        /// 新增 编辑 数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string doBookCU(tb_Book model)
        {
            string flag = "0";
            try
            {
                model.updateDate = DateTime.Now;
                model.updateUser = CurrentUserInfo.PersonnelID;
                if (model.id > 0)
                {
                    if (model != null && model.id > 0)
                    {
                        if (_bookbll.Update(model))
                        {
                            flag = "1";
                        }
                    }
                }
                else
                {
                    model.createDate = DateTime.Now;
                    model.createUser = CurrentUserInfo.PersonnelID;
                    model.repertory = model.num;
                    if (_bookbll.Add(model) > 0)
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
                if (_bookbll.Delete(id))
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

        #region 图书借阅（新增、修改、删除、列表）
        public ActionResult doBorrowManageAdd()
        {
            return View();
        }
        public ActionResult doBorrowManageUpdate(int id)
        {
            tb_BookBorrow model = new tb_BookBorrow();
            if (id > 0)
            {
                model = _bookborrowbll.GetModel(id);
            }
            return View(model);
        }

        public ActionResult doBorrowManageInfo(int id)
        {
            tb_BookBorrow model = new tb_BookBorrow();
            if (id > 0)
            {
                model = _bookborrowbll.GetModel(id);
            }
            return View(model);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetBorrwList(int pageNumber, int pageSize, string _search, string _searchtype, int _cid)
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
                        case "bianhao":
                            where = " code like '%%" + _search + "%%'";
                            break;
                        case "mingchen":
                            where = " bookName like '%%" + _search + "%%'";
                            break;
                        case "zhongshu":
                            var zhongshujihe = _basebll.GetModelList(" where pId = 10");
                            if (zhongshujihe != null && zhongshujihe.Count > 0)
                            {
                                zhongshujihe = zhongshujihe.Where(w => w.baseName.Contains(_search)).ToList();
                                where = " type1 = " + zhongshujihe.First().id;
                            }
                            break;
                        case "leibie":
                            var leibiejihe = _basebll.GetModelList(" where pId = 13");
                            if (leibiejihe != null && leibiejihe.Count > 0)
                            {
                                leibiejihe = leibiejihe.Where(w => w.baseName.Contains(_search)).ToList();
                                where = " type2 = " + leibiejihe.First().id;
                            }
                            break;
                        case "zuozhe":
                            where = " author like '%%" + _search + "%%'";
                            break;
                        case "zhuangtai":
                            var zhuangtaijihe = _basebll.GetModelList(" where pId = 13");
                            if (zhuangtaijihe != null && zhuangtaijihe.Count > 0)
                            {
                                zhuangtaijihe = zhuangtaijihe.Where(w => w.baseName.Contains(_search)).ToList();
                                where = " status = " + zhuangtaijihe.First().id;
                            }
                            break;
                        case "chubanshe":
                            where = " press like '%%" + _search + "%%'";
                            break;
                        case "jieyueren":
                            where = " name like '%%" + _search + "%%'";
                            break;
                        case "jieyueriqi":
                            where = string.Format(" and convert(char(8), borrowDate, 112) like '%%{0}%%'", _search);
                            break;
                        case "guihuanriqi":
                            where = string.Format(" and convert(char(8), backDate, 112) like '%%{0}%%'", _search);
                            break;
                    }
                }
                if (_cid > 0 && CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", _cid, _userid);
                }
                else if (_cid > 0 && CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and CreateUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                dt = _bookborrowbll.GetListByPage(where, "updateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                total = _bookborrowbll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        /// <summary>
        /// 新建数据或编辑数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        public string doBorrowCU(tb_BookBorrow model)
        {
            string flag = "0";
            try
            {
                model.updateDate = DateTime.Now;
                model.updateUser = CurrentUserInfo.PersonnelID;
                if (model.id > 0)
                {
                    var bookmodel = _bookbll.GetModel(model.bookId);
                    if (bookmodel.repertory + model.backNum <= bookmodel.num)
                    {
                        bookmodel.repertory = bookmodel.repertory + model.backNum;
                    }
                    if (_bookborrowbll.Update(model))
                    {
                        _bookbll.Update(bookmodel);
                        flag = "1";
                    }
                }
                else
                {
                    model.createDate = DateTime.Now;
                    model.createUser = CurrentUserInfo.PersonnelID;
                    model.borrowDate = DateTime.Now;
                    model.status = 2;
                    var bookmodel = _bookbll.GetModel(model.bookId);
                    try
                    {
                        var starttime = DateTime.Parse(model.temp1);
                        model.temp1 = starttime.ToString("yyyy/MM/dd");
                        var endtime = DateTime.Parse(model.temp2);
                        model.temp2 = endtime.ToString("yyyy/MM/dd");
                        model.dayNum = (endtime - starttime).Days;
                    }
                    catch
                    {

                    }
                    if (bookmodel.repertory - model.borrowNum >= 0)
                    {
                        bookmodel.repertory = bookmodel.repertory - model.borrowNum;
                    }
                    else
                    {
                        return flag;
                    }
                    if (_bookborrowbll.Add(model) > 0)
                    {
                        _bookbll.Update(bookmodel);
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
        public JsonResult Delete_BorrowItem(int id)
        {
            string str = "删除失败！";
            try
            {
                var model = _bookborrowbll.GetModel(id);
                var bookmodel = _bookbll.GetModel(model.bookId);
                if (_bookborrowbll.Delete(id))
                {
                    if (model.status == 2)
                    {
                        bookmodel.repertory += model.borrowNum;
                    }
                    else if (model.status == 3)
                    {
                        bookmodel.repertory += model.borrowNum - model.backNum;
                    }
                    _bookbll.Update(bookmodel);
                    str = "删除成功！";
                }
            }
            catch
            {
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region 图书统计
        /// <summary>
        /// 跳转页面
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public ActionResult BookLog()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }

        /// <summary>
        /// 获取图书统计列表
        /// 作者：章建国
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public string GetBookLogList(int cid)
        {
            DataTable dt = new DataTable();
            string where = " 1 = 1";
            if (cid > 0 && CurrentUserInfo.DataRange == 3)
            {
                int _userid = CurrentUserInfo.PersonnelID;
                where += string.Format(" and  CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", cid, _userid);
            }
            else if (cid > 0 && CurrentUserInfo.DataRange == 2)
            {
                int _userid = CurrentUserInfo.PersonnelID;
                where += string.Format(" and CreateUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", cid);
            }
            dt = _bookbll.GetBookLogList(where);
            return PublicClass.ToJson(dt, dt.Rows.Count);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetBorrwList_for_Log(int pageNumber, int pageSize, string _search, string _searchtype, int _cid)
        {
            DataTable bookdatetable = new DataTable();
            int total = 0;
            try
            {
                string where = " 1 = 1"; 

                #region 搜索条件
                if (!string.IsNullOrEmpty(_search))
                {
                    switch (_searchtype)
                    {
                        case "bianhao":
                            where = " code like '%%" + _search + "%%'";
                            break;
                        case "mingchen":
                            where = " name like '%%" + _search + "%%'";
                            break;
                        case "zhongshu":
                            var zhongshujihe = _basebll.GetModelList(" where pId = 10");
                            if (zhongshujihe != null && zhongshujihe.Count > 0)
                            {
                                zhongshujihe = zhongshujihe.Where(w => w.baseName.Contains(_search)).ToList();
                                where = " type1 = " + zhongshujihe.First().id;
                            }
                            break;
                        case "leibie":
                            var leibiejihe = _basebll.GetModelList(" where pId = 13");
                            if (leibiejihe != null && leibiejihe.Count > 0)
                            {
                                leibiejihe = leibiejihe.Where(w => w.baseName.Contains(_search)).ToList();
                                where = " type2 = " + leibiejihe.First().id;
                            }
                            break;
                        case "zuozhe":
                            where = " author like '%%" + _search + "%%'";
                            break;
                        case "zhuangtai":
                            var zhuangtaijihe = _basebll.GetModelList(" where pId = 13");
                            if (zhuangtaijihe != null && zhuangtaijihe.Count > 0)
                            {
                                zhuangtaijihe = zhuangtaijihe.Where(w => w.baseName.Contains(_search)).ToList();
                                where = " status = " + zhuangtaijihe.First().id;
                            }
                            break;
                        case "chubanshe":
                            where = " press like '%%" + _search + "%%'";
                            break;
                        case "jieyueren":
                            where = " name like '%%" + _search + "%%'";
                            break;
                        case "jieyueriqi":
                            where = string.Format(" and convert(char(8), borrowDate, 112) like '%%{0}%%'", _search);
                            break;
                        case "guihuanriqi":
                            where = string.Format(" and convert(char(8), backDate, 112) like '%%{0}%%'", _search);
                            break;
                    }
                }
                #endregion

                if (_cid > 0 && CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", _cid, _userid);
                }
                else if (_cid > 0 && CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and CreateUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }

                bookdatetable = _bookbll.GetListByPage(where, "updateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                bookdatetable.Columns.Add(new DataColumn("borrowNum"));
                bookdatetable.Columns.Add(new DataColumn("amount"));
                bookdatetable.Columns.Add(new DataColumn("bname"));
                for (int i = 0; i < bookdatetable.Rows.Count; i++)
                {
                    int bookid = Convert.ToInt32(bookdatetable.Rows[i]["id"]);
                    var bookborrowList = _bookborrowbll.GetModelList(" status = 2 and bookId = " + bookid);
                    int borrowNum = 0;
                    foreach (var item in bookborrowList)
                    {
                        borrowNum += item.borrowNum.Value;
                    }
                    bookdatetable.Rows[i]["amount"] = bookdatetable.Rows[i]["num"];
                    bookdatetable.Rows[i]["borrowNum"] = borrowNum;
                }
                bookdatetable.Columns.Remove("num");
                //dt = _bookborrowbll.GetListByPage(where, "updateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = bookdatetable.Rows.Count;
                total = _bookbll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(bookdatetable, total);
        }
        #endregion

        public JsonResult GetBookListForDropDownList(string q)
        {
            var list = _bookbll.GetModelList(" name like '%%" + q + "%%' or code like '%%" + q + "%%'", new int());
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInPersonnelListForDropDownList(string q)
        {
            var list = _inpersonnel.GetModelList(" PersonnelName like '%%" + q + "%%' or Department like '%%" + q + "%%' or Tel like '%%" + q + "%%' or CID like '%%" + q + "%%'");
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
