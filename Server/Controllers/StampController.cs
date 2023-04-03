using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/stamp")]
public class StampController : LlsifController
{
    [HttpPost("stampInfo")]
    [BatchApiCall("stamp", "stampInfo")]
    public IActionResult StampInfo([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}