namespace Server.Common.Live;

public record LiveShowDeckInfo
{
    public int UnitDeckId { get; set; }
    public int TotalSmile { get; set; }
    public int TotalPure { get; set; }
    public int TotalCool { get; set; }
    public int TotalHp { get; set; }
    public IEnumerable<UnitStats> UnitList { get; set; }
}