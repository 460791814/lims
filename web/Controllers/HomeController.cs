using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BLL.Laboratory;
using BLL.ShowImage;
using BLL.News;
using Model.PersonnelManage;
using Model.Default;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        T_tb_Laboratory tLaboratory = new T_tb_Laboratory(); //实验室管理
        T_tb_ShowImages tShowImages = new T_tb_ShowImages(); //图片数据
        T_tb_News tNews = new T_tb_News(); //公告管理
        T_tb_ElectronicsMagazine tElectronicsMagazine = new T_tb_ElectronicsMagazine(); //电子杂志
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Top()
        {
            E_tb_InPersonnel eInPersonnel = (E_tb_InPersonnel)Session["UserInfo"];
            return View(eInPersonnel);
        }

        public ActionResult Bottom()
        {
            return View();
        }

        public ActionResult Left()
        {
            return View();
        }

        public ActionResult Bar()
        {
            return View();
        }

        /// <summary>
        /// 首页显示窗口
        /// 作者：小朱
        /// </summary>
        /// <returns></returns>
        public ActionResult Default()
        {
            //获取实验室数据
            int total = 0;
            DataTable LaboratoryDt = tLaboratory.GetListByPage("AreaID=" + CurrentUserInfo.AreaID, "", 1, 8, ref total).Tables[0];
            ViewData["LaboratoryDt"] = LaboratoryDt;

            //获取大图数据列表
            DataTable MaxImgDt = tShowImages.GetList(4, "ImgTypeID=1 and AreaID=" + CurrentUserInfo.AreaID, "OrderID").Tables[0];
            ViewData["MaxImgDt"] = MaxImgDt;

            //获取小图数据列表
            //DataTable MinImgDt = tShowImages.GetList(16, "ImgTypeID=2 and AreaID=" + CurrentUserInfo.AreaID, "OrderID").Tables[0];
            //ViewData["MinImgDt"] = MinImgDt;
            DataTable MinImgDt = tShowImages.GetList(16, "ImgTypeID=2 ", "OrderID").Tables[0];
            ViewData["MinImgDt"] = MinImgDt;

            //获取电子杂志数据列表
            //DataTable MagazineDt = tElectronicsMagazine.GetList(6, "AreaID=" + CurrentUserInfo.AreaID, "AddTime Desc").Tables[0];
            //ViewData["MagazineDt"] = MagazineDt;
            DataTable MagazineDt = tElectronicsMagazine.GetList(6, "", "AddTime Desc").Tables[0];
            ViewData["MagazineDt"] = MagazineDt;

            //公告 公告通知
            //DataTable News2Dt = tNews.GetList(6, "NewTypeID=2 and AreaID=" + CurrentUserInfo.AreaID, "UpdateTime Desc").Tables[0];
            //DataTable News2Dt = tNews.GetList(6, "AreaID=" + CurrentUserInfo.AreaID, "UpdateTime Desc").Tables[0];
            //ViewData["News2Dt"] = News2Dt;
            DataTable News2Dt = tNews.GetList(6, "", "UpdateTime Desc").Tables[0];
            ViewData["News2Dt"] = News2Dt;

            E_Default eDefault = new E_Default();
            eDefault.MaxImgCount = MaxImgDt.Rows.Count + 1;


            #region 药品、易耗品、计量管理、实验计划首页提醒
            try
            {
                ViewData["expList"] = new List<Model.ExpePlan.E_tb_ExpePlan>();
                string expwhere = " (InspectTime - getdate()) <= 2 and (InspectTime - getdate()) > 0 ";
                expwhere += string.Format(" and AreaID = {0} ", CurrentUserInfo.AreaID);
                List<Model.ExpePlan.E_tb_ExpePlan> expList = new BLL.ExpePlan.T_tb_ExpePlan().GetModelList(expwhere);
                ViewData["expList"] = expList;

                //ViewData["_expList"] = new BLL.ExpePlan.T_tb_ExpePlan().GetUNFinishList();
                //张伟修改，增加统计委外未完成的数据
                ViewData["_expList"] = new BLL.ExpePlan.T_tb_ExpePlan().GetAllUNFinishList();

            }
            catch
            {

            }
            try
            {
                ViewData["drugList"] = new List<Model.tb_DrugIN>();
                string durgwhere = " (validDate - getdate()) <= 9 and (validDate - getdate()) > 0 ";
                durgwhere += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0})", CurrentUserInfo.AreaID);
                List<Model.tb_DrugIN> druglist = new BLL.tb_DrugINBLL().GetModelList(durgwhere);
                ViewData["drugList"] = druglist;
            }
            catch
            {

            }

            try
            {
                ViewData["easyConsumelist"] = new List<Model.tb_EasyConsumeIN>();
                string easyConsumewhere = " (validDate - getdate()) <= 9 and (validDate - getdate()) > 0 ";
                easyConsumewhere += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0})", CurrentUserInfo.AreaID);
                List<Model.tb_EasyConsumeIN> easyConsumelist = new BLL.tb_EasyConsumeINBLL().GetModelList(easyConsumewhere);
                ViewData["easyConsumelist"] = easyConsumelist;
            }
            catch
            {
            }

            try
            {
                ViewData["booklist"] = new List<Model.tb_BookBorrow>();
                string bookwhere = " (convert(datetime,temp2) - getdate()) <= 9 and (convert(datetime,temp2) - getdate()) > 0 ";
                bookwhere += string.Format(" and createUser in (select PersonnelID from tb_InPersonnel where AreaID = {0})", CurrentUserInfo.AreaID);
                List<Model.tb_BookBorrow> booklist = new BLL.tb_BookBorrowBLL().GetModelList(bookwhere);
                ViewData["booklist"] = booklist;
            }
            catch
            {
            }
            #endregion
            return View(eDefault);
        }

        /// <summary>
        /// 获取实验室数据
        /// 作者：小朱
        /// </summary>
        /// <returns>返回实验室数据列表</returns>
        public JsonResult GetLaboratoryDt()
        {
            int total = 0;
            DataTable LaboratoryDt = tLaboratory.GetListByPage("", "", 1, 8, ref total).Tables[0];
            string strJson = PublicClass.ToJson(LaboratoryDt);
            return Json("[" + strJson + "]", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取大图数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>返回大图数据列表</returns>
        public JsonResult GetMaxImg()
        {
            DataTable MaxImgList = tShowImages.GetList(4, "ImgTypeID=1 and AreaID=" + CurrentUserInfo.AreaID, "OrderID").Tables[0];
            string strJson = PublicClass.ToJson(MaxImgList);
            return Json("[" + strJson + "]", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取小图数据列表
        /// 作者：小朱
        /// </summary>
        /// <returns>返回小图数据列表</returns>
        public JsonResult GetMinImg()
        {
            DataTable MinImgList = tShowImages.GetList(16, "ImgTypeID=2 and AreaID=" + CurrentUserInfo.AreaID, "OrderID").Tables[0];
            string strJson = PublicClass.ToJson(MinImgList);
            return Json("[" + strJson + "]", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 全屏页面
        /// 作者：小朱
        /// </summary>
        /// <returns></returns>
        public ActionResult FullPage()
        {
            //获取实验室数据
            int total = 0;
            DataTable LaboratoryDt = tLaboratory.GetListByPage("AreaID=" + CurrentUserInfo.AreaID, "", 1, 8, ref total).Tables[0];
            ViewData["LaboratoryDt"] = LaboratoryDt;

            //获取大图数据列表
            DataTable MaxImgDt = tShowImages.GetList(4, "ImgTypeID=1 and AreaID=" + CurrentUserInfo.AreaID, "OrderID").Tables[0];
            ViewData["MaxImgDt"] = MaxImgDt;

            //获取小图数据列表
            //DataTable MinImgDt = tShowImages.GetList(16, "ImgTypeID=2 and AreaID=" + CurrentUserInfo.AreaID, "OrderID").Tables[0];
            //ViewData["MinImgDt"] = MinImgDt;
            DataTable MinImgDt = tShowImages.GetList(16, "ImgTypeID=2 ", "OrderID").Tables[0];
            ViewData["MinImgDt"] = MinImgDt;

            //获取电子杂志数据列表
            //DataTable MagazineDt = tElectronicsMagazine.GetList(6, "AreaID=" + CurrentUserInfo.AreaID, "AddTime Desc").Tables[0];
            //ViewData["MagazineDt"] = MagazineDt;
            DataTable MagazineDt = tElectronicsMagazine.GetList(6, "", "AddTime Desc").Tables[0];
            ViewData["MagazineDt"] = MagazineDt;

            //公告 公告通知
            //DataTable News2Dt = tNews.GetList(6, "NewTypeID=2 and AreaID=" + CurrentUserInfo.AreaID, "UpdateTime").Tables[0];
            //ViewData["News2Dt"] = News2Dt;
            DataTable News2Dt = tNews.GetList(6, "NewTypeID=2 ", "UpdateTime").Tables[0];
            ViewData["News2Dt"] = News2Dt;

            E_Default eDefault = new E_Default();
            eDefault.MaxImgCount = MaxImgDt.Rows.Count + 1;
            return View(eDefault);
        }

    }
}
