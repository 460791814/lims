using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Laboratory;
using System.Data;
using Model.Laboratory;
using BLL.ShowImage;
using Model.ShowImage;
using System.IO;

namespace Web.Controllers
{
    public class ShowImageController : BaseController
    {
        T_tb_ShowImages tShowImages = new T_tb_ShowImages(); //首页图片管理

        //
        // GET: /Laboratory/

        public ActionResult ShowImageList()
        {
            return View();
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
            if (StrSearch != null && StrSearch.Trim() != "")
            {
                strWhere = " ImgName like '%" + StrSearch.Trim() + "%'";
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
                dt = tShowImages.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult ShowImageEdit(E_tb_ShowImages eShowImages, string EditType, int? InfoID)
        {
            ViewData["ImgTypeList"] = GetImgTypeList();

            if (EditType == "Edit")
            {
                eShowImages = tShowImages.GetModel(Convert.ToInt32(InfoID));
            }
            eShowImages.EditType = EditType;
            return View(eShowImages);
        }

        /// <summary>
        /// 是否有效下拉框数据
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        private SelectList GetImgTypeList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "大图", Value = "1", Selected = true });
            list.Add(new SelectListItem() { Text = "小图", Value = "2" });
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 保存实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eShowImages">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_ShowImages eShowImages)
        {
            string msg = "0";
            eShowImages.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eShowImages.AreaID = CurrentUserInfo.AreaID;
            if (eShowImages.EditType == "Add")
            {
                tShowImages.Add(eShowImages);
                msg = "1";
            }
            else
            {
                tShowImages.Update(eShowImages);
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
            string str = (tShowImages.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
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
                    result = Path.GetFileName(FileData.FileName);//获得文件名
                    string ext = Path.GetExtension(FileData.FileName);//获得文件扩展名
                    string strdate = DateTime.Now.Year.ToString()+ DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") +  DateTime.Now.Minute.ToString("00") +DateTime.Now.Second.ToString();
                    string saveName = result.Replace(ext,"") + "(" + strdate + ")" + ext;//实际保存文件名
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

        [AcceptVerbs(HttpVerbs.Post)]
        public string ImportV2(HttpPostedFileBase FileData, string folder)
        {
            string result = "false";
            string saveName = "";
            if (null != FileData)
            {
                try
                {
                    result = Path.GetFileName(FileData.FileName);//获得文件名
                    string ext = Path.GetExtension(FileData.FileName);//获得文件扩展名
                    string strdate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString();
                    saveName = "LIMS" + strdate + ext; //result.Replace(ext,"") + "(" + strdate + ")" + ext;//实际保存文件名
                    saveFile(FileData, "UpFile", saveName);//保存文件
                }
                catch
                {
                    result = "false";
                }
            }
            return result + "|" + saveName;
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
