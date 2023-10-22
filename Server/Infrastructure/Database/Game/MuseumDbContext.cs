using Microsoft.EntityFrameworkCore;
using SunLight.Infrastructure.Database.Game.Museum;

namespace SunLight.Infrastructure.Database.Game;

public class MuseumDbContext : DbContext
{
    public DbSet<MuseumContentsM> MuseumContentsM { get; init; }

    public MuseumDbContext(DbContextOptions<MuseumDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Databases/museum.db_").UseSnakeCaseNamingConvention();
    }
}