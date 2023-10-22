using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SunLight.Infrastructure.Database.Game;
using SunLight.Modules.Live.LiveShow.Models;

namespace SunLight.Services.Live;

public class LiveNotesService : ILiveNotesService
{
    private readonly LiveNotesDbContext _liveNotesDbContext;

    public LiveNotesService(LiveNotesDbContext liveNotesDbContext)
    {
        _liveNotesDbContext = liveNotesDbContext;
    }

    public async Task<IEnumerable<LiveNote>> GetLiveNotesAsync(string notesSettingAsset)
    {
        var notes = await _liveNotesDbContext.LiveNotes.FirstAsync(note => note.NotesSettingAsset == notesSettingAsset);

        var liveNotes =
            JsonSerializer.Deserialize<IEnumerable<LiveNote>>(notes.Json, JsonSerializerDefaultOptions.GetOptions());

        return liveNotes;
    }
}