namespace SunLight.LiveShow.Models;

public class LiveInfo
{
    public int LiveDifficultyId { get; set; }
    public bool IsRandom { get; set; }
    public int AcFlag { get; set; }
    public int SwingFlag { get; set; }
    public IEnumerable<LiveNote> NotesList { get; set; }
}