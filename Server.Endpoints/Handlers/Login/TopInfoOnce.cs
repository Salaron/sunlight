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

internal record TopInfoOnceResponse(
    uint NewAchievementCnt,
    uint UnaccomplishedAchievementCnt,
    bool LiveDailyRewardExist,
    uint TrainingEnergy,
    uint TrainingEnergyMax,
    Notification Notification,
    bool OpenArena,
    bool CostumeStatus,
    bool OpenAccessory,
    bool ArenaSiSkillUniqueCheck,
    bool OpenV98
);

[Endpoint("login/topInfoOnce")]
internal class TopInfoOnceEndpoint : Action<EmptyObject, TopInfoResponse>
{
    public override Task<TopInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        throw new NotImplementedException();
    }
}