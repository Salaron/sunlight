namespace SunLight.Dtos.Request.Download;

[Serializable]
public class DownloadEventRequest : ClientRequest
{
    public string ClientVersion { get; init; }
    public string Os { get; init; }
    public int PackageType { get; init; }
    public List<int> ExcludedPackageIds { get; init; }
}