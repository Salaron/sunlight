using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Unit;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/unit")]
public class UnitController : LlsifController
{
    [HttpPost("unitAll")]
    [Produces(typeof(ServerResponse<UnitAllResponse>))]
    public IActionResult UnitAll([FromBody] ClientRequest requestData)
    {
        var response = new UnitAllResponse
        {
            Active = Enumerable.Empty<object>(),
            Waiting = Enumerable.Empty<object>()
        };

        return SendResponse(response);
    }

    [HttpPost("deckInfo")]
    [Produces(typeof(ServerResponse<IEnumerable<EmptyResponse>>))]
    public IActionResult DeckInfo([FromBody] ClientRequest requestData)
    {
        var response = Enumerable.Empty<EmptyResponse>();

        return SendResponse(response);
    }

    [HttpPost("supporterAll")]
    [Produces(typeof(ServerResponse<UnitSupporterAllResponse>))]
    public IActionResult SupporterAll([FromBody] ClientRequest requestData)
    {
        var response = new UnitSupporterAllResponse
        {
            UnitSupportList = Enumerable.Empty<object>()
        };

        return SendResponse(response);
    }

    [HttpPost("removableSkillInfo")]
    [Produces(typeof(ServerResponse<UnitRemovableSkillInfoResponse>))]
    public IActionResult RemovableSkillInfo([FromBody] ClientRequest requestData)
    {
        var response = new UnitRemovableSkillInfoResponse
        {
            OwningInfo = Enumerable.Empty<RemovableSkillOwningInfoDto>(),
            EquipmentInfo = ImmutableDictionary<string, RemovableSkillEquipInfoDto>.Empty
        };

        return SendResponse(response);
    }

    [HttpPost("accessoryAll")]
    [Produces(typeof(ServerResponse<AccessoryAllResponse>))]
    public IActionResult AccessoryAll([FromBody] ClientRequest requestData)
    {
        var response = new AccessoryAllResponse
        {
            AccessoryList = Enumerable.Empty<object>(),
            WearingInfo = Enumerable.Empty<object>(),
            EspecialCreateFlag = false
        };

        return SendResponse(response);
    }
}