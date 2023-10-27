using SunLight.Dtos.Response.Unit;

namespace SunLight.Dtos.Response;

public class BasicUserInfo
{
    public UserInfoStripped UserInfo { get; set; }
    public UnitInfoStripped CenterUnitInfo { get; set; }
    public int SettingAwardId { get; set; }
    public int AvailableSocialPoint { get; set; }
    public int FriendStatus { get; set; }
}