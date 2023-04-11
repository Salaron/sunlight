using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Museum;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/museum")]
public class MuseumController : LlsifController
{
    [HttpPost("info")]
    [Produces(typeof(ServerResponse<MuseumInfoResponse>))]
    public IActionResult MuseumInfo([FromBody] ClientRequest requestData)
    {
        var response = new MuseumInfoResponse
        {
            MuseumInfo = new MuseumInfoResponse.MuseumInfoParams()
            {
                Parameter = new MuseumInfoStats(),
                ContentsIdList = Enumerable.Empty<int>()
            }
        };

        return SendResponse(response);
    }
}