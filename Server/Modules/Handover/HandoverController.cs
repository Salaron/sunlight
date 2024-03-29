﻿using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Handover;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Handover;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/handover")]
public class HandoverController : LlsifController
{
    [HttpPost("kidStatus")]
    [Produces(typeof(ServerResponse<KlabIdStatusResponse>))]
    public IActionResult KlabIdStatus([FromBody] ClientRequest requestData)
    {
        var response = new KlabIdStatusResponse
        {
            HasKlabId = false
        };

        return SendResponse(response);
    }
}