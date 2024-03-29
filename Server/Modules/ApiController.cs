﻿using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Modules;

// the controller was replaced by ApiRequestMiddleware and will be never called
// exists for swagger
[ApiController]
[Route("main.php/api")]
public class ApiController : LlsifController
{
    [HttpPost]
    [Produces(typeof(ServerResponse<List<ApiResponse>>))]
    public IActionResult CallApiAsync([FromBody] IEnumerable<ClientApiRequest> apiRequests)
    {
        return Ok();
    }
}