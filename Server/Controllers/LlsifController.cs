using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

public abstract class LlsifController : ControllerBase
{
    protected uint UserId => uint.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

    protected IActionResult SendResponse<T>(T response, int jsonStatusCode = 200)
    {
        Response.Headers["status_code"] = jsonStatusCode.ToString();

        var serverResponse = new ServerResponse<T>(response, jsonStatusCode);
        return Ok(serverResponse);
    }
}