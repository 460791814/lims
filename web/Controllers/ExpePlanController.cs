using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.ExpePlan;
using Model.ExpePlan;
using System.Data;
using Common;
using BLL.Laboratory;
using BLL.PersonnelManage;
using System.Collections;
using BLL.EntrustManage;
using Model.EntrustManage;
using BLL.RoleManage;
using BLL;
using Model.Laboratory;

namespace Web.Controllers
{
    public class ExpePlanController : BaseController
    {
        T_tb_ExpePlan tExpePlan = new T_tb_ExpePlan(); //实验室管理
        T_tb_Project tProject = new T_tb_Project();
        T_tb_InPersonnel tInPersonnel = new T_tb_InPersonnel();
        T_tb_EntrustTesting tEntrustTesting = new T_tb_EntrustTesting(); //委托检验
        tb_SampleBLL tSample = new tb_SampleBLL(); //样品管理
        T_tb_Area tArea = new T_tb_Area();
        //
        // GET: /DetectProject/

        public ActionResult ExpePlanList(E_tb_ExpePlan eExpePlan)
        {
            ViewData["PlanTypeList"] = this.GetPlanTypeList(true);
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("").Tables[0], "ProjectID", "ProjectName", true);
            ViewData["AreaList"] = PageTools.GetSelectList(tArea.GetList("").Tables[0], "AreaID", "AreaName", true);
            if (Request["ApprovalPersonnelName"] != null)
                ViewData["ApprovalPersonnelName"] = Request["ApprovalPersonnelName"].ToString();
            else
                ViewData["ApprovalPersonnelName"] = "";
            ViewBag._userName = CurrentUserInfo.UserName;
            eExpePlan.AreaID = CurrentUserInfo.AreaID;
            ViewBag.IsDisabled = (CurrentUserInfo.RoleID != 1) ? "true" : "false"; //权限判断

            return View(eExpePlan);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string AreaID, string PlanTypeID, string InspectTimeStart, string InspectTimeEnd, string TaskNo, string ProjectID, string PlanID, string SampleName, string Status)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "";
            if (!string.IsNullOrEmpty(PlanID) && PlanID != "0")
            {
                strWhere = PageTools.AddWhere(strWhere, "T.PlanID=" + PlanID + " ");
            }

            if (!string.IsNullOrEmpty(AreaID))//区域
            {
                strWhere = PageTools.AddWhere(strWhere, "T.AreaID=" + AreaID + " ");
            }
            if (!string.IsNullOrEmpty(PlanTypeID))//计划类别
            {
                strWhere = PageTools.AddWhere(strWhere, "T.PlanTypeID=" + PlanTypeID + " ");
            }
            if (!string.IsNullOrEmpty(InspectTimeStart))//检验开始时间
            {
                strWhere = PageTools.AddWhere(strWhere, "InspectTime>=cast('" + InspectTimeStart + "' as datetime) ");
            }
            if (!string.IsNullOrEmpty(InspectTimeEnd))//送检结束时间
            {
                strWhere = PageTools.AddWhere(strWhere, "InspectTime<=cast('" + InspectTimeEnd + "' as datetime) ");
            }
            if (!string.IsNullOrEmpty(TaskNo))//任务单号
            {
                strWhere = PageTools.AddWhere(strWhere, "T.TaskNo like '%" + TaskNo.Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(ProjectID))//检验项目
            {
                strWhere = PageTools.AddWhere(strWhere, "T.ProjectID=" + ProjectID + " ");
            }
            if (!string.IsNullOrEmpty(SampleName))//样品名称
            {
                strWhere = PageTools.AddWhere(strWhere, "C.name like '%" + SampleName + "%' ");
            }
            if (!string.IsNullOrEmpty(Status))//样品名称
            {
                strWhere = PageTools.AddWhere(strWhere, "T.Status =" + Status);
            }
            //添加数据权限判断
            switch (CurrentUserInfo.DataRange)
            {
                case 2://区域
                    strWhere = PageTools.AddWhere(strWhere, "T.AreaID=" + CurrentUserInfo.AreaID + " ");
                    break;
                case 3://个人
                    strWhere = PageTools.AddWhere(strWhere, "T.EditPersonnelID=" + CurrentUserInfo.PersonnelID + " ");
                    break;
            }

            try
            {
                dt = tExpePlan.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult ExpePlanEdit(E_tb_ExpePlan eExpePlan, string EditType, int? InfoID)
        {
            ViewData["PlanTypeList"] = this.GetPlanTypeList(false);
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("").Tables[0], "ProjectID", "ProjectName", false);
            ViewData["PersonnelList"] = PageTools.GetSelectList(tInPersonnel.GetList(" AreaID=" + CurrentUserInfo.AreaID.ToString()).Tables[0], "PersonnelID", "PersonnelName", false);
            ViewData["SampleList"] = PageTools.GetSelectList(tSample.GetList(" handleUser='' order by id ").Tables[0], "id", "name", false);
            ViewBag.PersonnelID = CurrentUserInfo.PersonnelID;
            ViewBag.AreaAddr = tArea.GetModel(int.Parse(CurrentUserInfo.AreaID.ToString())).AreaName;
            ViewBag.SampleID = 0;
            ViewBag.ProjectID = 0;
            if (EditType == "Edit")
            {
                eExpePlan = tExpePlan.GetModel(Convert.ToInt32(InfoID));
                ViewBag.SampleID = eExpePlan.SampleID;
                ViewBag.ProjectID = eExpePlan.ProjectID;
            }
            eExpePlan.EditType = EditType;
            return View(eExpePlan);
        }

        /// <summary>
        /// 保存实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eExpePlan">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_ExpePlan eExpePlan)
        {
            string msg = "0";
            eExpePlan.UpdateTime = DateTime.Now;
            eExpePlan.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eExpePlan.AreaID = CurrentUserInfo.AreaID;
            if (eExpePlan.EditType == "Add")
            {
                eExpePlan.Status = 0;
                if (tExpePlan.IsExistsTaskNo(eExpePlan.TaskNo) > 0)
                {
                    msg = "2";
                }
                else
                {
                    tExpePlan.Add(eExpePlan);
                    msg = "1";
                }
            }
            else
            {
                tExpePlan.Update(eExpePlan);
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
            string str = (tExpePlan.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 是否有效下拉框数据
        /// </summary>
        /// <returns></returns>
        private SelectList GetPlanTypeList(bool IsSearch)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (IsSearch)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
            }
            list.Add(new SelectListItem() { Text = "计划外", Value = "2" });
            list.Add(new SelectListItem() { Text = "计划内", Value = "1" });
            list.First().Selected = true;
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 获取该项目下的所有任务单号
        /// </summary>
        /// <param name="ProjectID">项目ID</param>
        /// <returns></returns>
        public JsonResult GetTaskNoList(string ProjectID, string SampleID)
        {
            List<E_tb_EntrustTesting> list = tEntrustTesting.GetModelList("ProjectID=" + ProjectID + " and SampleID=" + SampleID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据计划类型获取对应的样品列表
        /// </summary>
        /// <param name="PlanTypeID">计划类型（1：计划内、2：计划外）</param>
        /// <returns></returns>
        public JsonResult GetSampleList(string PlanTypeID)
        {
            List<Model.tb_Sample> list = new List<Model.tb_Sample>();
            if (PlanTypeID == "2")
            {
                //读取计划外的 委托检验 未销毁 未完成的委托检验对应的样品
                list = tSample.GetModelList("handleUser is null and id in (select SampleID from tb_EntrustTesting where IsComplete=0)");
            }
            else
            {
                //获取全部未销毁样品
                list = tSample.GetModelList("handleUser is null");
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }


        /// <summary>
        /// 根据计划类型以及对应的样品 获取对应的委托检验里面对应的项目
        /// </summary>
        /// <param name="PlanTypeID"></param>
        /// <param name="SampleID"></param>
        /// <returns></returns>
        public JsonResult GetProjectList(string PlanTypeID, string SampleID)
        {
            List<E_tb_Project> list = new List<E_tb_Project>();
            if (PlanTypeID == "2" && !string.IsNullOrEmpty(SampleID))
            {
                //读取计划外的 委托检验 未销毁 未完成的委托检验对应的 检验项目
                list = tProject.GetModelList("ProjectID in (select ProjectID from tb_EntrustTesting where IsComplete=0 and SampleID=" + SampleID + ")");
            }
            else if (PlanTypeID == "1")
            {
                //获取全部未销毁样品
                list = tProject.GetModelList("");
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取对应委托检验对应的负责人
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <param name="SampleID"></param>
        /// <returns></returns>
        public string GetEntrustTestingPersonnelID(string ProjectID, string SampleID)
        {
            if (!string.IsNullOrEmpty(ProjectID) && !string.IsNullOrEmpty(SampleID))
            {
                List<E_tb_EntrustTesting> list = tEntrustTesting.GetModelList(string.Format("IsComplete=0 and ProjectID={0} and SampleID={1}", ProjectID, SampleID));
                if (list != null && list.Count > 0)
                {
                    return list.First().TestPersonnelID.ToString();
                }
            }
            return "0";

        }
        /// <summary>
        /// 获取负责人对应的检验地点
        /// </summary>
        /// <returns></returns>
        public string GetAreaNameByPersonnelID(string PID)
        {
            if (!string.IsNullOrEmpty(PID))
            {
                return tInPersonnel.GetAreaNameByPersonId(PID);
            }
            return "0";

        }

        /// <summary>
        /// 生成计划内任务单号
        /// </summary>
        /// <param name="ProjectID">项目ID</param>
        /// <param name="SampleID">样品ID</param>
        /// <returns></returns>
        public string CreateTaskNoList(string ProjectID, string SampleID)
        {
            return "JN" + DateTime.Now.ToString("yyyyMMdd") + "0" + SampleID + "0" + ProjectID;
        }

        /// <summary>
        /// 根据项目ID 获取对应的检验标准
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public string GetExpeMethod(string ProjectID)
        {
            E_tb_Project eProject = tProject.GetModel(int.Parse(ProjectID));
            return (eProject != null) ? eProject.ExpeMethod : "";
        }
    }
}
