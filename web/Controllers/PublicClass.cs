using BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Common;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace Web.Controllers
{
    public static class PublicClass
    {

        public static string ToJson(this DataTable dt, int total)
        {
            try
            { 
                string RowJson = JsonConvert.SerializeObject(dt, new ConvertDataTable());
                string json = string.Empty;
                //System.Text.StringBuilder rowJson = new System.Text.StringBuilder();
                //int colLen = dt.Columns.Count;
                //DataColumnCollection col = dt.Columns;
                //foreach (DataRow row in dt.Rows)
                //{
                //    System.Text.StringBuilder colJson = new System.Text.StringBuilder();
                //    rowJson.Append("{");
                //    for (int i = 0; i < colLen; i++)
                //    {
                //        colJson.Append("\"" + col[i].ColumnName + "\":\"" + row[i].ToString() + "\",");
                //    }
                //    rowJson.Append(colJson.ToString().TrimEnd(','));
                //    rowJson.Append("},");
                //}
                //json = "{\"total\":" + total + ",\"rows\":[" + rowJson.ToString().TrimEnd(',') + "]}";
                json = "{\"total\":" + total + ",\"rows\":" + RowJson + "}";
                return json;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 将Table 序列化为json
        /// 作者：小朱
        /// </summary>
        /// <param name="dt">需要序列化的DataTable</param>
        /// <returns></returns>
        public static string ToJson(this DataTable dt)
        {
            try
            {
                string json = string.Empty;
                if (dt != null && dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder rowJson = new System.Text.StringBuilder();
                    int colLen = dt.Columns.Count;
                    DataColumnCollection col = dt.Columns;
                    foreach (DataRow row in dt.Rows)
                    {
                        System.Text.StringBuilder colJson = new System.Text.StringBuilder();
                        rowJson.Append("{");
                        for (int i = 0; i < colLen; i++)
                        {
                            colJson.Append("\"" + col[i].ColumnName + "\":\"" + row[i].ToString() + "\",");
                        }
                        rowJson.Append(colJson.ToString().TrimEnd(','));
                        rowJson.Append("},");
                    }
                    json = rowJson.ToString().TrimEnd(',');
                }
                return json;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 转化一个DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            //创建属性的集合
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口
            Type type = typeof(T);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            {
                //创建一个DataRow实例
                DataRow row = dt.NewRow();
                //给row 赋值
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }


        /// <summary>
        /// 获取下拉框数据 
        /// 作者：章建国
        /// </summary>
        /// <returns></returns>
        public static SelectList GetDropDownList(int id, string firstItem)
        {
            tb_BaseBLL _basebll = new tb_BaseBLL();
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list.Add(new SelectListItem() { Text = firstItem, Value = "-1", Selected = true });
                foreach (var item in _basebll.GetModelList(" pId = " + id))
                {
                    list.Add(new SelectListItem() { Text = item.baseName, Value = item.id.ToString() });
                }
            }
            catch
            {

            }
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 获取区域（实验室、单位）数据
        /// 作者：章建国
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstItem"></param>
        /// <returns></returns>
        public static SelectList GetAreaList(string firstItem)
        {
            BLL.RoleManage.T_tb_Area _area = new BLL.RoleManage.T_tb_Area();
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list.Add(new SelectListItem() { Text = firstItem, Value = "-1", Selected = true });
                foreach (var item in _area.GetModelList(""))
                {
                    list.Add(new SelectListItem() { Text = item.AreaName, Value = item.AreaID.ToString() });
                }
            }
            catch
            {
            }
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 获取区域（实验室、单位）数据
        /// 作者：章建国
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstItem"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetAreaList(string firstItem, int _areaid)
        {
            BLL.RoleManage.T_tb_Area _area = new BLL.RoleManage.T_tb_Area();
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                list.Add(new SelectListItem() { Text = firstItem, Value = "-1", Selected = false });
                foreach (var item in _area.GetModelList(""))
                {
                    SelectListItem sli = new SelectListItem() { Text = item.AreaName, Value = item.AreaID.ToString(), Selected = false };
                    if (_areaid == item.AreaID)
                    {
                        sli.Selected = true;
                    }
                    list.Add(sli);
                }
            }
            catch
            {
            }
            return list;
        }

        /// <summary>
        /// 压缩文件
        /// 作者：章建国
        /// </summary>
        /// <param name="iFile">需要压缩的文件路径（包含文件名和扩展名）</param>
        /// <param name="oFile">压缩文件保存路径</param>
        /// <returns></returns>
        public static bool CompressFile(string iFile, string oFile)
        {
            bool flag = false;
            try
            {
                using (var zip = new Ionic.Zip.ZipFile())
                {

                    zip.AddFile(iFile, string.Empty);
                    zip.Save(oFile);
                }
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        /// <summary>
        /// 压缩文件
        /// 作者：章建国
        /// </summary>
        /// <param name="iFile">需要压缩的文件路径（包含文件名和扩展名）</param>
        /// <param name="oFile">压缩文件保存路径</param>
        /// <returns></returns>
        public static bool CompressFiles(string[] iFile, string oFile)
        {
            bool flag = false;
            try
            {
                using (var zip = new Ionic.Zip.ZipFile())
                {
                    for (int i = 0; i < iFile.Length; i++)
                    {
                        zip.AddFile(iFile[i], string.Empty);
                    }
                    zip.Save(oFile);
                }
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        /// <summary>
        /// 压缩文件
        /// 作者：章建国
        /// </summary>
        /// <param name="iFile">需要压缩的多个文件路径（包含文件名和扩展名）</param>
        /// <param name="oFile">压缩文件保存路径</param>
        /// <returns></returns>
        public static bool CompressFile(string[] iFile, string oFile)
        {
            bool flag = false;
            try
            {
                using (var zip = new Ionic.Zip.ZipFile())
                {
                    for (int i = 0; i < iFile.Count(); i++)
                    {
                        zip.AddFile(iFile[i], string.Empty);
                    }
                    zip.Save(oFile);
                }
                flag = true;
            }
            catch (Exception)
            {

                throw;
            }
            return flag;
        }

        /// <summary>
        /// PDF转换SWF
        /// 作者：章建国
        /// </summary>
        /// <param name="cmd">gpdf2swf.exe路径</param>
        /// <param name="args">SWF保存路径</param>
        public static void ExecutCmdForPDF2SWF(string cmd, string args)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = cmd;
                p.StartInfo.Arguments = args;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                //p.PriorityClass = ProcessPriorityClass.Normal;
                p.WaitForExit();
            }
        }

        /// <summary>
        /// 将DataSet数据集转换HSSFworkbook对象，并保存为Stream流
        /// </summary>
        /// <param name="ds"></param>
        /// <returns>返回数据流Stream对象</returns>
        public static System.IO.MemoryStream ExportDrugToExcel(DataTable dt)
        {
            try
            {
                //文件流对象
                System.IO.MemoryStream stream = new System.IO.MemoryStream();

                #region 创建数据库,表，设置单元的宽度
                //创建数据库  
                IWorkbook wb = new HSSFWorkbook();
                //创建表  
                ISheet sh = wb.CreateSheet("药品列表");
                //设置单元的宽度  
                sh.SetColumnWidth(0, 15 * 256);
                sh.SetColumnWidth(1, 15 * 256);
                sh.SetColumnWidth(2, 15 * 256);
                sh.SetColumnWidth(3, 6 * 256);
                sh.SetColumnWidth(4, 6 * 256);
                sh.SetColumnWidth(5, 6 * 256);
                sh.SetColumnWidth(6, 15 * 256);
                sh.SetColumnWidth(7, 10 * 256);
                #endregion

                #region 设置表头
                ICellStyle cellStyle = wb.CreateCellStyle();
                cellStyle.VerticalAlignment = VerticalAlignment.CENTER;
                cellStyle.Alignment = HorizontalAlignment.CENTER;

                IRow row0 = sh.CreateRow(0);
                row0.Height = 20 * 20;

                ICell icell1top = row0.CreateCell(0);
                icell1top.CellStyle = cellStyle;
                icell1top.SetCellValue("药品名称");

                ICell icell2top = row0.CreateCell(1);
                icell2top.CellStyle = cellStyle;
                icell2top.SetCellValue("药品编码");


                ICell icell3top = row0.CreateCell(2);
                icell3top.CellStyle = cellStyle;
                icell3top.SetCellValue("药品类别");

                ICell icell4top = row0.CreateCell(3);
                icell4top.CellStyle = cellStyle;
                icell4top.SetCellValue("单位");

                ICell icell5top = row0.CreateCell(4);
                icell5top.CellStyle = cellStyle;
                icell5top.SetCellValue("库存");

                ICell icell6top = row0.CreateCell(5);
                icell6top.CellStyle = cellStyle;
                icell6top.SetCellValue("易制毒");

                ICell icell7top = row0.CreateCell(6);
                icell7top.CellStyle = cellStyle;
                icell7top.SetCellValue("登记人");

                ICell icell8top = row0.CreateCell(7);
                icell8top.CellStyle = cellStyle;
                icell8top.SetCellValue("危险性类别");
                #endregion

                #region 读取数据库写入表
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string drugName = dt.Rows[i]["drugName"].ToString();
                    string drugCode = dt.Rows[i]["drugCode"].ToString();
                    string leibie = dt.Rows[i]["leibie"].ToString();
                    string danwei = dt.Rows[i]["danwei"].ToString();
                    string amount = dt.Rows[i]["amount"].ToString();
                    string temp1 = dt.Rows[i]["temp1"].ToString();
                    string dengjiren = dt.Rows[i]["dengjiren"].ToString();
                    string weixiandengji = dt.Rows[i]["weixiandengji"].ToString();

                    //创建行  
                    IRow row = sh.CreateRow(i + 1);
                    row.CreateCell(0); row.CreateCell(1); row.CreateCell(2); row.CreateCell(3); row.CreateCell(4); row.CreateCell(5);
                    row.CreateCell(6); row.CreateCell(7);
                    row.Cells[0].SetCellValue(drugName);
                    row.Cells[1].SetCellValue(drugCode);
                    row.Cells[2].SetCellValue(leibie);
                    row.Cells[3].SetCellValue(danwei);
                    row.Cells[4].SetCellValue(amount);
                    row.Cells[5].SetCellValue(temp1);
                    row.Cells[6].SetCellValue(dengjiren);
                    row.Cells[7].SetCellValue(weixiandengji);
                }
                #endregion
                sh.ForceFormulaRecalculation = true;
                wb.Write(stream);
                stream.Flush();
                stream.Position = 0;
                wb = null;
                return stream;
            }
            catch
            {
                return new System.IO.MemoryStream();
            }
        }

        /// <summary>
        /// 将DataSet数据集转换HSSFworkbook对象，并保存为Stream流
        /// </summary>
        /// <param name="ds"></param>
        /// <returns>返回数据流Stream对象</returns>
        public static System.IO.MemoryStream ExportReportToExcel(DataTable dt)
        {
            try
            {
                //文件流对象
                System.IO.MemoryStream stream = new System.IO.MemoryStream();

                #region 创建数据库,表，设置单元的宽度
                //创建数据库  
                IWorkbook wb = new HSSFWorkbook();
                //创建表  
                ISheet sh = wb.CreateSheet("实验统计列表");
                //设置单元的宽度  
                sh.SetColumnWidth(0, 6 * 256);
                sh.SetColumnWidth(1, 10 * 256);
                sh.SetColumnWidth(2, 25 * 256);
                sh.SetColumnWidth(3, 10 * 256);
                sh.SetColumnWidth(4, 20 * 256);
                sh.SetColumnWidth(5, 10 * 256);
                sh.SetColumnWidth(6, 10 * 256);
                sh.SetColumnWidth(7, 10 * 256);
                sh.SetColumnWidth(8, 10 * 256);
                sh.SetColumnWidth(9, 10 * 256);
                sh.SetColumnWidth(10, 10 * 256);
                #endregion

                #region 设置表头
                ICellStyle cellStyle = wb.CreateCellStyle();
                cellStyle.VerticalAlignment = VerticalAlignment.CENTER;
                cellStyle.Alignment = HorizontalAlignment.CENTER;

                IRow row0 = sh.CreateRow(0);
                row0.Height = 20 * 20;

                ICell icell1top = row0.CreateCell(0);
                icell1top.CellStyle = cellStyle;
                icell1top.SetCellValue("序号");

                ICell icell2top = row0.CreateCell(1);
                icell2top.CellStyle = cellStyle;
                icell2top.SetCellValue("检验时间");


                ICell icell3top = row0.CreateCell(2);
                icell3top.CellStyle = cellStyle;
                icell3top.SetCellValue("样品名称");

                ICell icell4top = row0.CreateCell(3);
                icell4top.CellStyle = cellStyle;
                icell4top.SetCellValue("检验单位");

                ICell icell5top = row0.CreateCell(4);
                icell5top.CellStyle = cellStyle;
                icell5top.SetCellValue("送/抽检单位");

                ICell icell6top = row0.CreateCell(5);
                icell6top.CellStyle = cellStyle;
                icell6top.SetCellValue("检验项目");

                ICell icell7top = row0.CreateCell(6);
                icell7top.CellStyle = cellStyle;
                icell7top.SetCellValue("检验人");

                ICell icell8top = row0.CreateCell(7);
                icell8top.CellStyle = cellStyle;
                icell8top.SetCellValue("检验次数");

                ICell icell9top = row0.CreateCell(8);
                icell9top.CellStyle = cellStyle;
                icell9top.SetCellValue("合格");

                ICell icell10top = row0.CreateCell(9);
                icell10top.CellStyle = cellStyle;
                icell10top.SetCellValue("不合格");
                #endregion

                #region 读取数据库写入表
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Row = dt.Rows[i]["Row"].ToString();
                    string DetectTime = dt.Rows[i]["DetectTime"].ToString();
                    string name = dt.Rows[i]["name"].ToString();
                    string GHS = dt.Rows[i]["GHS"].ToString();
                    string Department = dt.Rows[i]["Department"].ToString();
                    string ProjectName = dt.Rows[i]["ProjectName"].ToString();
                    string TestPersonnelName = dt.Rows[i]["TestPersonnelName"].ToString();
                    string QualifiedLevel = dt.Rows[i]["QualifiedLevel"].ToString();
                    string QualifiedLevelA = dt.Rows[i]["QualifiedLevelA"].ToString();
                    string QualifiedLevelB = dt.Rows[i]["QualifiedLevelB"].ToString();

                    //创建行  
                    IRow row = sh.CreateRow(i + 1);
                    row.CreateCell(0); row.CreateCell(1); 
                    row.CreateCell(2); row.CreateCell(3);
                    row.CreateCell(4); row.CreateCell(5);
                    row.CreateCell(6); row.CreateCell(7);
                    row.CreateCell(8); row.CreateCell(9);

                    row.Cells[0].SetCellValue(Row);
                    row.Cells[1].SetCellValue(DetectTime);
                    row.Cells[2].SetCellValue(name);
                    row.Cells[3].SetCellValue(GHS);
                    row.Cells[4].SetCellValue(Department);
                    row.Cells[5].SetCellValue(ProjectName);
                    row.Cells[6].SetCellValue(TestPersonnelName);
                    row.Cells[7].SetCellValue(QualifiedLevel);
                    row.Cells[8].SetCellValue(QualifiedLevelA);
                    row.Cells[9].SetCellValue(QualifiedLevelB);
                }
                #endregion
                sh.ForceFormulaRecalculation = true;
                wb.Write(stream);
                stream.Flush();
                stream.Position = 0;
                wb = null;
                return stream;
            }
            catch
            {
                return new System.IO.MemoryStream();
            }
        }

        internal static System.IO.MemoryStream ExportSampleToExcel(DataTable dt)
        {
            try
            {
                //文件流对象
                System.IO.MemoryStream stream = new System.IO.MemoryStream();

                #region 创建数据库,表，设置单元的宽度
                //创建数据库  
                IWorkbook wb = new HSSFWorkbook();
                //创建表  
                ISheet sh = wb.CreateSheet("样品列表");
                //设置单元的宽度  
                sh.SetColumnWidth(0, 15 * 256);
                sh.SetColumnWidth(1, 15 * 256);
                sh.SetColumnWidth(2, 15 * 256);
                sh.SetColumnWidth(3, 6 * 256);
                sh.SetColumnWidth(4, 6 * 256);
                sh.SetColumnWidth(5, 6 * 256);
                sh.SetColumnWidth(6, 15 * 256);
                sh.SetColumnWidth(7, 10 * 256);
                sh.SetColumnWidth(8, 10 * 256);
                sh.SetColumnWidth(9, 10 * 256);
                sh.SetColumnWidth(10, 10 * 256);
                sh.SetColumnWidth(11, 10 * 256);
                sh.SetColumnWidth(12, 10 * 256);
                sh.SetColumnWidth(13, 10 * 256);
                sh.SetColumnWidth(14, 10 * 256);
                sh.SetColumnWidth(15, 10 * 256);
                sh.SetColumnWidth(16, 10 * 256);
                sh.SetColumnWidth(17, 10 * 256);
                sh.SetColumnWidth(18, 10 * 256);
                sh.SetColumnWidth(19, 10 * 256);
                sh.SetColumnWidth(20, 10 * 256);
                sh.SetColumnWidth(21, 10 * 256);
                #endregion

                #region 设置表头
                ICellStyle cellStyle = wb.CreateCellStyle();
                cellStyle.VerticalAlignment = VerticalAlignment.CENTER;
                cellStyle.Alignment = HorizontalAlignment.CENTER;

                IRow row0 = sh.CreateRow(0);
                row0.Height = 20 * 20;

                ICell icell1top = row0.CreateCell(0);
                icell1top.CellStyle = cellStyle;
                icell1top.SetCellValue("样品编号");

                ICell icell2top = row0.CreateCell(1);
                icell2top.CellStyle = cellStyle;
                icell2top.SetCellValue("样品名称");


                ICell icell3top = row0.CreateCell(2);
                icell3top.CellStyle = cellStyle;
                icell3top.SetCellValue("产品批次");

                ICell icell03top = row0.CreateCell(3);
                icell03top.CellStyle = cellStyle;
                icell03top.SetCellValue("生产日期");

                ICell icell4top = row0.CreateCell(4);
                icell4top.CellStyle = cellStyle;
                icell4top.SetCellValue("抽样形式");

                ICell icell5top = row0.CreateCell(5);
                icell5top.CellStyle = cellStyle;
                icell5top.SetCellValue("抽样日期");

                ICell icell6top = row0.CreateCell(6);
                icell6top.CellStyle = cellStyle;
                icell6top.SetCellValue("抽样人");

                ICell icell7top = row0.CreateCell(7);
                icell7top.CellStyle = cellStyle;
                icell7top.SetCellValue("样品数量");

                ICell icell8top = row0.CreateCell(8);
                icell8top.CellStyle = cellStyle;
                icell8top.SetCellValue("包装方式");

                ICell icell9top = row0.CreateCell(9);
                icell9top.CellStyle = cellStyle;
                icell9top.SetCellValue("保质期");

                ICell icell10top = row0.CreateCell(10);
                icell10top.CellStyle = cellStyle;
                icell10top.SetCellValue("规格型号");

                ICell icell11top = row0.CreateCell(11);
                icell11top.CellStyle = cellStyle;
                icell11top.SetCellValue("抽样依据");

                ICell icell12top = row0.CreateCell(12);
                icell12top.CellStyle = cellStyle;
                icell12top.SetCellValue("抽样方法");

                ICell icell13top = row0.CreateCell(13);
                icell13top.CellStyle = cellStyle;
                icell13top.SetCellValue("抽样地点");

                ICell icell14top = row0.CreateCell(14);
                icell14top.CellStyle = cellStyle;
                icell14top.SetCellValue("抽样单位");

                ICell icell15top = row0.CreateCell(15);
                icell15top.CellStyle = cellStyle;
                icell15top.SetCellValue("送检单位");

                ICell icell16top = row0.CreateCell(16);
                icell16top.CellStyle = cellStyle;
                icell16top.SetCellValue("送检地址");

                ICell icell17top = row0.CreateCell(17);
                icell17top.CellStyle = cellStyle;
                icell17top.SetCellValue("项目名称");

                ICell icell18top = row0.CreateCell(18);
                icell18top.CellStyle = cellStyle;
                icell18top.SetCellValue("检验方法");

                ICell icell19top = row0.CreateCell(19);
                icell19top.CellStyle = cellStyle;
                icell19top.SetCellValue("样品管理员");

                ICell icell20top = row0.CreateCell(20);
                icell20top.CellStyle = cellStyle;
                icell20top.SetCellValue("销毁人");

                ICell icell21top = row0.CreateCell(21);
                icell21top.CellStyle = cellStyle;
                icell21top.SetCellValue("销毁时间");
                #endregion

                #region 读取数据库写入表
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string sampleNum = dr["sampleNum"].ToString();
                    string name = dr["name"].ToString();
                    string protNum = dr["protNum"].ToString();
                    string productDate = dr["productDate"].ToString();
                    string isDetection = dr["isDetection"].ToString() == "True" ? "抽样" : "送样";
                    string detectionDate = dr["detectionDate"].ToString();
                    string detectionUser = dr["detectionUser"].ToString();
                    string batch = dr["batch"].ToString();
                    string packaging = dr["packaging"].ToString();
                    string expirationDate = dr["expirationDate"].ToString();
                    string modelType = dr["modelType"].ToString();
                    string detectionGist = dr["detectionGist"].ToString();
                    string detectionMethod = dr["detectionMethod"].ToString();
                    string detectionAdress = dr["detectionAdress"].ToString();
                    string detectionCompany = dr["detectionCompany"].ToString();
                    string InspectCompany = dr["InspectCompany"].ToString();
                    string InspectAddress = dr["InspectAddress"].ToString();
                    string projectName = dr["projectName"].ToString();
                    string testMethod = dr["testMethod"].ToString();
                    string sampleAdmin = dr["sampleAdmin"].ToString();
                    string handleUser = dr["handleUser"].ToString();
                    string handleDate = dr["handleDate"].ToString();

                    //创建行  
                    IRow row = sh.CreateRow(i + 1);
                    row.CreateCell(0); row.CreateCell(1); row.CreateCell(2); row.CreateCell(3); row.CreateCell(4); row.CreateCell(5);
                    row.CreateCell(6); row.CreateCell(7); row.CreateCell(8); row.CreateCell(9); row.CreateCell(10); row.CreateCell(11);
                    row.CreateCell(12); row.CreateCell(13); row.CreateCell(14); row.CreateCell(15); row.CreateCell(16); row.CreateCell(17);
                    row.CreateCell(18); row.CreateCell(19); row.CreateCell(20); row.CreateCell(21);
                    row.Cells[0].SetCellValue(sampleNum);
                    row.Cells[1].SetCellValue(name);
                    row.Cells[2].SetCellValue(protNum);
                    row.Cells[3].SetCellValue(productDate);
                    row.Cells[4].SetCellValue(isDetection);
                    row.Cells[5].SetCellValue(detectionDate);
                    row.Cells[6].SetCellValue(detectionUser);
                    row.Cells[7].SetCellValue(batch);
                    row.Cells[8].SetCellValue(packaging);
                    row.Cells[9].SetCellValue(expirationDate);
                    row.Cells[10].SetCellValue(modelType);
                    row.Cells[11].SetCellValue(detectionGist);
                    row.Cells[12].SetCellValue(detectionMethod);
                    row.Cells[13].SetCellValue(detectionAdress);
                    row.Cells[14].SetCellValue(detectionCompany);
                    row.Cells[15].SetCellValue(InspectCompany);
                    row.Cells[16].SetCellValue(InspectAddress);
                    row.Cells[17].SetCellValue(projectName);
                    row.Cells[18].SetCellValue(testMethod);
                    row.Cells[19].SetCellValue(sampleAdmin);
                    row.Cells[20].SetCellValue(handleUser);
                    row.Cells[21].SetCellValue(handleDate);
                }
                #endregion
                sh.ForceFormulaRecalculation = true;
                wb.Write(stream);
                stream.Flush();
                stream.Position = 0;
                wb = null;
                return stream;
            }
            catch
            {
                return new System.IO.MemoryStream();
            }
        }
    }
}