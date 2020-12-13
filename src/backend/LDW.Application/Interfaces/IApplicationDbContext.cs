using System.Threading;
using System.Threading.Tasks;
using LDW.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LDW.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<DormitoryEntity> Dormitories { get; set; }
        DbSet<ForumSectionEntity> ForumSectionEntities { get; set; }
        DbSet<ForumThreadEntity> ForumThreadEntities { get; set; }
        DbSet<ForumThreadReplyEntity> ForumThreadReplyEntities { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}