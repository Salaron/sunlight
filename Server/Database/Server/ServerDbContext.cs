using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Server;

internal class ServerDbContext : DbContext
{
    public ServerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }

    public DbSet<AuthKey> AuthKeys { get; set; }

    public DbSet<User> Users { get; set; }
}