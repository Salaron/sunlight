using Server.Common;
using Server.Common.Items;
using Server.Common.Lbonus;
using Server.Common.Users;

namespace Server.Endpoints.Handlers.Lbonus;

public record SheetReward(int Seq, List<GameItem> Reward);

internal record LbonusSheet
{
    public int NlbonusItemNum { get; init; }
    public string DetailText { get; init; }
    public string BgAsset { get; init; }
    public bool ShowNextItem { get; init; }
    public List<SheetReward> Items { get; init; }
    public int StampNum { get; init; }
    public List<GameItem> GetItem { get; set; }
}

internal record LbonusCalendarInfo
{
    public string CurrentDate { get; set; }
    public MonthInfo CurrentMonth { get; set; }
    public MonthInfo NextMonth { get; set; }
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
    public List<object> Sheets { get; set; }
    public LbonusCalendarInfo CalendarInfo { get; set; }
    public TotalLoginInfo TotalLoginInfo { get; set; }
    public List<object> LicenseLbonusList { get; set; }
    public List<object> StartDashSheets { get; set; }
    public List<object> EffortPoint { get; set; }
    public List<object> LimitedEffortBox { get; set; }
}

[Endpoint("lbonus/execute", xCodeCheck: XCodeCheck.Special)]
internal class LbonusExecuteEndpoint(IActionContext context, ILoginBonusService loginBonusService, ItemManager itemManager) : Action<EmptyObject, LbonusResponse>
{
    public override async Task<LbonusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var currentDate = DateOnly.FromDateTime(DateTimeUtils.GetServerTime());

        var calendar = new LbonusCalendarInfo
        {
            CurrentDate = currentDate.ToString("yyyy-MM-dd"),
            CurrentMonth = loginBonusService.GetCalendar(context.UserId, currentDate),
            NextMonth = loginBonusService.GetCalendar(context.UserId, currentDate.AddMonths(1)),
        };

        if (loginBonusService.HasLoginBonus(context.UserId, currentDate))
        {
            var item = calendar.CurrentMonth.Days[currentDate.Day - 1].Item;
            await itemManager.AddAsync(context.UserId, Item.FromGameItem(item));
            calendar.GetItem = item;
            
            // TODO...
        }

        var totalLogin = new TotalLoginInfo
        {
            LoginCount = loginBonusService.GetLoginCount(context.UserId),
            RemainingCount = int.MaxValue,
            Reward = [Item.ToGameItem(Item.Loveca(10000))]
        };
        
        var response = new LbonusResponse
        {
            Sheets = [],
            CalendarInfo = calendar,
            TotalLoginInfo = totalLogin,
            LicenseLbonusList = [],
            StartDashSheets = [],
            EffortPoint = [
            new
            {
                LiveEffortPointBoxSpecId = 1,
                Capacity = 1,
                Before = 0,
                After = 0
            }],
            LimitedEffortBox = [],
        };

        return response;
    }
}