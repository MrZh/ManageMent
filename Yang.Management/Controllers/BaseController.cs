using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yang.Management.Controllers
{
    public class BaseController : Controller
    {
        public string CurrentUserId
        {
            get
            {
                if (HttpContext.Session["CurrentUserId"] == null) {
                    return "22110";
                }
                return HttpContext.Session["CurrentUserId"].ToString();
            }
            
        }

        public string ClientIp
        {
            get
            {
                return HttpContext.Request.UserHostAddress;
            }
        }
    }
}