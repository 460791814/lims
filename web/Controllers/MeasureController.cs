using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace Web.Controllers
{
    public class MeasureController : BaseController
    {
        tb_MeasureBLL _measurebll = new tb_MeasureBLL();
        tb_DeviceBLL _devicebll = new tb_DeviceBLL();
        //
        // GET: /Measure/

        public ActionResult Index()
        {
            return View();
        }

        #region 计量检定
        public ActionResult MeasureCheck()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            return View();
        }

        public string GetMeasureList(int pageNumber, int pageSize, string _search, string _searchtype, string _measureType)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = "";
                if (!string.IsNullOrEmpty(_measureType))
                {
                    if (_measureType.Equals("全部"))
                    {
                        where += " 1 = 1 ";
                    }
                    else
                    {
                        where += string.Format(" measureType = '{0}' ", _measureType);
                    }
                }
                if (!string.IsNullOrEmpty(_search))
                {
                    where += string.Format(" and deviceName like '%%{0}%%' ", _search);
                }
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

                dt = _measurebll.GetListByPage(where, "updateDate", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize).Tables[0];
                total = dt.Rows.Count;
                total = _measurebll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        public ActionResult doMeasureCheckInfo(int id)
        {
            tb_Measure model = new tb_Measure();
            if (id > 0)
            {
                model = _measurebll.GetModel(id);
            }
            return View(model);
        }

        /// <summary>
        /// 新增或编辑
        /// 作者：章建国
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string doMeasureInfoCU(tb_Measure model)
        {
            string flag = "0";
            try
            {
                model.updateDate = DateTime.Now;
                model.updateUser = CurrentUserInfo.PersonnelID;
                if (model.id > 0)
                {
                    if (_measurebll.Update(model))
                    {
                        flag = "1";
                    }
                }
                else
                {
                    model.createDate = DateTime.Now;
                    model.createUser = CurrentUserInfo.PersonnelID;
                    model.measureType = "计量";
                    if (_measurebll.Add(model) > 0)
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

        public JsonResult GetDeviceListForDropDownList(string q)
        {
            var list = _devicebll.GetModelList(" name like '%%" + q + "%%' or eCode like '%%" + q + "%%'");
            return Json(list, JsonRequestBehavior.AllowGet);
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

        public ActionResult MeasureCertificate(int id)
        {
            tb_Measure model = new tb_Measure();
            if (id > 0)
            {
                model = _measurebll.GetModel(id);
            }
            return View(model);
        }

        public JsonResult Delete_certification(int id)
        {
            tb_attachmentBLL _attachmentbll = new tb_attachmentBLL();
            string str = "删除失败！";
            try
            {
                if (_attachmentbll.Delete(id))
                {
                    str = "删除成功！";
                }
            }
            catch
            {

            }
            return Json(str, JsonRequestBehavior.AllowGet);

        }

        public string GetMeasureCertificateList(int _measureId)
        {
            DataTable dt = new DataTable();
            if (_measureId > 0)
            {
                try
                {
                    tb_attachmentBLL _attachmentbll = new tb_attachmentBLL();
                    dt = _attachmentbll.GetList(" type1='计量管理' and type2='计量' and tId = " + _measureId).Tables[0];
                }
                catch
                {
                }
            }
            return PublicClass.ToJson(dt,dt.Rows.Count);
        }

        public JsonResult doattachment(int _tid, string _urls, string _names, string _size)
        {
            string flag = "0";
            try
            {
                var strfilename = _names.Split(',');
                var strfilePath = _urls.Split(',');
                var strfileSize = _size.Split(',');
                if (strfilename.Count() >= 1 && strfilePath.Count() >= 1 && strfileSize.Count() >= 1)
                {
                    tb_attachmentBLL _attachmentbll = new tb_attachmentBLL();
                    for (int i = 0; i < strfilename.Count(); i++)
                    {
                        if (!string.IsNullOrEmpty(strfilename[i]) && !string.IsNullOrEmpty(strfilename[i]))
                        {
                            tb_attachment model = new tb_attachment();
                            model.fileName = strfilename[i];
                            model.filePath = strfilePath[i];
                            model.fileSize = strfileSize[i];
                            model.type1 = "计量管理";
                            model.type2 = "计量";
                            model.tId = _tid;
                            model.createDate = DateTime.Now;
                            model.createUser = CurrentUserInfo.PersonnelID;
                            model.updateDate = DateTime.Now;
                            model.updateUser = CurrentUserInfo.PersonnelID;
                            _attachmentbll.Add(model);
                        }
                    }
                }

            }
            catch
            {
                flag = "0";
            }
            return Json(flag, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 下载文件
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public FilePathResult GetFileFromDisk(int id)
        {
            tb_attachmentBLL _attachmentbll = new tb_attachmentBLL();
            var model = _attachmentbll.GetModel(id);
            string iFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//" + model.filePath;
            var strs = model.fileName.Split('.');
            string oFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//DownLoads//" + strs[0] + ".zip";
            string fileName = model.fileName;
            PublicClass.CompressFile(iFile, oFile);
            return File(oFile, "application/octet-stream", strs[0] + ".zip");
        }
        #region 上传文件
        [AcceptVerbs(HttpVerbs.Post)]
        public string Import(HttpPostedFileBase FileData, string folder)
        {
            string result = "false";
            if (null != FileData)
            {
                try
                {
                    result = System.IO.Path.GetFileName(FileData.FileName);//获得文件名
                    string ext = System.IO.Path.GetExtension(FileData.FileName);//获得文件扩展名
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
            if (!System.IO.Directory.Exists(phyPath))
            {
                System.IO.Directory.CreateDirectory(phyPath);
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
        #endregion

    }
}
