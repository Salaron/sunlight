using Server.Common;

namespace Server.Endpoints.Handlers.Banner;

internal record BannerListResponse(DateTime TimeLimit, List<object> BannerList);

[Endpoint("banner/bannerList", usedInApi: true)]
internal class BannerListEndpoint : Action<EmptyObject, BannerListResponse>
{
    public override Task<BannerListResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new BannerListResponse(DateTime.MaxValue, []));
    }
}
