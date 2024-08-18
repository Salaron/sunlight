using Server.Common.Download;

namespace Server.Endpoints.Main.Download;

internal record DownloadUpdateRequest(string TargetOs, Version InstallVersion, Version ExternalVersion, IReadOnlyList<string> PackageList);

[Endpoint("download/update")]
internal class DownloadUpdate(IDownloadService downloadService) : Action<DownloadUpdateRequest, IEnumerable<DownloadPackageInfo>>
{
    public override Task<IEnumerable<DownloadPackageInfo>> ExecuteAsync(DownloadUpdateRequest requestBody)
    {
        var platform = GetPlatformId(requestBody.TargetOs);
        var versions = new[] { requestBody.InstallVersion, requestBody.ExternalVersion };
        var urls = downloadService.GetUpdateUrlsAsync(platform, versions.Min().ToString());
        
        return urls;
    }
    
    private Platform GetPlatformId(string os) => os switch
    {
        "Android" => Platform.Android,
        "iOS" => Platform.iOS,
        _ => throw new ArgumentOutOfRangeException(nameof(os), os, null)
    };
}