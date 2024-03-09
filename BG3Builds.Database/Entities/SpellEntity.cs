using BG3Builds.Shared.Enums;
using BG3Builds.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class SpellEntity : IHasIconUrl
{
    public int SpellId { get; set; }
    public required string Name { get; set; }
    public required SpellType SpellType { get; set; }
    public required string WikiUrl { get; set; }
    public required string IconUrl { get; set; }

    public class SpellEntityConfiguration : IEntityTypeConfiguration<SpellEntity>
    {
        public void Configure(EntityTypeBuilder<SpellEntity> builder)
        {
            builder.ToTable("spells");
            builder.HasKey(c => c.SpellId);
            builder.Property(c => c.SpellId).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
            builder.Property(c => c.IconUrl).HasMaxLength(200).IsRequired();
        }
    }
}