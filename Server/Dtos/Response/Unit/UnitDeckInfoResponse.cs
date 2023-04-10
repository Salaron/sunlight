namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class UnitDeckInfoResponse
{
    public record SlotDetail
    {
        public int Position { get; set; }
        public int UnitOwningUserId { get; set; }
    }

    public int UnitDeckId { get; set; }
    public bool MainFlag { get; set; }
    public string DeckName { get; set; }
    public IEnumerable<SlotDetail> UnitOwningUserIds { get; set; }
}