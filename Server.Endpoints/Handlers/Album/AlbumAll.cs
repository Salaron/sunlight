using Server.Common;
using Server.Common.Unit;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Handlers.Album;

internal record AlbumItemDto
{
    public int UnitId { get; set; }
    public bool RankMaxFlag { get; set; }
    public bool LoveMaxFlag { get; set; }
    public bool RankLevelMaxFlag { get; set; }
    public bool AllMaxFlag { get; set; }
    public int HighestLovePerUnit { get; set; }
    public int TotalLove { get; set; }
    public int FavoritePoint { get; set; }
    public bool SignFlag { get; set; }
}

[Endpoint("album/albumAll", usedInApi: true)]
internal class AlbumAllEndpoint(IActionContext context, IUnitService unitService) : Action<EmptyObject, IEnumerable<AlbumItemDto>>
{
    public override async Task<IEnumerable<AlbumItemDto>> ExecuteAsync(EmptyObject requestBody)
    {
        var mapper = new UnitMapper();
        var album = await unitService.GetAlbumAsync(context.UserId);
        var albumItems = album.Select(mapper.AlbumItemToDto);

        return albumItems;
    }
}
