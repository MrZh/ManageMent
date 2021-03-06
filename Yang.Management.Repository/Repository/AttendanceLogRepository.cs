﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;

namespace Yang.Management.Repository.Repository
{
    public class AttendanceLogRepository : IAttendanceLogRepository
    {
        public DataContext context = new DataContext();
        public ListEntity<ListAttendanceLogEntity> GetList(string userId, string year, string month, int pageIndex, int pageSize)
        {
            var list = this.context.AttendanceLog.Where(c => true);
            if (!string.IsNullOrWhiteSpace(userId))
            {
                list = list.Where(c => c.UserId == userId);
            }

            if (!string.IsNullOrWhiteSpace(year))
            {
                list = list.Where(c => c.AttendanceYear == year);
            }

            if (!string.IsNullOrWhiteSpace(month))
            {
                list = list.Where(c => c.AttendanceMonth == month);
            }
            List<ListAttendanceLogEntity> tempList = new List<ListAttendanceLogEntity>();
            int total = list.Count();
            if (total <= 0)
            {
                return new ListEntity<ListAttendanceLogEntity>(tempList, total, pageIndex, pageSize);
            }

            List<string> ids = list.OrderByDescending(c => c.AttendanceTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(c => c.Id).ToList();

            BaseQuery query = new BaseQuery("SELECT Id,AttendanceIp,AttendanceTime,AttendanceType,AttendanceYear,LogoutTime,LogoutType,AttendanceMonth, (select name from UserInfo where Id=UserId) as UserName FROM AttendanceLog where id in @ids", new { ids = ids });
            tempList = DapperContext.BaseGetListByParam<ListAttendanceLogEntity>(query);
            return new ListEntity<ListAttendanceLogEntity>(tempList, total, pageIndex, pageSize);

        }

        public int IsAttendance(string userId, DateTime date)
        {
            var dbclass = this.context.AttendanceLog.Where(c => c.UserId.Equals(userId) && c.AttendanceDay == date.Day.ToString() && c.AttendanceMonth == date.Month.ToString() && c.AttendanceYear == date.Year.ToString()).FirstOrDefault();
            if (dbclass == null)
            {
                return 513;
            }

            if (dbclass.LogoutTime.HasValue)
            {
                return 515;
            }

            return 514;
        }

        public AttendanceLog GetAttendance(string userId, DateTime date)
        {
            var dbclass = this.context.AttendanceLog.Where(c => c.UserId.Equals(userId) && c.AttendanceDay == date.Day.ToString() && c.AttendanceMonth == date.Month.ToString() && c.AttendanceYear == date.Year.ToString()).FirstOrDefault();
            return dbclass;
        }

        public void Save(AttendanceLog entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            var dbclass = this.context.AttendanceLog.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (dbclass == null)
            {
                dbclass = new AttendanceLog();
                dbclass.Id = Guid.NewGuid().ToString();
                this.context.AttendanceLog.Add(dbclass);
            }
            dbclass.AttendanceIp = entity.AttendanceIp != null ? entity.AttendanceIp : dbclass.AttendanceIp;
            dbclass.AttendanceTime = entity.AttendanceTime != null ? entity.AttendanceTime : dbclass.AttendanceTime;
            dbclass.IsDayOff = entity.IsDayOff != null ? entity.IsDayOff : dbclass.IsDayOff;
            dbclass.LogoutTime = entity.LogoutTime != null ? entity.LogoutTime : dbclass.LogoutTime;
            dbclass.ShouldAttendanceTime = entity.ShouldAttendanceTime != null ? entity.ShouldAttendanceTime : dbclass.ShouldAttendanceTime;
            dbclass.ShouldLogoutTime = entity.ShouldLogoutTime != null ? entity.ShouldLogoutTime : dbclass.ShouldLogoutTime;
            dbclass.UserId = entity.UserId != null ? entity.UserId : dbclass.UserId;
            dbclass.AttendanceYear = DateTime.Now.Year.ToString();
            dbclass.AttendanceMonth = DateTime.Now.Month.ToString();
            dbclass.AttendanceDay = DateTime.Now.Day.ToString();
            dbclass.AttendanceType = 1;
            dbclass.LogoutType = 1;
            dbclass.IsDayOff = 0;
            if (entity.LogoutTime != null && entity.LogoutTime < entity.ShouldLogoutTime)
            {
                dbclass.LogoutType = 0;
            }

            if (entity.AttendanceTime != null && entity.AttendanceTime > entity.ShouldAttendanceTime)
            {
                dbclass.AttendanceType = 0;
            }

            if (dbclass.AttendanceType == 0 && dbclass.AttendanceType == 0)
            {
                dbclass.IsDayOff = 1;
            }

            this.context.SaveChanges();
        }
    }
}
