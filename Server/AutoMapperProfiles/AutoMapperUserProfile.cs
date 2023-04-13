using AutoMapper;
using SunLight.Database.Server;
using SunLight.Dtos.Response.User;

namespace SunLight.AutoMapperProfiles;

internal class AutoMapperUserProfile : Profile
{
    public AutoMapperUserProfile()
    {
        CreateMap<User, UserInfoDto>();
        CreateMap<User, UserInfoStripped>();
    }
}