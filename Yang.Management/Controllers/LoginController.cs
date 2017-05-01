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
        IUserInfoRepository iUserInfoRepository = new UserInfoRepository();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult NotLogin()
        {
            return new JsonResult
            {
                Data = new Result(125, null, ""),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public JsonResult Login(string userName, string passWord)
        {

            var entity = this.iUserLoginRepository.Login(userName, passWord);
            int result = 512;
            if (entity != null)
            {
                Session["CurrentUserId"] = entity.UserId;
                Session["CurrentUserType"] = "0";
                var user = this.iUserInfoRepository.GetUserById(entity.UserId);
                if (user != null)
                {
                    if (user.DepartmentId == "2c629df4-0f2f-4f64-8cc2-4fc8ce4dfb8a")
                    {
                        Session["CurrentUserType"] = "1";
                    }
                }
                if (user != null)
                {
                    if (user.Status != 0 || user.Status != 1) {
                        return new JsonResult
                        {
                            Data = new Result(500, null, ""),
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                }

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