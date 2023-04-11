﻿using Microsoft.EntityFrameworkCore;
using SunLight.Database.Game.Live;

namespace SunLight.Database.Game;

public class LiveDbContext : DbContext
{
    public DbSet<LiveSettingM> LiveSettingM { get; init; }
    public DbSet<NormalLiveM> NormalLiveM { get; init; }
    public DbSet<SpecialLiveM> SpecialLiveM { get; init; }

    public LiveDbContext(DbContextOptions<LiveDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Assets/live.db_").UseSnakeCaseNamingConvention();
    }
}