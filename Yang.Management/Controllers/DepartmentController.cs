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
    public class DepartmentController : BaseController
    {

        public IDepartmentRepository iDepartmentRepository = new DepartmentRepository();
        // GET: Department
        [LoginCheck]
        public ActionResult Index()
        {
            return View();
        }

        [LoginCheck]
        public ActionResult Create()
        {
            return View();
        }

        [LoginCheckJson]
        [HttpPost]
        public JsonResult Create(Department entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = this.CurrentUserId;
            if (entity.ParentDepartmentId.Equals("null"))
            {
                entity.ParentDepartmentId = null;
            }
            this.iDepartmentRepository.Save(entity);

            return new JsonResult
            {
                Data = new Result(null)
            };
        }

        [LoginCheck]
        public ActionResult Edit(string id)
        {
            ViewBag.id = id;
            return View();
        }

        [LoginCheckJson]
        [HttpPost]
        public JsonResult Edit(Department entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = this.CurrentUserId;
            if (entity.ParentDepartmentId.Equals("null"))
            {
                entity.ParentDepartmentId = null;
            }
            this.iDepartmentRepository.Save(entity);

            return new JsonResult
            {
                Data = new Result(null)
            };
        }

        [LoginCheckJson]
        public JsonResult DeleteDepartments(string id)
        {
            string[] ids = id.Split(',');
            int result = this.iDepartmentRepository.Delete(ids);
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
                Data = new Result(511,null,"存在子机构或者机构下有人"),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheckJson]
        public JsonResult GetDepartments(string key, int pageIndex, int pageSize)
        {
            return new JsonResult
            {
                Data = new Result(this.iDepartmentRepository.GetList(key,pageIndex,pageSize)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheckJson]
        public JsonResult GetDepartment(string id)
        {
            return new JsonResult
            {
                Data = new Result(this.iDepartmentRepository.GetItem(id)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheckJson]
        public JsonResult GetAllDepartment()
        {
            return new JsonResult
            {
                Data = new Result(this.iDepartmentRepository.GetAllList()),
                JsonRequestBehavior=JsonRequestBehavior.AllowGet
            };
        }
    }
}