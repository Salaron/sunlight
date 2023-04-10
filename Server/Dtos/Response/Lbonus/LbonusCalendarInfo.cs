namespace SunLight.Dtos.Response.Lbonus;

[Serializable]
public class LbonusCalendarInfo
{
    public record MonthInfo
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public IEnumerable<DayInfo> Days { get; set; }
    }

    public record DayInfo
    {
        public int Day { get; set; }
        public int DayOfTheWeek { get; set; }
        public bool SpecialDay { get; set; }
        public string SpecialImageAsset { get; set; }
        public bool Received { get; set; }
        public bool AdReceived { get; set; }
        public object Item { get; set; }
    }

    public string CurrentDate { get; set; } // YYYY.MM.dd
    public MonthInfo CurrentMonth { get; set; }
    public MonthInfo NextMonth { get; set; }
}