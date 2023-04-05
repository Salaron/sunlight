using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Gdpr;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/gdpr")]
public class GdprController : LlsifController
{
    [HttpPost("get")]
    [Produces(typeof(ServerResponse<GdprGetResponse>))]
    public IActionResult GdprGet([FromBody] ClientRequest requestData)
    {
        var response = new GdprGetResponse
        {
            EnableGdpr = false,
            IsEea = false,
            HasRequested = false,
            Permissions = new List<GdprPermissionDto>()
        };

        return SendResponse(response);
    }
}