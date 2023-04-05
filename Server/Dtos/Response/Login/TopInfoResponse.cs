namespace SunLight.Dtos.Response.Login;

[Serializable]
public class TopInfoResponse
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
    public string ServerDatetime { get; set; }
    public LicenseInfoDto LicenseInfo { get; set; }
    public IEnumerable<object> UsingBuffInfo { get; set; }
    public bool IsKlabIdTaskFlag { get; set; }
    public bool KlabIdTaskCanSync { get; set; }
    public bool HasUnreadAnnounce { get; set; }
    public IEnumerable<int> ExchangeBadgeCnt { get; set; }
    public bool AdFlag { get; set; }
    public bool HasAdReward { get; set; }
}