using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
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
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult Event([FromBody] DownloadEventRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }

    [HttpPost("getUrl")]
    [Produces(typeof(ServerResponse<DownloadGetUrlResponse>))]
    public IActionResult Event([FromBody] DownloadGetUrlRequest requestData)
    {
        var response = new DownloadGetUrlResponse
        {
            UrlList = requestData.PathList.Select(path => "http://192.168.0.4:8080/mdl/" + path)
        };

        return SendResponse(response);
    }
}