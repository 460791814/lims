using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.PersonnelManage;
using BLL.RoleManage;
using Model.RoleManage;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 当前登录的用户属性
        /// </summary>
        public E_tb_InPersonnel CurrentUserInfo { get; set; }

        /// <summary>
        /// 重新基类在Action执行之前的事情
        /// </summary>
        /// <param name="filterContext">重写方法的参数</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //得到用户登录的信息
            CurrentUserInfo = Session["UserInfo"] as E_tb_InPersonnel;
            //判断用户是否为空
            if (CurrentUserInfo == null)
            {
                Response.Redirect("/Login/Login");
            }


            //权限按钮控制
            T_tb_Action tAction = new T_tb_Action();
            T_tb_UserRole tUserRole = new T_tb_UserRole();
            T_tb_RoleAction tRoleAction = new T_tb_RoleAction();

            //获取用户对应角色
            List<E_tb_UserRole> UserRoleList = new List<E_tb_UserRole>();
            if (CurrentUserInfo != null)
            {
                UserRoleList=tUserRole.GetModelList("PersonnelID=" + CurrentUserInfo.PersonnelID);
            }
            string RoleIDS = "";
            UserRoleList.ForEach(p => {
                RoleIDS += p.RoleID + ",";
            });
            RoleIDS = RoleIDS.TrimEnd(',');

            if (CurrentUserInfo != null)
            {
                CurrentUserInfo.RoleIDS = RoleIDS;
                if (RoleIDS.IndexOf(',') < 0)
                {
                    CurrentUserInfo.RoleID = Convert.ToInt32(RoleIDS);
                }
            }
            
            //获取角色对应操作
            List<E_tb_RoleAction> RoleActionList = new List<E_tb_RoleAction>();
            if (RoleIDS.Length > 0)
            {
                RoleActionList = tRoleAction.GetModelList("RoleID in (" + RoleIDS + ")");
            }

            //加载所有权限代码
            List<E_tb_Action> ActionList = tAction.GetModelList("");
            ActionList.ForEach(p =>
            {
                ViewData[p.ActionCode] = (RoleActionList.Where(o => o.ActionID == p.ActionID).Count() > 0);
                //ViewData[p.ActionCode] =true;
            });
        }


        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="ActionCode">模块代码</param>
        /// <returns>返回是否具有该权限</returns>
        public bool Verification(string ActionCode)
        {
            return true;
        }
    }
}
