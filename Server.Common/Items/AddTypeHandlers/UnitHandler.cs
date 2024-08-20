using Microsoft.EntityFrameworkCore;
using Server.Database;
using Server.Database.Enums;
using Server.Database.Game;
using Server.Database.Server;

namespace Server.Common.Items;

public class UnitItem(int unitId, int level = 1, UnitRank rank = UnitRank.Normal, bool isSigned = false) : IItem
{
    public AddType AddType => AddType.Unit;
    public int UnitId => unitId;
    public int Level => level;
    public UnitRank Rank => rank;
    public bool IsSigned => isSigned;
}

internal class UnitHandler(UnitContext unitContext, ServerContext serverContext) : AddTypeHandler<UnitItem, UnitOwning>
{
    public override AddType AddType => AddType.Unit;

    public override async Task<UnitOwning> AddAsync(int userId, UnitItem item)
    {
        var unitInfo = await unitContext.UnitM
            .Where(u => u.UnitId == item.UnitId)
            .Include(u => u.UnitSkill)
            .FirstAsync();

        var levelUpInfo = await unitContext.UnitLevelUpPatternM.Where(levelUpPattern =>
            levelUpPattern.UnitLevelUpPatternId == unitInfo.UnitLevelUpPatternId &&
            (levelUpPattern.UnitLevel == item.Level ||
             levelUpPattern.UnitLevel == item.Level - 1)).ToListAsync();

        var exp = 0;
        var nextExp = 0;
        var statSmile = unitInfo.SmileMax;
        var statPure = unitInfo.PureMax;
        var statCool = unitInfo.CoolMax;
        var hp = unitInfo.HpMax;
        foreach (var levelUp in levelUpInfo)
        {
            if (item.Level == levelUp.UnitLevel)
            {
                nextExp = levelUp.NextExp;
                statSmile -= levelUp.SmileDiff;
                statPure -= levelUp.PureDiff;
                statCool -= levelUp.CoolDiff;
                hp -= levelUp.HpDiff;
            }
            else
            {
                exp = levelUp.NextExp;
            }
        }

        var unit = new UnitOwning
        {
            UserId = userId,
            UnitId = unitInfo.UnitId,
            Exp = exp,
            NextExp = nextExp,
            Level = item.Level,
            MaxLevel = 2, // TODO!!!
            LevelLimitId = 0,
            Rank = item.Rank,
            MaxRank = unitInfo.RankMax,
            Love = 0,
            MaxLove = 0,
            UnitSkillExp = 0,
            UnitSkillLevel = 0,
            MaxUnitSkillLevel = unitInfo.UnitSkill?.MaxLevel ?? 1,
            Attribute = unitInfo.AttributeId,
            StatSmile = statSmile,
            StatPure = statPure,
            StatCool = statCool,
            MaxHp = hp,
            UnitRemovableSkillCapacity = unitInfo.DefaultRemovableSkillCapacity,
            MaxUnitRemovableSkillCapacity = unitInfo.MaxRemovableSkillCapacity,
            FavoriteFlag = 0,
            DisplayRank = item.Rank,
            IsSigned = item.IsSigned,
        };

        await serverContext.UnitOwning.AddAsync(unit);

        await UpdateAlbumAsync(userId, unit);

        return unit;
    }

    public override Task<UnitOwning> SubtractAsync(int userId, UnitItem item)
    {
        throw new InvalidOperationException();
    }

    private async Task UpdateAlbumAsync(int userId, UnitOwning unitOwning)
    {
        var existingInfo = await serverContext.UnitAlbum
            .Where(a => a.UserId == userId && a.UnitId == unitOwning.UnitId)
            .FirstOrDefaultAsync();

        if (existingInfo == null)
        {
            existingInfo = new UnitAlbum
            {
                UserId = userId,
                UnitId = unitOwning.UnitId,
                // RankMaxFlag = unitOwning.IsRankMax,
                // LoveMaxFlag = unitOwning.IsLoveMax,
                // AllMaxFlag = unitOwning.IsRankMax && unitOwning.IsLoveMax
            };
            await serverContext.UnitAlbum.AddAsync(existingInfo);
        }
        else
        {
            // existingInfo.RankMaxFlag = existingInfo.RankMaxFlag || unitOwning.IsRankMax;
            // existingInfo.LoveMaxFlag = existingInfo.LoveMaxFlag || unitOwning.IsLoveMax;
            // existingInfo.AllMaxFlag = existingInfo.AllMaxFlag || (unitOwning.IsRankMax && unitOwning.IsLoveMax);
            serverContext.UnitAlbum.Update(existingInfo);
        }
        
        await serverContext.SaveChangesAsync();
    }
}