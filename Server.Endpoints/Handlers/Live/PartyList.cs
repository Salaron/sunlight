using System.ComponentModel.DataAnnotations;
using Server.Common.Unit;
using Server.Common.Users;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Handlers.Live;

internal record LivePartyListRequest(
    bool IsTraining,
    [Range(minimum: 1, maximum: 4)]
    int LpFactor,
    string LiveDifficultyId);

internal enum FriendStatus
{
    NotFriends,
    Friend,
    ApprovalWait,
    Pending
}

internal record LivePartyUser(
    LiveUserInfo UserInfo,
    LiveUnitInfo CenterUnitInfo,
    int SettingAwardId,
    int AvailableSocialPoint,
    FriendStatus FriendStatus);

internal record LivePartyListResponse
{
    public object LiveInfo { get; init; }
    public bool HasSlideNotes { get; init; }
    public int TrainingEnergy { get; init; }
    public int TrainingEnergyMax { get; init; }
    public List<LivePartyUser> PartyList { get; init; }
}

[Endpoint("live/partyList")]
internal class PartyListEndpoint(IActionContext action, IUserService userService, IUnitService unitService)
    : Action<LivePartyListRequest, LivePartyListResponse>
{
    public override async Task<LivePartyListResponse> ExecuteAsync(LivePartyListRequest requestBody)
    {
        var user = await userService.GetAsync(action.UserId);
        var centerUnit = await unitService.GetCenterUnitAsync(action.UserId);

        var liveUserInfo = Mappers.User.UserInfoToLiveUserInfo(user);
        var liveCenterUnitInfo = Mappers.Unit.UnitOwningToLiveUnitInfo(centerUnit);

        var response = new LivePartyListResponse
        {
            PartyList =
            [
                new LivePartyUser(liveUserInfo, liveCenterUnitInfo, user.SettingAwardId, 0, FriendStatus.Friend)
            ]
        };

        return response;
    }
}