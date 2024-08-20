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

    public static AwardItem Award(int awardId) => new(awardId);
    
    public static BackgroundItem Background(int backgroundId) => new(backgroundId);
}