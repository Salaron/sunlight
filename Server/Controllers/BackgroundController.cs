using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Background;
using SunLight.Services;

namespace SunLight.Controllers;

[Authorize]
[ApiController]
[XMessageCodeCheck]
[Route("main.php/background")]
public class BackgroundController : LlsifController
{
    private readonly IItemService _itemService;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public BackgroundController(IItemService itemService, IUserService userService, IConfiguration configuration)
    {
        _itemService = itemService;
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("backgroundInfo")]
    [Produces(typeof(ServerResponse<BackgroundInfoResponse>))]
    public async Task<IActionResult> BackgroundInfo([FromBody] ClientRequest requestData)
    {
        var backgrounds = await _itemService.GetBackgroundAsync();
        var userInfo = await _userService.GetUserInfoAsync(UserId);

        var defaultUnlockIds = _configuration.GetSection("Background:DefaultList").Get<int[]>();
        var unlockAll = _configuration.GetSection("Background:UnlockAll").Get<bool>();

        if (!unlockAll)
            backgrounds = backgrounds.Where(background => defaultUnlockIds.Contains(background.BackgroundId));

        var ownedBackgrounds = new List<BackgroundInfo>();
        foreach (var background in backgrounds)
        {
            ownedBackgrounds.Add(new BackgroundInfo
            {
                BackgroundId = background.BackgroundId,
                IsSet = userInfo.SettingBackgroundId == background.BackgroundId ? 1 : 0,
                InsertDate = ""
            });
        }

        var response = new BackgroundInfoResponse
        {
            BackgroundInfo = ownedBackgrounds
        };

        return SendResponse(response);
    }
}