using System.Text.Json.Serialization;
using Server.Common;
using Server.Common.Items;
using Server.Database.Server;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Main.Login;

internal record UserBirth(uint BirthMonth, uint BirthDay);

internal record UserInfoResponse(UserInfoDto User, [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] UserBirth? Birth, bool AdStatus);

[Endpoint("user/userInfo")]
internal class UserInfoEndpoint(IActionContext actionContext, ServerContext serverContext) : Action<EmptyObject, UserInfoResponse>
{
    public override async Task<UserInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var user = await serverContext.Users.FindAsync(actionContext.UserId);
        var userDto = new UserInfoDto
        {
            UserId = user.UserId,
            Name = user.Name,
            Level = user.Level,
            PreviousExp = user.PreviousExp,
            NextExp = user.NextExp,
            GameCoin = user.GameCoin,
            SnsCoin = user.SnsCoin,
            FreeSnsCoin = user.FreeSnsCoin,
            PaidSnsCoin = user.PaidSnsCoin,
            SocialPoint = user.SocialPoint,
            UnitMax = user.UnitMax,
            WaitingUnitMax = user.WaitingUnitMax,
            EnergyMax = user.EnergyMax,
            EnergyFullTime = user.EnergyFullTime,
            LicenseLiveEnergyRecoverlyTime = 0,
            EnergyFullNeedTime = 0,
            OverMaxEnergy = 0,
            TrainingEnergy = 5,
            TrainingEnergyMax = 5,
            FriendMax = user.FriendMax,
            InviteCode = user.InviteCode,
            TutorialState = user.TutorialState,
            LpRecoveryItem = user.LpRecoveryItem
        };
        
        return new UserInfoResponse(userDto, null, false);
    }
}