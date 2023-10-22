using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Gdpr;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Gdpr;

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