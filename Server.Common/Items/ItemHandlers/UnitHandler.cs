using Microsoft.EntityFrameworkCore;
using Server.Database.Game;
using Server.Database.Server;

namespace Server.Common.Items;

public record UnitParams(int Level, int Rank, int IsSigned);

internal class UnitHandler(UnitContext unitContext, ServerContext serverContext) : ItemHandler<UnitParams, UnitOwning>
{
    public override AddType AddType => AddType.Unit;

    public override async Task<UnitOwning> AddAsync(int userId, ItemDescription<UnitParams> description)
    {
        var unitInfo = await unitContext.UnitM
            .Where(u => u.UnitId == description.ItemId)
            .Include(u => u.UnitSkill)
            .FirstAsync();
        
        var levelUpInfo = await unitContext.UnitLevelUpPatternM.Where(levelUpPattern =>
            levelUpPattern.UnitLevelUpPatternId == unitInfo.UnitLevelUpPatternId &&
            (levelUpPattern.UnitLevel == description.Parameters.Level ||
             levelUpPattern.UnitLevel == description.Parameters.Level - 1)).ToListAsync();
        
        var exp = 0;
        var nextExp = 0;
        var statSmile = unitInfo.SmileMax;
        var statPure = unitInfo.PureMax;
        var statCool = unitInfo.CoolMax;
        var hp = unitInfo.HpMax;
        foreach (var levelUp in levelUpInfo)
        {
            if (description.Parameters.Level == levelUp.UnitLevel)
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
            Level = description.Parameters.Level,
            MaxLevel = 2,
            LevelLimitId = 0,
            Rank = description.Parameters.Rank,
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
            DisplayRank = description.Parameters.Rank,
            IsSigned = description.Parameters.IsSigned,
        };
        
        // await _serverDbContext.UnitOwning.AddAsync(unit);
        // await _serverDbContext.SaveChangesAsync();
        
        await UpdateAlbumAsync(userId, unit);

        return unit;
    }
    
    private async Task UpdateAlbumAsync(int userId, UnitOwning unitOwning)
    {
        // var existingInfo = await _serverDbContext.UnitAlbum
        //     .Where(a => a.UserId == userId && a.UnitId == unitOwning.UnitId)
        //     .FirstOrDefaultAsync();
        //
        // if (existingInfo == null)
        // {
        //     existingInfo = new UnitAlbum
        //     {
        //         UserId = userId,
        //         UnitId = unitOwning.UnitId
        //     };
        //     await _serverDbContext.UnitAlbum.AddAsync(existingInfo);
        //     await _serverDbContext.SaveChangesAsync();
        // }
        //
        // existingInfo.RankMaxFlag = existingInfo.RankMaxFlag || unitOwning.IsRankMax;
        // existingInfo.LoveMaxFlag = existingInfo.LoveMaxFlag || unitOwning.IsLoveMax;
        // existingInfo.AllMaxFlag = existingInfo.AllMaxFlag || (unitOwning.IsRankMax && unitOwning.IsLoveMax);
        // _serverDbContext.UnitAlbum.Update(existingInfo);
        // await _serverDbContext.SaveChangesAsync();
    }
}