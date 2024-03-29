﻿using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.LiveSe;
using SunLight.Infrastructure.Authorization;
using SunLight.Infrastructure.Database.Game;

namespace SunLight.Modules.LiveSe;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/livese")]
public class LiveSeController : LlsifController
{
    private readonly ItemDbContext _itemDbContext;

    public LiveSeController(ItemDbContext itemDbContext)
    {
        _itemDbContext = itemDbContext;
    }

    [HttpPost("liveseInfo")]
    [Produces(typeof(ServerResponse<LiveSeInfoResponse>))]
    public IActionResult LiveSeInfo([FromBody] ClientRequest requestData)
    {
        var liveSeIds = _itemDbContext.LiveSeM.Select(liveSe => liveSe.LiveSeId);

        var response = new LiveSeInfoResponse
        {
            LiveSeList = liveSeIds
        };

        return SendResponse(response);
    }
}