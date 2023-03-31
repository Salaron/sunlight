using Microsoft.AspNetCore.Mvc;

namespace SunLight.Controllers;

[ApiController]
[Route("main.php/api")]
[Produces("application/json")]
public class ApiController : ControllerBase
{
    [HttpPost]
    public async Task ServeAsync()
    {
        // тут будут жёсткие приколы с вызовом других контроллеров через рефлексию ну а что поделать
    }
}