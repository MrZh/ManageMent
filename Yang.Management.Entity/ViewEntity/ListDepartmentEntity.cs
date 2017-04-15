using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yang.Management.Entity.ViewEntity
{
    public class ListDepartmentEntity : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ParentDepartmentName { get; set; }
    }
}