using Server.Common;

namespace Server.Endpoints.Main.Unit;

internal record SkillOwning(int UnitRemovableSkillId, int TotalAmount, int EquippedAmount, DateTime InsertDate);

internal record SkillEquipDetail(int UnitRemovableSkillId);

internal record SkillEquipInfo(int UnitOwningUserId, List<SkillEquipDetail> Detail);

internal record RemoveSkillInfoResponse(List<SkillOwning> OwningInfo, Dictionary<string, SkillEquipInfo> EquipmentInfo);

[Endpoint("unit/removableSkillInfo", usedInApi: true)]
internal class RemovableSkillInfoEndpoint : Action<EmptyObject, RemoveSkillInfoResponse>
{
    public override Task<RemoveSkillInfoResponse> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(new RemoveSkillInfoResponse([], []));
    }
}