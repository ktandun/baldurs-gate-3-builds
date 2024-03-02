using BG3Builds.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class WeaponEntity
{
    public required Guid WeaponId { get; set; }
    public required string Name { get; set; }
    public required Guid ImageId { get; set; }
    public required string WikiUrl { get; set; }
    public required string Damage { get; set; }
    public required DamageType DamageType { get; set; }
    public string? ExtraDamage { get; set; }
    public DamageType? ExtraDamageType { get; set; }

    public class WeaponEntityConfiguration : IEntityTypeConfiguration<WeaponEntity>
    {
        public void Configure(EntityTypeBuilder<WeaponEntity> builder)
        {
            builder.ToTable("weapons");
            builder.HasKey(c => c.WeaponId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ImageId).IsRequired();
            builder.Property(c => c.Damage).HasMaxLength(20).IsRequired();
            builder.Property(c => c.DamageType).IsRequired();
            builder.Property(c => c.ExtraDamage).HasMaxLength(20);
        }
    }
}

