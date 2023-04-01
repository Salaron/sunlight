using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Tos;

namespace SunLight.Controllers;

[ApiController]
[Route("main.php/tos")]
public class TosController : LlsifController
{

    [XMessageCodeCheck]
    [HttpPost("tosCheck")]
    [Produces(typeof(ServerResponse<TosCheckResponse>))]
    public IActionResult TosCheck([FromForm] BaseRequest request)
    {
        var response = new TosCheckResponse
        {
            TosId = 1,
            TosType = 3,
            IsAgreed = true
        };

        return SendResponse(response);
    }
}