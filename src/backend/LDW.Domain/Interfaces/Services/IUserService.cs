using LDW.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LDW.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> FindByEmailAsync(string email);
    }
}
