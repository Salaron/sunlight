using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Server.Database.Game.Item;

namespace Server.Database.Game;

public partial class ItemContext : DbContext
{
    public ItemContext()
    {
    }

    public ItemContext(DbContextOptions<ItemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AwardM> AwardM { get; set; }

    public virtual DbSet<BackgroundFlashM> BackgroundFlashM { get; set; }

    public virtual DbSet<BackgroundM> BackgroundM { get; set; }

    public virtual DbSet<BackgroundShaderParamM> BackgroundShaderParamM { get; set; }

    public virtual DbSet<BuffItemM> BuffItemM { get; set; }

    public virtual DbSet<BuffItemUseLimitTimeM> BuffItemUseLimitTimeM { get; set; }

    public virtual DbSet<ChangeDelegateItemAmountM> ChangeDelegateItemAmountM { get; set; }

    public virtual DbSet<ChangeDelegateItemM> ChangeDelegateItemM { get; set; }

    public virtual DbSet<ItemExchangeM> ItemExchangeM { get; set; }

    public virtual DbSet<ItemExpireM> ItemExpireM { get; set; }

    public virtual DbSet<KgItemM> KgItemM { get; set; }

    public virtual DbSet<LiveNotesIconAssetM> LiveNotesIconAssetM { get; set; }

    public virtual DbSet<LiveNotesIconM> LiveNotesIconM { get; set; }

    public virtual DbSet<LiveSeGroupM> LiveSeGroupM { get; set; }

    public virtual DbSet<LiveSeM> LiveSeM { get; set; }

    public virtual DbSet<LotteryTicketItemM> LotteryTicketItemM { get; set; }

    public virtual DbSet<MemoriesM> MemoriesM { get; set; }

    public virtual DbSet<RecoveryItemM> RecoveryItemM { get; set; }

    public virtual DbSet<UnitEnhanceItemM> UnitEnhanceItemM { get; set; }

    public virtual DbSet<UnitReinforceItemM> UnitReinforceItemM { get; set; }

    public virtual DbSet<UnitReinforceItemTargetUnitM> UnitReinforceItemTargetUnitM { get; set; }

    public virtual DbSet<UserRankUpItemM> UserRankUpItemM { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Databases/item.db_");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AwardM>(entity =>
        {
            entity.Property(e => e.AwardId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BackgroundFlashM>(entity =>
        {
            entity.Property(e => e.BackgroundFlashParamId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BackgroundM>(entity =>
        {
            entity.Property(e => e.BackgroundId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BackgroundShaderParamM>(entity =>
        {
            entity.Property(e => e.BackgroundShaderParamId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BuffItemM>(entity =>
        {
            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BuffItemUseLimitTimeM>(entity =>
        {
            entity.Property(e => e.BuffItemUseLimitTimeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ChangeDelegateItemM>(entity =>
        {
            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ItemExchangeM>(entity =>
        {
            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<KgItemM>(entity =>
        {
            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveNotesIconM>(entity =>
        {
            entity.Property(e => e.LiveNotesIconId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveSeM>(entity =>
        {
            entity.Property(e => e.LiveSeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LotteryTicketItemM>(entity =>
        {
            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MemoriesM>(entity =>
        {
            entity.Property(e => e.MemoriesId).ValueGeneratedNever();
        });

        modelBuilder.Entity<RecoveryItemM>(entity =>
        {
            entity.Property(e => e.RecoveryItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitEnhanceItemM>(entity =>
        {
            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitReinforceItemM>(entity =>
        {
            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserRankUpItemM>(entity =>
        {
            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
