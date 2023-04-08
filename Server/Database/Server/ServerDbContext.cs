﻿using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Server;

internal class ServerDbContext : DbContext
{
    public ServerDbContext(DbContextOptions<ServerDbContext> dbContextOptions) : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }

    public DbSet<AuthKey> AuthKeys { get; init; }

    public DbSet<User> Users { get; init; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthKey>()
            .Property(p => p.CreationTime)
            .HasDefaultValue(DateTime.UtcNow);


        modelBuilder.Entity<User>()
            .Property(p => p.Name)
            .HasDefaultValue("New Comer");

        modelBuilder.Entity<User>()
            .Property(p => p.Level)
            .HasDefaultValue(1);

        modelBuilder.Entity<User>()
            .Property(p => p.NextExp)
            .HasDefaultValue(1234); // TODO: exp table

        modelBuilder.Entity<User>()
            .Property(p => p.UnitMax)
            .HasDefaultValue(300);

        modelBuilder.Entity<User>()
            .Property(p => p.WaitingUnitMax)
            .HasDefaultValue(300);

        modelBuilder.Entity<User>()
            .Property(p => p.EnergyMax)
            .HasDefaultValue(100); // TODO

        modelBuilder.Entity<User>()
            .Property(p => p.EnergyFullTime)
            .HasDefaultValue(DateTime.UtcNow);

        modelBuilder.Entity<User>()
            .Property(p => p.TrainingEnergy)
            .HasDefaultValue(5);

        modelBuilder.Entity<User>()
            .Property(p => p.TrainingEnergyMax)
            .HasDefaultValue(5);

        modelBuilder.Entity<User>()
            .Property(p => p.FriendMax)
            .HasDefaultValue(100);

        modelBuilder.Entity<User>()
            .Property(p => p.CreationTime)
            .HasDefaultValue(DateTime.UtcNow);

        modelBuilder.Entity<User>()
            .Property(p => p.LastLogin)
            .HasDefaultValue(DateTime.UtcNow);
    }
}