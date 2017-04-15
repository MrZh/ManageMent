using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yang.Management.Base
{
    public struct Result
    {
        public int Status { get; set; }

        public object Data { get; set; }

        public string Message { get; set; }

        public Result(int status, object data, string message)
        {
            this.Status = status;
            this.Data = data;
            this.Message = message;
        }

        public Result(object data)
        {
            this.Status = 200;
            this.Message = null;
            this.Data = data;
        }
    }
}