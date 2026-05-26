using Riok.Mapperly.Abstractions;
using Server.Common.Live;
using Server.Database.Server;
using Server.Endpoints.Handlers.Live;
using Server.Endpoints.Handlers.Reward;

namespace Server.Endpoints.Dtos;

[Mapper]
internal partial class ItemMapper
{
    [MapProperty(nameof(RewardBoxItem.Id), nameof(RewardItem.IncentiveId))]
    [MapProperty(nameof(RewardBoxItem.ItemId), nameof(RewardItem.IncentiveItemId))]
    [MapProperty(nameof(RewardBoxItem.Message), nameof(RewardItem.IncentiveMessage))]
    [MapProperty(nameof(RewardBoxItem.ExpireDate), nameof(RewardItem.RemainingTime))]
    public partial RewardItem RewardBotItemToRewardItem(RewardBoxItem rewardBoxItem);
}
