using LDW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Persistence.Context.Configs
{
	public class ForumThreadConfiguration : IEntityTypeConfiguration<ForumThreadEntity>
	{
		public void Configure(EntityTypeBuilder<ForumThreadEntity> builder)
		{
            builder.ToTable("ForumThreads");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.ForumSectionId)
                .IsRequired();

            builder.Property(e => e.ThreadTitle)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.ThreadBody)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(e => e.AuthorId)
                .IsRequired();

            builder.Property(e => e.CreationDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");


            builder
                .HasOne(ft => ft.Author)
                .WithMany(u => u.ForumThreads)
                .HasForeignKey(ft => ft.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(ft => ft.ForumSection)
                .WithMany(fs => fs.ForumThreads)
                .HasForeignKey(ft => ft.ForumSectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
	}
}
