using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Server.Database.Game.Live;

namespace Server.Database.Game;

public partial class LiveContext : DbContext
{
    public LiveContext()
    {
    }

    public LiveContext(DbContextOptions<LiveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FreeLiveM> FreeLiveMs { get; set; }

    public virtual DbSet<LiveComboM> LiveComboMs { get; set; }

    public virtual DbSet<LiveCutinBrightnessM> LiveCutinBrightnessMs { get; set; }

    public virtual DbSet<LiveGoalRewardCommonM> LiveGoalRewardCommonMs { get; set; }

    public virtual DbSet<LiveGoalRewardM> LiveGoalRewardMs { get; set; }

    public virtual DbSet<LiveNoteScoreFactorM> LiveNoteScoreFactorMs { get; set; }

    public virtual DbSet<LiveSettingM> LiveSettingMs { get; set; }

    public virtual DbSet<LiveSkillIconM> LiveSkillIconMs { get; set; }

    public virtual DbSet<LiveTimeM> LiveTimeMs { get; set; }

    public virtual DbSet<LiveTrackM> LiveTrackMs { get; set; }

    public virtual DbSet<LiveUnitRewardLotM> LiveUnitRewardLotMs { get; set; }

    public virtual DbSet<NormalLiveM> NormalLiveMs { get; set; }

    public virtual DbSet<SpecialLiveM> SpecialLiveMs { get; set; }

    public virtual DbSet<SpecialLiveRotationM> SpecialLiveRotationMs { get; set; }

    public virtual DbSet<TrainingModeM> TrainingModeMs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Databases/live.db_");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FreeLiveM>(entity =>
        {
            entity.Property(e => e.LiveDifficultyId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveComboM>(entity =>
        {
            entity.Property(e => e.ComboCnt).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveCutinBrightnessM>(entity =>
        {
            entity.Property(e => e.LiveCutinBrightnessId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveGoalRewardCommonM>(entity =>
        {
            entity.Property(e => e.LiveGoalRewardCommonId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveGoalRewardM>(entity =>
        {
            entity.Property(e => e.LiveGoalRewardId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveSettingM>(entity =>
        {
            entity.Property(e => e.LiveSettingId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveSkillIconM>(entity =>
        {
            entity.Property(e => e.SkillEffectType).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveTimeM>(entity =>
        {
            entity.Property(e => e.LiveTrackId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveTrackM>(entity =>
        {
            entity.Property(e => e.LiveTrackId).ValueGeneratedNever();
        });

        modelBuilder.Entity<LiveUnitRewardLotM>(entity =>
        {
            entity.Property(e => e.LiveUnitRewardLotId).ValueGeneratedNever();
        });

        modelBuilder.Entity<NormalLiveM>(entity =>
        {
            entity.Property(e => e.LiveDifficultyId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SpecialLiveM>(entity =>
        {
            entity.Property(e => e.LiveDifficultyId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TrainingModeM>(entity =>
        {
            entity.Property(e => e.TrainingModeId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
