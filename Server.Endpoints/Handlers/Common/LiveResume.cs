using Server.Common;

namespace Server.Endpoints.Handlers.Common;

internal record LiveResumeRequest(bool Cancel);

[Endpoint("common/liveResume")]
internal class LiveResumeEndpoint : Action<LiveResumeRequest, EmptyObject>
{
    public override Task<EmptyObject> ExecuteAsync(LiveResumeRequest requestBody)
    {
        return Task.FromResult(new EmptyObject());
    }
}
