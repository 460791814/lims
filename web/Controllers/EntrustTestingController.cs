using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.News;
using System.Data;
using Model.EntrustManage;
using BLL.EntrustManage;
using BLL.Laboratory;
using Common;
using BLL;
using BLL.PersonnelManage;
using BLL.ClientManage;

namespace Web.Controllers
{
    public class EntrustTestingController : BaseController
    {
        T_tb_EntrustTesting tEntrustTesting = new T_tb_EntrustTesting();
        T_tb_Project tProject = new T_tb_Project();
        tb_SampleBLL tSample = new tb_SampleBLL();
        T_tb_InPersonnel tInPersonnel = new T_tb_InPersonnel();
        T_tb_ClientManage tClientManage = new T_tb_ClientManage();
        //
        // GET: /Laboratory/

        public ActionResult EntrustTestingList()
        {
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("").Tables[0], "ProjectID", "ProjectName", true);
            return View();
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string EntrustCompany, string SampleName, string ProjectID, string TaskNo, string SubmissionTimeStart, string SubmissionTimeEnd)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "B.handleUser is null"; //已销毁的样品 对应的委托检验不显示
            if (!string.IsNullOrEmpty(EntrustCompany))//送检单位
            {
                strWhere = PageTools.AddWhere(strWhere, "EntrustCompany like '%" + EntrustCompany + "%' ");
            }
            if (!string.IsNullOrEmpty(SampleName))//样品名称
            {
                strWhere = PageTools.AddWhere(strWhere, "B.name like '%" + SampleName + "%' ");
            }
            if (!string.IsNullOrEmpty(ProjectID) && ProjectID!="-1")//检验项目
            {
                strWhere = PageTools.AddWhere(strWhere, " T.ProjectID=" + ProjectID);
            }
            if (!string.IsNullOrEmpty(TaskNo))//任务单号
            {
                strWhere = PageTools.AddWhere(strWhere, "TaskNo like '%" + TaskNo + "%' ");
            }
            if (!string.IsNullOrEmpty(SubmissionTimeStart))//起始送检日期
            {
                strWhere = PageTools.AddWhere(strWhere, "SubmissionTime>=cast('" + SubmissionTimeStart+"' as datetime) ");
            }
            if (!string.IsNullOrEmpty(SubmissionTimeEnd))//结束送检日期
            {
                strWhere = PageTools.AddWhere(strWhere, "SubmissionTime<=cast('" + SubmissionTimeEnd + "' as datetime) ");
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
                dt = tEntrustTesting.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
            }
            catch { }

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string RecordID = dt.Rows[i]["ReportID"].ToString();
                    if (RecordID != "0")
                    {
                        dt.Rows[i]["strReportID"] = string.Format("<a href='/TestReport/TestReportList?ReportID={0}' style='color:Blue; font-weight:bold;'>{0}</a>", RecordID);
                    }
                }
            }


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
        public ActionResult EntrustTestingEdit(E_tb_EntrustTesting eEntrustTesting, string EditType, int? InfoID)
        {
            if (EditType == "Edit")
            {
                eEntrustTesting = tEntrustTesting.GetModel(Convert.ToInt32(InfoID));
            }
            eEntrustTesting.EditType = EditType;
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("").Tables[0], "ProjectID", "ProjectName", false);
            ViewData["SampleList"] = PageTools.GetSelectList(tSample.GetList("handleUser is null").Tables[0], "id", "name", false);
            ViewData["PersonnelList"] = PageTools.GetSelectList(tInPersonnel.GetList("").Tables[0], "PersonnelID", "PersonnelName", false);
            return View(eEntrustTesting);
        }

        /// <summary>
        /// 保存信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eEntrustTesting">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_EntrustTesting eEntrustTesting)
        {
            string msg = "0";
            eEntrustTesting.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eEntrustTesting.AreaID = CurrentUserInfo.AreaID;
            Model.tb_Sample eSample = tSample.GetModel(int.Parse(eEntrustTesting.SampleID.ToString()));
            eEntrustTesting.SubmissionTime = eSample.detectionDate;
            if (eSample.isDetection) //是否抽检
            {
                eEntrustTesting.EntrustCompany = eSample.detectionCompany;
            }
            else
            {
                string id = eSample.InspectCompany;
                if (!string.IsNullOrEmpty(id))
                {
                    Model.ClientManage.E_tb_ClientManage cmmodel = tClientManage.GetModel(int.Parse(id));
                    eEntrustTesting.EntrustCompany = cmmodel.ClientName;
                }
                else
                {
                    eEntrustTesting.EntrustCompany = "";
                }
            }
            if (eEntrustTesting.EditType == "Add")
            {
                eEntrustTesting.ReportID = 0;
                eEntrustTesting.IsComplete = 0;
                eEntrustTesting.TaskNo = DateTime.Now.ToString("yyyyMMdd") + "0" + eEntrustTesting.SampleID + "0" + eEntrustTesting.ProjectID;
                if (tEntrustTesting.IsExistsTaskNo(eEntrustTesting.TaskNo) > 0)
                {
                    msg = "2";
                }
                else
                {
                    tEntrustTesting.Add(eEntrustTesting);
                    msg = "1";
                }
            }
            else
            {
                tEntrustTesting.Update(eEntrustTesting);
                msg = "1";
            }
            return msg;
        }

        /// <summary>
        /// 根据样品ID获取对应的基础数据
        /// </summary>
        public JsonResult GetBaseData(string SampleID)
        {
            List<string> list = new List<string>();
            Model.tb_Sample eSample = tSample.GetModel(int.Parse(SampleID));
            string SubmissionTime = eSample.detectionDate != null ? eSample.detectionDate.ToString() : ""; //送、抽检日期
            string EntrustCompany=""; //委托单位
            if (eSample.isDetection) //是否抽检
            {
                EntrustCompany = eSample.detectionCompany;
            }
            else
            {
                string id = eSample.InspectCompany;
                if (!string.IsNullOrEmpty(id))
                {
                    Model.ClientManage.E_tb_ClientManage cmmodel = tClientManage.GetModel(int.Parse(id));
                    EntrustCompany = cmmodel.ClientName;
                }
            }
            list.Add(SubmissionTime);
            list.Add(EntrustCompany);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除信息
        /// 作者：小朱
        /// </summary>
        /// <param name="InfoID">要删除的ID</param>
        /// <returns>返回是否删除成功</returns>
        public JsonResult Delete(int id)
        {
            string str = (tEntrustTesting.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }
    }
}
