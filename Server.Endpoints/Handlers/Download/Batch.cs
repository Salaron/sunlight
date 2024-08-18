using Server.Common.Download;

namespace Server.Endpoints.Main.Download;

internal record DownloadBatchRequest(int PackageType, string Os, int[] ExcludedPackageIds);

[Endpoint("download/batch")]
internal class DownloadBatchEndpoint(IDownloadService downloadService) : Action<DownloadBatchRequest, IEnumerable<DownloadPackageInfo>>
{
    public override Task<IEnumerable<DownloadPackageInfo>> ExecuteAsync(DownloadBatchRequest requestBody)
    {
        var platform = PlatformHelper.GetPlatformId(requestBody.Os);
        var urls = downloadService.GetBatchUrlsAsync(platform, requestBody.PackageType, requestBody.ExcludedPackageIds);
        
        return urls;
    }
}