using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Web.Models;

namespace Web.Controllers
{
    public class DocManagerWithDirController : BaseController
    {
        #region
        private tb_documentBLL _docbll = new tb_documentBLL();
        private tb_DirectoryBLL _dirbll = new tb_DirectoryBLL();
        #endregion
        //
        // GET: /DocManagerWithDir/

        public ActionResult Index()
        {
            ViewData["cbo_zhuangtai"] = GetcboStatus();
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
            ViewBag.RoleId = CurrentUserInfo.RoleID;
            return View();
        }

        #region 文件夹目录（列表、新增、编辑、删除）
        public ActionResult doDirInfo(int id, int pid)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in _dirbll.GetModelList(""))
            {
                list.Add(new SelectListItem() { Text = item.dir_Name, Value = item.id.ToString() });
            }
            ViewData["ddldir"] = new SelectList(list, "Value", "Text");
            tb_Directory model = new tb_Directory();
            if (pid > 0)
            {
                model.dir_ParentId = pid;
            }
            else
            {
                if (id > 0)
                {
                    model = _dirbll.GetModel(id);
                }
            }

            return View(model);
        }

        public JsonResult GetDirList()
        {
            List<TreeModel> list = new List<TreeModel>();
            var listdir = _dirbll.GetModelList(" isDelete = 0");
            string[] strjson = new string[listdir.Count];
            foreach (var item in listdir)
            {
                list.Add(new TreeModel() { Id = item.id, Pid = item.dir_ParentId.Value, Text = item.dir_Name, dirValue = item.dir_Value1 });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public string doDirCU(tb_Directory model)
        {
            string flag = "0";
            try
            {
                if (model.id > 0)
                {
                    model.updateDate = DateTime.Now;
                    model.updateUser = CurrentUserInfo.PersonnelID;
                    if (model.id == 1)
                    {
                        model.dir_ParentId = 0;
                        if (_dirbll.Update(model))
                        {
                            flag = "1";
                        }
                    }
                    else
                    {
                        var tempmodel = _dirbll.GetModel(model.dir_ParentId.Value);
                        model.dir_Value1 = tempmodel.dir_Value1 + string.Format("{0:D3}", _dirbll.GetModelListForNodesCount(model.dir_ParentId.Value) + 1) + ",";
                        if (_dirbll.Update(model))
                        {
                            flag = "1";
                        }
                    }
                }
                else
                {
                    model.createDate = DateTime.Now;
                    model.createUser = CurrentUserInfo.PersonnelID;
                    model.isDelete = false;
                    model.updateDate = DateTime.Now;
                    model.updateUser = CurrentUserInfo.PersonnelID;
                    var tempmodel = _dirbll.GetModel(model.dir_ParentId.Value);
                    model.dir_Value1 = tempmodel.dir_Value1 + string.Format("{0:D3}", _dirbll.GetModelListForNodesCount(model.dir_ParentId.Value) + 1) + ",";
                    if (_dirbll.Add(model) > 0)
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

        public string NewTreeNode()
        {
            string flag = "0";
            try
            {
                string txtDirName = Request.Form["txtDirName"];
                string ddldir = Request.Form["ddldir"];
                tb_Directory directory = new tb_Directory();
                directory.dir_Name = txtDirName;
                directory.dir_ParentId = Convert.ToInt32(ddldir);
                directory.createDate = DateTime.Now;
                directory.createUser = CurrentUserInfo.PersonnelID;
                directory.isDelete = false;
                directory.updateDate = DateTime.Now;
                directory.updateUser = CurrentUserInfo.PersonnelID;
                var tempmodel = _dirbll.GetModel(directory.dir_ParentId.Value);
                directory.dir_Value1 = tempmodel.dir_Value1 + string.Format("{0:D3}", _dirbll.GetModelListForNodesCount(directory.dir_ParentId.Value) + 1) + ",";
                if (_dirbll.Add(directory) > 0)
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

        public string EditTreeNode(int id, string txtDirName, int pid)
        {
            string flag = "0";
            try
            {
                var dirmodel = _dirbll.GetModel(id);
                dirmodel.dir_Name = txtDirName;
                dirmodel.dir_ParentId = pid;
                dirmodel.updateDate = DateTime.Now;
                dirmodel.updateUser = CurrentUserInfo.PersonnelID;
                var tempmodel = _dirbll.GetModel(dirmodel.dir_ParentId.Value);
                dirmodel.dir_Value1 = tempmodel.dir_Value1 + string.Format("{0:D3}", _dirbll.GetModelListForNodesCount(dirmodel.dir_ParentId.Value) + 1) + ",";
                if (_dirbll.Update(dirmodel))
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

        public string DeleteTreeNode(int id)
        {
            string flag = "0";
            try
            {
                if (_dirbll.Delete(id))
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
        #endregion

        #region 文件新增、下载、删除、编辑、列表

        public ActionResult doDocInfo(int id, int pid, string ptext)
        {
            ViewData["cbo_zhuangtai"] = GetcboStatus();
            tb_document model = new tb_document();
            if (id > 0)
            {
                model = _docbll.GetModel(id);
            }
            int count = _docbll.GetModelList(" doc_Type = '文档管理'").Count + 1;
            string _code = "WD000" + count;
            model.direct_Id = pid;
            ViewBag.ptext = ptext;
            ViewBag._code = _code;
            return View(model);
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
                model.doc_Type = "文档管理";
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
            try
            {
                var model = _docbll.GetModel(id);
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
        public string GetDocList(int id, int pageNumber, int pageSize, string _search, string _searchtype, int _cid)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = DocumentsController.GetWhere(_searchtype, _search);
                where += " and doc_Type = '文档管理'";
                if (_cid > 0 && CurrentUserInfo.DataRange == 3)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and  doc_createUser = (select PersonnelID from tb_InPersonnel where AreaID = {0} and PersonnelID = {1}) ", _cid, _userid);
                }
                else if (_cid > 0 && CurrentUserInfo.DataRange == 2)
                {
                    int _userid = CurrentUserInfo.PersonnelID;
                    where += string.Format(" and doc_createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0}) ", _cid);
                }
                if (id == 1)
                {
                    dt = _docbll.GetListByPage(where, "doc_UpdateDate desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                }
                else
                {
                    where += " and direct_Id=" + id;
                    dt = _docbll.GetListByPage(where, "doc_UpdateDate desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                    
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
                total = dt.Rows.Count;
                total = _docbll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
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
            CompressFile(iFile, oFile);
            return File(oFile, "application/octet-stream", strs[0] + ".zip");
        }

        /// <summary>
        /// 压缩文件
        /// 作者：章建国
        /// </summary>
        /// <param name="iFile">需要压缩的文件路径（包含文件名和扩展名）</param>
        /// <param name="oFile">压缩文件保存路径</param>
        /// <returns></returns>
        private bool CompressFile(string iFile, string oFile)
        {
            bool flag = false;
            try
            {
                using (var zip = new Ionic.Zip.ZipFile())
                {
                    zip.AddFile(iFile, string.Empty);
                    zip.Save(oFile);
                }
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
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
        public ActionResult vpoffice(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
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

        /// <summary>
        /// 父级文件夹目录
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDropDownListDir()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in _dirbll.GetModelList(""))
            {
                list.Add(new SelectListItem() { Text = item.dir_Name, Value = item.id.ToString() });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
