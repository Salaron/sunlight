using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Live;

namespace SunLight.Controllers;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/live")]
public class LiveController : LlsifController
{
    [HttpPost("liveStatus")]
    [Produces(typeof(ServerResponse<LiveStatusResponse>))]
    public IActionResult LiveStatus([FromBody] ClientRequest requestData)
    {
        var response = new LiveStatusResponse
        {
            NormalLiveStatusList = Enumerable.Empty<object>(),
            SpecialLiveStatusList = Enumerable.Empty<object>(),
            MarathonLiveStatusList = Enumerable.Empty<object>(),
            TrainingLiveStatusList = Enumerable.Empty<object>(),
            FreeLiveStatusList = Enumerable.Empty<object>(),
            CanResumeLive = true
        };

        return SendResponse(response);
    }

    [HttpPost("schedule")]
    [Produces(typeof(ServerResponse<LiveScheduleResponse>))]
    public IActionResult Schedule([FromBody] ClientRequest requestData)
    {
        var response = new LiveScheduleResponse
        {
            EventList = Enumerable.Empty<object>(),
            LiveList = Enumerable.Empty<object>(),
            LimitedBonusList = Enumerable.Empty<object>(),
            LimitedBonusCommonList = Enumerable.Empty<object>(),
            RandomLiveList = Enumerable.Empty<object>(),
            FreeLiveList = Enumerable.Empty<object>(),
            TrainingLiveList = Enumerable.Empty<object>(),
        };

        return SendResponse(response);
    }
}