using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Laboratory;
using Common;
using System.Data;
using BLL.OriginalRecord;
using System.Collections;
using Model.OriginalRecord;
using Model;
using BLL;

namespace Web.Controllers
{
    public class DataReportController : BaseController
    {
        //
        // GET: /DataReport/
        T_tb_Project tProject = new T_tb_Project();
        T_tb_RecordSample tRecordSample = new T_tb_RecordSample();
        tb_SampleBLL tSample = new tb_SampleBLL();

        public ActionResult OriginalRecordReport(int? ProjectID)
        {
            E_tb_RecordSample eRecordSample = new E_tb_RecordSample();
            ViewData["ProjectList"] = PageTools.GetSelectList(tProject.GetList("").Tables[0], "ProjectID", "ProjectName", true);
            ViewData["SampleData"] = new DataTable();
            if (ProjectID != null && ProjectID > 0)
            {
                eRecordSample.ProjectID = Convert.ToInt32(ProjectID);
                ViewData["SampleData"] = tRecordSample.GetSampleByProjectID(Convert.ToInt32(ProjectID)).Tables[0];
            }
            return View(eRecordSample);
        }


        //数据统计
        public JsonResult Report(string ProjectID, string StartTime, string EndTime, string RecordSampleIDS)
        {
            RecordSampleIDS = RecordSampleIDS.TrimEnd(',');
            //获取符合要求的数据集合
            string sqlWhere = "T.SampleID in (" + RecordSampleIDS.TrimEnd(',') + ") and T.ProjectID=" + ProjectID + " and T.DetectTime>=cast('" + StartTime + "' as datetime) and T.DetectTime<=cast('" + EndTime + "' as datetime) ";
            DataTable dt = tRecordSample.GetListForProject(sqlWhere).Tables[0];

            ArrayList XNamelist = new ArrayList();  //横坐标
            ArrayList DateList = new ArrayList();   //横坐标对应日期集合
            ArrayList res = new ArrayList();        //返回结果

            //拼接横坐标
            DateTime startTime = Convert.ToDateTime(StartTime);
            DateTime endTime = Convert.ToDateTime(EndTime);
            for (DateTime time = startTime; time <= endTime; time = time.AddDays(1))
            {
                DateList.Add(time);
                XNamelist.Add(time.ToString("MM月dd日"));
            }

            //获取数据结果
            for (int j = 0; j < RecordSampleIDS.Split(',').Length; j++)
            {
                double[] DataList = new double[DateList.Count];     //数据结果
                string SampleID = RecordSampleIDS.Split(',')[j];       //当前样品ID
                for (int i = 0; i < DateList.Count; i++)//遍历所有横坐标日期
                {
                    double Score = 0;
                    DateTime TempDateTime=Convert.ToDateTime(DateList[i]);
                    DataRow TempRow = dt.Select("SampleID=" + SampleID + " and DetectTime='" + TempDateTime.ToString()+"'").FirstOrDefault();
                    Score = (TempRow != null) ? Convert.ToDouble(TempRow["Result"].ToString()) : 0;
                    DataList[i] = Score;
                }

                //组装坐标点集合
                List<List<double>> TempListSum = new List<List<double>>();
                for (int k = 0; k < DataList.Count(); k++)
                {
                    List<double> TempList = new List<double>();
                    if (DataList[k] != 0)
                    {
                        TempList.Add(k);
                        TempList.Add(DataList[k]);
                        TempListSum.Add(TempList);
                    }
                }

                //添加到集合
                tb_Sample eSample = tSample.GetModel(Convert.ToInt32(SampleID));
                res.Add(new { name = eSample.name, data = TempListSum });
            }

            var reauts = new { XName = XNamelist, YData = res };
            return Json(reauts, JsonRequestBehavior.AllowGet);
        }

    }
}
