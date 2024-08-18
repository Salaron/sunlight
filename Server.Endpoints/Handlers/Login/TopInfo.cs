using Server.Common;

namespace Server.Endpoints.Main.Login;

internal enum LicenseType
{
    Lbonus = 1,
    Buff = 2,
    Premium = 3,
    Live = 4
}

internal record LicenseDetails(
    int LicenseId,
    LicenseType LicenseType
);

internal record LicenseUserStatus(DateTime EndDate);

internal record ActivatedLicenseDetails(int LicenseId, LicenseType LicenseType, LicenseUserStatus UserStatus);

internal record LicenseInfo(
    IEnumerable<LicenseDetails> LicenseList,
    IEnumerable<ActivatedLicenseDetails> LicensedInfo,
    IEnumerable<object> ExpiredInfo);

internal record TopInfoResponse
{
    public uint FriendActionCnt { get; set; }
    public uint FriendGreetCnt { get; set; }
    public uint FriendVarietyCnt { get; set; }
    public uint FriendNewCnt { get; set; }
    public uint FriendsApprovalWaitCnt { get; set; }
    public uint FriendsRequestCnt { get; set; }
    public bool IsTodayBirthday { get; set; }
    public uint PresentCnt { get; set; }
    public bool SecretBoxBadgeFlag { get; set; }
    public DateTime ServerDatetime { get; set; }
    public LicenseInfo LicenseInfo { get; set; }
    public IEnumerable<object> UsingBuffInfo { get; set; }
    public bool IsKlabIdTaskFlag { get; set; }
    public bool KlabIdTaskCanSync { get; set; }
    public bool HasUnreadAnnounce { get; set; }
    public IEnumerable<int> ExchangeBadgeCnt { get; set; }
    public bool AdFlag { get; set; }
    public bool HasAdReward { get; set; }
}

[Endpoint("login/topInfo", usedInApi: true)]
internal class TopInfoEndpoint : Action<EmptyObject, TopInfoResponse>
{
    public override Task<TopInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new TopInfoResponse
        {
            ExchangeBadgeCnt = new List<int> { 0, 0, 0 }
        });
    }
}