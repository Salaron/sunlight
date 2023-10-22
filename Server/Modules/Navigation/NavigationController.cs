using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Navigation;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Navigation;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/navigation")]
public class NavigationController : LlsifController
{
    [HttpPost("specialCutin")]
    [Produces(typeof(ServerResponse<SpecialCutinResponse>))]
    public IActionResult SpecialCutin([FromBody] ClientRequest requestData)
    {
        var response = new SpecialCutinResponse
        {
            SpecialCutinList = Enumerable.Empty<object>()
        };

        return SendResponse(response);
    }
}