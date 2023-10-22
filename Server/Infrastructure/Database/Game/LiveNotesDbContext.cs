using Microsoft.EntityFrameworkCore;
using SunLight.Infrastructure.Database.Game.LiveNotes;

namespace SunLight.Infrastructure.Database.Game;

public class LiveNotesDbContext : DbContext
{
    public DbSet<LiveNotesTable> LiveNotes { get; init; }

    public LiveNotesDbContext(DbContextOptions<LiveNotesDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Databases/sv_live_notes.db_").UseSnakeCaseNamingConvention();
    }
}