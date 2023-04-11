using AutoMapper;
using SunLight.Database.Server;
using SunLight.Dtos.Response.Live;

namespace SunLight.AutoMapperProfiles;

public class AutoMapperLiveProfile : Profile
{
    public AutoMapperLiveProfile()
    {
        CreateMap<LiveStatus, LiveStatusResponse.LiveStatusItem>();
    }
}