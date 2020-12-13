using LDW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LDW.Persistence.Context.Configs
{
	public class ForumThreadReplyConfiguration : IEntityTypeConfiguration<ForumThreadReplyEntity>
	{
		public void Configure(EntityTypeBuilder<ForumThreadReplyEntity> builder)
		{
			builder.ToTable("ForumThreadReplies");

			builder.HasKey(e => e.Id);

			builder.Property(e => e.ParentForumThreadId)
				.IsRequired();

			builder.Property(e => e.AuthorId)
				.IsRequired();

			builder.Property(e => e.ReplyBody)
				.IsRequired()
				.HasMaxLength(5000);

			builder.Property(e => e.CreationDate)
				.IsRequired()
				.ValueGeneratedOnAdd();

			builder
				.HasOne(ftr => ftr.Author)
				.WithMany(u => u.ForumThreadReplies)
				.HasForeignKey(ftr => ftr.AuthorId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			builder
				.HasOne(ftr => ftr.ForumThread)
				.WithMany(ft => ft.ForumThreadReplies)
				.HasForeignKey(ftr => ftr.ParentForumThreadId)
				.OnDelete(DeleteBehavior.Cascade);

			builder
				.HasOne(ftr => ftr.ParentForumThreadReply)
				.WithMany(ftr => ftr.ForumThreadReplies)
				.HasForeignKey(ftr => ftr.ParentForumThreadReplyId)
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
