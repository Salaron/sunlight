﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Response;

namespace SunLight.Modules;

public abstract class LlsifController : ControllerBase
{
    protected int UserId => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");

    protected IActionResult SendResponse<T>(T response, int jsonStatusCode = 200)
    {
        Response.Headers["status_code"] = jsonStatusCode.ToString();

        var serverResponse = new ServerResponse<T>(response, jsonStatusCode);
        return Ok(serverResponse);
    }
}