using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BLL.Laboratory;
using Model.Laboratory;
using Common;

namespace Web.Controllers
{
    public class ProjectController : BaseController
    {
        T_tb_Project tProject = new T_tb_Project();
        KnowledgeData Knowledge = new KnowledgeData();
        //
        // GET: /Project/

        public ActionResult ProjectList()
        {
            ViewData["AreaList"] = Knowledge.GetAreaList(true);
            ViewData["ProjectTypeList"] = Knowledge.GetTypeDictList(true, 2);
            ViewData["LaboratoryList"] = Knowledge.GetLaboratoryList(true);
            return View();
        }


        

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string AreaID, string ProjectName, string ExpeType, string ProjectTypeID, string LaboratoryID)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "";
            if (!string.IsNullOrEmpty(AreaID) && AreaID.Trim() != "-1") //区域ID
            {
                strWhere = PageTools.AddWhere(strWhere, "AreaID=" + AreaID);
            }
            if (!string.IsNullOrEmpty(ProjectName))//项目名称
            {
                strWhere = PageTools.AddWhere(strWhere, "ProjectName like '%" + ProjectName + "%'");
            }
            if (!string.IsNullOrEmpty(ExpeType))//检验类型
            {
                strWhere = PageTools.AddWhere(strWhere, "ExpeType like '%" + ExpeType + "%'");
            }
            if (!string.IsNullOrEmpty(ProjectTypeID) && ProjectTypeID.Trim() != "-1")//项目类别ID
            {
                strWhere = PageTools.AddWhere(strWhere, "ProjectTypeID=" + ProjectTypeID);
            }
            if (!string.IsNullOrEmpty(LaboratoryID) && LaboratoryID.Trim() != "-1")//实验室ID
            {
                strWhere = PageTools.AddWhere(strWhere, "LaboratoryID=" + LaboratoryID);
            }
            try
            {
                dt = tProject.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public ActionResult ProjectEdit(E_tb_Project eProject, string EditType, int? InfoID)
        {
            ViewData["AreaList"] = Knowledge.GetAreaList(false);
            ViewData["ProjectTypeList"] = Knowledge.GetTypeDictList(false, 2);
            ViewData["LaboratoryList"] = Knowledge.GetLaboratoryList(false);
            ViewData["PesCheckList"] = Knowledge.GetIsOrNo(false);
            if (EditType == "Edit")
            {
                eProject = tProject.GetModel(Convert.ToInt32(InfoID));
            }
            eProject.EditType = EditType;
            return View(eProject);
        }

        /// <summary>
        /// 保存实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eDetectProject">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_Project eProject)
        {
            string msg = "0";
            eProject.UpdateTime = DateTime.Now;
            if (eProject.EditType == "Add")
            {
                tProject.Add(eProject);
                msg = "1";
            }
            else
            {
                tProject.Update(eProject);
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
            string str = (tProject.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取模版文件地址
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public JsonResult GetFileURLForView(int wid)
        {
            var model = tProject.GetModel(wid);
            string iFile = "" + model.FilePath;
            return Json(iFile, JsonRequestBehavior.AllowGet);
        }

    }
}
