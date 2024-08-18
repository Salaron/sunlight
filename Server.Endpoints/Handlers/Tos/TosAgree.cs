using Server.Common;

namespace Server.Endpoints.Main.Tos;

internal record TosAgreeResponse(uint TosId, uint TosType, bool IsAgreed);

[Endpoint("tos/tosAgree")]
internal class TosAgreeEndpoint : Action<EmptyObject, TosAgreeResponse>
{
    public override Task<TosAgreeResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new TosAgreeResponse(1, 1, true));
    }
}