using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yang.Management.Base;

namespace Yang.Management.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string userName, string passWord)
        {
            Session["CurrentUserId"] = Guid.NewGuid().ToString();

            return new JsonResult {
                Data = new Result( new { name = userName, password = passWord }),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}