using BG3Builds.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class RingEntity
{
    public required Guid RingId { get; set; }
    public required string Name { get; set; }
    public required string WikiUrl { get; set; }
    public Guid ImageId { get; set; }

    public class RingEntityConfiguration : IEntityTypeConfiguration<RingEntity>
    {
        public void Configure(EntityTypeBuilder<RingEntity> builder)
        {
            builder.ToTable("rings");
            builder.HasKey(c => c.RingId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
        }
    }
}