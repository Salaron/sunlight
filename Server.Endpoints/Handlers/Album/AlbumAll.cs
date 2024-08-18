using Server.Common;

namespace Server.Endpoints.Main.Album;

internal record AlbumItem(
    int UnitId,
    bool RankMaxFlag,
    bool LoveMaxFlag,
    bool RankLevelMaxFlag,
    bool AllMaxFlag,
    int HighestLovePerUnit,
    int TotalLove,
    int FavoritePoint,
    bool SignFlag);

[Endpoint("album/albumAll", usedInApi: true)]
internal class AlbumAllEndpoint : Action<EmptyObject, IEnumerable<AlbumItem>>
{
    public override Task<IEnumerable<AlbumItem>> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(Enumerable.Empty<AlbumItem>());
    }
}