using Server.Common;

namespace Server.Endpoints.Handlers.Museum;

internal record MuseumStats(int Smile, int Pure, int Cool);

internal record MuseumInfo(MuseumStats Parameter, List<int> ContentsIdList);

internal record MuseumInfoResponse(MuseumInfo MuseumInfo);

[Endpoint("museum/info", usedInApi: true)]
internal class MuseumInfoEndpoint : Action<EmptyObject, MuseumInfoResponse>
{
    public override Task<MuseumInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new MuseumInfoResponse(new MuseumInfo(new MuseumStats(0, 0, 0), [])));
    }
}
