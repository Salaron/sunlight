using Server.Common.Items;

namespace Server.Common.LoginBonus;

public record SheetReward(int Seq, List<GameItem> Reward);

public record SheetInfo
{
    public int NlbonusItemNum { get; init; }
    public string DetailText { get; init; }
    public string BgAsset { get; init; }
    public bool ShowNextItem { get; init; }
    public List<SheetReward> Items { get; init; }
    public int StampNum { get; init; }
    public List<GameItem>? GetItem { get; set; }
}