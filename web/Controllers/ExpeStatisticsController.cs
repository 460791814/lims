using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BLL.Laboratory;
using Model.Laboratory;
using Newtonsoft.Json;
using System.IO;

namespace Web.Controllers
{
    public class ExpeStatisticsController : BaseController
    {
        T_tb_Laboratory tLaboratory = new T_tb_Laboratory(); //实验室操作
        T_tb_DetectProject tDetectProject = new T_tb_DetectProject();//实验项目操作
        //
        // GET: /ExpeStatistics/

        public ActionResult ExpeStatisticsList()
        {
            ViewData["ddl_company"] = PublicClass.GetAreaList("请选择", CurrentUserInfo.AreaID.Value);
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
            string strWhere = "";
            if (CurrentUserInfo.DataRange != 1)
            {
                strWhere = "AreaID=" + CurrentUserInfo.AreaID;
            }
            List<E_tb_Laboratory> listmd = tLaboratory.GetModelList(strWhere);
            foreach (E_tb_Laboratory item in listmd)
            {
                list.Add(new SelectListItem() { Text = item.LaboratoryName, Value = item.LaboratoryID.ToString() });
            }
            ViewData["LaboratoryList"] = new SelectList(list, "Value", "Text");

            return View();
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string LaboratoryID, string StartTime, string EndTime)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = " T.LaboratoryID>0";
            if (LaboratoryID != "-1")
            {
                strWhere = " T.LaboratoryID=" + LaboratoryID;
            }

            if (StartTime != null && StartTime.Trim() != "")
            {
                strWhere += " and T.DetectTime>=cast('" + StartTime + "' as datetime)";
            }
            if (EndTime != null && EndTime.Trim() != "")
            {
                strWhere += " and T.DetectTime<cast('" + Convert.ToDateTime(EndTime).AddDays(1).ToShortDateString() + "' as datetime)";
            }

            if (CurrentUserInfo.DataRange != 1) //若当前用户不是超级管理员 全部数据权限
            {
                strWhere += " and T.LaboratoryID in (select LaboratoryID from tb_Laboratory where AreaID =" + CurrentUserInfo.AreaID + ")";
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



        public string GetListByReport(int pageNumber, int pageSize, string ddl_selecttype, string txt_dept, string ddl_type, string txt_search, string txt_StartTime, string txt_EndTime)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = " 1=1 ";
            try
            {
                if (!string.IsNullOrEmpty(txt_dept))
                {
                    switch (ddl_selecttype)
                    {
                        case "mhcx":
                            {
                                strWhere += " and Department like '%%" + txt_dept + "%%'";
                                break;
                            }
                        case "qzpp":
                            {
                                strWhere += " and Department = '" + txt_dept + "'";
                                break;
                            }
                    }
                }
                if (!string.IsNullOrEmpty(txt_search))
                {
                    switch (ddl_type)
                    {
                        case "ypmc":
                            {
                                strWhere += " and name like '%%"+txt_search+"%%'";
                                break;
                            }
                        case "jyxm":
                            {
                                strWhere += " and ProjectName like '%%" + txt_search + "%%'";
                                break;
                            }
                        case "jyr":
                            {
                                strWhere += " and TestPersonnelName like '%%" + txt_search + "%%'";
                                break;
                            }
                    }
                }
                if (!string.IsNullOrEmpty(txt_StartTime))
                {
                    strWhere += " and DetectTime >= '" + txt_StartTime + "'";
                }
                if (!string.IsNullOrEmpty(txt_EndTime))
                {
                    strWhere += " and DetectTime <= '" + txt_EndTime + "'";
                }

                dt = tDetectProject.GetListByReport(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
                dt.Columns.Add("QualifiedLevelA", typeof(int)); dt.Columns.Add("QualifiedLevelB", typeof(int));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        dt.Rows[i]["QualifiedLevelA"] = tDetectProject.GetListCountForReport(dt.Rows[i], "合格");
                        dt.Rows[i]["QualifiedLevelB"] = tDetectProject.GetListCountForReport(dt.Rows[i], "");
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch
            {
            }
            //string strJson = PublicClass.ToJson(dt, total);
            //张伟修改，增加合计
            DataTable dt2=dt.Clone();

            DataRow dr1=dt2.NewRow();

            dr1["name"] = "本页合计";
            dr1["QualifiedLevel"] = dt.Compute("sum(QualifiedLevel)", "");
            dr1["QualifiedLevelA"] = dt.Compute("sum(QualifiedLevelA)", "");
            dr1["QualifiedLevelB"] = dt.Compute("sum(QualifiedLevelB)", "");
            dt2.Rows.InsertAt(dr1, 0);

            DataRow dr2 = dt2.NewRow();

            dr2["name"] = "总合计";
            dr2["QualifiedLevel"] = tDetectProject.GetAllListCountForReport(strWhere,"");
            dr2["QualifiedLevelA"] = tDetectProject.GetAllListCountForReport(strWhere,"1");
            dr2["QualifiedLevelB"] = tDetectProject.GetAllListCountForReport(strWhere,"2");
            dt2.Rows.InsertAt(dr2, 1);
            string strJson = "{\"total\":" + total + ",\"rows\":" + JsonConvert.SerializeObject(dt) + ",\"footer\":" + JsonConvert.SerializeObject(dt2) + "}";
            
            //if (strJson.Trim() == "")
            //{
            //    strJson = "{\"total\":0,\"rows\":[]}";
            //}
            return strJson;
        }

        public FileResult ExportReport(string ddl_selecttype,string txt_dept, string ddl_type, string txt_search, string txt_StartTime, string txt_EndTime)
        {
            DataTable dt = new DataTable();
            System.IO.MemoryStream stream = new MemoryStream();
            #region 获取数据
            int total = 0;
            
            string strWhere = " 1=1 ";
            try
            {
                if (!string.IsNullOrEmpty(txt_dept))
                {
                    switch (ddl_selecttype)
                    {
                        case "mhcx":
                            {
                                strWhere += " and Department like '%%" + txt_dept + "%%'";
                                break;
                            }
                        case "qzpp":
                            {
                                strWhere += " and Department = '" + txt_dept + "'";
                                break;
                            }
                    }
                }
                if (!string.IsNullOrEmpty(txt_search))
                {
                    switch (ddl_type)
                    {
                        case "ypmc":
                            {
                                strWhere += " and name like '%%"+txt_search+"%%'";
                                break;
                            }
                        case "jyxm":
                            {
                                strWhere += " and ProjectName like '%%" + txt_search + "%%'";
                                break;
                            }
                        case "jyr":
                            {
                                strWhere += " and TestPersonnelName like '%%" + txt_search + "%%'";
                                break;
                            }
                    }
                }
                if (!string.IsNullOrEmpty(txt_StartTime))
                {
                    strWhere += " and DetectTime >= '" + txt_StartTime + "'";
                }
                if (!string.IsNullOrEmpty(txt_EndTime))
                {
                    strWhere += " and DetectTime <= '" + txt_EndTime + "'";
                }

                dt = tDetectProject.GetExportListByReport(strWhere,"").Tables[0];
                dt.Columns.Add("QualifiedLevelA", typeof(int)); dt.Columns.Add("QualifiedLevelB", typeof(int));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        dt.Rows[i]["QualifiedLevelA"] = tDetectProject.GetListCountForReport(dt.Rows[i], "合格");
                        dt.Rows[i]["QualifiedLevelB"] = tDetectProject.GetListCountForReport(dt.Rows[i], "");
                    }
                    catch
                    {
                        continue;
                    }
                }

                DataRow dr2 = dt.NewRow();

                dr2["name"] = "总合计";
                dr2["QualifiedLevel"] = tDetectProject.GetAllListCountForReport(strWhere, "");
                dr2["QualifiedLevelA"] = tDetectProject.GetAllListCountForReport(strWhere, "1");
                dr2["QualifiedLevelB"] = tDetectProject.GetAllListCountForReport(strWhere, "2");
                dt.Rows.InsertAt(dr2,dt.Rows.Count);

                stream = PublicClass.ExportReportToExcel(dt);
            }
            catch { }
            #endregion

            string filename = "实验统计列表" + DateTime.Now.ToFileTime() + ".xls";
            return File(stream, "application/vnd.ms-excel", filename);
        }
    }
}
