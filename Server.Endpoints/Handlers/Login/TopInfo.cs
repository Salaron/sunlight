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

internal record TopInfoResponse(
    uint FriendActionCnt,
    uint FriendGreetCnt,
    uint FriendVarietyCnt,
    uint FriendNewCnt,
    uint FriendsApprovalWaitCnt,
    uint FriendsRequestCnt,
    bool IsTodayBirthday,
    uint PresentCnt,
    bool SecretBoxBadgeFlag,
    DateTime ServerDatetime,
    LicenseInfo LicenseInfo,
    IEnumerable<object> UsingBuffInfo,
    bool IsKlabIdTaskFlag,
    bool KlabIdTaskCanSync,
    bool HasUnreadAnnounce,
    IEnumerable<int> ExchangeBadgeCnt,
    bool AdFlag,
    bool HasAdReward
);

[Endpoint("login/topInfo")]
internal class TopInfo : Action<EmptyObject, TopInfoResponse>
{
    public override Task<TopInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        throw new NotImplementedException();
    }
}