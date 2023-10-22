using SunLight.Modules.Live.LiveShow.Models;

namespace SunLight.Services.Live;

public interface ILiveNotesService
{
    Task<IEnumerable<LiveNote>> GetLiveNotesAsync(string notesSettingAsset);
}