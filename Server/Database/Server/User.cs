﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SunLight.Database.Server;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint UserId { get; init; }

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
    public uint LicenseLiveEnergyRecoverlyTime { get; set; }
    public uint EnergyFullNeedTime { get; set; }
    public uint OverMaxEnergy { get; set; }
    public uint TrainingEnergy { get; set; }
    public uint TrainingEnergyMax { get; set; }
    public uint FriendMax { get; set; }
    public string InviteCode => UserId.ToString();

    public int TutorialState { get; set; }

    //public object LpRecoveryItem { get; set; }
    public string LoginKey { get; set; }
    public string LoginPasswd { get; set; }
    public Guid AuthorizeToken { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime CreationTime { get; set; }
}