namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class UnitRemovableSkillInfoResponse
{
    public IEnumerable<RemovableSkillOwningInfoDto> OwningInfo { get; set; }
    public IDictionary<string, RemovableSkillEquipInfoDto> EquipmentInfo { get; set; }
}