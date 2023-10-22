using SunLight.Dtos.Response.Download;

namespace SunLight.Modules.Download;

public interface IDownloadService
{
    Task<IEnumerable<string>> GetMicrodownloadUrlsAsync(Platform platformId, IEnumerable<string> assetPath);
    Task<IEnumerable<DownloadPackageInfo>> GetUpdateUrlsAsync(Platform platformId, string clientVersion);
    Task<IEnumerable<DownloadPackageInfo>> GetBatchUrlsAsync(Platform platformId, int packageType, int[] excludeIds);
    Task<IEnumerable<DownloadPackageInfo>> GetPackageUrlsAsync(Platform platformId, int packageType, int packageId);
}