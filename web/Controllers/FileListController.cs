using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BLL.FileList;
using Common;
using Model.FileList;

namespace Web.Controllers
{
    public class FileListController : Controller
    {
        T_tb_FileList tFileList = new T_tb_FileList();
        public ActionResult FileListList(E_tb_FileList eFileList)
        {
            return View(eFileList);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, int FileType, int ParentID)
        {
            DataTable dt = new DataTable();
            int total = 0;

            string strWhere = "";
            strWhere = PageTools.AddWhere(strWhere, "FileType=" + FileType);
            strWhere = PageTools.AddWhere(strWhere, "ParentID=" + ParentID);

            try
            {
                dt = tFileList.GetListByPage(strWhere, "FileID Desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        /// 保存
        /// </summary>
        /// <param name="eFileList"></param>
        public string Save(E_tb_FileList eFileList)
        {
            tFileList.Add(eFileList);
            return "1";
        }
    }
}
