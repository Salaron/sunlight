using Server.Common.Items;
using Server.Common.Users;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Handlers.Reward;

internal record RewardOpenRequest(int IncentiveId);

internal record RewardOpenResponse(
    int OpenedNum,
    IEnumerable<GameItem> Success,
    UserInfoDto BeforeUserInfo,
    UserInfoDto AfterUserInfo);

[Endpoint("reward/open")]
internal class OpenEndpoint(IActionContext context, IRewardBox rewardBox, IUserService userService)
    : Action<RewardOpenRequest, RewardOpenResponse>
{
    private static readonly UserMapper Mapper = new();

    public override async Task<RewardOpenResponse> ExecuteAsync(RewardOpenRequest requestBody)
    {
        var beforeUserInfo = Mapper.UserInfoToDto(await userService.GetAsync(context.UserId));
        var item = await rewardBox.OpenAsync(context.UserId, requestBody.IncentiveId);
        var afterUserInfo = Mapper.UserInfoToDto(await userService.GetAsync(context.UserId));

        var response = new RewardOpenResponse(1, [item], beforeUserInfo, afterUserInfo);
        return response;
    }
}