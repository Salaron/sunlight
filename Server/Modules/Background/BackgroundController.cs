using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Background;
using SunLight.Infrastructure.Authorization;
using SunLight.Infrastructure.Configuration;
using SunLight.Modules.Item;
using SunLight.Modules.UserModule;

namespace SunLight.Modules.Background;

[Authorize]
[ApiController]
[XMessageCodeCheck]
[Route("main.php/background")]
public class BackgroundController : LlsifController
{
    private readonly IItemService _itemService;
    private readonly IUserService _userService;
    private readonly BackgroundConfig _backgroundConfig;

    public BackgroundController(IItemService itemService, IUserService userService, IOptions<SunLightConfig> config)
    {
        _itemService = itemService;
        _userService = userService;
        _backgroundConfig = config.Value.Background;
    }

    [HttpPost("backgroundInfo")]
    [Produces(typeof(ServerResponse<BackgroundInfoResponse>))]
    public async Task<IActionResult> BackgroundInfo([FromBody] ClientRequest requestData)
    {
        var backgrounds = await _itemService.GetBackgroundAsync();
        var userInfo = await _userService.GetUserAsync(UserId);

        if (!_backgroundConfig.UnlockAll)
            backgrounds = backgrounds.Where(background => _backgroundConfig.DefaultList.Contains(background.BackgroundId));

        var ownedBackgrounds = backgrounds.Select(background => new BackgroundInfo
        {
            BackgroundId = background.BackgroundId,
            IsSet = userInfo.SettingAwardId == background.BackgroundId,
            InsertDate = DateTime.MinValue
        });

        var response = new BackgroundInfoResponse
        {
            BackgroundInfo = ownedBackgrounds
        };

        return SendResponse(response);
    }
}