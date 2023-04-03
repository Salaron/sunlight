using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/item")]
public class ItemController : LlsifController
{
    [HttpPost("list")]
    [BatchApiCall("item", "list")]
    public IActionResult ItemList([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}