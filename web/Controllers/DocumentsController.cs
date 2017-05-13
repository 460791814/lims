using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using System.IO;
using System.Web.UI;
using System.Text;
using System.Data;
using System.Collections;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Model.PersonnelManage;

namespace Web.Controllers
{
    public class DocumentsController : BaseController
    {
        #region
        private tb_documentBLL _docbll = new tb_documentBLL();
        private tb_LimitBLL _limitbll = new tb_LimitBLL();
        #endregion

        public ActionResult Index(string doc_Type)
        {
            Session["doc_Type"] = doc_Type;
            ViewData["cbo_zhuangtai"] = GetcboStatus();
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
            ViewBag.RoleId = CurrentUserInfo.RoleID;
            return View();
        }

        #region 文件新增、下载、删除、编辑、列表
        /// <summary>
        /// 获取文档编号
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDocCode()
        {
            string _code = "";
            try
            {
                string doc_Type = Session["doc_Type"].ToString();
                int count = _docbll.GetModelList(" doc_Type = '" + doc_Type + "'").Count + 1;
                switch (doc_Type)
                {
                    case "体系文件":
                        _code = "TX000" + count;
                        break;
                    case "工作手册":
                        _code = "GZ000" + count;
                        break;
                    case "安全管理":
                        _code = "AQ000" + count;
                        break;
                    case "成本管理":
                        _code = "CB000" + count;
                        break;
                }
            }
            catch
            {
            }
            return Json(_code, JsonRequestBehavior.AllowGet);
        }


        public string doDocCU(tb_document model)
        {
            string flag = "0";
            try
            {
                if (model != null && model.id > 0)
                {
                    model.doc_UpdateDate = DateTime.Now;
                    model.doc_UpdateUser = CurrentUserInfo.PersonnelID;
                    #region tb_documentHistory添加历史数据

                    var documentHistory = new tb_document_History();
                    documentHistory.direct_Id = model.direct_Id;
                    documentHistory.doc_Code = model.doc_Code;
                    documentHistory.doc_CreateDate = model.doc_CreateDate;
                    documentHistory.doc_CreateUser = model.doc_CreateUser;
                    documentHistory.doc_Guid = model.doc_Guid;
                    documentHistory.doc_Id = model.id;
                    documentHistory.doc_KeyWord = model.doc_KeyWord;
                    documentHistory.doc_Name = model.doc_Name;
                    documentHistory.doc_Path = model.doc_Path;
                    documentHistory.doc_Revo = model.doc_Revo;
                    documentHistory.doc_Size = model.doc_Size;
                    documentHistory.doc_Source = model.doc_Source;
                    documentHistory.doc_Status = model.doc_Status;
                    documentHistory.doc_Type = model.doc_Type;
                    documentHistory.doc_UpdateDate = model.doc_UpdateDate;
                    documentHistory.doc_UpdateUser = model.doc_UpdateUser;
                    documentHistory.doc_URL = model.doc_URL;
                    documentHistory.isDelete = model.isDelete;
                    documentHistory.remark = model.remark;
                    documentHistory.temp1 = model.temp1;
                    documentHistory.temp2 = model.temp2;
                    tb_document_HistoryBLL _docbllhistory = new tb_document_HistoryBLL();
                    documentHistory.doc_Revo = (_docbllhistory.GetDocHistoryCountByDocID(documentHistory.doc_Id) + 1).ToString();
                    _docbllhistory.Add(documentHistory);
                    #endregion

                    if (_docbll.Update(model))
                    {
                        flag = "1";
                    }
                }
                else
                {
                    //model.doc_CreateDate = DateTime.Now;
                    model.doc_CreateUser = CurrentUserInfo.PersonnelID;
                    model.doc_UpdateDate = DateTime.Now;
                    model.doc_UpdateUser = CurrentUserInfo.PersonnelID;
                    //model.doc_Size = (Convert.ToInt32(model.doc_Size) / 1000).ToString();

                    model.doc_Type = Session["doc_Type"].ToString();
                    if (_docbll.Add(model) > 0)
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
        [HttpPost]
        public string NewDoc(tb_document model)
        {
            string flag = "0";
            try
            {
                model.doc_CreateDate = DateTime.Now;
                model.doc_CreateUser = CurrentUserInfo.PersonnelID;
                model.doc_UpdateDate = DateTime.Now;
                model.doc_UpdateUser = CurrentUserInfo.PersonnelID;
                //model.doc_Size = (Convert.ToInt32(model.doc_Size) / 1000).ToString();
                model.doc_Type = Session["doc_Type"].ToString();
                if (_docbll.Add(model) > 0)
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
        /// 跳转至更新页面
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public ActionResult surfUpdateDoc(int id)
        {
            tb_document model = new tb_document();
            try
            {
                if (id == 0)
                {
                    string _code = "";
                    try
                    {
                        string doc_Type = Session["doc_Type"].ToString();
                        int count = _docbll.GetModelList(" doc_Type = '" + doc_Type + "'").Count + 1;
                        switch (doc_Type)
                        {
                            case "体系文件":
                                _code = "TX000" + count;
                                break;
                            case "工作手册":
                                _code = "GZ000" + count;
                                break;
                            case "安全管理":
                                _code = "AQ000" + count;
                                break;
                            case "成本管理":
                                _code = "CB000" + count;
                                break;
                        }
                    }
                    catch
                    {
                    }
                    model.doc_Code = _code;
                }
                else
                {
                    model = _docbll.GetModel(id);
                }
                ViewData["cbo_zhuangtai"] = GetcboStatus();
                return View("UpdateDoc", model);
            }
            catch (Exception)
            {
                return View("UpdateDoc");
            }
        }

        /// <summary>
        /// 更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">需要更新的模型</param>
        /// <returns></returns>
        public string UpdateDoc(tb_document model)
        {
            string flag = "0";
            try
            {
                if (model != null && model.id > 0)
                {
                    model.doc_UpdateDate = DateTime.Now;
                    model.doc_UpdateUser = CurrentUserInfo.PersonnelID;

                    #region tb_documentHistory添加历史数据
                    var documentHistory = new tb_document_History();
                    documentHistory.direct_Id = model.direct_Id;
                    documentHistory.doc_Code = model.doc_Code;
                    documentHistory.doc_CreateDate = model.doc_CreateDate;
                    documentHistory.doc_CreateUser = model.doc_CreateUser;
                    documentHistory.doc_Guid = model.doc_Guid;
                    documentHistory.doc_Id = model.id;
                    documentHistory.doc_KeyWord = model.doc_KeyWord;
                    documentHistory.doc_Name = model.doc_Name;
                    documentHistory.doc_Path = model.doc_Path;
                    documentHistory.doc_Revo = model.doc_Revo;
                    documentHistory.doc_Size = model.doc_Size;
                    documentHistory.doc_Source = model.doc_Source;
                    documentHistory.doc_Status = model.doc_Status;
                    documentHistory.doc_Type = model.doc_Type;
                    documentHistory.doc_UpdateDate = model.doc_UpdateDate;
                    documentHistory.doc_UpdateUser = model.doc_UpdateUser;
                    documentHistory.doc_URL = model.doc_URL;
                    documentHistory.isDelete = model.isDelete;
                    documentHistory.remark = model.remark;
                    documentHistory.temp1 = model.temp1;
                    documentHistory.temp2 = model.temp2;
                    tb_document_HistoryBLL _docbllhistory = new tb_document_HistoryBLL();
                    _docbllhistory.Add(documentHistory);
                    #endregion

                    if (_docbll.Update(model))
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
                if (_docbll.Delete(id))
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
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        [HttpPost]
        public string GetDocList(int pageNumber, int pageSize, string _type, string _text, int cid)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = GetWhere(_type, _text);
                string _docType = Session["doc_Type"].ToString();
                where += " and doc_Type = '" + _docType + "'";
                if (cid > 0 && CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  doc_CreateUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", cid, _userid);
                }
                else if (cid > 0 && CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and doc_CreateUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", cid);
                }
                dt.Columns.Add(new DataColumn("zz"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        int doc_CreateUser = Convert.ToInt32(dt.Rows[i]["doc_CreateUser"]);
                        dt.Rows[i]["zz"] = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(doc_CreateUser).PersonnelName;
                    }
                    catch
                    {
                        
                    }
                }
                dt = _docbll.GetListByPage(where, "doc_UpdateDate desc",  pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                total = _docbll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        public static string GetWhere(string _type, string _text)
        {
            string where = " 1=1 ";
            switch (_type)
            {
                case "文件名称":
                    where += string.Format(" and doc_Name like '%%{0}%%'", _text);
                    break;
                case "实施日期":
                    where += string.Format(" and convert(char(8), doc_CreateDate, 112) like '%%{0}%%'", _text);
                    break;
                case "更新日期":
                    where += string.Format(" and convert(char(8), doc_UpdateDate, 112) like '%%{0}%%'", _text);
                    break;
                case "作者":
                    where += string.Format(" and doc_CreateUser in (select PersonnelID from tb_InPersonnel where PersonnelName like '%%{0}%%')", _text);
                    break;
                case "关键字":
                    where += string.Format(" and doc_KeyWord like '%%{0}%%'", _text);
                    break;
            }
            return where;
        }

        /// <summary>
        /// 下载文件
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public FilePathResult GetFileFromDisk(int id)
        {
            var model = _docbll.GetModel(id);
            string iFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//" + model.doc_URL;
            var strs = model.doc_Name.Split('.');
            string oFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//DownLoads//" + strs[0] + ".zip";
            string fileName = model.doc_Name;
            PublicClass.CompressFile(iFile, oFile);
            return File(oFile, "application/octet-stream", strs[0] + ".zip");
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
                    string saveName = "";
                    saveName = "uploadfile" + strdate + ext;//实际保存文件名
                    result = saveName;
                    saveFile(FileData, "UpFile", saveName);//保存文件
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
                phyPath += saveName;
                postedFile.SaveAs(phyPath);
                string ext = Path.GetExtension(phyPath);//获得文件扩展名
                if (ext.Equals(".pdf"))
                {
                    string cmdStr = HttpContext.Server.MapPath("~/SWFTools/pdf2swf.exe");
                    string sourcePath = @"""" + phyPath + @"""";
                    string pathName = Path.GetFileName(phyPath);
                    pathName = pathName.Substring(0, pathName.Length - 4);
                    string targetPath = @"""" + Request.MapPath("../" + filepath + "/") + pathName + ".swf" + @"""";
                    string argsStr = "  -t " + sourcePath + " -s flashversion=9 -o " + targetPath;
                    PublicClass.ExecutCmdForPDF2SWF(cmdStr, argsStr);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);

            }
            return phyPath + saveName;
        }
        #endregion

        #region 文件预览
        /// <summary>
        /// 通过pageoffice展示数据
        /// 作者：章建国
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public ActionResult vpoffice(string filename,string _pname,string _ptype)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                ViewBag._pname = _pname;
                ViewBag._ptype = _ptype;
                ViewBag.Message = "Your contact page.";
                Page page = new Page();
                string controlOutput = string.Empty;
                PageOffice.PageOfficeCtrl pc = new PageOffice.PageOfficeCtrl();
                pc.SaveFilePage = "/Documents/SaveDoc?filename=" + filename;
                pc.ServerPage = "/pageoffice/server.aspx";
                var openmodeltype = PageOffice.OpenModeType.docAdmin;
                try
                {
                    var filenames = filename.Split('.');
                    switch (filenames[1])
                    {
                        case "doc":
                            openmodeltype = PageOffice.OpenModeType.docNormalEdit;
                            break;
                        case "docx":
                            openmodeltype = PageOffice.OpenModeType.docNormalEdit;
                            break;
                        case "xlsx":
                            openmodeltype = PageOffice.OpenModeType.xlsNormalEdit;
                            break;
                        case "xls":
                            openmodeltype = PageOffice.OpenModeType.xlsNormalEdit;
                            break;
                        case "pptx":
                            openmodeltype = PageOffice.OpenModeType.pptNormalEdit;
                            break;
                        case "ppt":
                            openmodeltype = PageOffice.OpenModeType.pptNormalEdit;
                            break;
                    }
                }
                catch
                {

                }
                pc.WebOpen("/UpFile/" + filename, openmodeltype, "s");
                page.Controls.Add(pc);
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb))
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        Server.Execute(page, htw, false); controlOutput = sb.ToString();
                    }
                }
                ViewBag.EditorHtml = controlOutput;
            }
            return View();
        }

        /// <summary>
        /// 通过FlexPaper展示PDF
        /// 作者：章建国
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public ActionResult SWFShow(string filename)
        {
            //filename = AppDomain.CurrentDomain.BaseDirectory + "UpFile//" + filename;
            ViewBag._SWFURL = filename;

            return View();
        }

        /// <summary>
        /// 保存在线修改的office文件
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveDoc(string filename)
        {
            ViewBag.Message = "Your app description page.";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "UpFile//" + filename;
            PageOffice.FileSaver fs = new PageOffice.FileSaver();
            fs.SaveToFile(filePath);
            fs.Close();
            return View();
        }
        #endregion

        #region 页面下拉框
        /// <summary>
        /// 是否有效下拉框数据
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        private SelectList GetcboStatus()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "有效", Value = "1", Selected = true });
            list.Add(new SelectListItem() { Text = "作废", Value = "0" });
            return new SelectList(list, "Value", "Text");
        }
        #endregion

        #region 文件权限
        /// <summary>
        /// 获取未加入权限的用户和用户组
        /// 作者：章建国
        /// </summary>
        /// <param name="_fid">文件ID</param>
        /// <returns></returns>
        public JsonResult GetUNSelectList(string _fid)
        {
            int _userid = CurrentUserInfo.PersonnelID;
            DataTable dt = _limitbll.GetUNSelectList(_fid, _userid);
            var list = from d in dt.AsEnumerable()
                       select new
                           {
                               Id = d["id"],
                               Pid = d["areaid"],
                               Text = d["userORgroup"]
                           };
            return Json(list.ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取已加入权限的用户和用户组
        /// 作者：章建国
        /// </summary>
        /// <param name="_fid">文件ID</param>
        /// <returns></returns>
        public JsonResult GetSelectedList(string _fid)
        {
            var limitlist = new tb_LimitBLL().GetModelList(" fileId = " + _fid);
            if (limitlist != null && limitlist.Count > 0)
            {
                BLL.PersonnelManage.T_tb_InPersonnel inpersonnelDAL = new BLL.PersonnelManage.T_tb_InPersonnel();
                BLL.Laboratory.T_tb_Laboratory laboratoryDAL = new BLL.Laboratory.T_tb_Laboratory();
                for (int i = 0; i < limitlist.Count; i++)
                {
                    if (limitlist[i].limitType.Equals("用户"))
                    {
                        limitlist[i].limitType = inpersonnelDAL.GetModel(Convert.ToInt32(limitlist[i].limitId)).PersonnelName;
                    }
                    else if (limitlist[i].limitType.Equals("用户组"))
                    {
                        limitlist[i].limitType = laboratoryDAL.GetModel(Convert.ToInt32(limitlist[i].limitId)).LaboratoryName;
                    }
                    continue;
                }
            }
            return Json(limitlist, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 给文件加入新的权限
        /// 作者：章建国
        /// </summary>
        /// <param name="_fileid">文件ID</param>
        /// <param name="_limitid">用户或者用户组ID</param>
        /// <param name="_limittype">类型（用户或用户组）</param>
        /// <returns></returns>
        public JsonResult addLimitToFile(string _fileid, string _limitid, string _limittype)
        {
            string flag = "false";
            if (!string.IsNullOrEmpty(_fileid) && !string.IsNullOrEmpty(_limitid) && !string.IsNullOrEmpty(_limittype))
            {
                try
                {
                    _limittype = _limittype.Equals("0") ? "用户" : _limittype.Equals("00") ? "用户组" : "";
                    tb_Limit limitmodel = new tb_Limit() { fileId = Convert.ToInt32(_fileid), limitDelete = false, limitRead = false, limitWrite = false, limitId = Convert.ToInt32(_limitid), limitType = _limittype };
                    if (new tb_LimitBLL().Add(limitmodel) > 0)
                    {
                        flag = "true";
                    }
                }
                catch { }
            }
            return Json(flag, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 给权限加入
        /// </summary>
        /// <param name="_limitid"></param>
        /// <param name="_limittype"></param>
        /// <param name="_isCheck"></param>
        /// <returns></returns>
        public JsonResult updateLimitToFile(string _limitid, string _limittype, bool _isCheck)
        {
            string _message = "修改权限失败！";
            try
            {
                if (!string.IsNullOrEmpty(_limitid) && !string.IsNullOrEmpty(_limittype))
                {
                    tb_LimitBLL limitbll = new tb_LimitBLL();
                    tb_Limit limitmodel = limitbll.GetModel(Convert.ToInt32(_limitid));
                    switch (_limittype)
                    {
                        case "read":
                            limitmodel.limitRead = _isCheck;
                            break;
                        case "write":
                            limitmodel.limitWrite = _isCheck;
                            break;
                        case "delete":
                            limitmodel.limitDelete = _isCheck;
                            break;
                    }
                    if (limitbll.Update(limitmodel))
                    {
                        _message = "修改权限成功！";
                    }
                }
            }
            catch { }
            return Json(_message, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除用户（用户组）对文件的使用权限
        /// </summary>
        /// <param name="_limitid">文件权限表主键ID</param>
        /// <returns></returns>
        public JsonResult deleteLimitToFile(string _limitid)
        {
            string _message = "删除权限失败！";
            try
            {
                if (!string.IsNullOrEmpty(_limitid))
                {
                    tb_LimitBLL limitbll = new tb_LimitBLL();
                    if (limitbll.Delete(Convert.ToInt32(_limitid)))
                    {
                        _message = "成功删除权限！";
                    }
                }
            }
            catch { }
            return Json(_message, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根本登陆用户ID和文件ID查找权限
        /// 作者：章建国
        /// </summary>
        /// <param name="_fileid"></param>
        /// <returns></returns>
        public JsonResult GetLimitByUserIDandFileID(string _fileid)
        {
            try
            {
                tb_Limit _limit = null;
                E_tb_InPersonnel _inpersonnel = Session["UserInfo"] as Model.PersonnelManage.E_tb_InPersonnel;
                
                tb_LimitBLL _limitBLL = new tb_LimitBLL();
                string where = string.Format(" limitId = {0} and fileId = {1} and limitType = '用户'", _inpersonnel.PersonnelID, _fileid);
                var limitList = _limitbll.GetModelList(where);
                if (limitList != null && limitList.Count > 0)
                {
                    _limit = limitList[0];
                }
                else
                {
                    where = string.Format(" limitId = {0} and fileId = {1} and limitType = '用户组'", _inpersonnel.AreaID, _fileid);
                    limitList = _limitbll.GetModelList(where);
                    if (limitList != null && limitList.Count > 0)
                    {
                        _limit = limitList[0];
                    }
                }
                return Json(_limit, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion 文件权限
    }
}
