using Microsoft.EntityFrameworkCore;

namespace SunLight.Infrastructure.Database.Game.Item;

[PrimaryKey(nameof(BackgroundId))]
public class BackgroundM
{
    public int BackgroundId { get; set; }
    public string Name { get; set; }
    public string NameEn { get; set; }
    public string Description { get; set; }
    public string DescriptionEn { get; set; }
    public string ImgAsset { get; set; }
}