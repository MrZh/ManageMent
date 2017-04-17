using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Entity.ViewEntity
{
    public class ListAttendanceLogEntity : Entity
    {
        public string AttendanceTime { get; set; }

        public string AttendanceIp { get; set; }

        public string UserName { get; set; }

        public string AttendanceType { get; set; }

        public string AttendanceYear { get; set; }

        public string LogoutTime { get; set; }

        public string LogoutType { get; set; }

        public string AttendanceMonth { get; set; }
    }
}
