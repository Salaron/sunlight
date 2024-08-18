using Server.Common;

namespace Server.Endpoints;

public interface IActionContext
{
    string RawRequestBody { get; }
    AuthorizeHeader AuthorizeHeader { get; }
    string? XMessageCode { get; }
    int UserId { get; }
}