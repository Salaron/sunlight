namespace SunLight.Dtos.Response.Login;

[Serializable]
public class TopInfoOnceResponse
{
    public uint NewAchievementCnt { get; set; }
    public uint UnaccomplishedAchievementCnt { get; set; }
    public bool LiveDailyRewardExist { get; set; }
    public uint TrainingEnergy { get; set; }
    public uint TrainingEnergyMax { get; set; }
    public NotificationDto Notification { get; set; }
    public bool OpenArena { get; set; }
    public bool CostumeStatus { get; set; }
    public bool OpenAccessory { get; set; }
    public bool ArenaSiSkillUniqueCheck { get; set; }
    public bool OpenV98 { get; set; }
}