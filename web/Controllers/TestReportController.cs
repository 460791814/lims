using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.TestReport;
using System.Data;
using Model.TestReport;
using BLL.OriginalRecord;
using BLL.PersonnelManage;
using Common;
using BLL.RoleManage;
using BLL.DictManage;
using BLL.ExpePlan;
using System.Text;
using System.Diagnostics;
using Model.ExpePlan;
using System.Text.RegularExpressions;

namespace Web.Controllers
{
    public class TestReportController : BaseController
    {
        T_tb_TestReport tTestReport = new T_tb_TestReport();            //检验报告管理
        T_tb_OriginalRecord tOriginalRecord = new T_tb_OriginalRecord();//原始记录管理
        T_tb_InPersonnel tInPersonnel = new T_tb_InPersonnel();         //人员管理
        T_tb_Area tArea = new T_tb_Area();                              //区域/单位
        T_tb_TestReportData tTestReportData = new T_tb_TestReportData(); //检验数据
        T_tb_TypeDict tTypeDict = new T_tb_TypeDict();//类别字典
        T_tb_ExpePlan tExpePlan = new T_tb_ExpePlan();//实验计划管理

        //
        // GET: /Laboratory/

        public ActionResult TestReportList(E_tb_TestReport eTestReport)
        {
            ViewData["AreaList"] = PageTools.GetSelectList(tArea.GetList("").Tables[0], "AreaID", "AreaName", true);
            ViewBag._userName = CurrentUserInfo.UserName;
            return View(eTestReport);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string AreaID, string StartTime, string EndTime, string SampleNum, string SampleName, string Department, string MainTestPersonne, string ReportID, string SamplingTimes, string SamplingTimee)
        {
            Session["_AreaID"] = AreaID;
            Session["_StartTime"] = StartTime;
            Session["_EndTime"] = EndTime;
            Session["_SampleNum"] = SampleNum;
            Session["_SampleName"] = SampleName;
            Session["_Department"] = Department;
            Session["_MainTestPersonne"] = MainTestPersonne;
            Session["_SamplingTimes"] = SamplingTimes;
            Session["_SamplingTimee"] = SamplingTimee;
            Session["_ReportID"] = ReportID;
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "";
            if (!string.IsNullOrEmpty(ReportID) && ReportID != "0")
            {
                strWhere = PageTools.AddWhere(strWhere, "T.ReportID=" + ReportID);
            }
            if (!string.IsNullOrEmpty(AreaID) && AreaID != "-1")
            {
                strWhere = PageTools.AddWhere(strWhere, "T.AreaID=" + AreaID);
            }
            if (!string.IsNullOrEmpty(StartTime))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.IssuedTime>=cast('" + StartTime + "' as datetime)");
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.IssuedTime<=cast('" + EndTime + "' as datetime)");
            }
            if (!string.IsNullOrEmpty(SampleNum))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.SampleNum like  '%" + SampleNum + "%'");
            }
            if (!string.IsNullOrEmpty(SampleName))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.SampleName like  '%" + SampleName + "%'");
            }
            if (!string.IsNullOrEmpty(Department))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.Department like  '%" + Department + "%'");
            }
            if (!string.IsNullOrEmpty(MainTestPersonne))
            {
                strWhere = PageTools.AddWhere(strWhere, "D.PersonnelName like '%" + MainTestPersonne + "%'");
            }

            if (!string.IsNullOrEmpty(SamplingTimes))
            {
                strWhere = PageTools.AddWhere(strWhere, "SamplingTime>=cast('" + SamplingTimes + "' as datetime)");
            }
            if (!string.IsNullOrEmpty(SamplingTimee))
            {
                strWhere = PageTools.AddWhere(strWhere, "SamplingTime<=cast('" + SamplingTimee + "' as datetime)");
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
                //dt = tTestReport.GetListByPage(strWhere, "UpdateTime DESC,T.SampleName ASC", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
                dt = tTestReport.GetListByPage(strWhere, "TestTime DESC", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];

            }
            catch { }

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ApprovalPersonnelName = dt.Rows[i]["ApprovalPersonnelName"].ToString();
                    string RecordIDS = dt.Rows[i]["RecordIDS"].ToString();
                    StringBuilder strRecordIDS = new StringBuilder();
                    if (!string.IsNullOrEmpty(RecordIDS))
                    {
                        string[] ArrRecordIDS = RecordIDS.Split(',');
                        foreach (string item in ArrRecordIDS)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                strRecordIDS.Append(string.Format("<a href='/OriginalRecord/OriginalRecordList?RecordID={0}&ApprovalPersonnelName={1}' style='color:Blue; font-weight:bold;'>{0}</a>，", item, ApprovalPersonnelName));
                            }
                        }
                    }
                    dt.Rows[i]["RecordIDS"] = strRecordIDS.ToString().TrimEnd('，');

                    string TaskNoS = dt.Rows[i]["TaskNoS"].ToString();
                    StringBuilder strTaskNoS = new StringBuilder();
                    if (!string.IsNullOrEmpty(TaskNoS))
                    {
                        string[] ArrTaskNoS = TaskNoS.Split(',');
                        foreach (string item in ArrTaskNoS)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                strTaskNoS.Append(string.Format("<a href='/ExpePlan/ExpePlanList?PlanID={0}&ApprovalPersonnelName={1}' style='color:Blue; font-weight:bold;'>{0}</a>，", item, ApprovalPersonnelName));
                            }
                        }
                    }
                    dt.Rows[i]["TaskNoS"] = strTaskNoS.ToString().TrimEnd('，');
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
        public ActionResult TestReportEdit(E_tb_TestReport eTestReport, string EditType, int? InfoID)
        {
            ViewData["RecordList"] = tOriginalRecord.GetList("").Tables[0];
            ViewData["_abclist"] = PageTools.GetSelectList(tTypeDict.GetList("SubjectID=5").Tables[0], "TypeID", "TypeName", false);
            ViewData["RecordSelect"] = new DataTable();
            ViewData["ReportDataList"] = new DataTable();
            ViewBag._userName = CurrentUserInfo.UserName;
            if (EditType == "Edit")
            {
                eTestReport = tTestReport.GetModel(Convert.ToInt32(InfoID));
                ViewData["RecordList"] = tOriginalRecord.GetList("RecordID not in (" + eTestReport.RecordIDS + ")").Tables[0];
                ViewData["RecordSelect"] = tOriginalRecord.GetList("RecordID in (" + eTestReport.RecordIDS + ")").Tables[0];
                ViewData["ReportDataList"] = tTestReportData.GetList("ReportID=" + eTestReport.ReportID).Tables[0]; //检验数据
                
                if (eTestReport.ApprovalPersonnelID != null && eTestReport.ApprovalPersonnelID > 0)
                {
                    eTestReport.ApprovalPersonnelName = tInPersonnel.GetModel(Convert.ToInt32(eTestReport.ApprovalPersonnelID)).PersonnelName;
                }
                if (eTestReport.examinePersonnelID != null && eTestReport.examinePersonnelID > 0)
                {
                    eTestReport.examinePersonnelName = tInPersonnel.GetModel(Convert.ToInt32(eTestReport.examinePersonnelID)).PersonnelName;
                }
                if (eTestReport.MainTestPersonnelID != null && eTestReport.MainTestPersonnelID > 0)
                {
                    eTestReport.MainTestPersonnelName = tInPersonnel.GetModel(Convert.ToInt32(eTestReport.MainTestPersonnelID)).PersonnelName;
                }
                if (string.IsNullOrEmpty(eTestReport.Explain))
                {
                    eTestReport.Explain = @"
一、	本检验报告复印、涂改无效；封面未加盖检验专用章和无检验专用骑缝章（如2页以上）的检验报告无效。<br/>
二、	检验报告仅对送检、抽检样品负责。<br/>
三、	本检验报告及检验单位名称不得用于产品的标签、广告评优及商品宣传等。<br/>
四、	本检验报告一式二份，一份由检验单位存档，一份交送检、抽检单位。<br/>
五、	本检验报告由出具报告单位负责，并进行解释说明。<br/>
六、	检验单位保存该检验报告2年。<br/><br/>";
                    if (eTestReport.MainTestPersonnelID > 0)
                    {
                        try
                        {
                            var _areaid = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(eTestReport.MainTestPersonnelID.Value).AreaID;
                            if (_areaid > 0)
                            {
                                switch (_areaid)
                                {
                                    case 2: {
                                        eTestReport.Explain += @"食品检测中心<br/>
检验单位地址：天津市塘沽区东沽石油新村配餐采购加工中心院内<br/>
邮政编码：300452<br/>
联系电话：022-66917343<br/>
传真：022-66917343<br/><br/>";
                                        break;
                                    }
                                    case 3:
                                        {
                                            eTestReport.Explain += @"食品检测中心（葫芦岛）<br/>
检验单位地址：辽宁省葫芦岛市龙港区北港码头配餐公司葫芦岛配送基地<br/>
邮政编码：125000<br/>
联系电话：0429-2080522<br/>
传真：0429-2082522<br/><br/>";
                                            break;
                                        }
                                    case 4:
                                        {
                                            eTestReport.Explain += @"食品检测中心（深圳）<br/>
检验单位地址：广东省惠州市大亚湾区石化大道中滨海十二路9号惠州物流基地W18<br/>
邮政编码：516082<br/>
联系电话：0752-5952819<br/>
传真：0752-5952818<br/><br/>";
                                            break;
                                        }
                                    case 5:
                                        {
                                            eTestReport.Explain += @"食品检测中心（湛江）<br/>
检验单位地址：广东省湛江市坡头区南油一区配餐服务公司湛江分公司<br/>
邮政编码：524057<br/>
联系电话：0759-3910316<br/>
传真：0759-3901145<br/><br/>";
                                            break;
                                        }
                                    case 6:
                                        {
                                            eTestReport.Explain += @"食品检测中心（龙口）<br/>
检验单位地址：:山东省烟台市龙口市环海中路中海油物流码头配餐公司龙口配送基地<br/>
邮政编码：265700<br/>
联系电话：0535-8838131<br/>
传真：0535-8838131";
                                            break;
                                        }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }


            ViewBag.SampleName = eTestReport.SampleName;
            if (eTestReport.SampleName.ToString().IndexOf('）') > -1)
            {
                ViewBag.SampleName = eTestReport.SampleName.ToString().Substring(0, eTestReport.SampleName.ToString().IndexOf('）') + 1);
            }
            else
            {
                ViewBag.SampleName = Regex.Replace(ViewBag.SampleName, @"[^\u4e00-\u9fa5|（|）]", "");
            }
            ViewBag.AreaName = tArea.GetModel(int.Parse(eTestReport.AreaID.ToString())).TestReportName;
            var sampleModel = new BLL.tb_SampleBLL().GetModelList(" sampleNum = '" + eTestReport.SampleNum + "'").FirstOrDefault();
            ViewBag._cydw = "none";
            ViewBag._sydw = "none";
            if (sampleModel.isDetection)
            {
                eTestReport.ToSampleMode = "抽样";
                ViewBag._cydw = "";
            }
            else
            {
                eTestReport.ToSampleMode = "送样";
                ViewBag._sydw = "";
            }
            ViewBag.Department = eTestReport.Department;
            var _orlist = new BLL.OriginalRecord.T_tb_OriginalRecord().GetModelList(" RecordID in (" + eTestReport.RecordIDS + ")");
            String _projectIds = "";
            int _tempProjectId = 0;
            for (int i = 0; i < _orlist.Count; i++)
            {
                if (_tempProjectId == _orlist[i].ProjectID)
                {
                    continue;
                }
                if (String.IsNullOrEmpty(_projectIds))
                {
                    _projectIds = _orlist[i].ProjectID.ToString();
                }
                else
                {
                    _projectIds += "," + _orlist[i].ProjectID.ToString();
                }
            }
            eTestReport.TestBasis = "";
            var _projectlist = new BLL.Laboratory.T_tb_Project().GetModelList(" ProjectID in (" + _projectIds + ")");
            foreach (var item in _projectlist)
            {
                if (String.IsNullOrEmpty(eTestReport.TestBasis))
                {
                    eTestReport.TestBasis = item.ExpeMethod;
                }
                else
                {
                    eTestReport.TestBasis += "," + item.ExpeMethod;
                }
            }
            //ViewBag.Department = "";
            //if (sampleModel != null)
            //{
            //    if (sampleModel.isDetection)
            //    {
            //        ViewBag.Department = sampleModel.detectionCompany;
            //    }
            //    else
            //    {
            //        var clint = new BLL.ClientManage.T_tb_ClientManage().GetModel(Convert.ToInt32(sampleModel.InspectCompany));
            //        ViewBag.Department = clint.ClientName;
            //    }
            //}


            ViewBag._TestType = "";
            if (eTestReport.TestType != null)
            {
                ViewBag._TestType = tTypeDict.GetModel(int.Parse(eTestReport.TestType.ToString())).TypeName;
            }
            //ViewBag.TestTime = eTestReport.TestTime == null ? "" : Convert.ToDateTime(eTestReport.TestTime).ToString("yyyy/MM/dd");
            ViewBag.TestTime = eTestReport.IssuedTime == null ? "" : Convert.ToDateTime(eTestReport.IssuedTime).ToString("yyyy/MM/dd");
            ViewBag.DetectPersonnelID = CurrentUserInfo.PersonnelID;
            ViewBag.DetectPersonnelName = CurrentUserInfo.PersonnelName;

            eTestReport.EditType = EditType;
            return View(eTestReport);
        }

        /// <summary>
        /// 保存实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eTestReport">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        [ValidateInput(false)]
        public string Save(E_tb_TestReport eTestReport)
        {
            string msg = "0";
            try
            {
                //检验数据
                List<E_ReportData> ReportDataList = new List<E_ReportData>();
                string strJson = eTestReport.TestReportDataJson;
                if (!string.IsNullOrEmpty(strJson))
                {
                    strJson = strJson.Replace("\r\n", "");
                    ReportDataList = JsonHelper.JsonDeserialize<List<E_ReportData>>(strJson);
                }
                //删除原有检验数据
                tTestReportData.DeleteByWhere("ReportID=" + eTestReport.ReportID);
                foreach (E_ReportData item in ReportDataList)
                {
                    E_tb_TestReportData eTestReportData = new E_tb_TestReportData();
                    eTestReportData.ReportID = eTestReport.ReportID;
                    eTestReportData.TestName = item.TestName;
                    eTestReportData.TestStandard = item.TestStandard;
                    eTestReportData.TestResult = item.TestResult;
                    eTestReportData.QualifiedLevel = item.QualifiedLevel;
                    eTestReportData.TestPersonnelName = item.TestPersonnelName;
                    eTestReportData.RecordID = int.Parse(item.RecordID);
                    eTestReportData.RecordFilePath = item.RecordFilePath;
                    tTestReportData.Add(eTestReportData);
                }

                //结论
                //eTestReport.Conclusion = "合格";
                DataTable TestReportDataDT = tTestReportData.GetList("ReportID=" + eTestReport.ReportID + " and QualifiedLevel=''").Tables[0];
                //if (TestReportDataDT != null && TestReportDataDT.Rows.Count > 0)
                //{
                //    eTestReport.Conclusion = "";
                //}
                //TestReportDataDT = tTestReportData.GetList("ReportID=" + eTestReport.ReportID + " and QualifiedLevel='不合格'").Tables[0];
                //if (TestReportDataDT != null && TestReportDataDT.Rows.Count > 0)
                //{
                //    eTestReport.Conclusion = "不合格";
                //}
              
                eTestReport.EditPersonnelID = CurrentUserInfo.PersonnelID;
                eTestReport.AreaID = new BLL.PersonnelManage.T_tb_InPersonnel().GetModel(eTestReport.MainTestPersonnelID.Value).AreaID;
                //if (CurrentUserInfo.DataRange != 1)
                //{
                //    eTestReport.AreaID = CurrentUserInfo.AreaID;
                //}
                eTestReport.RecordIDS = eTestReport.RecordIDS.TrimEnd(',');
                eTestReport.TaskNoS = eTestReport.TaskNoS.TrimEnd(',');
                eTestReport.UpdateTime = DateTime.Now;
                tTestReport.Update(eTestReport);

                //判断检验报告是否审核通过
                if (eTestReport.ApprovalPersonnelID > 0 && eTestReport.examinePersonnelID > 0 && eTestReport.MainTestPersonnelID > 0)
                {
                    tExpePlan.UpdateStatusByPlanIDS(eTestReport.TaskNoS, eTestReport.ReportID);
                }

                msg = "1";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
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
            string str = (tTestReport.Delete(id)) ? "删除成功！" : "删除失败！";
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
            var model = tTestReport.GetModel(wid);
            string iFile = "" + model.FilePath;
            return Json(iFile, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ExpPDF(int id)
        {
            ProcessStartInfo Pss = new ProcessStartInfo();
            Pss.FileName = Server.MapPath("/HtmlToPDF/wkhtmltopdf.exe");
            var eTestReport = tTestReport.GetModel(id);
            string strUrl = System.Configuration.ConfigurationManager.AppSettings["HostName"].ToString() + "/ReportView/TestReportView?ReportID=" + id;//Request.UserHostName
            //string FileName = Guid.NewGuid() + ".pdf";
            string FileName = UrnHtml(eTestReport.SampleNum) + ".pdf";
            string FilePath = Server.MapPath("/TestReportPDF/" + FileName);
            Pss.Arguments = string.Format("{0} {1}", "\"" + strUrl + "\"", "\"" + FilePath + "\"");
            Pss.UseShellExecute = false;
            Pss.StandardOutputEncoding = Encoding.UTF8;
            Pss.RedirectStandardInput = true;
            Pss.RedirectStandardOutput = true;
            
            bool bresult = false;
            using (Process PS = new Process())
            {
                PS.StartInfo = Pss;
                PS.Start();
                PS.WaitForExit();
                if (PS.ExitCode == 0)
                {
                    bresult = true;
                    PS.Close();
                }
            }
            return Json("/TestReportPDF/" + FileName, JsonRequestBehavior.AllowGet);
        }

        public FilePathResult ExpAllPDF()
        {
            string AreaID = Session["_AreaID"].ToString();
            string StartTime = Session["_StartTime"].ToString();
            string EndTime = Session["_EndTime"].ToString();
            string SampleNum = Session["_SampleNum"].ToString();
            string SampleName = Session["_SampleName"].ToString();
            string Department = Session["_Department"].ToString();
            string MainTestPersonne = Session["_MainTestPersonne"].ToString();
            string SamplingTimes = Session["_SamplingTimes"].ToString();
            string SamplingTimee = Session["_SamplingTimee"].ToString();

            string ReportID = "";
            if (Session["_ReportID"] != null)
            {
                ReportID = Session["_ReportID"].ToString();
            }


            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "";
            if (!string.IsNullOrEmpty(ReportID) && ReportID != "0")
            {
                strWhere = PageTools.AddWhere(strWhere, "T.ReportID=" + ReportID);
            }
            if (!string.IsNullOrEmpty(AreaID) && AreaID != "-1")
            {
                strWhere = PageTools.AddWhere(strWhere, "T.AreaID=" + AreaID);
            }
            if (!string.IsNullOrEmpty(StartTime))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.IssuedTime>=cast('" + StartTime + "' as datetime)");
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.IssuedTime<=cast('" + EndTime + "' as datetime)");
            }
            if (!string.IsNullOrEmpty(SampleNum))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.SampleNum like  '%" + SampleNum + "%'");
            }
            if (!string.IsNullOrEmpty(SampleName))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.SampleName like  '%" + SampleName + "%'");
            }
            if (!string.IsNullOrEmpty(Department))
            {
                strWhere = PageTools.AddWhere(strWhere, "T.Department like  '%" + Department + "%'");
            }
            if (!string.IsNullOrEmpty(MainTestPersonne))
            {
                strWhere = PageTools.AddWhere(strWhere, "D.PersonnelName like '%" + MainTestPersonne + "%'");
            }

            if (!string.IsNullOrEmpty(SamplingTimes))
            {
                strWhere = PageTools.AddWhere(strWhere, "SamplingTime>=cast('" + SamplingTimes + "' as datetime)");
            }
            if (!string.IsNullOrEmpty(SamplingTimee))
            {
                strWhere = PageTools.AddWhere(strWhere, "SamplingTime<=cast('" + SamplingTimee + "' as datetime)");
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
                //dt = tTestReport.GetListByPage(strWhere, "UpdateTime DESC,T.SampleName ASC", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
                dt = tTestReport.GetListByPage(strWhere, "TestTime DESC", 1, 10000, ref total).Tables[0];
            }
            catch { }
            string[] iFile = new string[1];
            if (dt != null && dt.Rows.Count > 0)
            {
                iFile = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProcessStartInfo Pss = new ProcessStartInfo();
                    Pss.FileName = Server.MapPath("/HtmlToPDF/wkhtmltopdf.exe");
                    string strUrl = System.Configuration.ConfigurationManager.AppSettings["HostName"].ToString() + "/ReportView/TestReportView?ReportID=" + dt.Rows[i]["ReportID"];//Request.UserHostName
                    var eTestReport = tTestReport.GetModel(Convert.ToInt32(dt.Rows[i]["ReportID"]));
                    //string FileName = Guid.NewGuid() + ".pdf";

                    string FileName = UrnHtml(eTestReport.SampleNum) + ".pdf";
                    string FilePath = Server.MapPath("/TestReportPDF/" + FileName);
                    Pss.Arguments = string.Format("{0} {1}", "\"" + strUrl + "\"", "\"" + FilePath + "\"");
                    Pss.UseShellExecute = false;
                    Pss.RedirectStandardInput = true;
                    Pss.RedirectStandardOutput = true;

                    bool bresult = false;
                    using (Process PS = new Process())
                    {
                        PS.StartInfo = Pss;
                        PS.Start();
                        PS.WaitForExit();
                        if (PS.ExitCode == 0)
                        {
                            bresult = true;
                            PS.Close();
                        }
                    }
                    iFile[i] = FilePath;
                }
            }

            var strs = DateTime.Now.ToFileTime().ToString();
            string oFile = AppDomain.CurrentDomain.BaseDirectory + "UpFile//DownLoads//" + strs + ".zip";
            PublicClass.CompressFiles(iFile, oFile);
            return File(oFile, "application/octet-stream", strs + ".zip");
        }


        public ActionResult mul_app(int reportid)
        {
            bool flag = false;
            var reportList = tTestReportData.GetList("ReportID=" + reportid).Tables[0]; //检验数据
            if (reportList!= null && reportList.Rows.Count > 0)
            {
                var _list = tTestReportData.DataTableToList(reportList);
                for (int i = 0; i < _list.Count; i++)
                {
                    _list[i].QualifiedLevel = "合格";
                    tTestReportData.Update(_list[i]);
                }
            }
            return Json(flag, JsonRequestBehavior.AllowGet);
        }

        public string UrnHtml(string thestr)
        {
            string[] aryReg = { "'", "<", ">", "%", "\"\"", ",", ".", ">=", "=<", "-", "_", ";", "||", "[", "]", "&", "/", "-", "|", " ", "—", };
            for (int i = 0; i < aryReg.Length; i++)
            {
                thestr = thestr.Replace(aryReg[i], string.Empty);
            }
            return thestr;
        }
    }
}
