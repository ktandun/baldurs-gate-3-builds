using System.Reflection;
using BG3Builds.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BG3Builds.Database;

public class DatabaseContext(string connectionString) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(connectionString)
            .LogTo(Console.WriteLine);
    }

    public DbSet<AmuletEntity> Amulets { get; set; } = null!;
    public DbSet<ArmourEntity> Armours { get; set; } = null!;
    public DbSet<CloakEntity> Cloaks { get; set; } = null!;
    public DbSet<FeatEntity> Feats { get; set; } = null!;
    public DbSet<FootwearEntity> Footwears { get; set; } = null!;
    public DbSet<HandwearEntity> Handwears { get; set; } = null!;
    public DbSet<HeadwearEntity> Headwears { get; set; } = null!;
    public DbSet<RingEntity> Rings { get; set; } = null!;
    public DbSet<WeaponEntity> Weapons { get; set; } = null!;
    public DbSet<SpellEntity> Spells { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}