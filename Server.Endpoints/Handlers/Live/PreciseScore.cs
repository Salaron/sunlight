using Server.Common;

namespace Server.Endpoints.Handlers.Live;

internal record PreciseScoreRequest(int LiveDifficultyId);

[Endpoint("live/preciseScore")]
internal class PreciseScoreEndpoint(IActionContext context) : Action<PreciseScoreRequest, EmptyObject>
{
    public override async Task<EmptyObject> ExecuteAsync(PreciseScoreRequest requestBody)
    {
        throw new ActionException(3421);
    }
}