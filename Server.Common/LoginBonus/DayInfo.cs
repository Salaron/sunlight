using Server.Common.Items;

namespace Server.Common.Lbonus;

public record DayInfo
{
    public int Day { get; set; }
    public int DayOfTheWeek { get; set; }
    public bool SpecialDay { get; set; }
    public required string SpecialImageAsset { get; set; }
    public bool Received { get; set; }
    public bool AdReceived { get; set; }
    public required GameItem Item { get; set; }
}
