using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Laboratory;
using System.Data;
using Model.Laboratory;
using Common;
using BLL.ExpePlan;
using BLL.PersonnelManage;
using Model.ExpePlan;
using Model.PersonnelManage;

namespace Web.Controllers
{
    public class DetectProjectController : BaseController
    {
        T_tb_DetectProject tDetectProject = new T_tb_DetectProject(); //实验室管理
        T_tb_ExpePlan tExpePlan = new T_tb_ExpePlan(); //实验计划
        T_tb_Project tProject = new T_tb_Project();
        T_tb_InPersonnel tInPersonnel = new T_tb_InPersonnel();
        //
        // GET: /DetectProject/

        public ActionResult DetectProjectList(int LaboratoryID)
        {
            E_tb_DetectProject eDetectProject = new E_tb_DetectProject();
            eDetectProject.LaboratoryID = LaboratoryID;
            return View(eDetectProject);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int LaboratoryID, int pageNumber, int pageSize, string StrSearch, string Searchtype, string txt_StartTime, string txt_EndTime)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = " T.LaboratoryID=" + LaboratoryID;
            if (!string.IsNullOrEmpty(txt_StartTime))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.DetectTime>=cast('" + txt_StartTime + "' as datetime) ");
            }
            if (!string.IsNullOrEmpty(txt_EndTime))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.DetectTime<=cast('" + txt_EndTime + "' as datetime) ");
            }

            if (StrSearch != null && StrSearch.Trim() != "")
            {
                switch (Searchtype)
                {
                    case "1": //检测项目
                        strWhere += " and T.ProjectName like '%" + StrSearch.Trim() + "%'";
                        break;
                    case "2": //负责人
                        strWhere += " and T.MainPerson like '%" + StrSearch.Trim() + "%'";
                        break;
                }
            }
            try
            {
                dt = tDetectProject.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult DetectProjectEdit(E_tb_DetectProject eDetectProject, int LaboratoryID, string EditType, int? InfoID)
        {
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("").Tables[0], "ProjectID", "ProjectName", false);
            ViewData["PersonnelList"] = PageTools.GetSelectList(tInPersonnel.GetList("").Tables[0], "PersonnelID", "PersonnelName", false);

            if (EditType == "Edit")
            {
                eDetectProject = tDetectProject.GetModel(Convert.ToInt32(InfoID));
            }
            eDetectProject.EditType = EditType;
            eDetectProject.LaboratoryID = LaboratoryID;
            return View(eDetectProject);
        }

        /// <summary>
        /// 保存实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eDetectProject">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_DetectProject eDetectProject)
        {
            string msg = "0";
            eDetectProject.ProjectName = tProject.GetModel(int.Parse(eDetectProject.RelationProjectID.ToString())).ProjectName; //项目名称
            E_tb_InPersonnel eInPersonnel=tInPersonnel.GetModel(int.Parse(eDetectProject.HeadPersonnelID.ToString()));          //负责人名称
            eDetectProject.MainPerson = eInPersonnel.PersonnelName; //联系电话
            eDetectProject.Tel = eInPersonnel.Tel;
            if (eDetectProject.EditType == "Add")
            {
                tDetectProject.Add(eDetectProject);
                msg = "1";
            }
            else
            {
                tDetectProject.Update(eDetectProject);
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
            string str = (tDetectProject.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取该项目下的所有任务单号
        /// </summary>
        /// <param name="ProjectID">项目ID</param>
        /// <returns></returns>
        public JsonResult GetTaskNoList(string ProjectID)
        {
            //ArrayList al = new ArrayList();
            List<E_tb_ExpePlan> list = tExpePlan.GetModelList("ProjectID=" + ProjectID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
