using Riok.Mapperly.Abstractions;
using Server.Database.Server;
using Server.Endpoints.Main.Album;
using Server.Endpoints.Main.Unit;

namespace Server.Endpoints.Dtos;

[Mapper]
internal partial class UnitMapper
{
    public partial UnitInfoDto UnitOwningToDto(UnitOwning unit);
    
    [MapProperty(nameof(UserUnitDeck.UnitDeckSlots), nameof(UnitDeckInfoResponse.UnitOwningUserIds))]
    public partial UnitDeckInfoResponse UnitDeckToDto(UserUnitDeck unitDeck);
    
    public partial AlbumItemDto AlbumItemToDto(UnitAlbum unit);
}