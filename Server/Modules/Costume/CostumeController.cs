using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Costume;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Costume;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/costume")]
public class CostumeController : LlsifController
{
    [HttpPost("costumeList")]
    [Produces(typeof(ServerResponse<CostumeListResponse>))]
    public IActionResult Event([FromBody] ClientRequest requestData)
    {
        var response = new CostumeListResponse
        {
            CostumeList = Enumerable.Empty<CostumeDto>()
        };

        return SendResponse(response);
    }
}