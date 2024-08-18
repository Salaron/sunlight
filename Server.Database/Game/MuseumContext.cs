using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Server.Database.Game.Museum;

namespace Server.Database.Game;

public partial class MuseumContext : DbContext
{
    public MuseumContext()
    {
    }

    public MuseumContext(DbContextOptions<MuseumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MuseumContentsM> MuseumContentsM { get; set; }

    public virtual DbSet<MuseumMenuM> MuseumMenuM { get; set; }

    public virtual DbSet<MuseumSettingM> MuseumSettingM { get; set; }

    public virtual DbSet<MuseumTabCategoryM> MuseumTabCategoryM { get; set; }

    public virtual DbSet<MuseumTabM> MuseumTabM { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Databases/museum.db_");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MuseumContentsM>(entity =>
        {
            entity.Property(e => e.MuseumContentsId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MuseumMenuM>(entity =>
        {
            entity.Property(e => e.MuseumMenuId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MuseumSettingM>(entity =>
        {
            entity.Property(e => e.MuseumSettingId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MuseumTabCategoryM>(entity =>
        {
            entity.Property(e => e.MuseumTabCategoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MuseumTabM>(entity =>
        {
            entity.Property(e => e.MuseumTabId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
