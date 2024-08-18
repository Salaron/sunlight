using Server.Common;

namespace Server.Endpoints.Main.Costume;

internal record CostumeDetails(int UnitId, bool IsRankMax, bool IsSigned);

internal record CostumeListResponse(List<CostumeDetails> CostumeList);

[Endpoint("costume/costumeList", usedInApi: true)]
internal class CostumeListEndpoint : Action<EmptyObject, CostumeListResponse>
{
    public override Task<CostumeListResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new CostumeListResponse([]));
    }
}