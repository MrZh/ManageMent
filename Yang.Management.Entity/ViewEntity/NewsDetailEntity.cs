using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Entity.ViewEntity
{
    public class NewsDetailEntity : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Contents { get; set; }

        public string CreateTime { get; set; }

        public string Type { get; set; }

        public string CreateUserId { get; set; }

        public string CreateUserName { get; set; }
    }
}
