using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yang.Management.Base;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;
using Yang.Management.Models;
using Yang.Management.Repository;
using Yang.Management.Repository.Repository;

namespace Yang.Management.Controllers
{
    public class NewsController : BaseController
    {
        public INewsRepository iNewsRepository = new NewsRepository();


        [LoginCheck]
        public ActionResult GetDetail(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [LoginCheckJson]
        public JsonResult NewsDetail(string id)
        {
            return new JsonResult
            {
                Data = new Result(this.iNewsRepository.GetDetail(id)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            
        }

        [LoginCheckJson]
        [HttpGet]
        // GET: News
        public JsonResult GetIndexNews(string type)
        {

            return new JsonResult
            {
                Data = new { name = "name", id = type },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheckJson]
        public JsonResult GetNewsList(int pageSize, int pageIndex, string key)
        {
            int temp = (pageIndex - 1) * pageSize;

            List<TestEntity> list = new List<TestEntity>();

            for (int i = temp + 1; i < temp + 1 + pageSize; i++)
            {
                list.Add(new TestEntity { Name = i.ToString(), Description = "", IdentificationCard = "1234" });
            }

            return new JsonResult
            {
                Data = new
                {
                    TotalPage = 10,
                    pageIndex = pageIndex,
                    data = list

                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpGet]
        [LoginCheckJson]
        public JsonResult GetNews(int pageSize, int pageIndex, string key)
        {
            ListEntity<NewsEntity> listData = this.iNewsRepository.GetList(key, pageIndex, pageSize);
            return new JsonResult
            {
                Data = new Result(listData),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheckJson]
        [HttpGet]
        public JsonResult GetNewsByType(int pageSize, int pageIndex, string type)
        {
            ListEntity<NewsEntity> listData = this.iNewsRepository.GetListByType(type, pageIndex, pageSize);
            return new JsonResult
            {
                Data = new Result(listData),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheck]
        public ActionResult Create()
        {
            return View();
        }

        [LoginCheckJson]
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Create(News entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.Description = CutString.CutWithOutHtml(entity.Contents, 200);
            this.iNewsRepository.Save(entity);

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
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Edit(News entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.Description = CutString.CutWithOutHtml(entity.Contents, 200);
            this.iNewsRepository.Save(entity);

            return new JsonResult
            {
                Data = new Result(null)
            };
        }

        [LoginCheckJson]
        public JsonResult DeleteNews(string id)
        {
            string[] ids = id.Split(',');
            int result = this.iNewsRepository.Delete(ids);
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
                Data = new Result(511, null, "无法被删除"),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheckJson]
        public JsonResult GetNewsDetail(string id)
        {
            return new JsonResult
            {
                Data = new Result(this.iNewsRepository.GetItem(id)),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [LoginCheck]
        public ActionResult Index()
        {
            return View();
        }


        //[ValidateInput(false)]
        //[HttpPost]
        //public JsonResult Create(TestEntity testenttiyt)
        //{
        //    //IdentificationCard= Request.Form["data[IdentificationCard2]"];
        //    return new JsonResult
        //    {
        //        Data = testenttiyt,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}
    }
}