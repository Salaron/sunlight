namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class RemovableSkillEquipInfoDto
{
    public int UnitOwningUserId { get; set; }
    public IEnumerable<RemovableSkillEquipDetailDto> Detail { get; set; }
}