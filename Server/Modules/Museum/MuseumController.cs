using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Museum;
using SunLight.Infrastructure.Authorization;
using SunLight.Infrastructure.Database.Game;

namespace SunLight.Modules.Museum;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/museum")]
public class MuseumController : LlsifController
{
    private readonly MuseumDbContext _museumDbContext;

    public MuseumController(MuseumDbContext museumDbContext)
    {
        _museumDbContext = museumDbContext;
    }

    [HttpPost("info")]
    [Produces(typeof(ServerResponse<MuseumInfoResponse>))]
    public IActionResult MuseumInfo([FromBody] ClientRequest requestData)
    {
        var contentIds = _museumDbContext.MuseumContentsM.Select(content => content.MuseumContentsId);

        var response = new MuseumInfoResponse
        {
            MuseumInfo = new MuseumInfoResponse.MuseumInfoParams()
            {
                Parameter = new MuseumInfoStats(),
                ContentsIdList = contentIds
            }
        };

        return SendResponse(response);
    }
}