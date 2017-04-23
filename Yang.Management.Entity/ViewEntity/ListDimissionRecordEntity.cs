using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yang.Management.Entity.ViewEntity
{
    public class ListDimissionRecordEntity : Entity
    {
        public string UserName { get; set; }

        public string CreateTime { get; set; }

        public string Type { get; set; }

        public string Content { get; set; }

        public string CreateUserName { get; set; }

        public string DepartmentName { get; set; }
    }
}