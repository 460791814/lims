using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.News;
using System.Data;
using Model.News;
using BLL.ClientManage;
using Model.ClientManage;
using BLL.PersonnelManage;
using Model.PersonnelManage;

namespace Web.Controllers
{
    public class OutPersonnelController : BaseController
    {
        T_tb_OutPersonnel tOutPersonnel = new T_tb_OutPersonnel();
        //
        // GET: /Laboratory/

        public ActionResult OutPersonnelList()
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
                strWhere = " PersonnelName like '%" + StrSearch.Trim() + "%'";
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
                dt = tOutPersonnel.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult OutPersonnelEdit(E_tb_OutPersonnel eOutPersonnel, string EditType, int? InfoID)
        {
            ViewData["SexList"] = GetSexList();

            if (EditType == "Edit")
            {
                eOutPersonnel = tOutPersonnel.GetModel(Convert.ToInt32(InfoID));
            }
            eOutPersonnel.EditType = EditType;
            return View(eOutPersonnel);
        }

        private SelectList GetSexList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "男", Value = "男", Selected = true });
            list.Add(new SelectListItem() { Text = "女", Value = "女" });
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 保存信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eOutPersonnel">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_OutPersonnel eOutPersonnel)
        {
            string msg = "0";
            eOutPersonnel.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eOutPersonnel.AreaID = CurrentUserInfo.AreaID;
            if (eOutPersonnel.EditType == "Add")
            {
                tOutPersonnel.Add(eOutPersonnel);
                msg = "1";
            }
            else
            {
                tOutPersonnel.Update(eOutPersonnel);
                msg = "1";
            }
            return msg;
        }

        /// <summary>
        /// 删除信息
        /// 作者：小朱
        /// </summary>
        /// <param name="InfoID">要删除的ID</param>
        /// <returns>返回是否删除成功</returns>
        public JsonResult Delete(int id)
        {
            string str = (tOutPersonnel.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }
    }
}
