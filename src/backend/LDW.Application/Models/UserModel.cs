using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Application.Models
{
    public class UserModel
    {
        public string PhotoUrl { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }
    }
}
