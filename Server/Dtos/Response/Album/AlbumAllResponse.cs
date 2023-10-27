namespace SunLight.Dtos.Response.Album;

public class AlbumAllResponse
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