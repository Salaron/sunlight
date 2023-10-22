using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SunLight.Infrastructure.Database.Server;

[PrimaryKey(nameof(UnitAlbumId))]
public class UnitAlbum
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UnitAlbumId { get; set; }
    public int UserId { get; set; }
    public int UnitId { get; set; }
    public bool RankMaxFlag { get; set; }
    public bool LoveMaxFlag { get; set; }
    public bool RankLevelMaxFlag { get; set; }
    public bool AllMaxFlag { get; set; }
    public int HighestLovePerUnit { get; set; }
    public int TotalLove { get; set; }
    public int FavoritePoint { get; set; }
    public bool SignFlag { get; set; }

    public virtual User User { get; set; }
}