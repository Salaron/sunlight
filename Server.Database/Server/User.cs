using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Server.Database.Enums;

#nullable enable

namespace Server.Database.Server;

[PrimaryKey(nameof(UserId))]
public class User
{
    public int UserId { get; init; }

    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    public int Level { get; set; }
    public int PreviousExp { get; set; }
    public int Exp { get; set; }
    public int NextExp { get; set; }
    public int GameCoin { get; set; }
    public int FreeSnsCoin { get; set; }
    public int PaidSnsCoin { get; set; }
    public int SocialPoint { get; set; }
    public int UnitMax { get; set; }
    public int WaitingUnitMax { get; set; }
    public int EnergyMax { get; set; }
    public DateTime EnergyFullTime { get; set; }
    public int LicenseLiveEnergyRecoveryTime { get; set; }
    public int OverMaxEnergy { get; set; }
    public int TrainingEnergy { get; set; }
    public int TrainingEnergyMax { get; set; }
    public int FriendMax { get; set; }
    public string InviteCode => UserId.ToString();
    public TutorialState TutorialState { get; set; }
    public int SettingAwardId { get; set; }
    public int SettingBackgroundId { get; set; }
    public string LoginKey { get; set; }
    public string LoginPasswd { get; set; }

    public string AuthorizeToken { get; set; } = string.Empty;
    public string SessionKey { get; set; } = string.Empty;
    public int? PartnerUnitId { get; set; }

    [ForeignKey(nameof(PartnerUnitId))]
    public virtual UnitOwning? PartnerUnit { get; set; }

    public DateOnly? Birthday { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime InsertDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdateDate { get; set; }

    public DateTime LastActivityDate { get; set; }
}