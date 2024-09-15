namespace Server.Common.Live;

public interface ILiveInfoProvider
{
    Task<LiveDifficulty> GetLiveDifficultyAsync(int liveDifficultyId);
    Task<IReadOnlyList<LiveShowNote>> GetLiveNotesAsync(string notesSettingAsset, NoteMods mods);
}