using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/navigation")]
public class NavigationController : LlsifController
{
    [HttpPost("specialCutin")]
    [BatchApiCall("navigation", "specialCutin")]
    public IActionResult SpecialCutin([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}