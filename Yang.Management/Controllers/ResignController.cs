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
    public class ResignController : Controller
    {
        public IResignRepository iResignRepository = new ResignRepository();
        // GET: Resign
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Resign entity)
        {
            entity.CreateTime = DateTime.Now;
            this.iResignRepository.Save(entity);

            return new JsonResult
            {
                Data = new Result(null)
            };
        }

        public JsonResult DeleteResigns(string id)
        {
            string[] ids = id.Split(',');
            int result = this.iResignRepository.Delete(ids);
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

        public JsonResult GetResigns(string key, int pageIndex, int pageSize)
        {
            return new JsonResult
            {
                Data = new Result(this.iResignRepository.GetList(key, pageIndex, pageSize)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetResign(string id)
        {
            return new JsonResult
            {
                Data = new Result(this.iResignRepository.GetItem(id)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetAllResign()
        {
            return new JsonResult
            {
                Data = new Result(this.iResignRepository.GetAllList()),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}