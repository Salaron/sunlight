using Microsoft.EntityFrameworkCore;

namespace SunLight.Database.Game.LiveNotes;

[PrimaryKey(nameof(NotesSettingAsset))]
public class LiveNotesTable
{
    public string NotesSettingAsset { get; set; }
    public string Json { get; set; }
}