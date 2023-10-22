using Microsoft.EntityFrameworkCore;

namespace SunLight.Infrastructure.Database.Game.Museum;

[PrimaryKey(nameof(MuseumContentsId))]
public class MuseumContentsM
{
    public int MuseumContentsId { get; set; }
    public int MuseumTabCategoryId { get; set; }
    public int? MasterId { get; set; }
    public string ThumbnailAsset { get; set; }
    public string ThumbnailAssetEn { get; set; }
    public string Title { get; set; }
    public string TitleEn { get; set; }
    public string Category { get; set; }
    public string CategoryEn { get; set; }
    public int MuseumRarity { get; set; }
    public int AttributeId { get; set; }
    public int SmileBuff { get; set; }
    public int PureBuff { get; set; }
    public int CoolBuff { get; set; }
    public int SortId { get; set; }
    public string ReleaseTag { get; set; }
    public int? EncryptionReleaseId { get; set; }
}