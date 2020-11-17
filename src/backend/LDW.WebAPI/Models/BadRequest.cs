using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LDW.WebAPI.Models
{
    internal class BadRequest
    {
        public string Message { get; set; }
        public string Details { get; set; }
        public Exception Exception { get; set; }
    }
}
