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

namespace Web.Controllers
{
    public class DocumentHistoryController : BaseController
    {
        #region
        private tb_document_HistoryBLL _dochistorybll = new tb_document_HistoryBLL();
        #endregion

        public ActionResult Index(int id, string doctype)
        {
            ViewData["cbo_zhuangtai"] = GetcboStatus();
            ViewBag.docId = id;
            ViewBag.docType = doctype;
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
                int count = _dochistorybll.GetModelList(" doc_Type = '" + doc_Type + "'").Count + 1;
                _code = "WD000" + count;
            }
            catch
            {
            }
            return Json(_code, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新建数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        [HttpPost]
        public string NewDoc(tb_document_History model)
        {
            string flag = "0";
            try
            {
                model.doc_CreateDate = DateTime.Now;
                model.doc_CreateUser = CurrentUserInfo.PersonnelID;
                model.doc_UpdateDate = DateTime.Now;
                model.doc_UpdateUser = CurrentUserInfo.PersonnelID;
                model.doc_Size = (Convert.ToInt32(model.doc_Size) / 1000).ToString();
                model.doc_Type = "体系文件";
                if (_dochistorybll.Add(model) > 0)
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
                var model = _dochistorybll.GetModel(id);
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
        public string UpdateDoc(tb_document_History model)
        {
            string flag = "0";
            try
            {
                if (model != null && model.id > 0)
                {
                    #region tb_document_HistoryHistory添加历史数据
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

                    model.doc_UpdateDate = DateTime.Now;
                    model.doc_UpdateUser = CurrentUserInfo.PersonnelID;
                    if (_dochistorybll.Update(model))
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
                if (_dochistorybll.Delete(id))
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
        public string GetDocList(int pageNumber, int id, string doctype)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                switch (doctype)
                {
                    case "wdgl":
                        doctype = "文档管理";
                        break;
                    case "txwj":
                        doctype = "体系文件";
                        break;
                }
                string where = " doc_Type = '" + doctype + "' and doc_Id=" + id;
                dt = _dochistorybll.GetListByPage(where, "doc_UpdateDate desc", pageNumber * 8 - 7, pageNumber * 8).Tables[0];
                total = dt.Rows.Count;
                total = _dochistorybll.GetModelList(where).Count;
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
            var model = _dochistorybll.GetModel(id);
            string iFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//" + model.doc_URL;
            var strs = model.doc_Name.Split('.');
            string oFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//DownLoads//" + strs[0] + ".zip";
            string fileName = model.doc_Name;
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
                    saveFile(FileData, folder, saveName);//保存文件

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
            string phyPath = Request.MapPath("~" + filepath + "/");
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
        #endregion

    }
}
