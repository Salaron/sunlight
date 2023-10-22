using AutoMapper;
using SunLight.Dtos.Response.Unit;
using SunLight.Infrastructure.Database.Server;

namespace SunLight.Modules.Unit;

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