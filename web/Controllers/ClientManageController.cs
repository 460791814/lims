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

namespace Web.Controllers
{
    public class ClientManageController : BaseController
    {
        T_tb_ClientManage tClientManage = new T_tb_ClientManage();
        T_tb_ContractImg tContractImg = new T_tb_ContractImg();

        //
        // GET: /Laboratory/

        public ActionResult ClientManageList()
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
                strWhere = " T.ClientName like '%" + StrSearch.Trim() + "%'";
            }

            //添加数据权限判断
            switch (CurrentUserInfo.DataRange)
            {
                case 2://区域
                    strWhere += (strWhere.Length > 0 ? " and " : "") + " T.AreaID=" + CurrentUserInfo.AreaID;
                    break;
                case 3://个人
                    strWhere += (strWhere.Length > 0 ? " and " : "") + " T.EditPersonnelID=" + CurrentUserInfo.PersonnelID;
                    break;
            }

            try
            {
                dt = tClientManage.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult ClientManageEdit(E_tb_ClientManage eClientManage, string EditType, int? InfoID)
        {
            ViewData["ClientLevelList"] = GetLevelList();
            ViewData["ContractImgList"] = GetContractImgList();
            if (EditType == "Edit")
            {
                eClientManage = tClientManage.GetModel(Convert.ToInt32(InfoID));
            }
            eClientManage.EditType = EditType;
            return View(eClientManage);
        }

        private SelectList GetLevelList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "1级", Value = "1级", Selected = true });
            list.Add(new SelectListItem() { Text = "2级", Value = "2级" });
            list.Add(new SelectListItem() { Text = "3级", Value = "3级" });
            return new SelectList(list, "Value", "Text");
        }

        private SelectList GetContractImgList()
        {
            List<E_tb_ContractImg> mdlist=tContractImg.GetModelList("");
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (E_tb_ContractImg item in mdlist)
            {
                list.Add(new SelectListItem() { Text = "/UpFile/" + item.ImgPath.ToString(), Value = item.ContractImgID.ToString() });
            }
            if (list.Count > 0)
            {
                list.First().Selected = true;
            }
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 保存信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eClientManage">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_ClientManage eClientManage)
        {
            string msg = "0";
            eClientManage.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eClientManage.AreaID = CurrentUserInfo.AreaID;
            if (eClientManage.EditType == "Add")
            {
                tClientManage.Add(eClientManage);
                msg = "1";
            }
            else
            {
                tClientManage.Update(eClientManage);
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
            string str = (tClientManage.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }

    }
}
