using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/livese")]
public class LiveSeController : LlsifController
{
    [HttpPost("liveseInfo")]
    [BatchApiCall("livese", "liveseInfo")]
    public IActionResult LiveSeInfo([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}