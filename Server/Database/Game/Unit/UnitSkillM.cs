using System.ComponentModel.DataAnnotations;

namespace SunLight.Database.Game.Unit;

public class UnitSkillM
{
    [Key]
    public int UnitSkillId { get; set; }
    public string Name { get; set; }
    public string NameEn { get; set; }
    public int MaxLevel { get; set; }
    public int SkillEffectType { get; set; }
    public int DischargeType { get; set; }
    public int TriggerType { get; set; }
    public int TriggerEffectType { get; set; }
    public int UnitSkillLevelUpPatternId { get; set; }
    public string StringKeyTrigger { get; set; }
    public string StringKeyEffect { get; set; }
    public string StringKeyLongDescription { get; set; }
}