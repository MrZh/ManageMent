﻿using System;
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
    public class MyAttendanceController : BaseController
    {
        IAttendanceLogRepository iAttendanceLogRepository = new AttendanceLogRepository();
        IUserInfoRepository iUserInfoRepository = new UserInfoRepository();
        // GET: MyAttendance
        [LoginCheck]
        public ActionResult Index()
        {
            return View();
        }

        [LoginCheckJson]
        public JsonResult GetCurrentUserInfo()
        {
            var user = iUserInfoRepository.GetUserById(this.CurrentUserId);
            if (user == null)
            {
                return new JsonResult
                {
                    Data = new Result(125, null, null),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

            return new JsonResult
            {
                Data = new Result(new { UserName = user.Name, Id = user.Id, DepartmentId = user.DepartmentId, Resign = user.Resign, Salary = user.Salary }),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet

            };
        }

        /// <summary>
        /// 515：已签退 514：已签到无签退 513;未签到
        /// </summary>
        /// <returns></returns>
        [LoginCheckJson]
        public JsonResult IsAttendance()
        {
            int status = this.iAttendanceLogRepository.IsAttendance(this.CurrentUserId, DateTime.Now);


            return new JsonResult
            {
                Data = new Result(status, null, null),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


        }

        [LoginCheckJson]
        public JsonResult GetMyAttendanceList(string year, string month, int pageIndex, int pageSize)
        {
            if (year == "null")
            {
                year = null;
            }
            if (month == "null")
            {
                month = null;
            }

            var result = this.iAttendanceLogRepository.GetList(this.CurrentUserId, year, month, pageIndex, pageSize);
            return new JsonResult
            {
                Data = new Result(result),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [LoginCheckJson]
        public JsonResult Attendance()
        {
            var result = this.iAttendanceLogRepository.GetAttendance(this.CurrentUserId, DateTime.Now);
            if (result == null)
            {
                result = new AttendanceLog();
                result.AttendanceIp = this.ClientIp;
                result.AttendanceTime = DateTime.Now;
                result.ShouldAttendanceTime = DateTime.Today.AddHours(9);
                result.ShouldLogoutTime = DateTime.Today.AddHours(17).AddMinutes(30);
                result.UserId = this.CurrentUserId;
                result.AttendanceType = DateTime.Now > result.ShouldAttendanceTime ? 1 : 0;
            }

            else
            {
                if (result.LogoutTime.HasValue)
                {
                    return new JsonResult
                    {
                        Data = new Result(515),
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }

                result.LogoutTime = DateTime.Now;
                result.LogoutType = DateTime.Now < result.ShouldLogoutTime ? 1 : 0;
            }


            this.iAttendanceLogRepository.Save(result);
            return new JsonResult
            {
                Data = new Result(null),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}