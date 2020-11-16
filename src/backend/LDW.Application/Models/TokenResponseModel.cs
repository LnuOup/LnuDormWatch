using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Application.Models
{
    public class TokenResponseModel
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
