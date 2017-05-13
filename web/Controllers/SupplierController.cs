using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using System.Data;
using System.IO;
using System.Collections;

namespace Web.Controllers
{
    public class SupplierController : BaseController
    {
        tb_SupplierBLL _supplierbll = new tb_SupplierBLL();
        tb_attachmentBLL _attachmentbll = new tb_attachmentBLL();
        //
        // GET: /Supplier/

        public ActionResult Index()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择");
            ViewBag._lid = CurrentUserInfo.AreaID;
            return View();
        }

        #region 供应商管理（新增、修改、删除、列表）
        public ActionResult doSupplierInfo(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var model = _supplierbll.GetModel(id);
            return View(model);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：章建国
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetSupplierList(int pageNumber, int pageSize, string _searchtext, string _searchtype, int _cid)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                string where = " 1=1 ";
                switch (_searchtype)
                {
                    case "名称":
                        where += string.Format(" and name like '%%{0}%%' ", _searchtext);
                        break;
                    case "地址":
                        where += string.Format(" and address like '%%{0}%%' ", _searchtext);
                        break;
                    case "联系人":
                        where += string.Format(" and linkMan like '%%{0}%%' ", _searchtext);
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
                dt = _supplierbll.GetListByPage(where, "temp1", pageNumber * 8 - 7, pageNumber * 8).Tables[0];
                total = dt.Rows.Count;
                total = _supplierbll.GetModelList(where).Count;
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        /// <summary>
        /// 新建数据、更新数据
        /// 作者：章建国
        /// </summary>
        /// <param name="model">新输入的数据</param>
        /// <returns></returns>
        public string doSupplierCU(tb_Supplier model)
        {
            string flag = "0";
            try
            {
                /**********************************/
                model.Jkz.type1 = "供应商管理"; model.Jkz.type2 = "健康证";
                //model.Jybg.type1 = "供应商管理"; model.Jybg.type2 = "检疫报告";
                //model.Jyz.type1 = "供应商管理"; model.Jyz.type2 = "检疫证";
                //model.Clws.type1 = "供应商管理"; model.Clws.type2 = "车辆卫生";
                //model.Xdzm.type1 = "供应商管理"; model.Xdzm.type2 = "消毒证明";

                List<tb_attachment> listattachment = new List<tb_attachment>();
                listattachment.Add(model.Jkz);
                //listattachment.Add(model.Jybg);
                //listattachment.Add(model.Jyz); listattachment.Add(model.Clws);
                //listattachment.Add(model.Xdzm);
                /*********************************/
                model.updateDate = DateTime.Now;
                model.updateUser = CurrentUserInfo.PersonnelID;
                int tid = 0;
                if (model.id > 0)
                {
                    tid = model.id;
                    if (_supplierbll.Update(model))
                    {
                        flag = "1";
                    }
                }
                else
                {
                    model.createDate = DateTime.Now;
                    model.createUser = CurrentUserInfo.PersonnelID;
                    if (_supplierbll.Add(model) > 0)
                    {
                        string where = string.Format(" name = '{0}' and address = '{1}'", model.name, model.address);
                        tid = _supplierbll.GetModelList(where).First().id;
                        flag = "1";
                    }
                }
                doattachment(tid, listattachment);
            }
            catch
            {
                flag = "0";
            }
            return flag;
        }

        private void doattachment(int id, List<tb_attachment> listattachment)
        {
            foreach (var item in listattachment)
            {
                try
                {
                    var strfilename = item.fileName.Split(',');
                    var strfilePath = item.filePath.Split(',');
                    var strfileSize = item.fileSize.Split(',');
                    if (strfilename.Count() >= 1 && strfilePath.Count() >= 1 && strfileSize.Count() >= 1)
                    {
                        _attachmentbll.Delete(item.type1, item.type2, id);
                        for (int i = 0; i < strfilename.Count(); i++)
                        {
                            if (!string.IsNullOrEmpty(strfilename[i]) && !string.IsNullOrEmpty(strfilename[i]))
                            {
                                tb_attachment model = new tb_attachment();
                                model.fileName = strfilename[i];
                                model.filePath = strfilePath[i];
                                model.fileSize = strfileSize[i];
                                model.type1 = item.type1;
                                model.type2 = item.type2;
                                model.tId = id;
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
                    continue;
                }
            }
        }

        /// <summary>
        /// 删除数据
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public JsonResult Delete_SupplierItem(int id)
        {
            string str = "删除失败！";
            try
            {
                if (_supplierbll.Delete(id))
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
        /// 下载文件
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public ActionResult GetFileFromDisk(string _fileName)
        {
            string oFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//DownLoads//" + _fileName + ".zip";
            return File(oFile, "application/octet-stream", _fileName + ".zip");
        }

        /// <summary>
        /// 验证文件是否存在
        /// 作者：章建国
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult isExists(int id, string _type)
        {
            switch (_type)
            {
                case "jkz":
                    _type = "健康证";
                    break;
                case "clws":
                    _type = "车辆卫生";
                    break;
                case "jyz":
                    _type = "检疫证";
                    break;
                case "xdzm":
                    _type = "消毒证明";
                    break;
                case "jybg":
                    _type = "检验报告";
                    break;
            }
            ArrayList al = new ArrayList();
            al.Add("false");
            try
            {
                string where = string.Format(" tId={0} and type2='{1}' and type1='供应商管理'", id, _type);
                var listmodel = _attachmentbll.GetModelList(where);
                string[] iFiles = new string[listmodel.Count];
                for (int i = 0; i < listmodel.Count; i++)
                {
                    string iFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//" + listmodel[i].filePath;
                    iFiles[i] = iFile;
                }

                //var strs = model.fileName.Split('.');
                string filename = DateTime.Now.ToFileTime().ToString();
                string oFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//DownLoads//" + filename + ".zip";
                //string fileName = model.fileName;
                //if (System.IO.File.Exists(iFile))    // 注意双引号路径应为双斜杠
                //{
                al[0] = "true";
                if (System.IO.File.Exists(oFile))    // 注意双引号路径应为双斜杠
                {
                    System.IO.File.Delete(oFile);
                }
                PublicClass.CompressFile(iFiles, oFile);
                al.Add(oFile);
                al.Add(filename);
                //}
            }
            catch
            {

            }
            return Json(al, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Sanitation(int _supplierId)
        {
            ViewBag._supplierId = _supplierId;
            return View();
        }

        public string GetSanitationList(int pageNumber, int pageSize, string _searchtext, string _searchtype, int _supplierId)
        {
            DataTable dt = new DataTable();
            int total = 0;
            try
            {
                if (_supplierId > 0 && !string.IsNullOrEmpty(_searchtype))
                {
                    string where = " type1='供应商管理' and type2 = '" + _searchtype + "' and tId = " + _supplierId;
                    if (!string.IsNullOrEmpty(_searchtext))
                    {
                        var strs = _searchtext.Split(',');
                        where += string.Format(" and createDate BETWEEN '{0}' and '{1}'", strs[0], strs[1]);
                    }
                    dt = _attachmentbll.GetListByPage(where, "updateDate", pageNumber * 8 - 7, pageNumber * 8).Tables[0];
                    total = dt.Rows.Count;
                    total = _attachmentbll.GetModelList(where).Count;
                }
            }
            catch { }
            return PublicClass.ToJson(dt, total);
        }

        public ActionResult doSanitationInfo(int _supplierId, int id)
        {
            tb_attachment model = new tb_attachment();
            ViewBag._supplierId = _supplierId;
            if (_supplierId > 0)
            {
                model = _attachmentbll.GetModel(id);
            }
            return View(model);
        }

        public string SaveSanitationInfo(tb_attachment _attachment)
        {
            _attachment.type1 = "供应商管理";
            _attachment.updateDate = DateTime.Now;
            _attachment.updateUser = CurrentUserInfo.PersonnelID;
            string flag = "0";
            if (_attachment.id > 0)
            {
                if (_attachmentbll.Update(_attachment))
                {
                    flag = "1";
                }
            }
            else
            {
                _attachment.createUser = CurrentUserInfo.PersonnelID;
                if (_attachmentbll.Add(_attachment) > 0)
                {
                    flag = "1";
                }
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
                postedFile.SaveAs(phyPath + saveName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);

            }
            return phyPath + saveName;
        }
        #endregion
    }
}
