namespace Server.Common.Download;

public interface IDownloadService
{
    Task<IEnumerable<string>> GetAssetUrlAsync(Platform platform, IEnumerable<string> assetPath);
    Task<IEnumerable<DownloadPackageInfo>> GetUpdateUrlsAsync(Platform platform, string clientVersion);
    Task<IEnumerable<DownloadPackageInfo>> GetBatchUrlsAsync(Platform platform, int packageType, int[] excludeIds);
    Task<IEnumerable<DownloadPackageInfo>> GetPackageUrlsAsync(Platform platform, int packageType, int packageId);
}