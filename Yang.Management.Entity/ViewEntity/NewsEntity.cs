using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Entity.ViewEntity
{
    public class NewsEntity : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string CreateTime { get; set; }

        public string Type { get; set; }

    }
}
