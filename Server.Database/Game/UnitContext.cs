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

    public virtual DbSet<AccessoryAssetM> AccessoryAssetMs { get; set; }

    public virtual DbSet<AccessoryBaseSettingM> AccessoryBaseSettingMs { get; set; }

    public virtual DbSet<AccessoryDescriptionM> AccessoryDescriptionMs { get; set; }

    public virtual DbSet<AccessoryEffectTargetM> AccessoryEffectTargetMs { get; set; }

    public virtual DbSet<AccessoryLevelLimitOverM> AccessoryLevelLimitOverMs { get; set; }

    public virtual DbSet<AccessoryLevelM> AccessoryLevelMs { get; set; }

    public virtual DbSet<AccessoryLotteryCostM> AccessoryLotteryCostMs { get; set; }

    public virtual DbSet<AccessoryLotteryGroupM> AccessoryLotteryGroupMs { get; set; }

    public virtual DbSet<AccessoryLotteryListM> AccessoryLotteryListMs { get; set; }

    public virtual DbSet<AccessoryM> AccessoryMs { get; set; }

    public virtual DbSet<AccessorySpecialM> AccessorySpecialMs { get; set; }

    public virtual DbSet<AlbumSeriesM> AlbumSeriesMs { get; set; }

    public virtual DbSet<AlbumSeriesThumbnailAssetM> AlbumSeriesThumbnailAssetMs { get; set; }

    public virtual DbSet<AlbumUnitSeriesM> AlbumUnitSeriesMs { get; set; }

    public virtual DbSet<HiddenUnitM> HiddenUnitMs { get; set; }

    public virtual DbSet<HiddenUnitSettingM> HiddenUnitSettingMs { get; set; }

    public virtual DbSet<HiddenUnitSkillM> HiddenUnitSkillMs { get; set; }

    public virtual DbSet<MemberTagM> MemberTagMs { get; set; }

    public virtual DbSet<MultiUnitAssetM> MultiUnitAssetMs { get; set; }

    public virtual DbSet<MultiUnitM> MultiUnitMs { get; set; }

    public virtual DbSet<MultiUnitSwitchSettingM> MultiUnitSwitchSettingMs { get; set; }

    public virtual DbSet<PresetDeckM> PresetDeckMs { get; set; }

    public virtual DbSet<PresetDeckUnitM> PresetDeckUnitMs { get; set; }

    public virtual DbSet<ReplaceUnitM> ReplaceUnitMs { get; set; }

    public virtual DbSet<SdCharM> SdCharMs { get; set; }

    public virtual DbSet<SkillEffectTypeM> SkillEffectTypeMs { get; set; }

    public virtual DbSet<SubUnitTypeM> SubUnitTypeMs { get; set; }

    public virtual DbSet<UnitAttributeM> UnitAttributeMs { get; set; }

    public virtual DbSet<UnitBaseFunctionVoiceM> UnitBaseFunctionVoiceMs { get; set; }

    public virtual DbSet<UnitBaseRandomVoiceM> UnitBaseRandomVoiceMs { get; set; }

    public virtual DbSet<UnitBaseTimeVoiceM> UnitBaseTimeVoiceMs { get; set; }

    public virtual DbSet<UnitBaseTouchVoiceM> UnitBaseTouchVoiceMs { get; set; }

    public virtual DbSet<UnitBirthdayVoiceM> UnitBirthdayVoiceMs { get; set; }

    public virtual DbSet<UnitFunctionVoiceM> UnitFunctionVoiceMs { get; set; }

    public virtual DbSet<UnitIllustratorM> UnitIllustratorMs { get; set; }

    public virtual DbSet<UnitLeaderSkillExtraM> UnitLeaderSkillExtraMs { get; set; }

    public virtual DbSet<UnitLeaderSkillM> UnitLeaderSkillMs { get; set; }

    public virtual DbSet<UnitLevelLimitM> UnitLevelLimitMs { get; set; }

    public virtual DbSet<UnitLevelLimitPatternM> UnitLevelLimitPatternMs { get; set; }

    public virtual DbSet<UnitLevelUpPatternM> UnitLevelUpPatternMs { get; set; }

    public virtual DbSet<UnitM> UnitMs { get; set; }

    public virtual DbSet<UnitMemberTagM> UnitMemberTagMs { get; set; }

    public virtual DbSet<UnitNaviAssetM> UnitNaviAssetMs { get; set; }

    public virtual DbSet<UnitNaviAssetPositionM> UnitNaviAssetPositionMs { get; set; }

    public virtual DbSet<UnitPairM> UnitPairMs { get; set; }

    public virtual DbSet<UnitPeriodVoiceM> UnitPeriodVoiceMs { get; set; }

    public virtual DbSet<UnitRandomVoiceM> UnitRandomVoiceMs { get; set; }

    public virtual DbSet<UnitRarityM> UnitRarityMs { get; set; }

    public virtual DbSet<UnitRemovableSkillExchangeM> UnitRemovableSkillExchangeMs { get; set; }

    public virtual DbSet<UnitRemovableSkillLiveEffectM> UnitRemovableSkillLiveEffectMs { get; set; }

    public virtual DbSet<UnitRemovableSkillM> UnitRemovableSkillMs { get; set; }

    public virtual DbSet<UnitSignAssetM> UnitSignAssetMs { get; set; }

    public virtual DbSet<UnitSkillComboPatternM> UnitSkillComboPatternMs { get; set; }

    public virtual DbSet<UnitSkillControlM> UnitSkillControlMs { get; set; }

    public virtual DbSet<UnitSkillEffectTargetM> UnitSkillEffectTargetMs { get; set; }

    public virtual DbSet<UnitSkillHealBonusM> UnitSkillHealBonusMs { get; set; }

    public virtual DbSet<UnitSkillLevelM> UnitSkillLevelMs { get; set; }

    public virtual DbSet<UnitSkillLevelUpPatternM> UnitSkillLevelUpPatternMs { get; set; }

    public virtual DbSet<UnitSkillM> UnitSkillMs { get; set; }

    public virtual DbSet<UnitSkillTriggerTargetM> UnitSkillTriggerTargetMs { get; set; }

    public virtual DbSet<UnitTalkVoiceGroupM> UnitTalkVoiceGroupMs { get; set; }

    public virtual DbSet<UnitTalkVoiceM> UnitTalkVoiceMs { get; set; }

    public virtual DbSet<UnitTimeVoiceM> UnitTimeVoiceMs { get; set; }

    public virtual DbSet<UnitTouchVoiceM> UnitTouchVoiceMs { get; set; }

    public virtual DbSet<UnitTypeM> UnitTypeMs { get; set; }

    public virtual DbSet<UnitTypeMemberTagM> UnitTypeMemberTagMs { get; set; }

    public virtual DbSet<UnitTypeSeriesM> UnitTypeSeriesMs { get; set; }

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
