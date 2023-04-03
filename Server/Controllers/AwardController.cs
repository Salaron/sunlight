using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/award")]
public class AwardController : LlsifController
{
    [HttpPost("awardInfo")]
    [BatchApiCall("award", "awardInfo")]
    public IActionResult AwardInfo([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}