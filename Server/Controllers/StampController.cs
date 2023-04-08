using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Stamp;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/stamp")]
public class StampController : LlsifController
{
    [HttpPost("stampInfo")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult StampInfo([FromBody] ClientRequest requestData)
    {
        var response = new StampInfoResponse
        {
            OwningStampIds = Enumerable.Empty<int>(),
            StampSetting = Enumerable.Empty<object>()
        };

        return SendResponse(response);
    }
}