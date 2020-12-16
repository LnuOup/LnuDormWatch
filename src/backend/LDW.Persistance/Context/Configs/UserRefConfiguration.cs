using LDW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Persistence.Context.Configs
{
	public class UserRefConfiguration : IEntityTypeConfiguration<UserRefEntity>
	{
		public void Configure(EntityTypeBuilder<UserRefEntity> builder)
		{
			builder.ToTable("UserRefs");

			builder.HasKey(e => e.Id);
		}
	}
}
