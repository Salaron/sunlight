using System.Collections.Immutable;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Database.Server;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Unit;
using SunLight.Services.Unit;

namespace SunLight.Controllers;

[Authorize]
[ApiController]
[XMessageCodeCheck]
[Route("main.php/unit")]
public class UnitController : LlsifController
{
    private readonly IUnitService _unitService;
    private readonly IUnitDeckService _unitDeckService;
    private readonly IMapper _mapper;

    public UnitController(IUnitService unitService, IUnitDeckService unitDeckService, IMapper mapper)
    {
        _unitService = unitService;
        _unitDeckService = unitDeckService;
        _mapper = mapper;
    }

    [HttpPost("unitAll")]
    [Produces(typeof(ServerResponse<UnitAllResponse>))]
    public async Task<IActionResult> UnitAll([FromBody] ClientRequest requestData)
    {
        var units = await _unitService.GetUnitsOwnedByUser(UserId);

        var trimmed = _mapper.Map<IEnumerable<UnitOwning>, IEnumerable<UnitInfo>>(units);

        var response = new UnitAllResponse
        {
            Active = trimmed,
            Waiting = Enumerable.Empty<UnitInfo>()
        };

        return SendResponse(response);
    }

    [HttpPost("deckInfo")]
    [Produces(typeof(ServerResponse<IEnumerable<UnitDeckInfoResponse>>))]
    public async Task<IActionResult> DeckInfo([FromBody] ClientRequest requestData)
    {
        var decks = await _unitDeckService.GetUserDeckAsync(UserId);

        var response = _mapper.Map<IEnumerable<UserUnitDeck>, IEnumerable<UnitDeckInfoResponse>>(decks);
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
            OwningInfo = Enumerable.Empty<UnitRemovableSkillInfoResponse.SkillOwningInfo>(),
            EquipmentInfo = ImmutableDictionary<string, UnitRemovableSkillInfoResponse.SkillEquipInfo>.Empty
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