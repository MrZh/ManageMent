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
    public class DepartmentController : Controller
    {

        public IDepartmentRepository iDepartmentRepository = new DepartmentRepository();
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Department entity)
        {
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
    }
}