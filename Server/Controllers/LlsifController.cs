using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

public abstract class LlsifController : ControllerBase
{
    protected IActionResult SendResponse<T>(T response, int jsonStatusCode = 200) where T : BaseResponse
    {
        Response.Headers.Add("status_code", jsonStatusCode.ToString());

        var serverResponse = new ServerResponse<T>(response, jsonStatusCode);
        return Ok(serverResponse);
    }

    protected IActionResult SendResponse<T>(ICollection<T> response, int jsonStatusCode = 200) where T : BaseResponse
    {
        Response.Headers.Add("status_code", jsonStatusCode.ToString());

        var serverResponse = new ServerCollectionResponse<T>(response, jsonStatusCode);
        return Ok(serverResponse);
    }
}