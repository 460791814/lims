using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DefaultController : BaseController
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ViewPageMain()
        {
            return View("ViewPageMain");
        }
    }
}
