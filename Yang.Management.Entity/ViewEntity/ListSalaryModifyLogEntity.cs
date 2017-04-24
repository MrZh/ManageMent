using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Entity.ViewEntity
{
    public class ListSalaryModifyLogEntity : Entity
    {
        public string CreateUserName { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }
        public string CreateUserId { get; set; }

        public DateTime CreateTime { get; set; }

        public decimal SalaryModify { get; set; }


        public decimal OriginalSalary { get; set; }

        public string Content { get; set; }
    }
}
