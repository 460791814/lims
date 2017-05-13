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
using Web.Attribute;

namespace Web.Controllers
{
    public class AreaController : BaseController
    {
        T_tb_Area tArea = new T_tb_Area();

        public ActionResult AreaList()
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
                strWhere = " AreaName like '%" + StrSearch.Trim() + "%'";
            }
            try
            {
                dt = tArea.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        /// 显示详情页  模块
        /// </summary>
        /// <param name="EditType">编辑类型</param>
        /// <returns>返回编辑结果</returns>
        public ActionResult AreaEdit(E_tb_Area eArea, string EditType, int? InfoID)
        {
            if (EditType == "Edit")
            {
                eArea = tArea.GetModel(Convert.ToInt32(InfoID));
            }
            eArea.EditType = EditType;
            return View(eArea);
        }


        /// <summary>
        /// 保存信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eArea">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_Area eArea)
        {
            string msg = "0";
            if (eArea.EditType == "Add")
            {
                tArea.Add(eArea);
                msg = "1";
            }
            else
            {
                tArea.Update(eArea);
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
            string str = (tArea.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }
    }
}
