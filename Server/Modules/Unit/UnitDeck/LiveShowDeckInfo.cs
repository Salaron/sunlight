namespace SunLight.Services.Unit;

public class LiveShowDeckInfo
{
    public int UnitDeckId { get; set; }
    public int TotalSmile { get; set; }
    public int TotalPure { get; set; }
    public int TotalCool { get; set; }
    public int TotalHp { get; set; }
    public IEnumerable<DeckSlotStat> UnitList { get; set; }
}