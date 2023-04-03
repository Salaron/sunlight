using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/unit")]
public class UnitController : LlsifController
{
    [HttpPost("unitAll")]
    [BatchApiCall("unit", "unitAll")]
    public IActionResult UnitAll([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }

    [HttpPost("deckInfo")]
    [BatchApiCall("unit", "deckInfo")]
    public IActionResult DeckInfo([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }

    [HttpPost("supporterAll")]
    [BatchApiCall("unit", "supporterAll")]
    public IActionResult SupporterAll([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }

    [HttpPost("removableSkillInfo")]
    [BatchApiCall("unit", "removableSkillInfo")]
    public IActionResult RemovableSkillInfo([FromBody] BaseRequest requestData)
    {
        var response = new EmptyResponse();

        return SendResponse(response);
    }
}