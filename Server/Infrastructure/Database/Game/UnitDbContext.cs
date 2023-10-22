using Microsoft.EntityFrameworkCore;
using SunLight.Infrastructure.Database.Game.Unit;

namespace SunLight.Infrastructure.Database.Game;

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
        optionsBuilder.UseSqlite("Data Source=Databases/unit.db_").UseSnakeCaseNamingConvention();
    }
}