using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yang.Management.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        [HttpPost]
        public JsonResult Upload()
        {
            HttpFileCollectionBase files = Request.Files;
            return new JsonResult {
                Data = new {
                    code = 0,
                    msg="",
                    data = new {
                        src = "/Content/1.jpg",
                        title=""
                    }
                },
                JsonRequestBehavior =JsonRequestBehavior.AllowGet
            };
        }
    }
}