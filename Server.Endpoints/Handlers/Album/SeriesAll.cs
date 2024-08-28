using System.Collections.Frozen;
using Server.Common;
using Server.Common.Unit;
using Server.Database.Game;
using Server.Endpoints.Dtos;

namespace Server.Endpoints.Main.Album;

internal record AlbumSeriesDto(int SeriesId, IEnumerable<AlbumItemDto> UnitList);

[Endpoint("album/seriesAll")]
internal class SeriesAllEndpoint : Action<EmptyObject, IEnumerable<AlbumSeriesDto>>
{
    private readonly IActionContext _context;
    private readonly IUnitService _unitService;
    private readonly UnitContext _unitDbContext;
    private static Lazy<FrozenDictionary<int, int>> _seriesIdByUnitId;

    public SeriesAllEndpoint(IActionContext context, IUnitService unitService, UnitContext unitDbContext)
    {
        _context = context;
        _unitService = unitService;
        _unitDbContext = unitDbContext;
        _seriesIdByUnitId ??= new Lazy<FrozenDictionary<int, int>>(CreateUnitIdBySeriesMap, LazyThreadSafetyMode.ExecutionAndPublication);
    }

    public override async Task<IEnumerable<AlbumSeriesDto>> ExecuteAsync(EmptyObject requestBody)
    {
        var mapper = new UnitMapper();
        var album = await _unitService.GetAlbumAsync(_context.UserId);
        var albumItems = album.Select(mapper.AlbumItemToDto);

        var result = new Dictionary<int, List<AlbumItemDto>>();
        foreach (var albumSeries in _unitDbContext.AlbumSeriesM)
            result.Add(albumSeries.AlbumSeriesId, []);

        foreach (var item in albumItems)
        {
            if (!_seriesIdByUnitId.Value.TryGetValue(item.UnitId, out var seriesId))
                continue;

            result[seriesId].Add(item);
        }

        return result.Select(pairs => new AlbumSeriesDto(pairs.Key, pairs.Value));
    }

    private FrozenDictionary<int, int> CreateUnitIdBySeriesMap()
    {
        var map = new Dictionary<int, int>();
        foreach (var unit in _unitDbContext.UnitM)
        {
            if (!unit.AlbumSeriesId.HasValue)
                continue;

            map[unit.UnitId] = unit.AlbumSeriesId.Value;
        }

        return map.ToFrozenDictionary();
    }
}
