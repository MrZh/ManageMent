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
                return "22110";
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