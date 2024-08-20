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

internal record LicenseInfo
{
    public IEnumerable<LicenseDetails> LicenseList { get; set; }
    public IEnumerable<ActivatedLicenseDetails> LicensedInfo { get; set; }
    public IEnumerable<object> ExpiredInfo { get; set; }
}

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
            UsingBuffInfo = [],
            ServerDatetime = DateTimeUtils.GetServerTime(),
            ExchangeBadgeCnt = new List<int> { 0, 0, 0 },
            LicenseInfo = new LicenseInfo
            {
                LicenseList = new List<LicenseDetails>
                {
                    new(1, LicenseType.Lbonus),
                    new(2, LicenseType.Buff),
                    new(3, LicenseType.Premium),
                    new(4, LicenseType.Live),
                },
                LicensedInfo = new List<ActivatedLicenseDetails>
                {
                    new(3, LicenseType.Premium, new LicenseUserStatus(DateTime.MaxValue)),
                    new(4, LicenseType.Live, new LicenseUserStatus(DateTime.MaxValue)),
                },
                ExpiredInfo = [],
            }
        });
    }
}