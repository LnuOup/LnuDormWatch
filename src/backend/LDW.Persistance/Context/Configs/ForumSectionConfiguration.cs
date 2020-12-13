using LDW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Persistence.Context.Configs
{
	public class ForumSectionConfiguration : IEntityTypeConfiguration<ForumSectionEntity>
	{
		public void Configure(EntityTypeBuilder<ForumSectionEntity> builder)
		{
            builder.ToTable("ForumSections");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.SectionTitle)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.SectionDescription)
                .HasMaxLength(200);

            builder.Property(e => e.CreationDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(fs => fs.Author)
                .WithMany(u => u.ForumSections)
                .HasForeignKey(fs => fs.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
	}
}
