namespace Server.Common.Live;

public record LiveStartInfo
{
    public IEnumerable<LiveInfoWithDeck> LiveList { get; init; } 
    public IEnumerable<LiveRankInfo> ScoreRank { get; init; }
}