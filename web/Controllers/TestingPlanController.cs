using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.News;
using System.Data;
using Model.EntrustManage;
using BLL.EntrustManage;

namespace Web.Controllers
{
    public class TestingPlanController : BaseController
    {
        T_tb_TestingPlan tTestingPlan = new T_tb_TestingPlan();
        //
        // GET: /Laboratory/

        public ActionResult TestingPlanList()
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
                strWhere = " PlanName like '%" + StrSearch.Trim() + "%'";
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
                dt = tTestingPlan.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult TestingPlanEdit(E_tb_TestingPlan eTestingPlan, string EditType, int? InfoID)
        {
            if (EditType == "Edit")
            {
                eTestingPlan = tTestingPlan.GetModel(Convert.ToInt32(InfoID));
            }
            eTestingPlan.EditType = EditType;
            return View(eTestingPlan);
        }

        /// <summary>
        /// 保存信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eTestingPlan">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_TestingPlan eTestingPlan)
        {
            string msg = "0";
            eTestingPlan.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eTestingPlan.AreaID = CurrentUserInfo.AreaID;
            if (eTestingPlan.EditType == "Add")
            {
                tTestingPlan.Add(eTestingPlan);
                msg = "1";
            }
            else
            {
                tTestingPlan.Update(eTestingPlan);
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
            string str = (tTestingPlan.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 阅览文件
        /// 作者：章建国
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public JsonResult GetFileURLForView(int wid)
        {
            var model = tTestingPlan.GetModel(wid);
            string iFile = "" + model.FilePath;
            return Json(iFile, JsonRequestBehavior.AllowGet);
        }
    }
}
