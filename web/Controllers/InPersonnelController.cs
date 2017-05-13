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
using BLL.RoleManage;
using Model.RoleManage;
using BLL.Laboratory;
using Model.Laboratory;

namespace Web.Controllers
{
    public class InPersonnelController : BaseController
    {
        T_tb_InPersonnel tInPersonnel = new T_tb_InPersonnel();
        T_tb_Role tRole = new T_tb_Role();
        T_tb_UserRole tUserRole = new T_tb_UserRole();
        T_tb_Area tArea = new T_tb_Area();

        //
        // GET: /Laboratory/

        public ActionResult InPersonnelList()
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
            try
            {
                dt = tInPersonnel.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult InPersonnelEdit(E_tb_InPersonnel eInPersonnel, string EditType, int? InfoID)
        {
            ViewData["SexList"] = GetSexList();
            ViewData["RoleList"] = GetRoleList();
            ViewData["AreaList"] = GetAreaList();
            ViewBag.PassWord = "";
            if (EditType == "Edit")
            {
                eInPersonnel = tInPersonnel.GetModel(Convert.ToInt32(InfoID));
                E_tb_UserRole eUserRole = tUserRole.GetModelList("PersonnelID=" + eInPersonnel.PersonnelID).FirstOrDefault();
                if (eUserRole != null)
                {
                    eInPersonnel.RoleID = eUserRole.RoleID;
                }
                ViewBag.PassWord = eInPersonnel.PassWord;
            }
            eInPersonnel.EditType = EditType;
            return View(eInPersonnel);
        }

        /// <summary>
        /// 获得区域数据列表
        /// </summary>
        /// <returns></returns>
        private SelectList GetAreaList()
        {
            List<E_tb_Area> Laboratorylist = tArea.GetModelList("");
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (E_tb_Area item in Laboratorylist)
            {
                list.Add(new SelectListItem() { Text = item.AreaName, Value = item.AreaID.ToString() });   
            }
            return new SelectList(list, "Value", "Text");
        }


        /// <summary>
        /// 获得性别下拉菜单
        /// </summary>
        /// <returns></returns>
        private SelectList GetSexList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "男", Value = "男", Selected = true });
            list.Add(new SelectListItem() { Text = "女", Value = "女" });
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 获得角色下拉菜单
        /// </summary>
        /// <returns></returns>
        private SelectList GetRoleList()
        {
            List<E_tb_Role> Rolelist = tRole.GetModelList("");
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (E_tb_Role item in Rolelist)
            {
                list.Add(new SelectListItem() { Text = item.RoleName, Value = item.RoleID.ToString() });
            }
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 验证用户名不能重复
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>返回用户名是否重复的标志</returns>
        public ActionResult CheckUserName(string UserName, string PersonnelID)
        {
            string strWhere = "UserName='" + UserName + "'";
            if (PersonnelID != "0")
            {
                strWhere += " and PersonnelID!=" + PersonnelID;
            }
            List<E_tb_InPersonnel> list = tInPersonnel.GetModelList(strWhere);
            if (list != null && list.Count > 0)
            {
                return Content("error");
            }
            return Content("OK");
        }

        /// <summary>
        /// 保存信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eInPersonnel">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_InPersonnel eInPersonnel)
        {
            string msg = "0";
            if (eInPersonnel.EditType == "Add")
            {
                eInPersonnel.PersonnelID=tInPersonnel.Add(eInPersonnel);
                E_tb_UserRole eUserRole = new E_tb_UserRole();
                eUserRole.RoleID = eInPersonnel.RoleID;
                eUserRole.PersonnelID = eInPersonnel.PersonnelID;
                tUserRole.Add(eUserRole);
                msg = "1";
            }
            else
            {
                tInPersonnel.Update(eInPersonnel);
                tUserRole.DeleteByWhere("PersonnelID="+eInPersonnel.PersonnelID);
                E_tb_UserRole eUserRole = new E_tb_UserRole();
                eUserRole.RoleID = eInPersonnel.RoleID;
                eUserRole.PersonnelID = eInPersonnel.PersonnelID;
                tUserRole.Add(eUserRole);
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
            string str = (tInPersonnel.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }
    }
}
