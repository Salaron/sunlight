using Microsoft.AspNetCore.Http;
using Server.Common;

namespace Server.Endpoints;

internal class ActionContext(IHttpContextAccessor accessor) : IActionContext
{
    public string RawRequestBody { get; } = accessor.HttpContext?.Items["RawRequestBody"] as string ?? string.Empty;
    public AuthorizeHeader AuthorizeHeader { get; } = AuthorizeHeader.FromString(accessor.HttpContext?.Request.Headers["Authorize"].FirstOrDefault() ?? string.Empty);
    public string? XMessageCode { get; } = accessor.HttpContext?.Request.Headers["X-Message-Code"].FirstOrDefault();
    public int UserId { get; set; }
}