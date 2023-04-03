using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/exchange")]
public class ExchangeController : LlsifController
{
    [HttpPost("owningPoint")]
    [BatchApiCall("exchange", "owningPoint")]
    public IActionResult OwningPoint([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}