using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Server;

public class ServerDbContext : DbContext
{
    public DbSet<AuthKey> AuthKeys { get; set; }
}
