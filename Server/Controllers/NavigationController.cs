using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Navigation;

namespace SunLight.Controllers;

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