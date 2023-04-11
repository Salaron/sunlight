namespace SunLight.Dtos.Response.Lbonus;

// TODO: remove it
[Serializable]
public class Item
{
    public int UnitId { get; set; }
    public int AddType { get; set; }
    public int Amount { get; set; }
    public bool IsRankMax { get; set; }
    public bool IsSigned { get; set; }
}