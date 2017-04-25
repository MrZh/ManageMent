using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Entity.ViewEntity
{
    public class ListUserModifyLogEntity : Entity
    {

        public string ModifyTime { get; set; }


        public string OrginalDepartmentId { get; set; }


        public string NowDepartmentId { get; set; }

        public string OrginalDepartmentName { get; set; }


        public string NowDepartmentName { get; set; }


        public string OriginalResign { get; set; }


        public string NowResign { get; set; }


        public string OriginalResignName { get; set; }


        public string NowResignName { get; set; }


        public string ModifyUserId { get; set; }

        public string UserName { get; set; }

        public string CreateUserId { get; set; }

        public string Content { get; set; }
    }
}
