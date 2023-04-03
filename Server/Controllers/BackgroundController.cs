using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/background")]
public class BackgroundController : LlsifController
{
    [HttpPost("backgroundInfo")]
    [BatchApiCall("background", "backgroundInfo")]
    public IActionResult BackgroundInfo([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}