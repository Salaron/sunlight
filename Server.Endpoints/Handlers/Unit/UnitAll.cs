using Server.Common;
using Server.Common.Unit;
using Server.Database.Server;

namespace Server.Endpoints.Main.Unit;

internal record UnitInfo
{
    public int UnitOwningUserId { get; set; }
    public int UnitId { get; set; }
    public int Exp { get; set; }
    public int NextExp { get; set; }
    public int Level { get; set; }
    public int MaxLevel { get; set; }
    public int LevelLimitId { get; set; }
    public int Rank { get; set; }
    public int MaxRank { get; set; }
    public int Love { get; set; }
    public int MaxLove { get; set; }
    public int UnitSkillExp { get; set; }
    public int UnitSkillLevel { get; set; }
    public int MaxHp { get; set; }
    public int UnitRemovableSkillCapacity { get; set; }
    public int FavoriteFlag { get; set; }
    public int DisplayRank { get; set; }
    public bool IsRankMax { get; set; }
    public bool IsLoveMax { get; set; }
    public bool IsLevelMax { get; set; }
    public bool IsSigned { get; set; }
    public bool IsSkillLevelMax { get; set; }
    public bool IsRemovableSkillCapacityMax { get; set; }
    public DateTime InsertDate { get; set; }
}

internal record UnitAllResponse(IEnumerable<UnitInfo> Active, IEnumerable<UnitInfo> Waiting);

[Endpoint("unit/unitAll", usedInApi: true)]
internal class UnitAllEndpoint(IActionContext context, IUnitService unitService) : Action<EmptyObject, UnitAllResponse>
{
    public override async Task<UnitAllResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var units = await unitService.GetUnitsAsync(context.UserId);
        var unitInfo = units.Select(MapUnit);

        return new UnitAllResponse(unitInfo, []);
    }

    private UnitInfo MapUnit(UnitOwning unit)
    {
        return new UnitInfo
        {
            UnitId = unit.UnitId,
            Exp = unit.Exp,
            NextExp = unit.NextExp,
            Level = unit.Level,
            MaxLevel = unit.MaxLevel,
            LevelLimitId = unit.LevelLimitId,
            Rank = unit.Rank,
            MaxRank = unit.MaxRank,
            Love = unit.Love,
            MaxLove = unit.MaxLove,
            UnitSkillExp = unit.UnitSkillExp,
            UnitSkillLevel = unit.UnitSkillLevel,
            MaxHp = unit.MaxHp,
            UnitRemovableSkillCapacity = unit.UnitRemovableSkillCapacity,
            FavoriteFlag = unit.FavoriteFlag,
            DisplayRank = unit.DisplayRank,
            IsRankMax = unit.IsRankMax,
            IsLoveMax = unit.IsLoveMax,
            IsLevelMax = unit.IsLevelMax,
            IsSigned = unit.IsSigned == 1,
            IsSkillLevelMax = unit.IsSkillLevelMax,
            IsRemovableSkillCapacityMax = unit.IsRemovableSkillCapacityMax,
            InsertDate = unit.InsertDate,
        };
    }
}