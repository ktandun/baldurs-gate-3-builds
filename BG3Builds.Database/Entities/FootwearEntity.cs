using BG3Builds.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class FootwearEntity
{
    public required Guid FootwearId { get; set; }
    public required string Name { get; set; }
    public required string WikiUrl { get; set; }
    public required ArmourProficiency ArmourProficiency { get; set; }
    public Guid ImageId { get; set; }

    public class FootwearEntityConfiguration : IEntityTypeConfiguration<FootwearEntity>
    {
        public void Configure(EntityTypeBuilder<FootwearEntity> builder)
        {
            builder.ToTable("footwears");
            builder.HasKey(c => c.FootwearId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
        }
    }
}