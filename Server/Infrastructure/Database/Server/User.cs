using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SunLight.Infrastructure.Database.Server;

[PrimaryKey(nameof(UserId))]
public class User
{
    public int UserId { get; init; }

    public string Name { get; set; }
    public uint Level { get; set; }
    public uint PreviousExp { get; set; }
    public uint NextExp { get; set; }
    public uint GameCoin { get; set; }
    public uint SnsCoin { get; set; }
    public uint FreeSnsCoin { get; set; }
    public uint PaidSnsCoin { get; set; }
    public uint SocialPoint { get; set; }
    public uint UnitMax { get; set; }
    public uint WaitingUnitMax { get; set; }
    public uint EnergyMax { get; set; }
    public string EnergyFullTime { get; set; }
    public uint LicenseLiveEnergyRecoveryTime { get; set; }
    public uint EnergyFullNeedTime { get; set; }
    public uint OverMaxEnergy { get; set; }
    public uint TrainingEnergy { get; set; }
    public uint TrainingEnergyMax { get; set; }
    public uint FriendMax { get; set; }
    public string InviteCode => UserId.ToString();
    public int TutorialState { get; set; }
    public int SettingAwardId { get; set; }
    public int SettingBackgroundId { get; set; }
    public int? MainUnitDeckId { get; set; }
    public int? PartnerUnitId { get; set; }
    public ICollection<object> LpRecoveryItem => new List<object>();
    public DateTime LastLogin { get; set; }
    public DateTime CreationTime { get; set; }
    public Guid AuthorizeToken { get; set; }
    public string LoginKey { get; set; }
    public string LoginPasswd { get; set; }

    [ForeignKey(nameof(MainUnitDeckId))]
    public virtual UserUnitDeck? MainUnitDeck { get; set; }

    [ForeignKey(nameof(PartnerUnitId))]
    public virtual UnitOwning? PartnerUnit { get; set; }
}