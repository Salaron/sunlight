namespace Server.Common.Live;

public record LiveRankInfo
{
    public LiveRank Rank { get; set; }
    public int RankMin { get; set; }
    public int RankMax { get; set; }
}