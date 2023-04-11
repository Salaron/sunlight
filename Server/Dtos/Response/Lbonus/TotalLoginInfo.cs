namespace SunLight.Dtos.Response.Lbonus;

[Serializable]
public class TotalLoginInfo
{
    public int LoginCount { get; set; }
    public int RemainingCount { get; set; }
    public IEnumerable<Item> Reward { get; set; }
}