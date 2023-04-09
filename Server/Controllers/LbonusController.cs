using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Award;

namespace SunLight.Controllers;

[Authorize]
[ApiController]
[XMessageCodeCheck(specialApi: true)]
[Route("main.php/lbonus")]
public class LbonusController : LlsifController
{

    [HttpPost("execute")]
    [Produces(typeof(ServerResponse<AwardInfoResponse>))]
    public async Task<IActionResult> Execute([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();
        return SendResponse(response);
    }
}