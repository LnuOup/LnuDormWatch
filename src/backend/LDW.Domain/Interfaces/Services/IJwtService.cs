using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LDW.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        Task<string> GenerateToken(
            string userId,
            IEnumerable<string> roles,
            TimeSpan timeSpan);
    }
}
