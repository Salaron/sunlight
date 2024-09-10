using Server.Common;
using Server.Common.Items;
using Server.Common.Users;
using Server.Database.Enums;

namespace Server.Endpoints.Handlers.Background;

internal record BackgroundInfo(int BackgroundId, bool IsSet, DateTime InsertDate);

internal record BackgroundInfoResponse(IEnumerable<BackgroundInfo> BackgroundInfo);

[Endpoint("background/backgroundInfo", usedInApi: true)]
internal class AwardInfoEndpoint(IActionContext context, IUserService userService, IUnlockedItemsProvider itemsProvider) : Action<EmptyObject, BackgroundInfoResponse>
{
    public override async Task<BackgroundInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var user = await userService.GetAsync(context.UserId);
        var unlockedItems = await itemsProvider.GetUnlockedAsync(context.UserId, AddType.Background);

        var backgroundList = unlockedItems.Select(item =>
            new BackgroundInfo(item.ItemId, item.ItemId == user.SettingBackgroundId, item.UnlockDate));

        return new BackgroundInfoResponse(backgroundList);
    }
}
