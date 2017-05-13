using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.OriginalRecord;
using System.Data;
using Model.OriginalRecord;
using Common;
using BLL.Laboratory;
using BLL.EntrustManage;
using System.Text;
using System.IO;
using System.Web.UI;
using BLL.PersonnelManage;
using Model.Laboratory;
using System.Text.RegularExpressions;
using BLL;
using Model;
using BLL.RoleManage;
using BLL.ExpePlan;
using Model.ExpePlan;
using Model.TestReport;
using BLL.TestReport;
using Model.EntrustManage;
using System.Collections;

namespace Web.Controllers
{
    public class OriginalRecordController : BaseController
    {
        T_tb_Area tArea = new T_tb_Area();
        T_tb_OriginalRecord tOriginalRecord = new T_tb_OriginalRecord(); //原始记录管理
        T_tb_Project tProject = new T_tb_Project();//项目管理
        T_tb_EntrustTesting tEntrustTesting = new T_tb_EntrustTesting();//委托检验管理
        T_tb_InPersonnel tInPersonnel = new T_tb_InPersonnel();//内部人员管理
        tb_SampleBLL tSample = new tb_SampleBLL();//样品管理
        T_tb_RecordSample tRecordSample = new T_tb_RecordSample();//原始记录样品计算结果
        T_tb_ExpePlan tExpePlan = new T_tb_ExpePlan();//实验计划
        T_tb_TestReport tTestReport = new T_tb_TestReport();//检验报告
        T_tb_TestReportData tTestReportData = new T_tb_TestReportData();//检验报告数据

        //
        // GET: /Laboratory/

        public ActionResult OriginalRecordList(E_tb_OriginalRecord eOriginalRecord)
        {
            ViewData["AreaList"] = PageTools.GetSelectList(tArea.GetList("").Tables[0], "AreaID", "AreaName", true);
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("").Tables[0], "ProjectID", "ProjectName", true);
            if (Request["ApprovalPersonnelName"] != null)
                ViewData["ApprovalPersonnelName"] = Request["ApprovalPersonnelName"].ToString();
            else
                ViewData["ApprovalPersonnelName"] = "";
            ViewBag._userName = CurrentUserInfo.UserName;
            eOriginalRecord.AreaID = CurrentUserInfo.AreaID;
            ViewBag.IsDisabled = (CurrentUserInfo.RoleID != 1) ? "true" : "false"; //权限判断
            return View(eOriginalRecord);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string AreaID, string ProjectID, string StartTime, string EndTime, string TaskNo, string RecordID)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "";
            if (!string.IsNullOrEmpty(RecordID) && RecordID != "0")
            {
                strWhere = PageTools.AddWhere(strWhere, "T.RecordID=" + RecordID);
            }
            if (!string.IsNullOrEmpty(AreaID) && AreaID != "-1")
            {
                strWhere = PageTools.AddWhere(strWhere, "T.AreaID=" + AreaID);
            }
            if (!string.IsNullOrEmpty(ProjectID) && ProjectID != "-1")
            {
                strWhere = PageTools.AddWhere(strWhere, "T.ProjectID=" + ProjectID);
            }
            if (!string.IsNullOrEmpty(StartTime))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.DetectTime>=cast('" + StartTime + "' as datetime)");
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.DetectTime<=cast('" + EndTime + "' as datetime)");
            }
            if (!string.IsNullOrEmpty(TaskNo))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.TaskNo like  '%" + TaskNo + "%'");
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
                dt = tOriginalRecord.GetListByPage(strWhere, "", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
                //dt.Columns.Add("ApprovalPersonnelID");
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    try
                //    {
                //        dt.Rows[i]["ApprovalPersonnelID"] = tDetectProject.GetListCountForReport(dt.Rows[i], "合格");
                //    }
                //    catch
                //    {
                //        continue;
                //    }
                //}
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
        public ActionResult OriginalRecordEdit(E_tb_OriginalRecord eOriginalRecord, string EditType, int? InfoID, int? ProjectID, int? SampleID)
        {
            if (eOriginalRecord == null)
            {
                eOriginalRecord = new E_tb_OriginalRecord();
            }
            //获取符合格式要求的项目列表

            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetListByOriginalRecord(""), "ProjectID", "ProjectName", false);
            eOriginalRecord = tOriginalRecord.GetModel(Convert.ToInt32(InfoID));
            ViewData["InsStandList"] = new SelectList(new List<SelectListItem>());
            //if (!String.IsNullOrEmpty(eOriginalRecord.InsStand))
            //{
            //    List<SelectListItem> list = new List<SelectListItem>();

            //    list.Add(new SelectListItem() { Text = eOriginalRecord.InsStand, Value = eOriginalRecord.InsStand, Selected = true });

            //    ViewData["InsStandList"] = new SelectList(list, "Value", "Text");
            //}
            //else
            //{
                try
                {
                    String InsStandList = new BLL.Laboratory.T_tb_Project().GetModel(eOriginalRecord.ProjectID.Value).InsStand;
                    if (!String.IsNullOrEmpty(InsStandList))
                    {
                        String[] ins = InsStandList.Split('、');
                        if (ins.Length > 0)
                        {
                            List<SelectListItem> list = new List<SelectListItem>();
                            for (int i = 0; i < ins.Length; i++)
                            {
                                if (!String.IsNullOrEmpty(eOriginalRecord.InsStand))
                                {
                                    list.Add(new SelectListItem() { Text = ins[i], Value = ins[i],Selected=true });
                                }
                                else
                                {
                                    list.Add(new SelectListItem() { Text = ins[i], Value = ins[i] });
                                }
                            }
                            ViewData["InsStandList"] = new SelectList(list, "Value", "Text");
                        }
                    }
                }
                catch
                {
                }
            //}
            if (eOriginalRecord.DetectPersonnelID != null && eOriginalRecord.DetectPersonnelID > 0)
            {
                eOriginalRecord.DetectPersonnelName = tInPersonnel.GetModel(Convert.ToInt32(eOriginalRecord.DetectPersonnelID)).PersonnelName;
            }
            DataTable SampleDt = tSample.GetList(" id = " + eOriginalRecord.SampleID).Tables[0];
            ViewData["SampleList"] = PageTools.GetSelectList(SampleDt, "id", "name", false);
            ViewData["ExpePlanList"] = PageTools.GetSelectList(tExpePlan.GetList("ProjectID=" + eOriginalRecord.ProjectID).Tables[0], "TaskNo", "TaskNo", false);
            ViewBag.FilePath = eOriginalRecord.FilePath;
            ViewBag.DetectPersonnelID = CurrentUserInfo.PersonnelID;
            ViewBag.DetectPersonnelName = CurrentUserInfo.PersonnelName;
            ViewBag.SampleID = eOriginalRecord.SampleID;
            ViewBag.ProjectID = eOriginalRecord.ProjectID;
            eOriginalRecord.EditType = EditType;

            #region 文档预览
            string filename = eOriginalRecord.FilePath;
            E_tb_Project eProject = tProject.GetModel(Convert.ToInt32(eOriginalRecord.ProjectID));
            if (!string.IsNullOrEmpty(filename))
            {
                Page page = new Page();
                string controlOutput = string.Empty;
                PageOffice.PageOfficeCtrl pc = new PageOffice.PageOfficeCtrl();
                pc.SaveFilePage = "/OriginalRecord/SaveDoc?filename=" + filename;
                pc.ServerPage = "/pageoffice/server.aspx";

                PageOffice.ExcelWriter.Workbook wb = new PageOffice.ExcelWriter.Workbook();
                PageOffice.ExcelWriter.Sheet sheetOrder = wb.OpenSheet("Sheet1");
                PageOffice.ExcelWriter.Table table = sheetOrder.OpenTable(eProject.SampleDataRange.Replace("：", ":").ToUpper());
                pc.SetWriter(wb);
                pc.SaveDataPage = "/OriginalRecord/SaveData?FilePath=" + filename + "&ProjectID=" + eOriginalRecord.ProjectID.ToString();

                if (EditType != "Edit" && eProject.IsPesCheck != 1)
                {
                    tb_Sample eSample = tSample.GetModel(int.Parse(eOriginalRecord.SampleID.ToString()));

                    ArrayList CellArr = new ArrayList { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                    string StrDataRange = eProject.SampleDataRange.Replace("：", ":").ToUpper();
                    int CellStartIndex = CellArr.IndexOf(StrDataRange.Split(':')[0].Substring(0, 1).ToUpper());
                    int DRangeStartIndex = int.Parse(StrDataRange.Split(':')[0].Substring(1, StrDataRange.Split(':')[0].Length - 1)) + 1;
                    int DRangeEndIndex = int.Parse(StrDataRange.Split(':')[1].Substring(1, StrDataRange.Split(':')[0].Length - 1));

                    //定义Workbook对象
                    PageOffice.ExcelWriter.Workbook workBook = new PageOffice.ExcelWriter.Workbook();
                    //定义Sheet对象，"Sheet1"是打开的Excel表单的名称
                    PageOffice.ExcelWriter.Sheet sheet = workBook.OpenSheet("Sheet1");
                    for (int i = DRangeStartIndex; i <= DRangeEndIndex; i++)
                    {
                        //或者直接给Cell赋值
                        sheet.OpenCell(CellArr[CellStartIndex].ToString() + i).Value = eSample.sampleNum;                         //样品编号
                        sheet.OpenCell(CellArr[CellStartIndex + 1].ToString() + i).Value = eSample.name;                          //样品名称
                        sheet.OpenCell(CellArr[CellStartIndex + 2].ToString() + i).Value = eSample.productDate.ToString(); ;      //成品日期
                        sheet.OpenCell(CellArr[CellStartIndex + 3].ToString() + i).Value = eSample.detectionDate.ToString();      //抽样日期
                    }
                    pc.SetWriter(workBook);// 注意不要忘记此代码，如果缺少此句代码，不会赋值成功。
                }

                var openmodeltype = PageOffice.OpenModeType.docAdmin;
                try
                {
                    var filenames = filename.Split('.');
                    switch (filenames[1])
                    {
                        case "doc":
                            openmodeltype = PageOffice.OpenModeType.docNormalEdit;
                            break;
                        case "docx":
                            openmodeltype = PageOffice.OpenModeType.docNormalEdit;
                            break;
                        case "xlsx":
                            openmodeltype = PageOffice.OpenModeType.xlsNormalEdit;
                            break;
                        case "xls":
                            openmodeltype = PageOffice.OpenModeType.xlsNormalEdit;
                            break;
                        case "pptx":
                            openmodeltype = PageOffice.OpenModeType.pptNormalEdit;
                            break;
                        case "ppt":
                            openmodeltype = PageOffice.OpenModeType.pptNormalEdit;
                            break;
                    }
                }
                catch
                {

                }
                pc.WebOpen("/UpFile/" + filename, openmodeltype, "s");
                page.Controls.Add(pc);
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb))
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        Server.Execute(page, htw, false); controlOutput = sb.ToString();
                    }
                }
                ViewBag.EditorHtml = controlOutput;
            }
            #endregion

            String InsStand = "";
            if (ProjectID != null && ProjectID > 0)
            {
                int FirstProjectID = Convert.ToInt32(ProjectID);
                try
                {
                    InsStand = new BLL.OriginalRecord.T_tb_OriginalRecord().GetModel(FirstProjectID).InsStand;
                }
                catch
                {
                }
                eOriginalRecord.InsStand = InsStand;
            }
            return View(eOriginalRecord);
        }

        /// <summary>
        /// 添加原始记录
        /// </summary>
        public ActionResult OriginalRecordAdd(E_tb_OriginalRecord eOriginalRecord, string EditType, int? InfoID, int? ProjectID, int? SampleID)
        {

            if (eOriginalRecord == null)
            {
                eOriginalRecord = new E_tb_OriginalRecord();
            }
            //获取符合格式要求的项目列表
            //ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("FilePath is not null and FilePath !='' and (SampleDataRange like '%:%' or SampleDataRange like '%：%')").Tables[0], "ProjectID", "ProjectName", false);
            DataTable SampleDt = tSample.GetList("id in (select SampleID from tb_ExpePlan where Status=0)").Tables[0];
            ViewData["SampleList"] = PageTools.GetSelectList(SampleDt, "id", "name", false);
            string strWhere = "FilePath is not null and FilePath !='' and (SampleDataRange like '%:%' or SampleDataRange like '%：%') and " + "ProjectID in (select ProjectID from tb_ExpePlan where Status=0 and SampleID=" + SampleDt.Rows[0]["id"].ToString() + ")";
            if (SampleID != null)
            {
                strWhere = "FilePath is not null and FilePath !='' and (SampleDataRange like '%:%' or SampleDataRange like '%：%') and " + "ProjectID in (select ProjectID from tb_ExpePlan where Status=0 and SampleID=" + SampleID + ")";
            }
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetListByOriginalRecord(strWhere), "ProjectID", "ProjectName", false);

            if (EditType == "Edit")
            {
                eOriginalRecord = tOriginalRecord.GetModel(Convert.ToInt32(InfoID));
                if (eOriginalRecord.DetectPersonnelID != null && eOriginalRecord.DetectPersonnelID > 0)
                {
                    eOriginalRecord.DetectPersonnelName = tInPersonnel.GetModel(Convert.ToInt32(eOriginalRecord.DetectPersonnelID)).PersonnelName;
                }
                ViewData["InsStandList"] = new SelectList(new List<SelectListItem>());
                if (!String.IsNullOrEmpty(eOriginalRecord.InsStand))
                {
                    List<SelectListItem> list = new List<SelectListItem>();

                    list.Add(new SelectListItem() { Text = eOriginalRecord.InsStand, Value = eOriginalRecord.InsStand, Selected = true });

                    ViewData["InsStandList"] = new SelectList(list, "Value", "Text");
                }


                ViewData["ExpePlanList"] = PageTools.GetSelectList(tExpePlan.GetList("ProjectID=" + eOriginalRecord.ProjectID).Tables[0], "TaskNo", "TaskNo", false);
            }
            else
            {
                int FirstSampleID = int.Parse((this.ViewData["SampleList"] as SelectList).First().Value);
                if (SampleID != null && SampleID > 0)
                {
                    FirstSampleID = Convert.ToInt32(SampleID);
                }

                int FirstProjectID = 0;
                if ((this.ViewData["ProjectList"] as SelectList).Count() > 0)
                {
                    FirstProjectID = int.Parse((this.ViewData["ProjectList"] as SelectList).First().Value);
                }
                string projectwhere = "";
                if (ProjectID > 0)
                {
                    projectwhere += "" + ProjectID;
                }
                else
                {
                    projectwhere += "" + FirstProjectID;
                }
                projectwhere += " and SampleID=" + FirstSampleID;
                ViewData["ExpePlanList"] = PageTools.GetSelectList(tExpePlan.GetList("ProjectID=" + projectwhere).Tables[0], "TaskNo", "TaskNo", false);

                if (FirstProjectID == 0)
                {
                    return View(eOriginalRecord);
                }
                ViewData["InsStandList"] = new SelectList(new List<SelectListItem>());
                String InsStand = "";
                if (ProjectID != null && ProjectID > 0)
                {
                    FirstProjectID = Convert.ToInt32(ProjectID);
                }
                if (FirstProjectID > 0)
                {
                    try
                    {
                        InsStand = new BLL.Laboratory.T_tb_Project().GetModel(FirstProjectID).InsStand;
                        if (!String.IsNullOrEmpty(InsStand))
                        {
                            String[] ins = InsStand.Split('、');
                            if (ins.Length > 0)
                            {
                                List<SelectListItem> list = new List<SelectListItem>();
                                for (int i = 0; i < ins.Length; i++)
                                {
                                    list.Add(new SelectListItem() { Text = ins[i], Value = ins[i], Selected = true });
                                }
                                ViewData["InsStandList"] = new SelectList(list, "Value", "Text");
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                eOriginalRecord.InsStand = InsStand;
                eOriginalRecord.SampleID = FirstSampleID;
                eOriginalRecord.ProjectID = FirstProjectID;

                try
                {
                    eOriginalRecord.DetectTime = tExpePlan.GetModelList(string.Format("Status=0 and SampleID={0} and ProjectID={1}", FirstSampleID, FirstProjectID)).First().InspectTime;
                }
                catch
                {

                }
                string TempFileName = tProject.GetModel(FirstProjectID).FilePath;
                string Suffix = TempFileName.Split('.')[1];
                string NewFileName = Guid.NewGuid().ToString() + "." + Suffix;
                string TempFilePath = Server.MapPath("~/UpFile/" + tProject.GetModel(FirstProjectID).FilePath);
                string NewFilePath = Server.MapPath("~/UpFile/OriginalRecordFile/" + NewFileName);
                try
                {
                    System.IO.File.Copy(TempFilePath, NewFilePath);
                }
                catch (Exception ex)
                {
                    var script = ex.Message;
                    return Content(script, "text/html");
                }
                eOriginalRecord.FilePath = "OriginalRecordFile/" + NewFileName; //显示默认的模版目录
            }
            ViewBag.FilePath = eOriginalRecord.FilePath;
            ViewBag.DetectPersonnelID = CurrentUserInfo.PersonnelID;
            ViewBag.DetectPersonnelName = CurrentUserInfo.PersonnelName;
            ViewBag.SampleID = eOriginalRecord.SampleID;
            ViewBag.ProjectID = eOriginalRecord.ProjectID;
            eOriginalRecord.EditType = EditType;
            #region 文档预览
            string filename = eOriginalRecord.FilePath;
            E_tb_Project eProject = tProject.GetModel(Convert.ToInt32(eOriginalRecord.ProjectID));
            if (!string.IsNullOrEmpty(filename))
            {
                Page page = new Page();
                string controlOutput = string.Empty;
                PageOffice.PageOfficeCtrl pc = new PageOffice.PageOfficeCtrl();
                pc.SaveFilePage = "/OriginalRecord/SaveDoc?filename=" + filename;
                pc.ServerPage = "/pageoffice/server.aspx";

                PageOffice.ExcelWriter.Workbook wb = new PageOffice.ExcelWriter.Workbook();
                PageOffice.ExcelWriter.Sheet sheetOrder = wb.OpenSheet("Sheet1");
                PageOffice.ExcelWriter.Table table = sheetOrder.OpenTable(eProject.SampleDataRange.Replace("：", ":").ToUpper());
                pc.SetWriter(wb);
                pc.SaveDataPage = "/OriginalRecord/SaveData?FilePath=" + filename + "&ProjectID=" + eOriginalRecord.ProjectID.ToString();

                if (EditType != "Edit" && eProject.IsPesCheck != 1)
                {
                    tb_Sample eSample = tSample.GetModel(int.Parse(eOriginalRecord.SampleID.ToString()));

                    ArrayList CellArr = new ArrayList { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
                    string StrDataRange = eProject.SampleDataRange.Replace("：", ":").ToUpper();
                    int CellStartIndex = CellArr.IndexOf(StrDataRange.Split(':')[0].Substring(0, 1).ToUpper());
                    int DRangeStartIndex = int.Parse(StrDataRange.Split(':')[0].Substring(1, StrDataRange.Split(':')[0].Length - 1)) + 1;
                    int DRangeEndIndex = int.Parse(StrDataRange.Split(':')[1].Substring(1, StrDataRange.Split(':')[0].Length - 1));

                    //定义Workbook对象
                    PageOffice.ExcelWriter.Workbook workBook = new PageOffice.ExcelWriter.Workbook();
                    //定义Sheet对象，"Sheet1"是打开的Excel表单的名称
                    PageOffice.ExcelWriter.Sheet sheet = workBook.OpenSheet("Sheet1");
                    for (int i = DRangeStartIndex; i <= DRangeEndIndex; i++)
                    {
                        //或者直接给Cell赋值
                        sheet.OpenCell(CellArr[CellStartIndex].ToString() + i).Value = eSample.sampleNum;                         //样品编号
                        sheet.OpenCell(CellArr[CellStartIndex + 1].ToString() + i).Value = eSample.name;                          //样品名称
                        sheet.OpenCell(CellArr[CellStartIndex + 2].ToString() + i).Value = eSample.productDate.ToString(); ;      //成品日期
                        sheet.OpenCell(CellArr[CellStartIndex + 3].ToString() + i).Value = eSample.detectionDate.ToString();      //抽样日期
                    }
                    pc.SetWriter(workBook);// 注意不要忘记此代码，如果缺少此句代码，不会赋值成功。
                }

                var openmodeltype = PageOffice.OpenModeType.docAdmin;
                try
                {
                    var filenames = filename.Split('.');
                    switch (filenames[1])
                    {
                        case "doc":
                            openmodeltype = PageOffice.OpenModeType.docNormalEdit;
                            break;
                        case "docx":
                            openmodeltype = PageOffice.OpenModeType.docNormalEdit;
                            break;
                        case "xlsx":
                            openmodeltype = PageOffice.OpenModeType.xlsNormalEdit;
                            break;
                        case "xls":
                            openmodeltype = PageOffice.OpenModeType.xlsNormalEdit;
                            break;
                        case "pptx":
                            openmodeltype = PageOffice.OpenModeType.pptNormalEdit;
                            break;
                        case "ppt":
                            openmodeltype = PageOffice.OpenModeType.pptNormalEdit;
                            break;
                    }
                }
                catch
                {

                }
                pc.WebOpen("/UpFile/" + filename, openmodeltype, "s");
                page.Controls.Add(pc);
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb))
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        Server.Execute(page, htw, false); controlOutput = sb.ToString();
                    }
                }
                ViewBag.EditorHtml = controlOutput;
            }
            #endregion
            return View(eOriginalRecord);
        }

        /// <summary>
        /// 保存实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eOriginalRecord">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_OriginalRecord eOriginalRecord)
        {
            string msg = "0";
            eOriginalRecord.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eOriginalRecord.AreaID = CurrentUserInfo.AreaID;
            if (eOriginalRecord.EditType == "Add")
            {

                tOriginalRecord.Add(eOriginalRecord);
                msg = "1";
            }
            else
            {
                tOriginalRecord.Update(eOriginalRecord);
                msg = "1";
            }
            //关联样品数据
            tRecordSample.UpdateRecordIDByFilePath(eOriginalRecord.RecordID, eOriginalRecord.FilePath);

            //生成检验报告
            E_tb_ExpePlan eExpePlan = tExpePlan.GetModelList("TaskNo='" + eOriginalRecord.TaskNo + "' and SampleID=" + eOriginalRecord.SampleID.Value).FirstOrDefault();
            //E_tb_ExpePlan eExpePlan = tExpePlan.GetModelList(" Status=0 and SampleID=" + eOriginalRecord.SampleID.Value).FirstOrDefault();
            if (eExpePlan != null)
            {
                //tb_Sample eSample = tSample.GetModel(int.Parse(eExpePlan.SampleID.ToString()));
                Updatethings(eOriginalRecord, eExpePlan);
            }
            else
            {
                /*这一段章建国写的如果出错请删除
                eExpePlan = new E_tb_ExpePlan();
                var tempsample = tSample.GetModel(eOriginalRecord.SampleID.Value);
                eExpePlan.PlanTypeID = 1;
                eExpePlan.ProjectID = eOriginalRecord.ProjectID;
                eExpePlan.SampleID = tempsample.id;
                eExpePlan.InspectTime = eOriginalRecord.DetectTime;
                eExpePlan.InspectMethod = tempsample.testMethod;
                if (!String.IsNullOrEmpty(tempsample.InspectAddress))
                {
                    eExpePlan.InspectPlace = tempsample.InspectAddress;
                }
                else if (!String.IsNullOrEmpty(tempsample.detectionAdress))
                {
                    eExpePlan.InspectPlace = tempsample.detectionAdress;
                }
                eExpePlan.HeadPersonnelID = CurrentUserInfo.PersonnelID;
                eExpePlan.TaskNo = eOriginalRecord.TaskNo;
                eExpePlan.AreaID = CurrentUserInfo.AreaID;
                eExpePlan.EditPersonnelID = CurrentUserInfo.PersonnelID;
                eExpePlan.Status = 0;
                eExpePlan.UpdateTime = DateTime.Now;
                tExpePlan.Add(eExpePlan);
                eExpePlan = tExpePlan.GetModelList("TaskNo='" + eOriginalRecord.TaskNo + "' and SampleID=" + eOriginalRecord.SampleID.Value).FirstOrDefault();
                Updatethings(eOriginalRecord,eExpePlan);*/
            }
            return msg;
        }

        private void Updatethings(E_tb_OriginalRecord eOriginalRecord, E_tb_ExpePlan eExpePlan)
        {
            tb_Sample eSample = tSample.GetModel(eOriginalRecord.SampleID.Value);
            string productNum = eSample.protNum;//产品批次
            E_tb_TestReport eTestReport = null;
            //if (!String.IsNullOrEmpty(productNum))
            //{
            //    eTestReport = tTestReport.GetModelList("productNum='" + productNum + "'").First();
            //}
            var tempmodel = tTestReport.GetModelList(" SampleNum = '" + eSample.sampleNum + "'");
            if (tempmodel != null && tempmodel.Count > 0)
            {
                eTestReport = tempmodel.First();
                eTestReport.SampleNum = eSample.sampleNum;//样品编号
                eTestReport.SampleName = eSample.name;//样品名称
            }
            if (eTestReport == null)
            {
                eTestReport = new E_tb_TestReport();
                eTestReport.productNum = productNum; //批次号
                eTestReport.SampleNum = eSample.sampleNum;//样品编号
                eTestReport.SampleName = eSample.name;//样品名称
                eTestReport.ProductionTime = eSample.productDate;//生产日期
                eTestReport.Specifications = eSample.modelType;//规格型号
                eTestReport.ShelfLife = eSample.expirationDate;//保质期
                //string Department = "/";
                //if (eExpePlan.TaskNo.IndexOf("JN") < 0)
                //{
                //    E_tb_EntrustTesting eEntrustTesting = tEntrustTesting.GetModelList("TaskNo='" + eExpePlan.TaskNo + "'").FirstOrDefault();
                //    if (eEntrustTesting != null)
                //    {
                //        Department = eEntrustTesting.EntrustCompany;
                //    }
                //}
                string Department = "/";
                if (eSample.isDetection)
                {
                    Department = eSample.detectionCompany;
                }
                else
                {
                    var clint = new BLL.ClientManage.T_tb_ClientManage().GetModel(Convert.ToInt32(eSample.InspectCompany));
                    Department = clint.ClientName;
                }
                eTestReport.Department = Department;//送/抽检单位
                eTestReport.SendTestAddress = eSample.InspectAddress;//送检单位地址
                eTestReport.SamplingPlace = eSample.detectionAdress;//抽样地点
                eTestReport.SamplingCompany = eSample.detectionCompany; //抽样单位
                eTestReport.SamplingPersonnel = eSample.detectionUser;//抽样者
                eTestReport.Packing = eSample.packaging;//包装形式
                eTestReport.SamplingTime = eSample.detectionDate;//抽样日期
                //eTestReport.TestBasis = eSample.testMethod;//检验依据
                eTestReport.TestBasis = new BLL.Laboratory.T_tb_Project().GetModel(eOriginalRecord.ProjectID.Value).ExpeMethod;

                eTestReport.TestTime = eOriginalRecord.DetectTime;//检验日期
                DataTable dt = tOriginalRecord.GetRecordIDListBySampleID(int.Parse(eExpePlan.SampleID.ToString()));
                string RecordIDS = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RecordIDS += dt.Rows[i]["RecordID"].ToString() + ",";
                    }
                    RecordIDS = RecordIDS.TrimEnd(',');
                }
                eTestReport.RecordIDS = RecordIDS;//原始记录IDS
                DataTable dtExpePlan = tExpePlan.GetList("SampleID=" + eExpePlan.SampleID.ToString()).Tables[0];
                string TaskNoS = "";
                if (dtExpePlan != null && dtExpePlan.Rows.Count > 0)
                {
                    for (int i = 0; i < dtExpePlan.Rows.Count; i++)
                    {
                        TaskNoS += dtExpePlan.Rows[i]["PlanID"].ToString() + ",";
                    }
                    TaskNoS = TaskNoS.TrimEnd(',');
                }
                eTestReport.TaskNoS = TaskNoS;//任务单号 对应的检验计划IDS 
                eTestReport.EditPersonnelID = CurrentUserInfo.PersonnelID;
                eTestReport.AreaID = CurrentUserInfo.AreaID;
                eTestReport.AddTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                eTestReport.UpdateTime = DateTime.Now;
                eTestReport.ReportID = tTestReport.Add(eTestReport);
            }
            else
            {
                DataTable dt = tOriginalRecord.GetRecordIDListBySampleID(int.Parse(eExpePlan.SampleID.ToString()));
                string RecordIDS = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RecordIDS += dt.Rows[i]["RecordID"].ToString() + ",";
                    }
                    RecordIDS = RecordIDS.TrimEnd(',');
                }
                eTestReport.RecordIDS = RecordIDS;//原始记录IDS
                DataTable dtExpePlan = tExpePlan.GetList("SampleID=" + eExpePlan.SampleID.ToString()).Tables[0];
                string TaskNoS = "";
                if (dtExpePlan != null && dtExpePlan.Rows.Count > 0)
                {
                    for (int i = 0; i < dtExpePlan.Rows.Count; i++)
                    {
                        TaskNoS += dtExpePlan.Rows[i]["PlanID"].ToString() + ",";
                    }
                    TaskNoS = TaskNoS.TrimEnd(',');
                }
                eTestReport.TaskNoS = TaskNoS;//任务单号 对应的检验计划IDS 
                eTestReport.AreaID = CurrentUserInfo.AreaID;
                eTestReport.EditPersonnelID = CurrentUserInfo.PersonnelID;
                eTestReport.UpdateTime = DateTime.Now;
                eTestReport.TestBasis = new BLL.Laboratory.T_tb_Project().GetModel(eOriginalRecord.ProjectID.Value).ExpeMethod;
                tTestReport.Update(eTestReport);
            }

            //更新检验报告数据
            List<E_tb_TestReportData> eTestReportDataList = tTestReportData.GetModelList("RecordFilePath='" + eOriginalRecord.FilePath + "'");
            if (eTestReportDataList != null)
            {
                E_tb_Project eProject = tProject.GetModel(Convert.ToInt32(eOriginalRecord.ProjectID));
                if (eProject.IsPesCheck != null && int.Parse(eProject.IsPesCheck.ToString()) == 1)//判断是否为农药残留检查项目
                {
                    foreach (E_tb_TestReportData eTestReportData in eTestReportDataList)
                    {
                        eTestReportData.RecordID = eOriginalRecord.RecordID;    //原始记录ID
                        eTestReportData.ReportID = eTestReport.ReportID;        //检验报告ID
                        eTestReportData.TestStandard = eProject.ExpeMethod;     //检验标准

                        if (!String.IsNullOrEmpty(eOriginalRecord.InsStand))
                        {
                            String[] strs = eOriginalRecord.InsStand.Split('：');
                            if (strs == null || strs.Length <= 2)
                            {
                                strs = eOriginalRecord.InsStand.Split(':');
                            }
                            if (strs != null && strs.Length >= 2)
                            {
                                String str = strs[1];
                                int result = 0;
                                if (!String.IsNullOrEmpty(str))
                                {
                                    // 正则表达式剔除非数字字符（不包含小数点.） 
                                    str = Regex.Replace(str, @"[^\d.\d]", "");
                                    // 如果是数字，则转换为decimal类型 
                                    if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                                    {
                                        result = int.Parse(str);
                                    }
                                    if (!String.IsNullOrEmpty(eTestReportData.TestResult))
                                    {
                                        Decimal _testResult = Convert.ToDecimal(eTestReportData.TestResult);
                                        if (_testResult <= result)
                                        {
                                            eTestReportData.QualifiedLevel = "合格";
                                        }
                                        else
                                        {
                                            eTestReportData.QualifiedLevel = "不合格";
                                        }
                                    }
                                }
                            }
                        }

                        tTestReportData.Update(eTestReportData);
                    }
                }
                else
                {
                    foreach (E_tb_TestReportData eTestReportData in eTestReportDataList)
                    {
                        eTestReportData.RecordID = eOriginalRecord.RecordID;    //原始记录ID
                        eTestReportData.ReportID = eTestReport.ReportID;        //检验报告ID
                        eTestReportData.TestName = eProject.ProjectName;        //检验名称/检验项目名称
                        eTestReportData.TestStandard = eProject.ExpeMethod;     //检验标准
                        if (!String.IsNullOrEmpty(eOriginalRecord.InsStand))
                        {
                            String[] strs = eOriginalRecord.InsStand.Split('：');
                            if (strs == null || strs.Length <= 2)
                            {
                                strs = eOriginalRecord.InsStand.Split(':');
                            }
                            if (strs != null && strs.Length >= 2)
                            {
                                String str = strs[1];
                                int result = 0;
                                if (!String.IsNullOrEmpty(str))
                                {
                                    // 正则表达式剔除非数字字符（不包含小数点.） 
                                    str = Regex.Replace(str, @"[^\d.\d]", "");
                                    // 如果是数字，则转换为decimal类型 
                                    if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                                    {
                                        result = int.Parse(str);
                                    }
                                    if (!String.IsNullOrEmpty(eTestReportData.TestResult))
                                    {
                                        Decimal _testResult = Convert.ToDecimal(eTestReportData.TestResult);
                                        if (_testResult <= result)
                                        {
                                            eTestReportData.QualifiedLevel = "合格";
                                        }
                                        else
                                        {
                                            eTestReportData.QualifiedLevel = "不合格";
                                        }
                                    }
                                }
                            }
                        }
                        tTestReportData.Update(eTestReportData);
                    }
                }
            }
        }

        public ActionResult SaveData(string FilePath, string ProjectID)
        {
            PageOffice.ExcelReader.Workbook wb = new PageOffice.ExcelReader.Workbook();
            PageOffice.ExcelReader.Sheet sheet = wb.OpenSheet("Sheet1");
            E_tb_Project eProject = tProject.GetModel(int.Parse(ProjectID));
            PageOffice.ExcelReader.Table table = sheet.OpenTable(eProject.SampleDataRange.Replace("：", ":").ToUpper());

            DataTable dt = new DataTable();
            for (int i = 0; i < table.DataFields.Count; i++)
            {
                dt.Columns.Add(table.DataFields[i].Text);
            }
            table.NextRow();
            while (!table.EOF)
            {
                //获取提交的数值
                if (!table.DataFields.IsEmpty)
                {
                    DataRow row = dt.NewRow();
                    for (int i = 0; i < table.DataFields.Count; i++)
                    {
                        row[i] = table.DataFields[i].Text;
                    }
                    dt.Rows.Add(row);
                }

                try
                {
                    table.NextRow(); //循环进入下一行
                }
                catch
                {
                    break;
                }
            }

            //删除历史数据
            tRecordSample.DeleteListByWhere("RecordFilePath='" + FilePath + "'");
            tTestReportData.DeleteByWhere("RecordFilePath='" + FilePath + "'");

            //关联检验报告
            Regex reg = new Regex("^[0-9]+(.[0-9])?$");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (eProject.IsPesCheck != null && Convert.ToInt32(eProject.IsPesCheck.ToString()) == 1) //判断是否为检验农药残留项目
                {
                    DataRow item = dt.Rows[i];
                    string SampleName = item["样品名称"].ToString(); //样品名称
                    string strResult = item["复检值2"].ToString();//复检值2
                    if (strResult.Trim() == "")
                    {
                        strResult = item["最终值"].ToString();//最终值
                    }
                    if (!string.IsNullOrEmpty(SampleName.Trim()))
                    {
                        E_tb_TestReportData eTestReportData = new E_tb_TestReportData();
                        eTestReportData.RecordID = 0;               //原始记录ID
                        eTestReportData.RecordFilePath = FilePath;  //原始记录文件名
                        eTestReportData.ReportID = 0;               //检验报告ID
                        eTestReportData.TestName = SampleName;      //检验名称/检验项目名称 (农药残留检验项目，直接显示样品名称)
                        eTestReportData.TestStandard = "";          //检验标准
                        eTestReportData.TestResult = strResult;     //检验结果
                        eTestReportData.QualifiedLevel = "";        //是否合格
                        eTestReportData.TestPersonnelName = "";     //检验人
                        tTestReportData.Add(eTestReportData);
                    }
                }
                else
                {
                    DataRow item = dt.Rows[i];
                    string strSampleID = item["编号"].ToString();
                    string strResult = item["最终值"].ToString();
                    tb_Sample eSample = tSample.GetModelList("sampleNum='" + strSampleID.Trim() + "'").FirstOrDefault();
                    if (eSample != null && !string.IsNullOrEmpty(strResult))
                    {
                        E_tb_TestReportData eTestReportData = new E_tb_TestReportData();
                        eTestReportData.RecordID = 0;               //原始记录ID
                        eTestReportData.RecordFilePath = FilePath;  //原始记录文件名
                        eTestReportData.ReportID = 0;               //检验报告ID
                        eTestReportData.TestName = "";              //检验名称/检验项目名称
                        eTestReportData.TestStandard = "";          //检验标准
                        eTestReportData.TestResult = strResult;     //检验结果
                        eTestReportData.QualifiedLevel = "";        //是否合格
                        eTestReportData.TestPersonnelName = "";     //检验人
                        tTestReportData.Add(eTestReportData);
                    }
                }
            }
            table.Close();
            wb.Close();
            return View();
        }

        /// <summary>
        /// 删除实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="InfoID">要删除的实验室</param>
        /// <returns>返回是否删除成功</returns>
        public JsonResult Delete(int id)
        {
            tRecordSample.DeleteListByWhere("RecordID=" + id); //删除对应的样品记录信息
            string str = (tOriginalRecord.Delete(id)) ? "删除成功！" : "删除失败！";
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
            E_tb_OriginalRecord eOriginalRecord = tOriginalRecord.GetModel(wid);
            E_tb_Project eProject = tProject.GetModel(Convert.ToInt32(eOriginalRecord.ProjectID));
            string SaveFilePage = "/OriginalRecord/SaveDoc?filename=" + eOriginalRecord.FilePath;
            string SaveDataPage = "/OriginalRecord/SaveData?FilePath=" + eOriginalRecord.FilePath + "|ProjectID=" + eOriginalRecord.ProjectID.ToString();
            string DataRange = eProject.SampleDataRange.Replace("：", ":").ToUpper();
            string UrlParams = string.Format("filename={0}&SaveFilePage={1}&SaveDataPage={2}&DataRange={3}", eOriginalRecord.FilePath, SaveFilePage, SaveDataPage, DataRange);
            return Json(UrlParams, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据样品ID获取对应的 未完成的实验计划对应的项目
        /// </summary>
        /// <param name="SampleID"></param>
        /// <returns></returns>
        public JsonResult GetProjectList(string SampleID)
        {
            List<E_tb_Project> list = new List<E_tb_Project>();
            list = tProject.GetModelList("ProjectID in (select ProjectID from tb_ExpePlan where Status=0 and SampleID=" + SampleID + ")");
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据样品ID 项目ID
        /// </summary>
        /// <param name="SampleID"></param>
        /// <returns></returns>
        public JsonResult GetTaskList(string SampleID, string ProjectID)
        {
            List<E_tb_ExpePlan> list = new List<E_tb_ExpePlan>();
            list = new T_tb_ExpePlan().GetModelList(" SampleID=" + SampleID + " and ProjectID=" + ProjectID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #region 文件预览
        /// <summary>
        /// 通过pageoffice展示数据
        /// 作者：章建国
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public ActionResult FileView(string filename, string _pname, string _ptype)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                ViewBag._pname = _pname;
                ViewBag._ptype = _ptype;
                ViewBag.Message = "Your contact page.";
                Page page = new Page();
                string controlOutput = string.Empty;
                PageOffice.PageOfficeCtrl pc = new PageOffice.PageOfficeCtrl();
                pc.SaveFilePage = "/OriginalRecord/SaveDoc?filename=" + filename;
                pc.ServerPage = "/pageoffice/server.aspx";
                var openmodeltype = PageOffice.OpenModeType.docAdmin;
                try
                {
                    var filenames = filename.Split('.');
                    switch (filenames[1])
                    {
                        case "doc":
                            openmodeltype = PageOffice.OpenModeType.docNormalEdit;
                            break;
                        case "docx":
                            openmodeltype = PageOffice.OpenModeType.docNormalEdit;
                            break;
                        case "xlsx":
                            openmodeltype = PageOffice.OpenModeType.xlsNormalEdit;
                            break;
                        case "xls":
                            openmodeltype = PageOffice.OpenModeType.xlsNormalEdit;
                            break;
                        case "pptx":
                            openmodeltype = PageOffice.OpenModeType.pptNormalEdit;
                            break;
                        case "ppt":
                            openmodeltype = PageOffice.OpenModeType.pptNormalEdit;
                            break;
                    }
                }
                catch
                {

                }
                pc.WebOpen("/UpFile/" + filename, openmodeltype, "s");
                page.Controls.Add(pc);
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb))
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        Server.Execute(page, htw, false); controlOutput = sb.ToString();
                    }
                }
                ViewBag.EditorHtml = controlOutput;
            }
            return View();
        }

        /// <summary>
        /// 通过FlexPaper展示PDF
        /// 作者：章建国
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public ActionResult SWFShow(string filename)
        {
            ViewBag._SWFURL = filename;
            return View();
        }

        /// <summary>
        /// 保存在线修改的office文件
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveDoc(string filename)
        {
            ViewBag.Message = "Your app description page.";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "UpFile//" + filename;
            PageOffice.FileSaver fs = new PageOffice.FileSaver();
            fs.SaveToFile(filePath);
            fs.Close();

            return View();
        }
        #endregion
    }
}
