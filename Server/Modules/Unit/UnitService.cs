﻿using Microsoft.EntityFrameworkCore;
using SunLight.Infrastructure.Database.Game;
using SunLight.Infrastructure.Database.Server;

namespace SunLight.Services.Unit;

internal class UnitService : IUnitService
{
    private readonly ServerDbContext _serverDbContext;
    private readonly UnitDbContext _unitDbContext;

    public UnitService(ServerDbContext serverDbContext, UnitDbContext unitDbContext)
    {
        _serverDbContext = serverDbContext;
        _unitDbContext = unitDbContext;
    }

    /// <returns>Unit Owning User Id of added unit</returns>
    public async Task<int> AddUnitToUserAsync(int userId, int unitId, int level = 1, int rank = 1)
    {
        var unitInfo = await _unitDbContext.UnitM
            .Where(u => u.UnitId == unitId)
            .Include(u => u.UnitSkill)
            .FirstAsync();

        var levelUpInfo = await _unitDbContext.UnitLevelUpPatternM.Where(levelUpPattern =>
            levelUpPattern.UnitLevelUpPatternId == unitInfo.UnitLevelUpPatternId &&
            (levelUpPattern.UnitLevel == level ||
             levelUpPattern.UnitLevel == level - 1)).ToListAsync();

        var exp = 0;
        var nextExp = 0;
        var statSmile = unitInfo.SmileMax;
        var statPure = unitInfo.PureMax;
        var statCool = unitInfo.CoolMax;
        var hp = unitInfo.HpMax;
        foreach (var levelUp in levelUpInfo)
        {
            if (level == levelUp.UnitLevel)
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
            Level = level,
            MaxLevel = 2,
            LevelLimitId = 0,
            Rank = rank,
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
            DisplayRank = rank,
            IsSigned = 0,
        };

        await _serverDbContext.UnitOwning.AddAsync(unit);
        await _serverDbContext.SaveChangesAsync();
        
        await UpdateAlbumAsync(userId, unit);

        return unit.UnitOwningUserId;
    }

    public async Task<IEnumerable<UnitOwning>> GetUnitsOwnedByUser(int userId)
    {
        var units = await _serverDbContext.UnitOwning.Where(u => u.UserId == userId).ToListAsync();

        return units;
    }

    private async Task UpdateAlbumAsync(int userId, UnitOwning unitOwning)
    {
        var existingInfo = await _serverDbContext.UnitAlbum
            .Where(a => a.UserId == userId && a.UnitId == unitOwning.UnitId)
            .FirstOrDefaultAsync();

        if (existingInfo == null)
        {
            existingInfo = new UnitAlbum
            {
                UserId = userId,
                UnitId = unitOwning.UnitId
            };
            await _serverDbContext.UnitAlbum.AddAsync(existingInfo);
            await _serverDbContext.SaveChangesAsync();
        }

        existingInfo.RankMaxFlag = existingInfo.RankMaxFlag || unitOwning.IsRankMax;
        existingInfo.LoveMaxFlag = existingInfo.LoveMaxFlag || unitOwning.IsLoveMax;
        existingInfo.AllMaxFlag = existingInfo.AllMaxFlag || (unitOwning.IsRankMax && unitOwning.IsLoveMax);
        _serverDbContext.UnitAlbum.Update(existingInfo);
        await _serverDbContext.SaveChangesAsync();
    }
}