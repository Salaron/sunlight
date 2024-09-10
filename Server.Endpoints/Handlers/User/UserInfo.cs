using System.Text.Json.Serialization;
using Server.Common;
using Server.Common.Users;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Handlers.Login;

internal record UserBirth(int BirthMonth, int BirthDay);

internal record UserInfoResponse(
    UserInfoDto User,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    UserBirth? Birth,
    bool AdStatus);

[Endpoint("user/userInfo", usedInApi: true)]
internal class UserInfoEndpoint(IActionContext actionContext, IUserService userService)
    : Action<EmptyObject, UserInfoResponse>
{
    public override async Task<UserInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var mapper = new UserMapper();
        var user = await userService.GetAsync(actionContext.UserId);
        var userDto = mapper.UserInfoToDto(user);

        UserBirth? birthday = null;
        if (user.Birthday.HasValue)
            birthday = new UserBirth(user.Birthday.Value.Month, user.Birthday.Value.Day);

        return new UserInfoResponse(userDto, birthday, false);
    }
}
