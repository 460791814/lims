using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.EntrustManage;
using BLL.Laboratory;
using BLL;
using System.Data;
using Common;
using Model.EntrustManage;

namespace Web.Controllers
{
    public class OutsourcingTestingController : BaseController
    {
        T_tb_OutsourcingTesting tOutsourcingTesting = new T_tb_OutsourcingTesting();
        T_tb_Project tProject = new T_tb_Project();
        tb_SampleBLL tSample = new tb_SampleBLL();
        //
        // GET: /Laboratory/

        public ActionResult OutsourcingTestingList()
        {
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("").Tables[0], "ProjectID", "ProjectName", true);
            return View();
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string EntrustCompany, string SampleName, string ProjectID, string SubmissionTimeStart, string SubmissionTimeEnd)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "";
            if (!string.IsNullOrEmpty(EntrustCompany))//送检单位
            {
                strWhere = PageTools.AddWhere(strWhere, "EntrustCompany like '%" + EntrustCompany + "%' ");
            }
            if (!string.IsNullOrEmpty(SampleName))//样品名称
            {
                strWhere = PageTools.AddWhere(strWhere, "B.name like '%" + SampleName + "%' ");
            }
            if (!string.IsNullOrEmpty(ProjectID) && ProjectID != "-1")//检验项目
            {
                strWhere = PageTools.AddWhere(strWhere, " T.ProjectID=" + ProjectID);
            }
            if (!string.IsNullOrEmpty(SubmissionTimeStart))//起始送检日期
            {
                strWhere = PageTools.AddWhere(strWhere, "T.SubmissionTime>=cast('" + SubmissionTimeStart + "' as datetime) ");
            }
            if (!string.IsNullOrEmpty(SubmissionTimeEnd))//结束送检日期
            {
                strWhere = PageTools.AddWhere(strWhere, "T.SubmissionTime<=cast('" + SubmissionTimeEnd + "' as datetime) ");
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
                dt = tOutsourcingTesting.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult OutsourcingTestingEdit(E_tb_OutsourcingTesting eOutsourcingTesting, string EditType, int? InfoID)
        {
            if (EditType == "Edit")
            {
                eOutsourcingTesting = tOutsourcingTesting.GetModel(Convert.ToInt32(InfoID));
            }
            eOutsourcingTesting.EditType = EditType;
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("").Tables[0], "ProjectID", "ProjectName", false);
            ViewData["SampleList"] = PageTools.GetSelectList(tSample.GetList("").Tables[0], "id", "name", false);
            return View(eOutsourcingTesting);
        }

        /// <summary>
        /// 保存信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eEntrustTesting">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_OutsourcingTesting eOutsourcingTesting)
        {
            string msg = "0";
            eOutsourcingTesting.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eOutsourcingTesting.AreaID = CurrentUserInfo.AreaID;
            eOutsourcingTesting.IsComplete = 0;
            if (!string.IsNullOrEmpty(eOutsourcingTesting.OutsourcingReport))
            {
                eOutsourcingTesting.IsComplete = 1;
            }
            if (eOutsourcingTesting.EditType == "Add")
            {
                tOutsourcingTesting.Add(eOutsourcingTesting);
                msg = "1";
            }
            else
            {
                tOutsourcingTesting.Update(eOutsourcingTesting);
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
            string str = (tOutsourcingTesting.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 阅览文件
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public JsonResult GetFileURLForView(int id)
        {
            var model = tOutsourcingTesting.GetModel(id);
            string iFile = "" + model.OutsourcingReport;
            return Json(iFile, JsonRequestBehavior.AllowGet);
        }
    }
}
