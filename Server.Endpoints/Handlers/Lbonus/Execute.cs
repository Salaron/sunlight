using Server.Common;
using Server.Common.Items;
using Server.Common.Lbonus;
using Server.Common.LoginBonus;
using Server.Common.Users;

namespace Server.Endpoints.Handlers.Lbonus;

internal record LbonusCalendarInfo
{
    public string CurrentDate { get; set; }
    public LbonusCalendar CurrentMonth { get; set; }
    public LbonusCalendar NextMonth { get; set; }
    public GameItem GetItem { get; set; }
}

internal record TotalLoginInfo
{
    public int LoginCount { get; set; }
    public int RemainingCount { get; set; }
    public List<GameItem> Reward { get; set; }
}

internal record LbonusResponse
{
    public List<SheetInfo> Sheets { get; set; }
    public LbonusCalendarInfo CalendarInfo { get; set; }
    public TotalLoginInfo TotalLoginInfo { get; set; }
    public List<object> LicenseLbonusList { get; set; }
    public List<object> StartDashSheets { get; set; }
    public List<object> EffortPoint { get; set; }
    public List<object> LimitedEffortBox { get; set; }
}

[Endpoint("lbonus/execute", xCodeCheck: XCodeCheck.Special)]
internal class LbonusExecuteEndpoint(
    IActionContext context,
    ILoginBonusService loginBonusService,
    IRewardBox rewardBox) : Action<EmptyObject, LbonusResponse>
{
    public override async Task<LbonusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var currentDateTime = DateTimeUtils.GetServerTime();
        var currentDate = DateOnly.FromDateTime(currentDateTime);

        var calendar = new LbonusCalendarInfo
        {
            CurrentDate = currentDate.ToString("yyyy-MM-dd"),
            CurrentMonth = loginBonusService.GetCalendar(context.UserId, currentDate),
            NextMonth = loginBonusService.GetCalendar(context.UserId, currentDate.AddMonths(1)),
        };

        var sheets = loginBonusService.GetSheets(context.UserId, currentDateTime).ToList();

        if (loginBonusService.HasLoginBonus(context.UserId, currentDate))
        {
            var itemOfTheDay = calendar.CurrentMonth.Days[currentDate.Day - 1].Item;
            await rewardBox.AddAsync(context.UserId, itemOfTheDay, "stub");
            calendar.GetItem = itemOfTheDay;

            foreach (var sheet in sheets)
            {
                if (sheet.StampNum != sheet.NlbonusItemNum)
                {
                    sheet.GetItem = sheet.Items[sheet.StampNum].Reward;

                    await Task.WhenAll(sheet.GetItem.Select(item => rewardBox.AddAsync(context.UserId, item, "stub")));
                }
            }

            loginBonusService.MarkDay(context.UserId, currentDate);
        }

        var totalLogin = new TotalLoginInfo
        {
            LoginCount = loginBonusService.GetLoginCount(context.UserId),
            RemainingCount = int.MaxValue,
            Reward = [Item.ToGameItem(Item.Loveca(10000))]
        };
        
        var response = new LbonusResponse
        {
            Sheets = sheets,
            CalendarInfo = calendar,
            TotalLoginInfo = totalLogin,
            LicenseLbonusList = [],
            StartDashSheets = [],
            EffortPoint =
            [
                new
                {
                    LiveEffortPointBoxSpecId = 1,
                    Capacity = 1,
                    Before = 0,
                    After = 0
                }
            ],
            LimitedEffortBox = [],
        };

        return response;
    }
}