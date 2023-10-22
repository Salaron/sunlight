using System.Text.Json;
using Microsoft.Extensions.Options;
using SunLight.Dtos.Response.Download;
using SunLight.Infrastructure.Configuration;

namespace SunLight.Modules.Download;

public class NppsDownloadBackend(IOptions<ServerConfig> serverConfig) : IDownloadService
{
    private static readonly HttpClient HttpClient = new();

    private readonly ServerConfig _serverConfig = serverConfig.Value;

    public async Task<IEnumerable<string>> GetMicrodownloadUrlsAsync(Platform platformId, IEnumerable<string> assetPath)
    {
        var files = await PerformApiRequest<IEnumerable<DownloadPackageInfo>>("/api/v1/getfile", new
        {
            files = assetPath,
            platform = platformId
        });

        var urls = files.Select(f => f.Url);
        return urls;
    }

    public async Task<IEnumerable<DownloadPackageInfo>> GetUpdateUrlsAsync(Platform platformId, string clientVersion)
    {
        var packagesInfo = await PerformApiRequest<IEnumerable<DownloadPackageInfo>>("/api/v1/update", new
        {
            version = clientVersion,
            platform = platformId
        });

        return packagesInfo;
    }

    public async Task<IEnumerable<DownloadPackageInfo>> GetBatchUrlsAsync(Platform platformId, int packageType, int[] excludeIds)
    {
        var packagesInfo = await PerformApiRequest<IEnumerable<DownloadPackageInfo>>("/api/v1/batch", new
        {
            package_type = packageType,
            platform = platformId,
            exclude = excludeIds
        });

        return packagesInfo;
    }

    public async Task<IEnumerable<DownloadPackageInfo>> GetPackageUrlsAsync(Platform platformId, int packageType,
        int packageId)
    {
        var packagesInfo = await PerformApiRequest<IEnumerable<DownloadPackageInfo>>("/api/v1/download", new
        {
            package_type = packageType,
            package_id = packageId,
            platform = platformId
        });

        return packagesInfo;
    }

    private async Task<T> PerformApiRequest<T>(string apiPath, object requestBody)
    {
        var uri = new Uri(new Uri(_serverConfig.Download.Npps4DlApiUrl), apiPath);

        var content = JsonContent.Create(requestBody);
        if (!string.IsNullOrEmpty(_serverConfig.Download.Npp4DlApiSharedKey))
            content.Headers.Add("DLAPI-Shared-Key", _serverConfig.Download.Npp4DlApiSharedKey);

        var response = await HttpClient.PostAsync(uri, content);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var jsonResponse = JsonSerializer.Deserialize<T>(responseBody, JsonSerializerDefaultOptions.GetOptions());

        return jsonResponse;
    }
}