using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Entity.ViewEntity
{
    public class ListResignEntity : Entity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreateTime { get; set; }

        public string Responsibility { get; set; }
    }
}
