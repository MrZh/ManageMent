using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yang.Management
{
    public class LoginCheck: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["CurrentUserId"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}