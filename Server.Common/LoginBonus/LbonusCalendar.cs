namespace Server.Common.Lbonus;

public record LbonusCalendar
{
    public int Year { get; set; }
    public int Month { get; set; }
    public IReadOnlyList<DayInfo> Days { get; set; }
}