using System;
using System.Collections.Generic;
using System.IO;
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
            if (Request.Files.Count <= 0)
            {
                return new JsonResult
                {
                    Data = new
                    {
                        code = 0,
                        msg = "",
                        data = new
                        {
                            src = "",
                            title = ""
                        }
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            HttpFileCollectionBase files = Request.Files;
            var file = files[0];
            String url = Server.MapPath("/Content/Image/");
            string extention= Path.GetExtension(file.FileName);
            string tempName = Guid.NewGuid().ToString();
            string fileName = url + tempName + extention;
            file.SaveAs(fileName);
           
            return new JsonResult {
                Data = new {
                    code = 0,
                    msg="",
                    data = new {
                        src = "/Content/Image/"+tempName+extention,
                        title=""
                    }
                },
                JsonRequestBehavior =JsonRequestBehavior.AllowGet
            };
        }
    }
}