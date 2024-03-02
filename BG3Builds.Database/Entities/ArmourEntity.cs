using BG3Builds.Shared.Enums;
using BG3Builds.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class ArmourEntity : IHasIconUrl
{
    public required Guid ArmourId { get; set; }
    public required string Name { get; set; }
    public required string WikiUrl { get; set; }
    public required string IconUrl { get; set; }
    public required ArmourProficiency ArmourProficiency { get; set; }
    public required int ArmourClass { get; set; }
    public required bool StealthDisadvantage { get; set; }

    public class ArmourEntityConfiguration : IEntityTypeConfiguration<ArmourEntity>
    {
        public void Configure(EntityTypeBuilder<ArmourEntity> builder)
        {
            builder.ToTable("armours");
            builder.HasKey(c => c.ArmourId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
            builder.Property(c => c.IconUrl).HasMaxLength(200).IsRequired();
        }
    }
}

