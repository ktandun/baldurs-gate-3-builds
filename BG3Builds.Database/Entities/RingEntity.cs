using BG3Builds.Shared.Enums;
using BG3Builds.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class RingEntity : IHasIconUrl
{
    public required Guid RingId { get; set; }
    public required string Name { get; set; }
    public required string WikiUrl { get; set; }
    public required string IconUrl { get; set; }

    public class RingEntityConfiguration : IEntityTypeConfiguration<RingEntity>
    {
        public void Configure(EntityTypeBuilder<RingEntity> builder)
        {
            builder.ToTable("rings");
            builder.HasKey(c => c.RingId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
            builder.Property(c => c.IconUrl).HasMaxLength(200).IsRequired();
        }
    }
}