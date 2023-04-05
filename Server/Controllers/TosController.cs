﻿using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Tos;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/tos")]
public class TosController : LlsifController
{
    [HttpPost("tosCheck")]
    [Produces(typeof(ServerResponse<TosCheckResponse>))]
    public IActionResult TosCheck([FromForm] ClientRequest request)
    {
        var response = new TosCheckResponse
        {
            TosId = 1,
            TosType = 3,
            IsAgreed = true
        };

        return SendResponse(response);
    }

    [HttpPost("tosAgree")]
    [Produces(typeof(ServerResponse<TosCheckResponse>))]
    public IActionResult TosAgree([FromForm] ClientRequest request)
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