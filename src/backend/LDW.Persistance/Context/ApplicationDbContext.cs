using System.Threading;
using LDW.Application.Interfaces;
using LDW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using LDW.Persistence.Context.Configs;

namespace LDW.Persistence.Context
{
    public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<DormitoryEntity> Dormitories { get; set; }
		public DbSet<ForumSectionEntity> ForumSections { get; set; }
		public DbSet<ForumThreadEntity> ForumThreads { get; set; }
		public DbSet<ForumThreadReplyEntity> ForumThreadReplies { get; set; }

		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DormitoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserRefConfiguration());
            modelBuilder.ApplyConfiguration(new ForumSectionConfiguration());
            modelBuilder.ApplyConfiguration(new ForumThreadConfiguration());
            modelBuilder.ApplyConfiguration(new ForumThreadReplyConfiguration());
        }
    }
}