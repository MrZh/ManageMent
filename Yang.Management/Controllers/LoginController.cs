using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yang.Management.Base;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Repository;
using Yang.Management.Repository.Repository;

namespace Yang.Management.Controllers
{
    public class LoginController : BaseController
    {
        IUserLoginRepository iUserLoginRepository = new UserLoginRepository();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string userName, string passWord)
        {

            var entity = this.iUserLoginRepository.Login(userName, passWord);
            int result = 512;
            if (entity != null)
            {
                Session["CurrentUserId"] = entity.UserId;
                result = 200;
            }

            return new JsonResult
            {
                Data = new Result(result, null, ""),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}