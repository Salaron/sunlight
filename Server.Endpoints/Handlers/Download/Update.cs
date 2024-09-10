using Server.Common.Download;

namespace Server.Endpoints.Handlers.Download;

internal record DownloadUpdateRequest(string TargetOs, Version InstallVersion, Version ExternalVersion, IReadOnlyList<string> PackageList);

[Endpoint("download/update", ignoreVersion: true)]
internal class UpdateEndpoint(IDownloadService downloadService) : Action<DownloadUpdateRequest, IEnumerable<DownloadPackageInfo>>
{
    public override Task<IEnumerable<DownloadPackageInfo>> ExecuteAsync(DownloadUpdateRequest requestBody)
    {
        var platform = PlatformHelper.GetPlatformId(requestBody.TargetOs);
        var versions = new[] { requestBody.InstallVersion, requestBody.ExternalVersion };
        var urls = downloadService.GetUpdateUrlsAsync(platform, versions.Min().ToString());

        return urls;
    }
}
