using Server.Common;

namespace Server.Endpoints;

internal class ResponseFactory
{
    public static readonly ServerResponse<EmptyObject> Empty = new(new EmptyObject(), 200, []);
}