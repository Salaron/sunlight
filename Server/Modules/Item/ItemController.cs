using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Item;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/item")]
public class ItemController : LlsifController
{
    [HttpPost("list")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult ItemList([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }
}