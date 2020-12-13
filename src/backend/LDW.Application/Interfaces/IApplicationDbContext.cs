using System.Threading;
using System.Threading.Tasks;
using LDW.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LDW.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<DormitoryEntity> Dormitories { get; set; }
        DbSet<ForumSectionEntity> ForumSectionEntities { get; set; } //TODO: rename
        DbSet<ForumThreadEntity> ForumThreadEntities { get; set; } //TODO: rename
        DbSet<ForumThreadReplyEntity> ForumThreadReplyEntities { get; set; } //TODO: rename
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}