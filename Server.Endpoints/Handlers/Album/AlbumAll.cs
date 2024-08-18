using Server.Common;
using Server.Common.Unit;
using Server.Database.Server;

namespace Server.Endpoints.Main.Album;

internal record AlbumItem
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
internal class AlbumAllEndpoint(IActionContext context, IUnitService unitService) : Action<EmptyObject, IEnumerable<AlbumItem>>
{
    public override async Task<IEnumerable<AlbumItem>> ExecuteAsync(EmptyObject requestBody)
    {
        var album = await unitService.GetAlbumAsync(context.UserId);
        var albumItems = album.Select(MapAlbumUnit);

        return albumItems;
    }

    private AlbumItem MapAlbumUnit(UnitAlbum unit)
    {
        return new AlbumItem
        {
            UnitId = unit.UnitId,
            RankMaxFlag = unit.RankMaxFlag,
            LoveMaxFlag = unit.LoveMaxFlag,
            RankLevelMaxFlag = unit.RankLevelMaxFlag,
            AllMaxFlag = unit.AllMaxFlag,
            HighestLovePerUnit = unit.HighestLovePerUnit,
            TotalLove = unit.TotalLove,
            FavoritePoint = unit.FavoritePoint,
            SignFlag = unit.SignFlag
        };
    }
}