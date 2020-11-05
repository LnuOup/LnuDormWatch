using Microsoft.EntityFrameworkCore;

namespace LnuDormWatch.WebApi.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options):base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Dorm> Dorms { get; set; }
    }
}