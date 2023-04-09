using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Game.Unit;

[PrimaryKey(nameof(UnitLevelUpPatternId), nameof(UnitLevel))]
public class GameUnitLevelUpPattern
{
    public int UnitLevelUpPatternId { get; set; }
    public int UnitLevel { get; set; }
    public int NextExp { get; set; }
    public int HpDiff { get; set; }
    public int SmileDiff { get; set; }
    public int PureDiff { get; set; }
    public int CoolDiff { get; set; }
    public int MergeExp { get; set; }
    public int MergeCost { get; set; }
    public int SalePrice { get; set; }
}