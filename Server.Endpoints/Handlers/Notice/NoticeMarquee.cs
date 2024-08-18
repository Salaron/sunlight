using Server.Common;

namespace Server.Endpoints.Main.Notice;

internal record Marquee(int MarqueeId, string Text, DateTime StartDate, DateTime EndDate);

internal record NoticeMarqueeResponse(int ItemCount, List<Marquee> MarqueeList);

[Endpoint("notice/noticeMarquee", usedInApi: true)]
internal class NoticeMarqueeEndpoint : Action<EmptyObject, NoticeMarqueeResponse>
{
    public override Task<NoticeMarqueeResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new NoticeMarqueeResponse(0, []));
    }
}