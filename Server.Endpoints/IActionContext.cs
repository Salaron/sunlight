using Server.Common;

namespace Server.Endpoints;

internal interface IActionContext
{
    string RawRequestBody { get; }
    AuthorizeHeader AuthorizeHeader { get; }
    string? XMessageCode { get; }
    byte[] SessionKey { get; }
    int UserId { get; }
}