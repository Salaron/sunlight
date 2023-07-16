using Microsoft.EntityFrameworkCore;
using SunLight.Database.Game.LiveNotes;

namespace SunLight.Database.Game;

public class LiveNotesDbContext : DbContext
{
    public DbSet<LiveNotesTable> LiveNotes { get; init; }

    public LiveNotesDbContext(DbContextOptions<LiveNotesDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Assets/sv_live_notes.db_").UseSnakeCaseNamingConvention();
    }
}