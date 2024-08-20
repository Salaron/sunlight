namespace Server.Common.Unit;

public record UnitAlbumInfo
{
    public int UserId { get; init; }
    public int UnitId { get; init; }
    public bool RankMaxFlag { get; init; }
    public bool LoveMaxFlag { get; init; }
    public bool RankLevelMaxFlag { get; init; }
    public bool AllMaxFlag { get; init; }
    public int HighestLovePerUnit { get; init; }
    public int TotalLove { get; init; }
    public int FavoritePoint { get; init; }
    public bool SignFlag { get; init; }
}