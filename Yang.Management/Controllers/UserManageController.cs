using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yang.Management.Base;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;
using Yang.Management.Repository;
using Yang.Management.Repository.Repository;

namespace Yang.Management.Controllers
{
    public class UserManageController : Controller
    {

        public IUserInfoRepository iUserInfoRepository = new UserInfoRepository();

        // GET: UserManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UserInfo entity)
        {

            entity.Password = "123456";
            entity.CreateTime = DateTime.Now;
            entity.Status = 0;
            iUserInfoRepository.Save(entity);
            return new JsonResult
            {
                Data = new Result(null),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult IsExist(string name)
        {
            int status = 200;
            if (this.iUserInfoRepository.IsExist(name))
            {
                status = 511;
            }

            return new JsonResult
            {
                Data = new Result(status, null, ""),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult getUserList()
        {
            ListEntity<ListUserEntity> list = this.iUserInfoRepository.GetListByKey("1", 1, 3);

            return new JsonResult
            {
                Data = new Result(list),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}