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
    public class UserManageController : BaseController
    {

        public IUserInfoRepository iUserInfoRepository = new UserInfoRepository();
        public IDimissionRecordRepository iDimissionRecordRepository = new DimissionRecordRepository();
        public IUserModifyLogRepository iUserModifyLogRepository = new UserModifyLogRepository();
        public ISalaryModifyLogRepository iSalaryModifyLogRepository = new SalaryModifyLogRepository();

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

        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(UserInfo entity)
        {
            iUserInfoRepository.Save(entity);
            return new JsonResult
            {
                Data = new Result(null),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult DimissRecord()
        {
            return View();
        }

        public JsonResult GetDimissListByUserId(string userId, int pageIndex, int pageSize)
        {
            if (userId == "null")
            {
                userId = "";
            }

            var result = this.iDimissionRecordRepository.GetListByUserId(userId, pageIndex, pageSize);
            return new JsonResult
            {
                Data = new Result(result),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult Dismiss(String id)
        {
            ViewBag.Id = id;
            var user = iUserInfoRepository.GetUserById(id);
            if (user != null)
            {
                ViewBag.Name = user.Name;
                ViewBag.DepartmentId = user.DepartmentId;
            }
            return View();
        }

        [HttpPost]
        public JsonResult Dismiss(DimissionRecord entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = CurrentUserId;
            UserInfo user = new UserInfo();
            user.Id = entity.UserId;
            user.Status = 2;
            if (entity.Type == 3)
            {
                user.Status = 3;
            }
            iDimissionRecordRepository.Save(entity);
            iUserInfoRepository.Save(user);
            return new JsonResult
            {
                Data = new Result(null),
            };
        }

        public ActionResult ChangePassword()
        {
            ViewBag.Id = CurrentUserId;
            return View();
        }

        public ActionResult UserModify(String id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public JsonResult UserModify(UserModifyLog entity)
        {
            entity.ModifyTime = DateTime.Now;
            entity.CreateUserId = CurrentUserId;
            UserInfo user = new UserInfo();
            user.Id = entity.ModifyUserId;
            user.DepartmentId = entity.NowDepartmentId;
            user.Resign = entity.NowResign;
            iUserModifyLogRepository.Save(entity);
            iUserInfoRepository.Save(user);
            return new JsonResult
            {
                Data = new Result(null),
            };
        }

        public ActionResult UserModifyRecord()
        {
            return View();
        }

        public JsonResult GetModifyListByUserId(string userId, int pageIndex, int pageSize)
        {
            if (userId == "null")
            {
                userId = "";
            }

            var result = this.iUserModifyLogRepository.GetList(userId, pageIndex, pageSize);
            return new JsonResult
            {
                Data = new Result(result),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult UserSalaryModify(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public JsonResult UserSalaryModify(SalaryModifyLog entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = CurrentUserId;
            UserInfo user = new UserInfo();
            user.Id = entity.UserId;
            user.Salary = entity.SalaryModify;
            iSalaryModifyLogRepository.Save(entity);
            iUserInfoRepository.Save(user);
            return new JsonResult
            {
                Data = new Result(null),
            };
        }

        public ActionResult UserSalaryModifyRecord()
        {
            return View();
        }

        public JsonResult GetSalaryModifyListByUserId(string userId, int pageIndex, int pageSize)
        {
            if (userId == "null")
            {
                userId = "";
            }

            var result = this.iSalaryModifyLogRepository.GetList(userId, pageIndex, pageSize);
            return new JsonResult
            {
                Data = new Result(result),
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

        public JsonResult DeleteUsers(string id)
        {
            string[] ids = id.Split(',');
            int result = 1;
            this.iUserInfoRepository.DeleteUsers(ids);
            if (result == 1)
            {
                return new JsonResult
                {
                    Data = new Result(null),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return new JsonResult
            {
                Data = new Result(511, null, "该职务下有人"),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetUserList(string key, int pageSize,int pageIndex)
        {
            ListEntity<ListUserEntity> list = this.iUserInfoRepository.GetListByKey(key, pageIndex, pageSize);

            return new JsonResult
            {
                Data = new Result(list),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetAllUserList()
        {
            List<ListUserEntity> list = this.iUserInfoRepository.GetAllList();

            return new JsonResult
            {
                Data = new Result(list),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}