using System;
using System.Collections.Generic;
using System.Text;
using LDW.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace LDW.Domain.Entities
{
    public class UserEntity : IdentityUser
    {
        public string PhotoUrl { get; set; }
    }
}
