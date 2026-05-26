using Server.Common.Items;
using Server.Common.Unit;
using Server.Database.Enums;
using Server.Database.Game;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Handlers.Reward;

internal record RewardListRequest(RewardBoxCategory Category, RewardBoxOrder Order, List<int> Filter, int? Offset);

internal record RewardItem
{
    public int IncentiveId { get; init; }
    public int? IncentiveItemId { get; init; }
    public AddType AddType { get; init; }
    public int Amount { get; init; }
    public int ItemCategoryId => 0;
    public string IncentiveMessage { get; init; }
    public DateTime InsertDate { get; init; }
    public string RemainingTime { get; init; }
}

internal record RewardUnit : RewardItem
{
    public int MaxLevel { get; init; }
    public int MaxRank { get; init; }
    public int MaxLove { get; init; }
    public int UnitId { get; init; }
    public bool IsSupportMember { get; init; }
    public int Exp { get; init; }
    public int NextExp { get; init; }
    public int MaxHp { get; init; }
    public int Level { get; init; }
    public int SkillLevel { get; init; }
    public int Rank { get; init; }
    public int Love { get; init; }
    public bool IsRankMax { get; init; }
    public bool IsLevelMax { get; init; }
    public bool IsLoveMax { get; init; }
    public bool NewUnitFlag { get; init; }
    public int UnitSkillExp { get; init; }
    public int LevelLimitId { get; init; }
    public int DisplayRank { get; init; }
    public int RemovableSkillCapacity { get; init; }
}

internal record RewardListResponse(int ItemCount, int Limit, RewardBoxOrder Order, IEnumerable<RewardItem> Items);

[Endpoint("reward/rewardList", usedInApi: true)]
internal class RewardListEndpoint(
    IActionContext context,
    IRewardBox rewardBox)
    : Action<RewardListRequest, RewardListResponse>
{
    private const int Limit = 20;

    public override async Task<RewardListResponse> ExecuteAsync(RewardListRequest requestBody)
    {
        var filter = new RewardBoxFilter(requestBody.Order, requestBody.Category, requestBody.Filter, Limit, requestBody.Offset ?? 0);
        var rewards = await rewardBox.GetAsync(context.UserId, filter);
        var total = await rewardBox.GetTotalAsync(context.UserId);
        
        var rewardItems = rewards.Select(r =>
        {
            if (r.AddType == AddType.Unit)
            {
                return new RewardUnit
                {
                    IncentiveId = r.Id,
                    IncentiveItemId = r.ItemId,
                    AddType = r.AddType,
                    Amount = r.Amount,
                    IncentiveMessage = r.Message,
                    InsertDate = r.InsertDate,
                    RemainingTime = "AMOGUS",
                    UnitId = r.ItemId!.Value,
                };
            }
            else
            {
                return new RewardItem
                {
                    IncentiveId = r.Id,
                    IncentiveItemId = r.ItemId,
                    AddType = r.AddType,
                    Amount = r.Amount,
                    IncentiveMessage = r.Message,
                    InsertDate = r.InsertDate,
                    RemainingTime = "AMOGUS"
                };
            }
        });

        var response = new RewardListResponse(total, Limit, requestBody.Order, rewardItems);
        return response;
    }
}