using AutoMapper;
using SunLight.Dtos.Response.Live;
using SunLight.Infrastructure.Database.Server;

namespace SunLight.Modules.Live;

public class AutoMapperLiveProfile : Profile
{
    public AutoMapperLiveProfile()
    {
        CreateMap<LiveStatus, LiveStatusResponse.LiveStatusItem>();
    }
}