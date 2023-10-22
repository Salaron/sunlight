namespace SunLight.Dtos.Request.Download;

public class DownloadAdditionalRequest : ClientRequest
{
    public int PackageType { get; set; }
    public int PackageId { get; set; }
    public int[] ExcludedPackageIds { get; set; }
    public string TargetOs { get; set; }
}