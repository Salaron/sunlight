using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Background;
using SunLight.Services;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/background")]
public class BackgroundController : LlsifController
{
    private readonly IItemService _itemService;

    public BackgroundController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost("backgroundInfo")]
    [Produces(typeof(ServerResponse<BackgroundInfoResponse>))]
    public async Task<IActionResult> BackgroundInfo([FromBody] ClientRequest requestData)
    {
        var backgrounds = await _itemService.GetBackgroundAsync();

        var ownedBackgrounds = new List<BackgroundInfo>();
        foreach (var background in backgrounds)
        {
            ownedBackgrounds.Add(new BackgroundInfo
            {
                BackgroundId = background.BackgroundId,
                IsSet = 0,
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