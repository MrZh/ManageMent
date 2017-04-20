using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;

namespace Yang.Management.Repository
{
    public interface IAttendanceLogRepository
    {
        void Save(AttendanceLog entity);

        ListEntity<ListAttendanceLogEntity> GetList(string userId,string year,string month, int pageIndex, int pageSize);

        int IsAttendance(string userId, DateTime date);

        AttendanceLog GetAttendance(string userId, DateTime date);
    }
}
