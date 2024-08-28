using Microsoft.EntityFrameworkCore;

namespace Server.Database.Server;

public class ServerContext : DbContext
{
    public ServerContext(DbContextOptions<ServerContext> dbContextOptions) : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }

    public DbSet<LoginBonus> LoginBonus { get; init; }
    public DbSet<User> Users { get; init; }
    public DbSet<UnitAlbum> UnitAlbum { get; init; }
    public DbSet<UnitOwning> UnitOwning { get; init; }
    public DbSet<UserUnitDeck> UserUnitDeck { get; init; }
    public DbSet<UserUnitDeckSlot> UserUnitDeckSlot { get; init; }
    public DbSet<UserItemUnlock> UserItemUnlock { get; init; }
    public DbSet<UserItems> UserItems { get; init; }
    public DbSet<UserLiveStatus> UserLiveStatus { get; init; }
    public DbSet<UserLiveStatusGoal> UserLiveStatusGoal { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(p => p.InsertDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<User>().Property(p => p.UpdateDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        modelBuilder.Entity<UserItemUnlock>().Property(p => p.InsertDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<UserItems>().Property(p => p.InsertDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<UserItems>().Property(p => p.UpdateDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

        base.OnModelCreating(modelBuilder);
    }
}