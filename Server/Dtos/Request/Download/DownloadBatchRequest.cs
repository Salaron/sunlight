namespace SunLight.Dtos.Request.Download;

public class DownloadBatchRequest : ClientRequest
{
    public int PackageType { get; set; }
    public string Os { get; set; }
    public int[] ExcludedPackageIds { get; set; }
}