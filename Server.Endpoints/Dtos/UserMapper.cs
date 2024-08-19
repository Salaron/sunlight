using Riok.Mapperly.Abstractions;
using Server.Common.Users;

namespace Server.Endpoints.Dtos;

[Mapper]
internal partial class UserMapper
{
    public partial UserInfoDto UserInfoToDto(UserInfo userInfo);
}