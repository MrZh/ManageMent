using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Repository
{
    public class BaseCommand
    {
        public string CommandId { get; protected set; }

        public string Sql { get; protected set; }

        public object Obj { get; protected set; }

        public BaseCommand(string sql, object obj)
        {
            Sql = sql;
            Obj = obj;
            CommandId = Guid.NewGuid().ToString();
        }

    }
}
