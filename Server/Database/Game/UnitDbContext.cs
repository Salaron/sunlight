using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Game;

public class UnitDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Assets/unit.db_");
    }
}