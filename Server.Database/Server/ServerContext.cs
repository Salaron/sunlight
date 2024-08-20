using Microsoft.EntityFrameworkCore;

namespace Server.Database.Server;

public class ServerContext : DbContext
{
    public ServerContext(DbContextOptions<ServerContext> dbContextOptions) : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; init; }
    public DbSet<UnitAlbum> UnitAlbum { get; init; }
    public DbSet<UnitOwning> UnitOwning { get; init; }
    public DbSet<UserUnitDeck> UserUnitDeck { get; init; }
    public DbSet<UserUnitDeckSlot> UserUnitDeckSlot { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(p => p.InsertDate).HasDefaultValueSql("now()");
        modelBuilder.Entity<User>().Property(p => p.UpdateDate).HasDefaultValueSql("now()");

        base.OnModelCreating(modelBuilder);
    }
}