using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Award;
using SunLight.Services;

namespace SunLight.Controllers;

[Authorize]
[ApiController]
[XMessageCodeCheck]
[Route("main.php/award")]
public class AwardController : LlsifController
{
    private readonly IItemService _itemService;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AwardController(IItemService itemService, IUserService userService, IConfiguration configuration)
    {
        _itemService = itemService;
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("awardInfo")]
    [Produces(typeof(ServerResponse<AwardInfoResponse>))]
    public async Task<IActionResult> AwardInfo([FromBody] ClientRequest requestData)
    {
        var awards = await _itemService.GetAwardAsync();
        var userInfo = await _userService.GetUserInfoAsync(UserId);

        var defaultUnlockIds = _configuration.GetSection("Award:DefaultList").Get<int[]>();
        var unlockAll = _configuration.GetSection("Award:UnlockAll").Get<bool>();

        if (!unlockAll)
            awards = awards.Where(award => defaultUnlockIds.Contains(award.AwardId));

        var ownedAwards = awards.Select(award => new AwardInfo
        {
            AwardId = award.AwardId,
            IsSet = userInfo.SettingAwardId == award.AwardId,
            InsertDate = DateTime.MinValue
        });

        var response = new AwardInfoResponse
        {
            AwardInfo = ownedAwards
        };

        return SendResponse(response);
    }
}