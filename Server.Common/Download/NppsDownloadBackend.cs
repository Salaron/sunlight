using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Server.Common.Config;
using Server.Common.Json;

namespace Server.Common.Download;

internal class NppsDownloadBackend(IOptions<ServerConfig> serverConfig) : IDownloadService
{
    private static readonly HttpClient HttpClient = new();

    public async Task<IEnumerable<string>> GetAssetUrlAsync(Platform platform, IEnumerable<string> files)
    {
        var response = await SendRequest<IEnumerable<DownloadPackageInfo>>("/api/v1/getfile", new
        {
            files,
            platform
        });

        var urls = response.Select(f => f.Url);
        return urls;
    }

    public async Task<IEnumerable<DownloadPackageInfo>> GetUpdateUrlsAsync(Platform platform, string version)
    {
        var packagesInfo = await SendRequest<IEnumerable<DownloadPackageInfo>>("/api/v1/update", new
        {
            version,
            platform
        });

        return packagesInfo;
    }

    public async Task<IEnumerable<DownloadPackageInfo>> GetBatchUrlsAsync(Platform platform, int packageType, int[] excludeIds)
    {
        var packagesInfo = await SendRequest<IEnumerable<DownloadPackageInfo>>("/api/v1/batch", new
        {
            package_type = packageType,
            exclude = excludeIds,
            platform,
        });

        return packagesInfo;
    }

    public async Task<IEnumerable<DownloadPackageInfo>> GetPackageUrlsAsync(Platform platform, int packageType,
        int packageId)
    {
        var packagesInfo = await SendRequest<IEnumerable<DownloadPackageInfo>>("/api/v1/download", new
        {
            package_type = packageType,
            package_id = packageId,
            platform
        });

        return packagesInfo;
    }

    private async Task<T> SendRequest<T>(string apiPath, object requestBody)
    {
        var uri = new Uri(new Uri(serverConfig.Value.Download.NppsDownloadApiUrl), apiPath);

        var content = JsonContent.Create(requestBody);
        if (!string.IsNullOrEmpty(serverConfig.Value.Download.NppsDownloadApiKey))
            content.Headers.Add("DLAPI-Shared-Key", serverConfig.Value.Download.NppsDownloadApiKey);

        var response = await HttpClient.PostAsync(uri, content);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var jsonResponse = JsonSerializer.Deserialize<T>(responseBody, JsonSerializerDefaultOptions.GetOptions());

        return jsonResponse;
    }
}