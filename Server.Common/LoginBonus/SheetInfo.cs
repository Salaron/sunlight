using Server.Common.Config;

namespace Server.Common.LoginBonus;

public record SheetInfo
{
    public string DetailText { get; init; }
    public string BgAsset { get; init; }
    public IReadOnlyList<SheetDay> Items { get; init; }
    public int StampNum { get; init; }
}