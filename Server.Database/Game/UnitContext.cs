using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Server.Database.Game.Unit;

namespace Server.Database.Game;

public partial class UnitContext : DbContext
{
    public UnitContext()
    {
    }

    public UnitContext(DbContextOptions<UnitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessoryAssetM> AccessoryAssetM { get; set; }

    public virtual DbSet<AccessoryBaseSettingM> AccessoryBaseSettingM { get; set; }

    public virtual DbSet<AccessoryDescriptionM> AccessoryDescriptionM { get; set; }

    public virtual DbSet<AccessoryEffectTargetM> AccessoryEffectTargetM { get; set; }

    public virtual DbSet<AccessoryLevelLimitOverM> AccessoryLevelLimitOverM { get; set; }

    public virtual DbSet<AccessoryLevelM> AccessoryLevelM { get; set; }

    public virtual DbSet<AccessoryLotteryCostM> AccessoryLotteryCostM { get; set; }

    public virtual DbSet<AccessoryLotteryGroupM> AccessoryLotteryGroupM { get; set; }

    public virtual DbSet<AccessoryLotteryListM> AccessoryLotteryListM { get; set; }

    public virtual DbSet<AccessoryM> AccessoryM { get; set; }

    public virtual DbSet<AccessorySpecialM> AccessorySpecialM { get; set; }

    public virtual DbSet<AlbumSeriesM> AlbumSeriesM { get; set; }

    public virtual DbSet<AlbumSeriesThumbnailAssetM> AlbumSeriesThumbnailAssetM { get; set; }

    public virtual DbSet<AlbumUnitSeriesM> AlbumUnitSeriesM { get; set; }

    public virtual DbSet<HiddenUnitM> HiddenUnitM { get; set; }

    public virtual DbSet<HiddenUnitSettingM> HiddenUnitSettingM { get; set; }

    public virtual DbSet<HiddenUnitSkillM> HiddenUnitSkillM { get; set; }

    public virtual DbSet<MemberTagM> MemberTagM { get; set; }

    public virtual DbSet<MultiUnitAssetM> MultiUnitAssetM { get; set; }

    public virtual DbSet<MultiUnitM> MultiUnitM { get; set; }

    public virtual DbSet<MultiUnitSwitchSettingM> MultiUnitSwitchSettingM { get; set; }

    public virtual DbSet<PresetDeckM> PresetDeckM { get; set; }

    public virtual DbSet<PresetDeckUnitM> PresetDeckUnitM { get; set; }

    public virtual DbSet<ReplaceUnitM> ReplaceUnitM { get; set; }

    public virtual DbSet<SdCharM> SdCharM { get; set; }

    public virtual DbSet<SkillEffectTypeM> SkillEffectTypeM { get; set; }

    public virtual DbSet<SubUnitTypeM> SubUnitTypeM { get; set; }

    public virtual DbSet<UnitAttributeM> UnitAttributeM { get; set; }

    public virtual DbSet<UnitBaseFunctionVoiceM> UnitBaseFunctionVoiceM { get; set; }

    public virtual DbSet<UnitBaseRandomVoiceM> UnitBaseRandomVoiceM { get; set; }

    public virtual DbSet<UnitBaseTimeVoiceM> UnitBaseTimeVoiceM { get; set; }

    public virtual DbSet<UnitBaseTouchVoiceM> UnitBaseTouchVoiceM { get; set; }

    public virtual DbSet<UnitBirthdayVoiceM> UnitBirthdayVoiceM { get; set; }

    public virtual DbSet<UnitFunctionVoiceM> UnitFunctionVoiceM { get; set; }

    public virtual DbSet<UnitIllustratorM> UnitIllustratorM { get; set; }

    public virtual DbSet<UnitLeaderSkillExtraM> UnitLeaderSkillExtraM { get; set; }

    public virtual DbSet<UnitLeaderSkillM> UnitLeaderSkillM { get; set; }

    public virtual DbSet<UnitLevelLimitM> UnitLevelLimitM { get; set; }

    public virtual DbSet<UnitLevelLimitPatternM> UnitLevelLimitPatternM { get; set; }

    public virtual DbSet<UnitLevelUpPatternM> UnitLevelUpPatternM { get; set; }

    public virtual DbSet<UnitM> UnitM { get; set; }

    public virtual DbSet<UnitMemberTagM> UnitMemberTagM { get; set; }

    public virtual DbSet<UnitNaviAssetM> UnitNaviAssetM { get; set; }

    public virtual DbSet<UnitNaviAssetPositionM> UnitNaviAssetPositionM { get; set; }

    public virtual DbSet<UnitPairM> UnitPairM { get; set; }

    public virtual DbSet<UnitPeriodVoiceM> UnitPeriodVoiceM { get; set; }

    public virtual DbSet<UnitRandomVoiceM> UnitRandomVoiceM { get; set; }

    public virtual DbSet<UnitRarityM> UnitRarityM { get; set; }

    public virtual DbSet<UnitRemovableSkillExchangeM> UnitRemovableSkillExchangeM { get; set; }

    public virtual DbSet<UnitRemovableSkillLiveEffectM> UnitRemovableSkillLiveEffectM { get; set; }

    public virtual DbSet<UnitRemovableSkillM> UnitRemovableSkillM { get; set; }

    public virtual DbSet<UnitSignAssetM> UnitSignAssetM { get; set; }

    public virtual DbSet<UnitSkillComboPatternM> UnitSkillComboPatternM { get; set; }

    public virtual DbSet<UnitSkillControlM> UnitSkillControlM { get; set; }

    public virtual DbSet<UnitSkillEffectTargetM> UnitSkillEffectTargetM { get; set; }

    public virtual DbSet<UnitSkillHealBonusM> UnitSkillHealBonusM { get; set; }

    public virtual DbSet<UnitSkillLevelM> UnitSkillLevelM { get; set; }

    public virtual DbSet<UnitSkillLevelUpPatternM> UnitSkillLevelUpPatternM { get; set; }

    public virtual DbSet<UnitSkillM> UnitSkillM { get; set; }

    public virtual DbSet<UnitSkillTriggerTargetM> UnitSkillTriggerTargetM { get; set; }

    public virtual DbSet<UnitTalkVoiceGroupM> UnitTalkVoiceGroupM { get; set; }

    public virtual DbSet<UnitTalkVoiceM> UnitTalkVoiceM { get; set; }

    public virtual DbSet<UnitTimeVoiceM> UnitTimeVoiceM { get; set; }

    public virtual DbSet<UnitTouchVoiceM> UnitTouchVoiceM { get; set; }

    public virtual DbSet<UnitTypeM> UnitTypeM { get; set; }

    public virtual DbSet<UnitTypeMemberTagM> UnitTypeMemberTagM { get; set; }

    public virtual DbSet<UnitTypeSeriesM> UnitTypeSeriesM { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Databases/unit.db_");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessoryAssetM>(entity =>
        {
            entity.Property(e => e.AccessoryAssetId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AccessoryBaseSettingM>(entity =>
        {
            entity.Property(e => e.AccessoryBaseSettingId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AccessoryDescriptionM>(entity =>
        {
            entity.Property(e => e.AccessoryDescriptionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AccessoryLotteryCostM>(entity =>
        {
            entity.Property(e => e.AccessoryLotteryCostId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AccessoryLotteryGroupM>(entity =>
        {
            entity.Property(e => e.AccessoryLotteryGroupId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AccessoryLotteryListM>(entity =>
        {
            entity.Property(e => e.AccessoryLotteryListId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AccessoryM>(entity =>
        {
            entity.Property(e => e.AccessoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AccessorySpecialM>(entity =>
        {
            entity.Property(e => e.AccessoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AlbumSeriesM>(entity =>
        {
            entity.Property(e => e.AlbumSeriesId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AlbumUnitSeriesM>(entity =>
        {
            entity.Property(e => e.AlbumUnitSeriesId).ValueGeneratedNever();
        });

        modelBuilder.Entity<HiddenUnitM>(entity =>
        {
            entity.Property(e => e.HiddenUnitId).ValueGeneratedNever();
        });

        modelBuilder.Entity<HiddenUnitSettingM>(entity =>
        {
            entity.Property(e => e.HiddenUnitSettingId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MemberTagM>(entity =>
        {
            entity.Property(e => e.MemberTagId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MultiUnitAssetM>(entity =>
        {
            entity.Property(e => e.MultiUnitId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MultiUnitSwitchSettingM>(entity =>
        {
            entity.Property(e => e.MultiUnitSwitchSettingId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PresetDeckM>(entity =>
        {
            entity.Property(e => e.PresetDeckId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ReplaceUnitM>(entity =>
        {
            entity.Property(e => e.ReplaceUnitId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SdCharM>(entity =>
        {
            entity.Property(e => e.SdCharId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SkillEffectTypeM>(entity =>
        {
            entity.Property(e => e.SkillEffectType).ValueGeneratedNever();
        });

        modelBuilder.Entity<SubUnitTypeM>(entity =>
        {
            entity.Property(e => e.UnitTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitAttributeM>(entity =>
        {
            entity.Property(e => e.AttributeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitBaseFunctionVoiceM>(entity =>
        {
            entity.Property(e => e.UnitBaseFunctionVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitBaseRandomVoiceM>(entity =>
        {
            entity.Property(e => e.UnitBaseRandomVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitBaseTimeVoiceM>(entity =>
        {
            entity.Property(e => e.UnitBaseTimeVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitBaseTouchVoiceM>(entity =>
        {
            entity.Property(e => e.UnitBaseTouchVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitBirthdayVoiceM>(entity =>
        {
            entity.Property(e => e.UnitBirthdayVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitFunctionVoiceM>(entity =>
        {
            entity.Property(e => e.UnitFunctionVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitIllustratorM>(entity =>
        {
            entity.Property(e => e.UnitId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitLeaderSkillExtraM>(entity =>
        {
            entity.Property(e => e.UnitLeaderSkillId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitLeaderSkillM>(entity =>
        {
            entity.Property(e => e.UnitLeaderSkillId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitLevelLimitM>(entity =>
        {
            entity.Property(e => e.UnitLevelLimitId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitM>(entity =>
        {
            entity.Property(e => e.UnitId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitNaviAssetM>(entity =>
        {
            entity.Property(e => e.UnitNaviAssetId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitNaviAssetPositionM>(entity =>
        {
            entity.Property(e => e.UnitNaviAssetId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitPairM>(entity =>
        {
            entity.Property(e => e.UnitPairId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitPeriodVoiceM>(entity =>
        {
            entity.Property(e => e.UnitPeriodVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitRandomVoiceM>(entity =>
        {
            entity.Property(e => e.UnitRandomVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitRarityM>(entity =>
        {
            entity.Property(e => e.Rarity).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitRemovableSkillExchangeM>(entity =>
        {
            entity.Property(e => e.UnitRemovableSkillId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitRemovableSkillLiveEffectM>(entity =>
        {
            entity.Property(e => e.UnitRemovableSkillId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitRemovableSkillM>(entity =>
        {
            entity.Property(e => e.UnitRemovableSkillId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitSignAssetM>(entity =>
        {
            entity.Property(e => e.UnitId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitSkillControlM>(entity =>
        {
            entity.Property(e => e.UnitSkillControlId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitSkillHealBonusM>(entity =>
        {
            entity.Property(e => e.TotalHp).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitSkillM>(entity =>
        {
            entity.Property(e => e.UnitSkillId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitTalkVoiceM>(entity =>
        {
            entity.Property(e => e.UnitTalkVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitTimeVoiceM>(entity =>
        {
            entity.Property(e => e.UnitTimeVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitTouchVoiceM>(entity =>
        {
            entity.Property(e => e.UnitTouchVoiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UnitTypeM>(entity =>
        {
            entity.Property(e => e.UnitTypeId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
