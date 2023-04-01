using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

public abstract class LlsifController : ControllerBase
{
    protected IActionResult SendResponse<T>(T response, int jsonStatusCode = 200) where T : BaseResponse
    {
        Response.Headers.Add("status_code", jsonStatusCode.ToString());

        var serverResponse = new ServerResponse<T>(response);
        return Ok(serverResponse);
    }
}