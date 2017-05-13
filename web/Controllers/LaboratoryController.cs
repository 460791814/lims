using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BLL.Laboratory;
using Model.Laboratory;
using BLL.RoleManage;
using Model.RoleManage;
using BLL.DictManage;
using Common;

namespace Web.Controllers
{
    public class LaboratoryController : BaseController
    {
        T_tb_Laboratory tLaboratory = new T_tb_Laboratory(); //实验室管理
        T_tb_Area tArea = new T_tb_Area();
        T_tb_TypeDict tTypeDict = new T_tb_TypeDict();

        //
        // GET: /Laboratory/

        public ActionResult LaboratoryList()
        {
            return View();
        }


        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string StrSearch, string Searchtype)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "";
            if (StrSearch != null && StrSearch.Trim() != "")
            {
                switch (Searchtype)
                {
                    case "1": //实验室名称
                        strWhere = " LaboratoryName like '%" + StrSearch.Trim() + "%'";
                        break;
                    case "2": //实验日期
                        strWhere = " DetectTime=cast('" + StrSearch.Trim() + "' as datetime)";
                        break;
                    case "3": //检测项目
                        strWhere = " ProjectName like '%" + StrSearch.Trim() + "%'";
                        break;
                    case "4": //负责人
                        strWhere = " MainPerson like '%" + StrSearch.Trim() + "%'";
                        break;
                }
            }
            if (CurrentUserInfo.DataRange != 1)
            {
                strWhere += (strWhere.Length > 0 ? " and " : "") + " AreaID=" + CurrentUserInfo.AreaID;//区域
            }

            try
            {
                dt = tLaboratory.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult LaboratoryEdit(E_tb_Laboratory eLaboratory, string EditType, int? InfoID)
        {
            ViewData["AreaList"] = GetAreaList();
            DataTable typelist = tTypeDict.GetList("SubjectID=4").Tables[0];
            ViewData["LaboratoryTypeList"] = PageTools.GetSelectList(typelist, "TypeID", "TypeName", false);
            if (EditType == "Edit")
            {
                eLaboratory = tLaboratory.GetModel(Convert.ToInt32(InfoID));
            }
            eLaboratory.UserAreaID = Convert.ToInt32(CurrentUserInfo.AreaID);
            eLaboratory.UserDataRange = CurrentUserInfo.DataRange;
            eLaboratory.EditType = EditType;
            return View(eLaboratory);
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
        /// 保存实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eLaboratory">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string SaveLadoratory(E_tb_Laboratory eLaboratory)
        {
            string msg = "0";
            if (CurrentUserInfo.DataRange != 1) //若当前用户不是超级管理员 则数据为自己所属区域的数据
            {
                eLaboratory.AreaID = CurrentUserInfo.AreaID;
            }
            if (eLaboratory.EditType == "Add")
            {
                tLaboratory.Add(eLaboratory);
                msg = "1";
            }
            else
            {
                tLaboratory.Update(eLaboratory);
                msg = "1";
            }
            return msg;
        }

        /// <summary>
        /// 设置实验室使用状态
        /// </summary>
        /// <param name="InfoID">要设置的实验室ID</param>
        /// <param name="IsUse">是否使用 0：空闲 1使用</param>
        /// <returns>返回是否设置成功</returns>
        public JsonResult SetUse(int InfoID, int IsUse)
        {
            E_tb_Laboratory eLaboratory = tLaboratory.GetModel(InfoID);
            eLaboratory.IsUse = IsUse;
            string str = (tLaboratory.Update(eLaboratory)) ? "设置成功！" : "设置失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 删除实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="InfoID">要删除的实验室</param>
        /// <returns>返回是否删除成功</returns>
        public JsonResult Delete(int id)
        {
            string str = (tLaboratory.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }
    }
}
