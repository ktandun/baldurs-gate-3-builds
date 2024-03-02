using BG3Builds.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BG3Builds.Database.Entities;

public class HeadwearEntity
{
    public required Guid HeadwearId { get; set; }
    public required string Name { get; set; }
    public required string WikiUrl { get; set; }
    public required ArmourProficiency HeadwearProficiency { get; set; }
    public Guid ImageId { get; set; }

    public class HeadwearEntityConfiguration : IEntityTypeConfiguration<HeadwearEntity>
    {
        public void Configure(EntityTypeBuilder<HeadwearEntity> builder)
        {
            builder.ToTable("headwears");
            builder.HasKey(c => c.HeadwearId);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.WikiUrl).HasMaxLength(100).IsRequired();
        }
    }
}

