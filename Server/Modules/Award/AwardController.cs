using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Award;
using SunLight.Infrastructure.Authorization;
using SunLight.Infrastructure.Configuration;
using SunLight.Modules.Item;
using SunLight.Modules.UserModule;

namespace SunLight.Modules.Award;

[Authorize]
[ApiController]
[XMessageCodeCheck]
[Route("main.php/award")]
public class AwardController : LlsifController
{
    private readonly IItemService _itemService;
    private readonly IUserService _userService;
    private readonly AwardConfig _awardConfig;

    public AwardController(IItemService itemService, IUserService userService, IOptions<SunLightConfig> config)
    {
        _itemService = itemService;
        _userService = userService;
        _awardConfig = config.Value.Award;
    }

    [HttpPost("awardInfo")]
    [Produces(typeof(ServerResponse<AwardInfoResponse>))]
    public async Task<IActionResult> AwardInfo([FromBody] ClientRequest requestData)
    {
        var awards = await _itemService.GetAwardAsync();
        var userInfo = await _userService.GetUserInfoAsync(UserId);

        if (!_awardConfig.UnlockAll)
            awards = awards.Where(award => _awardConfig.DefaultList.Contains(award.AwardId));

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