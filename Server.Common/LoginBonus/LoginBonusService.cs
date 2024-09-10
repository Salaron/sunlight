using Microsoft.Extensions.Options;
using Server.Common.Config;
using Server.Common.LoginBonus;
using Server.Database.Server;

namespace Server.Common.Lbonus;

internal class LoginBonusService(IOptionsSnapshot<ServerConfig> serverConfig, ServerContext serverContext)
    : ILoginBonusService
{
    public IEnumerable<SheetInfo> GetSheets(int userId, DateTime date)
    {
        var activeSheets =
            serverConfig.Value.LoginBonus.Sheets.Where(sheet => date >= sheet.StartDate && date <= sheet.EndDate);
        foreach (var sheet in activeSheets)
        {
            var collectedCount = serverContext.LoginBonus.Count(d => date >= sheet.StartDate && date <= sheet.EndDate);
            yield return new SheetInfo
            {
                DetailText = sheet.Text,
                BgAsset = sheet.AssetPath,
                StampNum = collectedCount,
                Items = sheet.Days
            };
        }
    }

    public MonthInfo GetCalendar(int userId, DateOnly date)
    {
        var start = new DateOnly(date.Year, date.Month, 1);
        var end = new DateOnly(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

        var userLoginDays = serverContext.LoginBonus
            .Where(u => u.UserId == userId && u.Date >= start && u.Date <= end)
            .Select(d => d.Date.Day)
            .ToList();

        return new MonthInfo
        {
            Year = date.Year,
            Month = date.Month,
            Days = Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month)).Select(day =>
                new DayInfo
                {
                    Day = day,
                    DayOfTheWeek = (int)new DateTime(date.Year, date.Month, day).DayOfWeek + 1,
                    SpecialDay = false,
                    SpecialImageAsset = string.Empty,
                    Received = userLoginDays.Contains(day),
                    AdReceived = false,
                    Item = serverConfig.Value.LoginBonus.CalendarBase[day]
                }).ToList()
        };
    }
    
    public void MarkDay(int userId, DateOnly date) => serverContext.LoginBonus.Add(new Database.Server.LoginBonus()
    {
        UserId = userId,
        Date = date,
    });

    public bool HasLoginBonus(int userId, DateOnly date) =>
        !serverContext.LoginBonus.Any(login => login.UserId == userId && login.Date == date);

    public int GetLoginCount(int userId) => serverContext.LoginBonus.Count(login => login.UserId == userId);
}