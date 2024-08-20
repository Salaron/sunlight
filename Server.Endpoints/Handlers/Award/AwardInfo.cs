using Server.Common;
using Server.Common.Items;
using Server.Common.Users;
using Server.Database.Enums;

namespace Server.Endpoints.Main.Award;

internal record AwardInfo(int AwardId, bool IsSet, DateTime InsertDate);

internal record AwardInfoResponse(IEnumerable<AwardInfo> AwardInfo);

[Endpoint("award/awardInfo", usedInApi: true)]
internal class AwardInfoEndpoint(IActionContext context, IUserService userService, IUnlockedItemsProvider itemsProvider)
    : Action<EmptyObject, AwardInfoResponse>
{
    public override async Task<AwardInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var user = await userService.GetAsync(context.UserId);
        var unlockedAwards = await itemsProvider.GetUnlockedAsync(context.UserId, AddType.Award);

        var awardList = unlockedAwards.Select(item =>
            new AwardInfo(item.ItemId, item.ItemId == user.SettingAwardId, item.UnlockDate));
        
        return new AwardInfoResponse(awardList);
    }
}