using LDW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Persistence.Context.Configs
{
	public class DormitoryPictureConfiguration : IEntityTypeConfiguration<DormitoryPictureEntity>
	{
		public void Configure(EntityTypeBuilder<DormitoryPictureEntity> builder)
		{
			builder.ToTable("DormitoryPictures");

			builder.HasKey(dp => dp.Id);

			builder.Property(dp => dp.IsMain)
				.IsRequired();

			builder.Property(dp => dp.Image)
				.IsRequired();

			builder
				.HasOne(dp => dp.Dormitory)
				.WithMany(d => d.DormitoryPictures)
				.HasForeignKey(dp => dp.DormitoryId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
