using Microsoft.EntityFrameworkCore;
using SunLight.Database.Game.Museum;

namespace SunLight.Database.Game;

public class MuseumDbContext : DbContext
{
    public DbSet<MuseumContentsM> MuseumContentsM { get; init; }

    public MuseumDbContext(DbContextOptions<MuseumDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Assets/museum.db_").UseSnakeCaseNamingConvention();
    }
}