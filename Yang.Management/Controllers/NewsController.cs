using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yang.Management.Base;
using Yang.Management.Entity;
using Yang.Management.Entity.ViewEntity;
using Yang.Management.Models;

namespace Yang.Management.Controllers
{
    public class NewsController : BaseController
    {

        [HttpGet]
        // GET: News
        public JsonResult GetIndexNews(string type)
        {

            return new JsonResult {
                Data = new { name="name",id=type},
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetNewsList(int pageSize,int pageIndex, string key)
        {
            int temp= (pageIndex - 1) * pageSize;

            List<TestEntity> list = new List<TestEntity>();

            for (int i = temp + 1; i < temp + 1 + pageSize; i++)
            {
                list.Add(new TestEntity {Name=i.ToString(),Description="",IdentificationCard="1234" });
            }

            return new JsonResult
            {
                Data = new
                {
                    TotalPage = 10,
                    pageIndex = pageIndex,
                    data=list

                },
                JsonRequestBehavior=JsonRequestBehavior.AllowGet
            };
        }

        [HttpGet]
        public JsonResult GetNews(int pageSize, int pageIndex,string key)
        {
            List<NewsEntity> list = new List<NewsEntity>();
            int temp = (pageIndex - 1) * pageSize;
            for (int i = temp + 1; i < temp + 1 + pageSize; i++)
            {
                list.Add(new NewsEntity { Title = i.ToString(), Description = this.CurrentUserId, Content = "1234" ,Id=i.ToString(),CreateTime=DateTime.Now.ToShortDateString()});
            }

            ListEntity<NewsEntity> listData = new ListEntity<NewsEntity>();
            listData.PageIndex = pageIndex;
            listData.PageSize = pageSize;
            listData.TotalPage = 100;
            listData.Entity = list;

            return new JsonResult
            {
                Data = new Result(listData),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public JsonResult Create(TestEntity testenttiyt)
        {
            //IdentificationCard= Request.Form["data[IdentificationCard2]"];
            return new JsonResult {
                Data=testenttiyt,
                JsonRequestBehavior=JsonRequestBehavior.AllowGet
            };
        }
    }
}