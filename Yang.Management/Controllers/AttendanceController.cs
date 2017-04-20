using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yang.Management.Base;
using Yang.Management.Repository;
using Yang.Management.Repository.Repository;

namespace Yang.Management.Controllers
{
    public class AttendanceController : BaseController
    {
        IAttendanceLogRepository iAttendanceLogRepository = new AttendanceLogRepository();
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetListByUserId(string userId, string year, string month, int pageIndex, int pageSize)
        {
            var result = this.iAttendanceLogRepository.GetList(this.CurrentUserId, year, month, pageIndex, pageSize);
            return new JsonResult
            {
                Data = new Result(result),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}