using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ShowImage;
using BLL.ShowImage;
using System.Data;
using BLL.News;
using Model.News;
using BLL.DictManage;
using Model.DictManage;

namespace Web.Controllers
{
    public class NewsController : BaseController
    {
        T_tb_News tNews = new T_tb_News(); //首页图片管理
        T_tb_TypeDict tTypeDict = new T_tb_TypeDict();//类别字典
        //
        // GET: /Laboratory/

        public ActionResult NewsList()
        {
            ViewData["SearchNewsTypeList"] = GetNewsTypeList(true);
            ViewData["NewsTypeList"] = GetNewsTypeList(false);
            return View();
        }

        /// <summary>
        /// 前台显示的公告列表页面
        /// </summary>
        /// <param name="NewTypeID">公告类型</param>
        /// <returns></returns>
        public ActionResult NewsShowList(int NewTypeID)
        {
            E_tb_News eNews = new E_tb_News();
            eNews.NewTypeID = NewTypeID;
            return View(eNews);
        }

        /// <summary>
        /// 获取所有数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>将DataTable转换为Json数据格式通过string类型返回</returns>
        public string GetList(int pageNumber, int pageSize, string StrSearch, string NewTypeID, string StartTime, string EndTime)
        {
            DataTable dt = new DataTable();
            int total = 0;
            string strWhere = "NewTypeID>0";
            if (StrSearch != null && StrSearch.Trim() != "")
            {
                strWhere += " and Title like '%" + StrSearch.Trim() + "%'";
            }
            if (NewTypeID != null && NewTypeID.Trim() != "" && NewTypeID.Trim() != "-1" && NewTypeID.Trim() != "0")
            {
                strWhere += " and NewTypeID=" + NewTypeID;
            }
            if (StartTime != null && StartTime.Trim() != "")
            {
                strWhere += " and UpdateTime>=cast('" + StartTime + "' as datetime)";
            }
            if (EndTime != null && EndTime.Trim() != "")
            {
                strWhere += " and UpdateTime<=cast('" + EndTime + "' as datetime)";
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
                dt = tNews.GetListByPage(strWhere,"UpdateTime Desc", pageNumber * pageSize - (pageSize - 1), pageNumber * pageSize, ref total).Tables[0];
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
        public JsonResult NewsEdit(E_tb_News eNews, string EditType, int? InfoID)
        {
            ViewData["NewsTypeList"] = GetNewsTypeList(false);

            if (EditType == "Edit")
            {
                eNews = tNews.GetModel(Convert.ToInt32(InfoID));
            }
            eNews.EditType = EditType;
            return Json(eNews, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 详情页
        /// 作者：小朱
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsInfo(E_tb_News eNews, int InfoID)
        {
            eNews = tNews.GetModel(Convert.ToInt32(InfoID));
            return View(eNews);
        }

        /// <summary>
        /// 是否有效下拉框数据
        /// </summary>
        /// <returns></returns>
        private SelectList GetNewsTypeList(bool IsSearch)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (IsSearch)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
            }
            List<E_tb_TypeDict> TypeDictList = tTypeDict.GetModelList("SubjectID=1");
            foreach (E_tb_TypeDict eTypeDict in TypeDictList)
            {
                list.Add(new SelectListItem() { Text = eTypeDict.TypeName, Value = eTypeDict.TypeID.ToString() });
            }
            list.First().Selected = true;
            return new SelectList(list, "Value", "Text");
        }


        /// <summary>
        /// 保存实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eNews">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        [ValidateInput(false)]
        public string Save(E_tb_News eNews)
        {
            string msg = "0"; 
            eNews.UpdateTime = DateTime.Now;
            eNews.EditPersonnelID = CurrentUserInfo.PersonnelID;
            eNews.AreaID = CurrentUserInfo.AreaID;
            if (eNews.EditType == "Add")
            {
                tNews.Add(eNews);
                msg = "1";
            }
            else
            {
                tNews.Update(eNews);
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
            string str = (tNews.Delete(id)) ? "删除成功！" : "删除失败！";
            return Json(str, JsonRequestBehavior.AllowGet);
        }

    }
}
