using Server.Common;

namespace Server.Endpoints.Handlers.Gdpr;

internal record GdprGetResponse(bool EnableGdpr, bool IsEea, bool HasRequested, IEnumerable<object> Permissions);

[Endpoint("gdpr/get")]
internal class GdprGetEndpoint : Action<EmptyObject, GdprGetResponse>
{
    public override Task<GdprGetResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new GdprGetResponse(false, false, false, []));
    }
}
