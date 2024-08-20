using Server.Common;

namespace Server.Endpoints.Main.Login;

internal record Notification
{
    public bool Push { get; set; }
    public bool Lp { get; set; }
    public bool UpdateInfo { get; set; }
    public bool Campaign { get; set; }
    public bool Live { get; set; }
    public bool Lbonus { get; set; }
    public bool Event { get; set; }
    public bool Secretbox { get; set; }
    public bool Birthday { get; set; }
}

internal record TopInfoOnceResponse
{
    public uint NewAchievementCnt { get; set; }
    public uint UnaccomplishedAchievementCnt { get; set; }
    public bool LiveDailyRewardExist { get; set; }
    public uint TrainingEnergy { get; set; }
    public uint TrainingEnergyMax { get; set; }
    public Notification Notification { get; set; }
    public bool OpenArena { get; set; }
    public bool CostumeStatus { get; set; }
    public bool OpenAccessory { get; set; }
    public bool ArenaSiSkillUniqueCheck { get; set; }
    public bool OpenV98 { get; set; }
}

[Endpoint("login/topInfoOnce", usedInApi: true)]
internal class TopInfoOnceEndpoint : Action<EmptyObject, TopInfoOnceResponse>
{
    public override Task<TopInfoOnceResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new TopInfoOnceResponse
        {
            NewAchievementCnt = 0,
            UnaccomplishedAchievementCnt = 0,
            LiveDailyRewardExist = false,
            TrainingEnergy = 5,
            TrainingEnergyMax = 5,
            Notification = new Notification(),
            OpenArena = false,
            CostumeStatus = false,
            OpenAccessory = false,
            ArenaSiSkillUniqueCheck = false,
            OpenV98 = true
        });
    }
}