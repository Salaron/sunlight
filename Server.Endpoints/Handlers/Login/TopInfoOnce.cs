using Server.Common;

namespace Server.Endpoints.Main.Login;

internal record Notification(
    bool Push,
    bool Lp,
    bool UpdateInfo,
    bool Campaign,
    bool Live,
    bool Lbonus,
    bool Event,
    bool Secretbox,
    bool Birthday
);

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
internal class TopInfoOnceEndpoint : Action<EmptyObject, TopInfoResponse>
{
    public override Task<TopInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new TopInfoResponse());
    }
}