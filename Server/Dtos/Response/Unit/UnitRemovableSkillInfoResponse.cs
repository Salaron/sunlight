namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class UnitRemovableSkillInfoResponse
{
    public record SkillOwningInfo
    {
        public int UnitRemovableSkillId { get; set; }
        public int TotalAmount { get; set; }
        public int EquippedAmount { get; set; }
        public DateTime InsertDate { get; set; }
    }

    public IEnumerable<SkillOwningInfo> OwningInfo { get; set; }

    public record SkillEquipInfo
    {
        public record EquipDetail
        {
            public int UnitRemovableSkillId { get; set; }
        }

        public int UnitOwningUserId { get; set; }
        public IEnumerable<EquipDetail> Detail { get; set; }
    }

    public IDictionary<string, SkillEquipInfo> EquipmentInfo { get; set; }
}