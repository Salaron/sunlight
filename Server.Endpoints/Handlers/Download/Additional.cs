using Server.Common.Download;

namespace Server.Endpoints.Handlers.Download;

internal record DownloadAdditionalRequest(int PackageType, int PackageId, string TargetOs, int[] ExcludedPackageIds);

[Endpoint("download/additional")]
internal class DownloadAdditionalEndpoint(IDownloadService downloadService) : Action<DownloadAdditionalRequest, IEnumerable<DownloadPackageInfo>>
{
    public override Task<IEnumerable<DownloadPackageInfo>> ExecuteAsync(DownloadAdditionalRequest requestBody)
    {
        var platform = PlatformHelper.GetPlatformId(requestBody.TargetOs);
        var urls = downloadService.GetPackageUrlsAsync(platform, requestBody.PackageType, requestBody.PackageId);

        return urls;
    }
}
