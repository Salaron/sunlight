using AutoMapper;
using SunLight.Dtos.Response.Login;
using SunLight.Infrastructure.Database.Server;

namespace SunLight.Modules.Login;

internal class AutoMapperLoginProfile : Profile
{
    public AutoMapperLoginProfile()
    {
        CreateMap<AuthKey, AuthKeyResponse>()
            .ForMember(dest => dest.DummyToken, opt => opt.MapFrom(src => src.ServerKey));

    }
}