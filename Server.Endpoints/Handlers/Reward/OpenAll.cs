using Server.Common.Items;
using Server.Common.Users;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Handlers.Reward;

internal record RewardOpenAllRequest(RewardBoxCategory Category, RewardBoxOrder Order, List<int> Filter);

internal record RewardOpenAllResponse(
    int RewardNum,
    int OpenedNum,
    int TotalNum,
    RewardBoxOrder Order,
    bool UpperLimit,
    IEnumerable<GameItem> RewardItemList,
    UserInfoDto BeforeUserInfo,
    UserInfoDto AfterUserInfo);

[Endpoint("reward/openAll")]
internal class OpenAllEndpoint(IActionContext context, IRewardBox rewardBox, IUserService userService)
    : Action<RewardOpenAllRequest, RewardOpenAllResponse>
{
    private const int Limit = 1000;

    public override async Task<RewardOpenAllResponse> ExecuteAsync(RewardOpenAllRequest requestBody)
    {
        var filter = new RewardBoxFilter(requestBody.Order, requestBody.Category, requestBody.Filter, Limit, Offset: 0);
        var items = await rewardBox.GetAsync(context.UserId, filter);
        var totalItems = await rewardBox.GetTotalAsync(context.UserId);

        var beforeUserInfo = Mappers.User.UserInfoToDto(await userService.GetAsync(context.UserId));

        var rewardOpenTasks = items.Select(item => rewardBox.OpenAsync(context.UserId, item.Id));
        var rewardList = await Task.WhenAll(rewardOpenTasks);

        var afterUserInfo = Mappers.User.UserInfoToDto(await userService.GetAsync(context.UserId));

        var response = new RewardOpenAllResponse(rewardList.Length,
            rewardList.Length,
            totalItems,
            requestBody.Order,
            false,
            rewardList,
            beforeUserInfo,
            afterUserInfo);

        return response;
    }
}