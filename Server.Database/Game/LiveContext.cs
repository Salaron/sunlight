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

    public virtual DbSet<FreeLiveM> FreeLiveM { get; set; }

    public virtual DbSet<LiveComboM> LiveComboM { get; set; }

    public virtual DbSet<LiveCutinBrightnessM> LiveCutinBrightnessM { get; set; }

    public virtual DbSet<LiveGoalRewardCommonM> LiveGoalRewardCommonM { get; set; }

    public virtual DbSet<LiveGoalRewardM> LiveGoalRewardM { get; set; }

    public virtual DbSet<LiveNoteScoreFactorM> LiveNoteScoreFactorM { get; set; }

    public virtual DbSet<LiveSettingM> LiveSettingM { get; set; }

    public virtual DbSet<LiveSkillIconM> LiveSkillIconM { get; set; }

    public virtual DbSet<LiveTimeM> LiveTimeM { get; set; }

    public virtual DbSet<LiveTrackM> LiveTrackM { get; set; }

    public virtual DbSet<LiveUnitRewardLotM> LiveUnitRewardLotM { get; set; }

    public virtual DbSet<NormalLiveM> NormalLiveM { get; set; }

    public virtual DbSet<SpecialLiveM> SpecialLiveM { get; set; }

    public virtual DbSet<SpecialLiveRotationM> SpecialLiveRotationM { get; set; }

    public virtual DbSet<TrainingModeM> TrainingModeM { get; set; }

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
