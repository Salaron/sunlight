using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request.Download;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Download;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Download;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/download")]
public class DownloadController(IDownloadService downloadService) : LlsifController
{
    [HttpPost("event")]
    [Produces(typeof(ServerResponse<IEnumerable<DownloadPackageInfo>>))]
    public IActionResult Event([FromBody] DownloadEventRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }

    [HttpPost("additional")]
    [Produces(typeof(ServerResponse<IEnumerable<DownloadPackageInfo>>))]
    public async Task<IActionResult> Additional([FromBody] DownloadAdditionalRequest requestData)
    {
        var platformId = GetPlatformId(requestData.TargetOs);
        var batchUrls = await downloadService.GetPackageUrlsAsync(platformId,
            requestData.PackageType, requestData.PackageId);

        return SendResponse(batchUrls);
    }

    [HttpPost("batch")]
    [Produces(typeof(ServerResponse<IEnumerable<DownloadPackageInfo>>))]
    public async Task<IActionResult> Batch([FromBody] DownloadBatchRequest requestData)
    {
        var platformId = GetPlatformId(requestData.Os);
        var batchUrls = await downloadService.GetBatchUrlsAsync(platformId, requestData.PackageType,
            requestData.ExcludedPackageIds);

        return SendResponse(batchUrls);
    }

    [HttpPost("getUrl")]
    [Produces(typeof(ServerResponse<DownloadGetUrlResponse>))]
    public async Task<IActionResult> Microdl([FromBody] DownloadGetUrlRequest requestData)
    {
        var platformId = GetPlatformId(requestData.Os);

        var urlList = await downloadService.GetMicrodownloadUrlsAsync(platformId, requestData.PathList);
        var response = new DownloadGetUrlResponse
        {
            UrlList = urlList
        };

        return SendResponse(response);
    }

    private Platform GetPlatformId(string os) => os switch
    {
        "Android" => Platform.Android,
        "iOS" => Platform.iOS,
        _ => throw new ArgumentOutOfRangeException(nameof(os), os, null)
    };
}