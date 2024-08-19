namespace Server.Endpoints.Dtos;

public class UserInfoDto
{
    public int UserId { get; init; }
    public string Name { get; init; }
    public int Level { get; init; }
    public int PreviousExp { get; init; }
    public int NextExp { get; init; }
    public int GameCoin { get; init; }
    public int SnsCoin { get; init; }
    public int FreeSnsCoin { get; init; }
    public int PaidSnsCoin { get; init; }
    public int SocialPoint { get; init; }
    public int UnitMax { get; init; }
    public int WaitingUnitMax { get; init; }
    public int EnergyMax { get; init; }
    public DateTime EnergyFullTime { get; init; }
    public int LicenseLiveEnergyRecoverlyTime { get; init; }
    public int EnergyFullNeedTime { get; init; }
    public int OverMaxEnergy { get; init; }
    public int TrainingEnergy { get; init; }
    public int TrainingEnergyMax { get; init; }
    public int FriendMax { get; init; }
    public string InviteCode { get; init; }
    public int TutorialState { get; init; }
    public List<object> LpRecoveryItem { get; init; }
    public short UnlockRandomLiveMuse { get; init; }
    public short UnlockRandomLiveAqours { get; init; }
}