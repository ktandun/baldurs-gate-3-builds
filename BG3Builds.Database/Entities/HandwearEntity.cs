using BG3Builds.Shared.Enums;
using BG3Builds.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class HandwearEntity : IHasIconUrl
{
    public required Guid HandwearId { get; set; }
    public required string Name { get; set; }
    public required string WikiUrl { get; set; }
    public required string IconUrl { get; set; }
    public required ArmourProficiency ArmourProficiency { get; set; }
    public Guid ImageId { get; set; }

    public class HandwearEntityConfiguration : IEntityTypeConfiguration<HandwearEntity>
    {
        public void Configure(EntityTypeBuilder<HandwearEntity> builder)
        {
            builder.ToTable("handwears");
            builder.HasKey(c => c.HandwearId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
            builder.Property(c => c.IconUrl).HasMaxLength(200).IsRequired();
        }
    }
}