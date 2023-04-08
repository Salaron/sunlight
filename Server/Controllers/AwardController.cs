using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Award;
using SunLight.Services;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/award")]
public class AwardController : LlsifController
{
    private readonly IItemService _itemService;
    private readonly IConfiguration _configuration;

    public AwardController(IItemService itemService, IConfiguration configuration)
    {
        _configuration = configuration;
        _itemService = itemService;
    }

    [HttpPost("awardInfo")]
    [Produces(typeof(ServerResponse<AwardInfoResponse>))]
    public async Task<IActionResult> AwardInfo([FromBody] ClientRequest requestData)
    {
        var awards = await _itemService.GetAwardAsync();

        var defaultUnlockIds = _configuration.GetSection("Award:DefaultList").Get<int[]>();
        var unlockAll = _configuration.GetSection("Award:UnlockAll").Get<bool>();

        if (!unlockAll)
            awards = awards.Where(award => defaultUnlockIds.Contains(award.AwardId));
                
        var ownedAwards = new List<AwardInfo>();
        foreach (var award in awards)
        {
            ownedAwards.Add(new AwardInfo
            {
                AwardId = award.AwardId,
                IsSet = 0,
                InsertDate = ""
            });
        }

        var response = new AwardInfoResponse
        {
            AwardInfo = ownedAwards
        };

        return SendResponse(response);
    }
}