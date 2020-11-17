using LDW.Application.Interfaces;
using LDW.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Persistence.Context
{
    public class UserDbContext : IdentityDbContext<UserEntity>, IUserDbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
