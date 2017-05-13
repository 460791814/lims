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

namespace Web.Controllers
{
    public class RoleController : BaseController
    {
        T_tb_Role tRole = new T_tb_Role();
        T_tb_Action tAction = new T_tb_Action();
        T_tb_RoleAction tRoleAction = new T_tb_RoleAction();

        public ActionResult RoleList()
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
                strWhere = " RoleName like '%" + StrSearch.Trim() + "%'";
            }
            try
            {
                dt = tRole.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult RoleEdit(E_tb_Role eRole, string EditType, int? InfoID)
        {
            ViewData["DataRangeList"] = GetDataRangeList();
            if (EditType == "Edit")
            {
                eRole = tRole.GetModel(Convert.ToInt32(InfoID));
            }
            eRole.EditType = EditType;
            return View(eRole);
        }

        /// <summary>
        /// 获得性别下拉菜单
        /// </summary>
        /// <returns></returns>
        private SelectList GetDataRangeList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "全部", Value = "1", Selected = true });
            list.Add(new SelectListItem() { Text = "区域", Value = "2" });
            list.Add(new SelectListItem() { Text = "个人", Value = "3" });
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 显示详情页
        /// </summary>
        /// <param name="EditType">编辑类型</param>
        /// <returns>返回编辑结果</returns>
        public ActionResult RolePurview(E_tb_Role eRole, int InfoID)
        {
            eRole = tRole.GetModel(Convert.ToInt32(InfoID));
            return View(eRole);
        }

        //实例化树形  
        public string InitTree(int InfoID)
        {

            string result = "";
            IList<E_tb_Action> list = tAction.GetModelList("ParentID=0").ToList();
            List<E_tb_RoleAction> RoleActionList = tRoleAction.GetModelList("RoleID=" + InfoID);
            foreach (E_tb_Action node in list)
            {
                result += Recursion(node, RoleActionList) + ",";
            }
            return "[" + result.TrimEnd(',') + "]";
        }

        // 递归树形  
        public string Recursion(E_tb_Action model, List<E_tb_RoleAction> RoleActionList)
        {
            string res_s = "";
            //你想要在视图中得到的值  
            string strChecked = this.ActionIsChecked(RoleActionList, model.ActionID);
            //if (RoleActionList.Where(p=>p.ActionID==model.ActionID).Count()>0)
            //{
            //    strChecked = "true";
            //}

            res_s += "{\"id\":\"" + model.ActionID + "\",\"text\":\"" + model.ActionName+"("+model.ActionCode+")" + "\",\"checked\":" + strChecked;

            IList<E_tb_Action> list = tAction.GetModelList("ParentID=" + model.ActionID).ToList();
            if (list != null)
            {
                res_s += "," + "\"children\":[";
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0)
                        res_s += ",";
                    res_s += Recursion(list[i], RoleActionList);
                }
                res_s += "]";
            };
            res_s += "}";
            return res_s;
        }

        /// <summary>
        /// 判断该节点是否应该选中
        /// </summary>
        /// <returns>返回是否选中状态</returns>
        public string ActionIsChecked(List<E_tb_RoleAction> RoleActionList, int ActionID)
        {
            string strChecked = "true";
            if (RoleActionList.Where(p => p.ActionID == ActionID).Count() == 0)
            {
                strChecked = "false";
                return strChecked;
            }

            List<E_tb_Action> list = tAction.GetModelList("ParentID=" + ActionID).ToList();
            if (list != null && list.Count > 0)
            {
                foreach (E_tb_Action item in list)
                {
                    if (RoleActionList.Where(p => p.ActionID == item.ActionID).Count() == 0)
                    {
                        strChecked = "false";
                        return strChecked;
                    }

                    List<E_tb_Action> listtemp = tAction.GetModelList("ParentID=" + item.ActionID).ToList();
                    if (listtemp != null && listtemp.Count > 0)
                    {
                        foreach (E_tb_Action itemtemp in listtemp)
                        {
                            if (RoleActionList.Where(p => p.ActionID == itemtemp.ActionID).Count() == 0)
                            {
                                strChecked = "false";
                                return strChecked;
                            }
                        }
                    }
                }
            }
            return strChecked;
        }


        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="ActionIDS"></param>
        /// <returns></returns>
        public ActionResult SaveRolePurview(E_tb_Role eRole,string ActionIDS)
        {
            tRoleAction.DeleteByWhere("RoleID=" + eRole.RoleID);
            if (ActionIDS.Length > 0)
            {
                ActionIDS = ActionIDS.TrimEnd(',');
                string[] IDS = ActionIDS.Split(',');
                for (int i = 0; i < IDS.Count(); i++)
                {
                    E_tb_RoleAction eRoleAction = new E_tb_RoleAction();
                    eRoleAction.RoleID = eRole.RoleID;
                    eRoleAction.ActionID = int.Parse(IDS[i]);
                    tRoleAction.Add(eRoleAction);
                }
            }
            return Content("OK");
        }


        /// <summary>
        /// 保存信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eRole">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_Role eRole)
        {
            string msg = "0";
            if (eRole.EditType == "Add")
            {
                tRole.Add(eRole);
                msg = "1";
            }
            else
            {
                tRole.Update(eRole);
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
            string str = (tRole.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }

    }
}
