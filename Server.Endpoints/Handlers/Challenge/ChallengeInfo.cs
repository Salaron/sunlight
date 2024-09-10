using Server.Common;

namespace Server.Endpoints.Handlers.Challenge;

[Endpoint("challenge/challengeInfo", usedInApi: true)]
internal class ChallengeInfoEndpoint : Action<EmptyObject, IEnumerable<EmptyObject>>
{
    public override Task<IEnumerable<EmptyObject>> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(Enumerable.Empty<EmptyObject>());
    }
}
