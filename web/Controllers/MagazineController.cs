using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.News;
using System.Data;
using Common;
using Model.News;
using System.Text;
using Common.PDFViewer;
using System.Configuration;



namespace Web.Controllers
{
    public class MagazineController : BaseController
    {
        T_tb_ElectronicsMagazine tElectronicsMagazine = new T_tb_ElectronicsMagazine(); //电子杂志管理
        //
        // GET: /Laboratory/

        public ActionResult MagazineList()
        {
            ViewData["MagazineTypeList"] = GetNewsTypeList(true);
            return View();
        }

        /// <summary>
        /// 前台显示的电子杂志列表页面
        /// </summary>
        /// <param name="NewTypeID">公告类型</param>
        /// <returns></returns>
        public ActionResult MagazineShowList(int? PageIndex)
        {
            E_tb_ElectronicsMagazine eElectronicsMagazine = new E_tb_ElectronicsMagazine();
            StringBuilder PageHtml = new StringBuilder();

            if (PageIndex == null || PageIndex == 0)
            {
                PageIndex = 1;
            }

            int pageSize = 12; //每页数据条数
            int total = 0; //总数据条数
            int pageNumber = Convert.ToInt32(PageIndex); //当前页数
            int pageCount; //总页数

            DataTable dt=new DataTable();
            dt = tElectronicsMagazine.GetListByPage("", "AddTime Desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
            pageCount = total / pageSize + (total % pageSize > 0 ? 1 : 0);

            //首页
            if (pageNumber == 1)
            {
                PageHtml.Append("<a disabled=\"disabled\">首页</a>");
            }
            else
            {
                PageHtml.Append("<a href=\"/Magazine/MagazineShowList?PageIndex=1\">首页</a>");
            }

            //上一页
            if (pageNumber == 1)
            {
                PageHtml.Append("<a disabled=\"disabled\">上一页</a>");
            }
            else
            {
                PageHtml.Append("<a href=\"/Magazine/MagazineShowList?PageIndex="+(pageNumber-1)+"\">上一页</a>");
            }

            //下一页
            if (pageNumber == pageCount)
            {
                PageHtml.Append("<a disabled=\"disabled\">下一页</a>");
            }
            else
            {
                PageHtml.Append("<a href=\"/Magazine/MagazineShowList?PageIndex=" + (pageNumber + 1) + "\">下一页</a>");
            }

            //末页
            if (pageNumber == pageCount)
            {
                PageHtml.Append("<a disabled=\"disabled\">末页</a>");
            }
            else
            {
                PageHtml.Append("<a href=\"/Magazine/MagazineShowList?PageIndex=" + pageCount + "\">末页</a>");
            }

            ViewData["MagazineDt"] = dt;
            eElectronicsMagazine.PageHtml = PageHtml.ToString();
            return View(eElectronicsMagazine);
        }

        /// <summary>
        /// 电子杂志显示
        /// </summary>
        /// <param name="FilePath">显示文件地址</param>
        /// <returns></returns>
        public ActionResult MagazineView(string FilePath)
        {
            ViewData["fileURL"] = "fileURL='/FlexPaper/sorry.swf';";
            string fileName = FilePath;//传入的文件名-doc pdf等
            string sPath = "/UpFile/"; //间接路径-/UPloadFiles/2012-1/1/
            fileName = FilePath;
            sPath = sPath.Substring(0, sPath.LastIndexOf("/") + 1);
            if (IsSpecifiedFileExtension(fileName))
            {
                if (Transfer(fileName, sPath))
                {
                    ViewData["fileURL"] = "fileURL='/" + ConfigurationManager.AppSettings["targetDir"] + "/" + fileName.Substring(0, fileName.LastIndexOf(".")) + ".swf';";
                }
            }
            return View();
        }

        /// <summary>
        /// 文件预览支持的格式
        /// </summary>
        private static string[] fileExstensionArr = new string[] { "doc", "docx", "xls", "xlsx", "ppt", "pptx", "pdf" };

        /// <summary>
        /// 是否是指定的文件预览格式
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>true or false</returns>
        private bool IsSpecifiedFileExtension(string fileName)
        {
            bool isExist = false;
            foreach (string specifiedExt in fileExstensionArr)
            {
                if (fileName.ToLower().IndexOf("." + specifiedExt) > -1)
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }

        

        /// <summary>
        /// 文件分类转换//传入需要修改的文件名即可转化为swf
        /// </summary>
        /// <param name="FileURL"></param>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public bool Transfer(string FileURL, string sPath)
        {
            bool result = false;
            string filePath = Server.MapPath("~/"+sPath);
            string tempPath =Server.MapPath("~/"+ConfigurationManager.AppSettings["sourceDir"] + "/");
            string savePath =Server.MapPath("~/"+ConfigurationManager.AppSettings["targetDir"] + "/");
            

            //文件名
            string fileName = FileURL;
            //文件名(不带扩展名)
            string fileNameOnly = fileName.Substring(0, fileName.LastIndexOf("."));
            //扩展名
            string fileExtention = fileName.Substring(fileName.LastIndexOf(".")).ToLower().Trim();

            if (System.IO.File.Exists(savePath + fileNameOnly + ".swf"))
                    return true;

            if (!System.IO.File.Exists(filePath + fileName))//源文件不存在
            {
                return false;
            }

            IConvertToSWF conertToSWF = null;

            try
            {
                if (!System.IO.Directory.Exists(savePath))
                {
                    System.IO.Directory.CreateDirectory(savePath);
                }

                if (!System.IO.Directory.Exists(tempPath))
                {
                    System.IO.Directory.CreateDirectory(tempPath);
                    System.IO.DirectoryInfo DirInfo = new System.IO.DirectoryInfo(tempPath);
                    DirInfo.Attributes = System.IO.FileAttributes.Archive;
                }

                Loger.logger("filePath=" + filePath);
                Loger.logger("tempPath=" + tempPath);
                Loger.logger("savePath=" + savePath);
                Loger.logger("fileName=" + fileName);

                //复制源文件到临时文件夹
                if (!System.IO.File.Exists(tempPath + fileName))
                {
                    System.IO.File.Copy(filePath + fileName, tempPath + fileName, true);
                    Loger.logger("复制源文件到临时文件成功");
                }

                Loger.logger("文件夹属性：" + System.IO.File.GetAttributes(tempPath).ToString() + "文件属性：" + System.IO.File.GetAttributes(tempPath + fileName).ToString());
                if (System.IO.File.GetAttributes(tempPath + fileName) != System.IO.FileAttributes.Archive)
                {
                    System.IO.File.SetAttributes(tempPath + fileName, System.IO.FileAttributes.Archive);
                }

                conertToSWF = ConvertToSwfByAspno.GetInstance();

                if (!System.IO.File.Exists(savePath + fileNameOnly + ".swf"))
                {
                    switch (fileExtention)
                    {
                        case ".pdf":
                            {
                                result = conertToSWF.PDF2SWF(tempPath + fileName, savePath + fileNameOnly + ".swf");
                                LogByResult(result, fileName, "pdf-swf");
                                break;
                            }
                        case ".doc":
                        case ".docx":
                            {
                                result = conertToSWF.DOC2PDF(tempPath + fileName, savePath + fileNameOnly + ".pdf");
                                LogByResult(result, fileName, "word-pdf");
                                if (result)
                                {
                                    result = conertToSWF.PDF2SWF(savePath + fileNameOnly + ".pdf", savePath + fileNameOnly + ".swf");
                                    LogByResult(result, fileName, "word-pdf-swf");
                                }

                                break;
                            }
                        case ".ppt":
                        case ".pptx":
                            {
                                result = conertToSWF.PPT2PDF(tempPath + fileName, savePath + fileNameOnly + ".pdf");
                                LogByResult(result, fileName, "ppt-pdf");
                                if (result)
                                {
                                    result = conertToSWF.PDF2SWF(savePath + fileNameOnly + ".pdf", savePath + fileNameOnly + ".swf");
                                    LogByResult(result, fileName, "ppt-pdf-swf");
                                }
                                break;
                            }
                        case ".xlsx":
                        case ".xls":
                            {
                                result = conertToSWF.XLS2PDF(tempPath + fileName, savePath + fileNameOnly + ".pdf");
                                LogByResult(result, fileName, "xls-pdf");
                                if (result)
                                {
                                    result = conertToSWF.PDF2SWF(savePath + fileNameOnly + ".pdf", savePath + fileNameOnly + ".swf");
                                    LogByResult(result, fileName, "xls-pdf-swf");
                                }

                                break;
                            }
                    }

                    if (System.IO.File.Exists(savePath + fileNameOnly + ".pdf"))
                    {
                        System.IO.File.Delete(savePath + fileNameOnly + ".pdf");
                    }
                }

                //删除临时文件夹的文件
                if (System.IO.File.Exists(tempPath + fileName))
                {
                    System.IO.File.Delete(tempPath + fileName);
                    Loger.logger("删除临时文件成功\r\n");
                }
            }
            catch (Exception ex)
            {
                Loger.logger(ex);
                return false;
            }
            finally
            {
                filePath = null;
                tempPath = null;
                savePath = null;
                conertToSWF = null;
            }
            return result;
        }

        /// <summary>
        /// 根据执行结果记录日志
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private void LogByResult(bool result, string fileName, string promptMsg)
        {
            if (result)
            {
                Loger.logger(string.Format("{0}:{1} 成功", fileName, promptMsg));
            }
            else//失败记录错误日志
            {
                Loger.logger(string.Format("{0}:{1} 失败", fileName, promptMsg));
            }
        }


        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string StrSearch)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "";
            if (!string.IsNullOrEmpty(StrSearch))
            {
                strWhere = PageTools.AddWhere(strWhere, "MagazineName like '%" + StrSearch + "%' ");
            }

            //添加数据权限判断
            switch (CurrentUserInfo.DataRange)
            {
                case 2://区域
                    strWhere += (strWhere.Length > 0 ? " and " : "") + " AreaID=" + CurrentUserInfo.AreaID;
                    break;
                case 3://个人
                    strWhere += (strWhere.Length > 0 ? " and " : "") + " EditPersonnelID=" + CurrentUserInfo.PersonnelID;
                    break;
            }

            try
            {
                dt = tElectronicsMagazine.GetListByPage(strWhere, "AddTime Desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
            }
            catch { }
            string strJson = PublicClass.ToJson(dt, total);
            if (strJson.Trim() == "")
            {
                strJson = "{\"total\":0,\"rows\":[]}";
            }
            return strJson;
        }

        /// <summary>
        /// 显示详情页
        /// </summary>
        /// <param name="EditType">编辑类型</param>
        /// <returns>返回编辑结果</returns>
        public ActionResult MagazineEdit(E_tb_ElectronicsMagazine eElectronicsMagazine, string EditType, int? InfoID)
        {
            ViewData["MagazineTypeList"] = GetNewsTypeList(false);
            if (EditType == "Edit")
            {
                eElectronicsMagazine = tElectronicsMagazine.GetModel(Convert.ToInt32(InfoID));
            }
            eElectronicsMagazine.EditType = EditType;
            return View(eElectronicsMagazine);
        }


        /// <summary>
        /// 是否有效下拉框数据
        /// </summary>
        /// <returns></returns>
        private SelectList GetNewsTypeList(bool IsSearch)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (IsSearch)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
            }
            list.Add(new SelectListItem() { Text = "年刊", Value = "1" });
            list.Add(new SelectListItem() { Text = "月刊", Value = "2" });
            list.First().Selected = true;
            return new SelectList(list, "Value", "Text");
        }


        /// <summary>
        /// 保存实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eElectronicsMagazine">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        [ValidateInput(false)]
        public string Save(E_tb_ElectronicsMagazine eElectronicsMagazine)
        {
            string msg = "0";
            eElectronicsMagazine.AddTime = DateTime.Now;
            eElectronicsMagazine.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eElectronicsMagazine.AreaID = CurrentUserInfo.AreaID;
            if (eElectronicsMagazine.EditType == "Add")
            {
                tElectronicsMagazine.Add(eElectronicsMagazine);
                msg = "1";
            }
            else
            {
                tElectronicsMagazine.Update(eElectronicsMagazine);
                msg = "1";
            }
            return msg;
        }

        /// <summary>
        /// 删除实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="InfoID">要删除的实验室</param>
        /// <returns>返回是否删除成功</returns>
        public JsonResult Delete(int id)
        {
            string str = (tElectronicsMagazine.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }

    }
}
