using BG3Builds.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class AmuletEntity
{
    public required Guid AmuletId { get; set; }
    public required string Name { get; set; }
    public required string WikiUrl { get; set; }
    public Guid ImageId { get; set; }

    public class AmuletEntityConfiguration : IEntityTypeConfiguration<AmuletEntity>
    {
        public void Configure(EntityTypeBuilder<AmuletEntity> builder)
        {
            builder.ToTable("amulets");
            builder.HasKey(c => c.AmuletId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
        }
    }
}