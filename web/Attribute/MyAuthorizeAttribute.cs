using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.PersonnelManage;
using BLL.PersonnelManage;
namespace Web.Attribute
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //string currentRole = (Session["user"] as User).Role;
            ////从Session中获取User对象，然后得到其角色信息。如果用户重写了Identity, 则可以在httpContext.Current.User.Identity中获取
            //if (Roles.Contains(currentRole))
            //    return true;
            string UserName = httpContext.User.Identity.Name;
            return true;
            return base.AuthorizeCore(httpContext);
        }
    }
}
