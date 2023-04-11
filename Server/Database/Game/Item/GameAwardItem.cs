using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Game.Item;

[PrimaryKey(nameof(AwardId))]
public class AwardM
{
    public int AwardId { get; set; }
    public string Name { get; set; }
    public string NameEn { get; set; }
    public string Description { get; set; }
    public string DescriptionEn { get; set; }
    public string ImgAsset { get; set; }
    public string ImgAssetEn { get; set; }
    public int DiAssetDisplayFlag { get; set; }
}