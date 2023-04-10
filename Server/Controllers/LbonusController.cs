using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Lbonus;

namespace SunLight.Controllers;

[Authorize]
[ApiController]
[XMessageCodeCheck(specialApi: true)]
[Route("main.php/lbonus")]
public class LbonusController : LlsifController
{

    [HttpPost("execute")]
    [Produces(typeof(ServerResponse<LbonusResponse>))]
    public async Task<IActionResult> Execute([FromBody] ClientRequest requestData)
    {
        var response = new LbonusResponse
        {
            Sheets = Enumerable.Empty<object>(),
        };
        
        return SendResponse(response);
    }
}