using Server.Common.Download;

namespace Server.Endpoints.Main.Download;

internal record DownloadGetUrlRequest(string Os, List<string> PathList);

internal record DownloadGetUrlResponse(IEnumerable<string> UrlList);

[Endpoint("download/getUrl")]
internal class DownloadGetUrlEndpoint(IDownloadService downloadService): Action<DownloadGetUrlRequest, DownloadGetUrlResponse>
{
    public override async Task<DownloadGetUrlResponse> ExecuteAsync(DownloadGetUrlRequest requestBody)
    {
        var platform = PlatformHelper.GetPlatformId(requestBody.Os);
        
        var urlList = await downloadService.GetAssetUrlAsync(platform, requestBody.PathList);

        return new DownloadGetUrlResponse(urlList);
    }
}