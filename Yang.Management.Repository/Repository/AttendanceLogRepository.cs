using System;
using System.Collections.Generic;
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
        public ListEntity<ListAttendanceLogEntity> GetList(string userId, string year, string month, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Save(AttendanceLog entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.AttendanceYear = entity.AttendanceTime.Value.Year.ToString();
            entity.AttendanceMonth = entity.AttendanceTime.Value.Month.ToString();
            throw new NotImplementedException();
        }
    }
}
