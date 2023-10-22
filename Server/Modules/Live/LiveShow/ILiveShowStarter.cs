namespace SunLight.Modules.Live.LiveShow;

public interface ILiveShowStarter
{
    Task<LiveStartInfo> StartLiveShowAsync(int userId, IEnumerable<int> liveDifficultyIds, int unitDeckId);
}