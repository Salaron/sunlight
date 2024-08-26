namespace Server.Common.Lbonus;

public interface ILoginBonusService
{
    MonthInfo GetCalendar(int userId, DateOnly date);
    bool HasLoginBonus(int userId, DateOnly date);
    int GetLoginCount(int userId);
}