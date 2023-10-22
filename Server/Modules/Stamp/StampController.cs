using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Stamp;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Stamp;

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