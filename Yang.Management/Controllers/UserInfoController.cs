using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yang.Management.Base;
using Yang.Management.Repository;
using Yang.Management.Repository.Repository;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;

namespace Yang.Management.Controllers
{
    public class UserInfoController : BaseController
    {

        IUserInfoRepository iUserInfoRepository = new UserInfoRepository();
        IUserLoginRepository iUserLoginRepository = new UserLoginRepository();
        // GET: UserInfo
        [LoginCheck]
        public ActionResult Index()
        {
            ViewBag.Id = CurrentUserId;
            return View();
        }

        [LoginCheck]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [LoginCheckJson]
        public ActionResult Edit(UserInfo entity)
        {
            iUserInfoRepository.Save(entity);
            return new JsonResult
            {
                Data = new Result(null),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        [LoginCheckJson]
        public JsonResult ChangePassword(string OldPassword, string NewPassword, string ConfirmPassword)
        {            
            int status = 200;
            string message = "";
            if (NewPassword != ConfirmPassword)
            {
                status = 511;
                message = "两次密码不一致";
            }

            if (OldPassword == NewPassword)
            {
                status = 511;
                message = "新旧密码不能相同";
            }
            var user = iUserLoginRepository.GetPassword(CurrentUserId);
            
            if (user == null)
            {
                status = 125;
                message = "重新登录";

            }
            if (user.PassWord.Equals(CommonEncrypt.Encrypt(OldPassword)))
            {
                status = 511;
                message = "旧密码不正确";
            }
            user.PassWord = CommonEncrypt.Encrypt(NewPassword);
            iUserLoginRepository.Save(user);
            return new JsonResult
            {
                Data = new Result(status, null, message),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheckJson]
        public JsonResult GetUserById(string id)
        {
            var user = iUserInfoRepository.GetUserById(id);
            if (user == null)
            {
                return new JsonResult
                {
                    Data = new Result(null),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return new JsonResult
            {
                Data = new Result(
               new
               {
                   Id = user.Id,
                   Name = user.Name,
                   LoginName = user.LoginName,
                   Birthday = user.Birthday.Value.ToString("yyyy-MM-dd"),
                   IdentificationCard = user.IdentificationCard,
                   EntryTime = user.EntryTime.Value.ToString("yyyy-MM-dd"),
                   Address = user.Address,
                   NativePlace = user.NativePlace,
                   Resign = user.Resign,
                   DepartmentId = user.DepartmentId,
                   Sex = user.Sex,
                   IsMarried = user.IsMarried,
                   MobilePhone = user.MobilePhone,
                   Email = user.Email
               }

                ),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}