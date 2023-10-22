using AutoMapper;
using SunLight.Dtos.Response;

namespace SunLight.Modules.UserModule;

internal class AutoMapperUserProfile : Profile
{
    public AutoMapperUserProfile()
    {
        CreateMap<Infrastructure.Database.Server.User, UserInfoDto>();
        CreateMap<Infrastructure.Database.Server.User, UserInfoStripped>();
    }
}