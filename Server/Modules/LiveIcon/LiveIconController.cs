using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.LiveIcon;
using SunLight.Infrastructure.Authorization;
using SunLight.Infrastructure.Database.Game;

namespace SunLight.Modules.LiveIcon;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/liveicon")]
public class LiveIconController : LlsifController
{
    private readonly ItemDbContext _itemDbContext;

    public LiveIconController(ItemDbContext itemDbContext)
    {
        _itemDbContext = itemDbContext;
    }

    [HttpPost("liveiconInfo")]
    [Produces(typeof(ServerResponse<LiveIconInfoResponse>))]
    public IActionResult LiveSeInfo([FromBody] ClientRequest requestData)
    {
        var liveNotesIds = _itemDbContext.LiveNotesIconM.Select(icon => icon.LiveNotesIconId);

        var response = new LiveIconInfoResponse
        {
            LiveNotesIconList = liveNotesIds
        };

        return SendResponse(response);
    }
}