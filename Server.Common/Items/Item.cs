using Server.Database.Enums;

namespace Server.Common.Items;

public static class Item
{
    public static GameCoinItem GameCoin(int amount) => new(amount);
    public static SocialPointItem SocialPoint(int amount) => new(amount);
    public static PlayerExpItem PlayerExp(int amount) => new(amount);

    public static LovecaItem Loveca(int amount, bool isPaid = false) => new(amount, isPaid);

    public static UnitItem Unit(int unitId, int level = 1, UnitRank rank = UnitRank.Normal, bool isSigned = false,
        int amount = 1) =>
        new(unitId, level, rank, isSigned);
    
    public static LiveItem Live(int liveTrackId) => new(liveTrackId);

    public static AwardItem Award(int awardId) => new(awardId);
    
    public static BackgroundItem Background(int backgroundId) => new(backgroundId);

    public static ExchangePointItem ExchangePoint(int rarity, int amount) => new(rarity, amount);

    public static IItem FromGameItem(GameItem gameItem) => gameItem.AddType switch
    {
        AddType.GameCoin => GameCoin(gameItem.Amount),
        AddType.SocialPoint => SocialPoint(gameItem.Amount),
        AddType.PlayerExp => PlayerExp(gameItem.Amount),
        AddType.Loveca => Loveca(gameItem.Amount),
        AddType.Unit => Unit(gameItem.UnitId ?? gameItem.ItemId ?? throw new ArgumentNullException()),
        AddType.Live => Live(gameItem.ItemId!.Value),
        AddType.Award => Award(gameItem.ItemId!.Value),
        AddType.Background => Background(gameItem.ItemId!.Value),
        AddType.ExchangePoint => ExchangePoint(gameItem.ItemId!.Value, gameItem.Amount),
        _ => throw new ArgumentOutOfRangeException()
    };
    
    public static GameItem ToGameItem(IItem item) => item switch
    {
        GameCoinItem coin => new GameItem(AddType.GameCoin, coin.Amount),
        SocialPointItem point => new GameItem(AddType.SocialPoint, point.Amount),
        PlayerExpItem exp => new GameItem(AddType.PlayerExp, exp.Amount),
        LovecaItem loveca => new GameItem(AddType.Loveca, loveca.Amount),
        UnitItem unit => new GameItem(AddType.Unit, unit.UnitId),
        LiveItem live => new GameItem(AddType.PlayerExp, live.LiveDifficultyId),
        AwardItem award => new GameItem(AddType.PlayerExp, award.AwardId),
        BackgroundItem background => new GameItem(AddType.PlayerExp, background.BackgroundId),
        ExchangePointItem exchangePoint => new GameItem(AddType.ExchangePoint, exchangePoint.Rarity),
        _ => throw new ArgumentOutOfRangeException()
    };
}