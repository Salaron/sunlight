using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Album;
using SunLight.Infrastructure.Authorization;
using SunLight.Infrastructure.Database.Server;

namespace SunLight.Modules.Album;

[ApiController]
[XMessageCodeCheck]
[Route("main.php/album")]
internal class AlbumController(ServerDbContext serverDbContext, IMapperBase mapper) : LlsifController
{
    
    [HttpPost("albumAll")]
    [Produces(typeof(ServerResponse<IEnumerable<AlbumAllResponse>>))]
    public async Task<IActionResult> AlbumAll([FromBody] ClientRequest requestData)
    {
        var album = await serverDbContext.UnitAlbum.Where(a => a.UserId == UserId).ToListAsync();

        var response = mapper.Map<IEnumerable<UnitAlbum>, IEnumerable<AlbumAllResponse>>(album);
        return SendResponse(response);
    }
}