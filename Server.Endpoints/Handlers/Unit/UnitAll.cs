using Server.Common;

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

internal record UnitAllResponse(List<UnitInfo> Active, List<UnitInfo> Waiting);

[Endpoint("unit/unitAll", usedInApi: true)]
internal class UnitAllEndpoint : Action<EmptyObject, UnitAllResponse>
{
    public override Task<UnitAllResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new UnitAllResponse([], []));
    }
}