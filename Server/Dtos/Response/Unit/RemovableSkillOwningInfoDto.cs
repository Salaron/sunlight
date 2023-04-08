namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class RemovableSkillOwningInfoDto
{
    public int UnitRemovableSkillId { get; set; }
    public int TotalAmount { get; set; }
    public int EquippedAmount { get; set; }
    public DateTime InsertDate { get; set; }
}