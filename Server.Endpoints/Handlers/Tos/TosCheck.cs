using Server.Common;

namespace Server.Endpoints.Main.Tos;

internal record TosCheckResponse(uint TosId, uint TosType, bool IsAgreed);

[Endpoint("tos/tosCheck")]
internal class TosCheck : Action<EmptyObject, TosCheckResponse>
{
    public override Task<TosCheckResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new TosCheckResponse(1, 1, true));
    }
}