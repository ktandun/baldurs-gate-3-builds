using BG3Builds.Shared.Enums;
using BG3Builds.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class FeatEntity : IHasIconUrl
{
    public required Guid FeatId { get; set; }
    public required string Name { get; set; }
    public required FeatExtraChoice ExtraChoice { get; set; }
    public required string WikiUrl { get; set; }
    public required string IconUrl { get; set; }

    public class FeatEntityConfiguration : IEntityTypeConfiguration<FeatEntity>
    {
        public void Configure(EntityTypeBuilder<FeatEntity> builder)
        {
            builder.ToTable("feats");
            builder.HasKey(c => c.FeatId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(200).IsRequired();
            builder.Property(c => c.IconUrl).HasMaxLength(200).IsRequired();
        }
    }
}