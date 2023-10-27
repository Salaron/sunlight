using AutoMapper;
using SunLight.Dtos.Response.Album;
using SunLight.Infrastructure.Database.Server;

namespace SunLight.Modules.Album;

public class AutoMapperAlbumProfile : Profile
{
    public AutoMapperAlbumProfile()
    {
        CreateMap<UnitAlbum, AlbumAllResponse>();
    }
}