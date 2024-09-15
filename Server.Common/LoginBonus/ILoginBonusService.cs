using Server.Common.LoginBonus;

namespace Server.Common.Lbonus;

public interface ILoginBonusService
{
    IEnumerable<SheetInfo> GetSheets(int userId, DateTime date);
    LbonusCalendar GetCalendar(int userId, DateOnly date);
    bool HasLoginBonus(int userId, DateOnly date);
    int GetLoginCount(int userId);
    void MarkDay(int userId, DateOnly date);
}