using LDW.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LDW.Persistence.Context.Configs
{
    public class DormitoryConfiguration : IEntityTypeConfiguration<DormitoryEntity>
    {
        public void Configure(EntityTypeBuilder<DormitoryEntity> builder)
        {
            builder.ToTable("Dormitories");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.Address)
                .IsRequired();

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15);
        }
    }
}