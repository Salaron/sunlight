using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Request.Download;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Download;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/download")]
public class DownloadController : LlsifController
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
    public async Task<IActionResult> Additional([FromBody] ClientRequest requestData)
    {
        var httpClient = new HttpClient();

        var resp = await httpClient.GetAsync("http://192.168.0.4:8089/additional.json");

        var responseBody = await resp.Content.ReadAsStringAsync();
        var additional = JsonSerializer.Deserialize<IEnumerable<DownloadPackageInfo>>(responseBody, JsonSerializerDefaultOptions.GetOptions());

        return SendResponse(additional);
    }

    [HttpPost("batch")]
    [Produces(typeof(ServerResponse<IEnumerable<DownloadPackageInfo>>))]
    public async Task<IActionResult> Batch([FromBody] ClientRequest requestData)
    {
        var httpClient = new HttpClient();

        var resp = await httpClient.GetAsync("http://192.168.0.4:8089/batch.json");

        var responseBody = await resp.Content.ReadAsStringAsync();
        var additional = JsonSerializer.Deserialize<IEnumerable<DownloadPackageInfo>>(responseBody, JsonSerializerDefaultOptions.GetOptions());

        return SendResponse(additional);
    }

    [HttpPost("getUrl")]
    [Produces(typeof(ServerResponse<DownloadGetUrlResponse>))]
    public IActionResult Event([FromBody] DownloadGetUrlRequest requestData)
    {
        var response = new DownloadGetUrlResponse
        {
            UrlList = requestData.PathList.Select(path => "http://192.168.0.4:8088/mdl/" + path)
        };

        return SendResponse(response);
    }
}