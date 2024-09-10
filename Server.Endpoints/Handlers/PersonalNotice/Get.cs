using Server.Common;

namespace Server.Endpoints.Handlers.PersonalNotice;

internal record PersonalNoticeResponse(bool HasNotice, int NoticeId, int Type, string Title, string Contents);

[Endpoint("personalnotice/get")]
internal class PersonalNoticeGet : Action<EmptyObject, PersonalNoticeResponse>
{
    public override Task<PersonalNoticeResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new PersonalNoticeResponse(false, 0, 0, string.Empty, string.Empty));
    }
}
