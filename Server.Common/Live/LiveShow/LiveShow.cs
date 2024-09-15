namespace Server.Common.Live;

public record LiveShow
{
    public int LiveDifficultyId { get; set; }
    public bool IsRandom { get; set; }
    public int AcFlag { get; set; }
    public int SwingFlag { get; set; }
    public IEnumerable<LiveShowNote> NotesList { get; set; }
}