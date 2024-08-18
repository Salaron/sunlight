using Server.Common;
using Server.Common.Items;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Main.Login;

internal record UserBirth(uint BirthMonth, uint BirthDay);

internal record UserInfoResponse(UserInfoDto User, UserBirth? Birth, bool AdStatus);

[Endpoint("user/userInfo")]
internal class UserInfo() : Action<EmptyObject, UserInfoResponse>
{
    public override Task<UserInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new UserInfoResponse(new UserInfoDto(), null, false));
    }
}