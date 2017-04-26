using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yang.Management.Controllers
{
    public class HomeController : BaseController
    {
        [LoginCheck]
        public ActionResult Index()
        {
            return View();
        }

        [LoginCheck]
        public ActionResult News()
        {
            return View();
        }

        [LoginCheck]
        public ActionResult NormalNews()
        {
            return View();
        }
    }
}