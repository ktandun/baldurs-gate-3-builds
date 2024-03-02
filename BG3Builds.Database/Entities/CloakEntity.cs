using BG3Builds.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class CloakEntity : IHasIconUrl
{
    public required Guid CloakId { get; set; }
    public required string Name { get; set; }
    public required string WikiUrl { get; set; }
    public required string IconUrl { get; set; }
    public Guid ImageId { get; set; }

    public class CloakEntityConfiguration : IEntityTypeConfiguration<CloakEntity>
    {
        public void Configure(EntityTypeBuilder<CloakEntity> builder)
        {
            builder.ToTable("cloaks");
            builder.HasKey(c => c.CloakId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
            builder.Property(c => c.IconUrl).HasMaxLength(200).IsRequired();
        }
    }
}