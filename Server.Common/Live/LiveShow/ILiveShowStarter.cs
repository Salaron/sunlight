namespace Server.Common.Live;

public interface ILiveShowStarter
{
    Task<LiveStartInfo> StartLiveShowAsync(int userId, IEnumerable<int> liveDifficultyIds, int unitDeckId);
}