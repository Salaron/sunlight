using AutoMapper;
using SunLight.Database.Server;
using SunLight.Dtos.Response.Login;

namespace SunLight.AutoMapperProfiles;

internal class AutoMapperLoginProfile : Profile
{
    public AutoMapperLoginProfile()
    {
        CreateMap<AuthKey, AuthKeyResponse>()
            .ForMember(dest => dest.DummyToken, opt => opt.MapFrom(src => src.ServerKey));

    }
}