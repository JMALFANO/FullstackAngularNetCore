using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fullstack_Angular_NetCore.Models.Response
{
    public class Status
    {
        public int Succes { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
