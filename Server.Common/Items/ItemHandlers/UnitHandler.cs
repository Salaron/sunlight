using Microsoft.EntityFrameworkCore;
using Server.Database.Game;
using Server.Database.Server;

namespace Server.Common.Items;

public record UnitParams(int Level, int Rank, int IsSigned);

internal class UnitHandler(UnitContext unitContext, ServerContext serverContext) : ItemHandler<UnitParams, UnitOwning>
{
    private readonly UnitParams _defaultParams = new(Level: 1, Rank: 1, IsSigned: 0);

    public override AddType AddType => AddType.Unit;

    public override async Task<UnitOwning> AddAsync(int userId, ItemDescription<UnitParams> description)
    {
        var param = description.Parameters ?? _defaultParams;
        
        var unitInfo = await unitContext.UnitM
            .Where(u => u.UnitId == description.ItemId)
            .Include(u => u.UnitSkill)
            .FirstAsync();

        var levelUpInfo = await unitContext.UnitLevelUpPatternM.Where(levelUpPattern =>
            levelUpPattern.UnitLevelUpPatternId == unitInfo.UnitLevelUpPatternId &&
            (levelUpPattern.UnitLevel == param.Level ||
             levelUpPattern.UnitLevel == param.Level - 1)).ToListAsync();

        var exp = 0;
        var nextExp = 0;
        var statSmile = unitInfo.SmileMax;
        var statPure = unitInfo.PureMax;
        var statCool = unitInfo.CoolMax;
        var hp = unitInfo.HpMax;
        foreach (var levelUp in levelUpInfo)
        {
            if (param.Level == levelUp.UnitLevel)
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
            Level = param.Level,
            MaxLevel = 2, // TODO!!!
            LevelLimitId = 0,
            Rank = param.Rank,
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
            DisplayRank = param.Rank,
            IsSigned = param.IsSigned,
        };

        await serverContext.UnitOwning.AddAsync(unit);
        await serverContext.SaveChangesAsync();

        await UpdateAlbumAsync(userId, unit);

        return unit;
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
                UnitId = unitOwning.UnitId
            };
            await serverContext.UnitAlbum.AddAsync(existingInfo);
            await serverContext.SaveChangesAsync();
        }

        existingInfo.RankMaxFlag = existingInfo.RankMaxFlag || unitOwning.IsRankMax;
        existingInfo.LoveMaxFlag = existingInfo.LoveMaxFlag || unitOwning.IsLoveMax;
        existingInfo.AllMaxFlag = existingInfo.AllMaxFlag || (unitOwning.IsRankMax && unitOwning.IsLoveMax);
        serverContext.UnitAlbum.Update(existingInfo);
        await serverContext.SaveChangesAsync();
    }
}