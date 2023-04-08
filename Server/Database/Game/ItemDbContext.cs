using Microsoft.EntityFrameworkCore;
using SunLight.Database.Game.Item;

namespace SunLight.Database.Game;

public class ItemDbContext : DbContext
{
    public DbSet<GameAwardInfo> AwardM { get; init; }
    public DbSet<GameBackgroundItem> BackgroundM { get; init; }

    public ItemDbContext(DbContextOptions<ItemDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Assets/item.db_").UseSnakeCaseNamingConvention();
    }
}