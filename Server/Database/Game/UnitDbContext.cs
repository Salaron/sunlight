using Microsoft.EntityFrameworkCore;
using SunLight.Database.Game.Unit;

namespace SunLight.Database.Game;

public class UnitDbContext : DbContext
{
    public DbSet<UnitM> UnitM { get; init; }
    public DbSet<UnitSkillM> UnitSkillM { get; init; }
    public DbSet<UnitLevelUpPatternM> UnitLevelUpPatternM { get; init; }

    public UnitDbContext(DbContextOptions<UnitDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Assets/unit.db_").UseSnakeCaseNamingConvention();
    }
}