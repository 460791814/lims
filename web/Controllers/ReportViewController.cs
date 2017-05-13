using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.TestReport;
using BLL.TestReport;
using BLL.DictManage;
using Model.DictManage;
using Model.PersonnelManage;
using BLL.PersonnelManage;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Text.RegularExpressions;
using BLL.RoleManage;

namespace Web.Controllers
{
    public class ReportViewController : Controller
    {
        T_tb_TestReport tTestReport = new T_tb_TestReport();            //检验报告管理
        T_tb_TestReportData tTestReportData = new T_tb_TestReportData(); //检验数据
        T_tb_TypeDict tTypeDict = new T_tb_TypeDict();
        T_tb_InPersonnel tInPersonnel = new T_tb_InPersonnel();
        T_tb_Area tArea = new T_tb_Area();                              //区域/单位

        public ActionResult TestReportView(E_tb_TestReport eTestReport)
        {
            ViewData["ReportDataList"] = tTestReportData.GetList("ReportID=" + eTestReport.ReportID).Tables[0]; //检验数据
            eTestReport = tTestReport.GetModel(eTestReport.ReportID);
            E_tb_TypeDict eTypeDict = tTypeDict.GetModel(Convert.ToInt32(eTestReport.TestType));
            eTestReport.TestTypeName = (eTypeDict != null ? eTypeDict.TypeName : "");
            E_tb_InPersonnel eInPersonnel=new E_tb_InPersonnel();
            if(eTestReport.ApprovalPersonnelID!=null&&eTestReport.ApprovalPersonnelID>0)
            {
                eInPersonnel = tInPersonnel.GetModel(Convert.ToInt32(eTestReport.ApprovalPersonnelID));
                if (eInPersonnel != null)
                {
                    eTestReport.ApprovalPersonnelName = eInPersonnel.PersonnelName;
                }
            }

            if (eTestReport.examinePersonnelID != null && eTestReport.examinePersonnelID > 0)
            {
                eInPersonnel = tInPersonnel.GetModel(Convert.ToInt32(eTestReport.examinePersonnelID));
                if (eInPersonnel != null)
                {
                    eTestReport.examinePersonnelName = eInPersonnel.PersonnelName;
                }
            }

            if (eTestReport.MainTestPersonnelID != null && eTestReport.MainTestPersonnelID > 0)
            {
                eInPersonnel = tInPersonnel.GetModel(Convert.ToInt32(eTestReport.MainTestPersonnelID));
                if (eInPersonnel != null)
                {
                    eTestReport.MainTestPersonnelName = eInPersonnel.PersonnelName;
                }
            }

            //eTestReport.SampleName = Regex.Replace(eTestReport.SampleName, @"[^\u4e00-\u9fa5]", "");
            if (eTestReport.SampleName.ToString().IndexOf('）') > -1)
            {
                eTestReport.SampleName = eTestReport.SampleName.ToString().Substring(0, eTestReport.SampleName.ToString().IndexOf('）') + 1);
            }
            else
            {
                eTestReport.SampleName = Regex.Replace(eTestReport.SampleName, @"[^\u4e00-\u9fa5|（|）]", "");
            }

            var sampleModel = new BLL.tb_SampleBLL().GetModelList(" sampleNum = '" + eTestReport.SampleNum + "'").FirstOrDefault();
            ViewBag._cydw = "none";
            ViewBag._sydw = "none";
            ViewBag._scjdw = "";
            if (sampleModel != null)
            {
                if (sampleModel.isDetection)
                {
                    eTestReport.ToSampleMode = "抽样";
                    ViewBag._cydw = "";
                    ViewBag._scjdw = eTestReport.SamplingCompany;
                    eTestReport.Department = "/";
                }
                else
                {
                    eTestReport.ToSampleMode = "送样";
                    ViewBag._sydw = "";
                    eTestReport.SamplingCompany = "/";
                    ViewBag._scjdw = eTestReport.Department;
                }
            }
            if (String.IsNullOrEmpty(eTestReport.Specifications))
            {
                eTestReport.Specifications = "/";
            }
            if (String.IsNullOrEmpty(eTestReport.Packing))
            {
                eTestReport.Packing = "/";
            }
            if (String.IsNullOrEmpty(eTestReport.productNum))
            {
                eTestReport.productNum = "/";
            }
            


            ViewBag._IssuedTime ="";
            if (eTestReport.IssuedTime != null)
	        {
                ViewBag._IssuedTime = eTestReport.IssuedTime.Value.ToString("yyyy/MM/dd");
	        }
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
            ViewBag.AreaName = tArea.GetModel(int.Parse(eTestReport.AreaID.ToString())).TestReportName;
            return View(eTestReport);
        }

        /// <summary>
        /// 文件预览
        /// </summary>
        /// <returns></returns>
        public ActionResult FileView(string filename, string SaveFilePage, string SaveDataPage, string DataRange)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                while (SaveFilePage.IndexOf('|') > -1)
                {
                    SaveFilePage = SaveFilePage.Replace('|', '&');
                }
                while (SaveDataPage.IndexOf('|') > -1)
                {
                    SaveDataPage = SaveDataPage.Replace('|', '&');
                }

                Page page = new Page();
                string controlOutput = string.Empty;
                PageOffice.PageOfficeCtrl pc = new PageOffice.PageOfficeCtrl();
                pc.SaveFilePage = SaveFilePage;
                pc.ServerPage = "/pageoffice/server.aspx";

                if (!string.IsNullOrEmpty(SaveDataPage) && !string.IsNullOrEmpty(DataRange))
                {
                    PageOffice.ExcelWriter.Workbook wb = new PageOffice.ExcelWriter.Workbook();
                    PageOffice.ExcelWriter.Sheet sheetOrder = wb.OpenSheet("Sheet1");
                    PageOffice.ExcelWriter.Table table = sheetOrder.OpenTable(DataRange);
                    pc.SetWriter(wb);
                    pc.SaveDataPage = SaveDataPage;
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

            return View();
        }

    }
}
