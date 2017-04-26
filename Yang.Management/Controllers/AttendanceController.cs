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
        [LoginCheck]
        public ActionResult Index()
        {
            return View();
        }

        [LoginCheckJson]
        public JsonResult GetListByUserId(string userId, string year, string month, int pageIndex, int pageSize)
        {
            if (userId == "null")
            {
                userId = "";
            }

            if (month == "null")
            {
                month = "";
            }

            if (year == "null")
            {
                year = "";
            }

            var result = this.iAttendanceLogRepository.GetList(userId, year, month, pageIndex, pageSize);
            return new JsonResult
            {
                Data = new Result(result),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}