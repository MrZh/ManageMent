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
    public class ResignController : BaseController
    {
        public IResignRepository iResignRepository = new ResignRepository();
        // GET: Resign
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
        public JsonResult Create(Resign entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = this.CurrentUserId;
            this.iResignRepository.Save(entity);

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
        public JsonResult Edit(Resign entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = this.CurrentUserId;
            this.iResignRepository.Save(entity);

            return new JsonResult
            {
                Data = new Result(null)
            };
        }

        [LoginCheckJson]
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

        [LoginCheckJson]
        public JsonResult GetResigns(string key, int pageIndex, int pageSize)
        {
            return new JsonResult
            {
                Data = new Result(this.iResignRepository.GetList(key, pageIndex, pageSize)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheckJson]
        public JsonResult GetResign(string id)
        {
            return new JsonResult
            {
                Data = new Result(this.iResignRepository.GetItem(id)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheckJson]
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