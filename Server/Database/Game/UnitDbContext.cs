using Microsoft.EntityFrameworkCore;
using SunLight.Database.Game.Unit;

namespace SunLight.Database.Game;

public class UnitDbContext : DbContext
{
    public DbSet<GameUnitInfo> UnitM { get; init; }
    public DbSet<GameUnitSkillInfo> UnitSkillM { get; init; }
    public DbSet<GameUnitLevelUpPattern> UnitLevelUpPatternM { get; init; }

    public static readonly ILoggerFactory MyLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });

    public UnitDbContext(DbContextOptions<UnitDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(MyLoggerFactory).UseSqlite("Data Source=Assets/unit.db_")
            .UseSnakeCaseNamingConvention();
    }
}