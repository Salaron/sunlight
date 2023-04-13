using AutoMapper;
using SunLight.Database.Server;
using SunLight.Dtos.Response.Unit;

namespace SunLight.AutoMapperProfiles;

internal class AutoMapperUnitProfile : Profile
{
    public AutoMapperUnitProfile()
    {
        CreateMap<UnitOwning, UnitInfo>();
        CreateMap<UnitOwning, UnitInfoStripped>();

        CreateMap<UserUnitDeckSlot, UnitDeckInfoResponse.SlotDetail>();
        CreateMap<UserUnitDeck, UnitDeckInfoResponse>();
    }
}