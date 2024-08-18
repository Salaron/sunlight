using Microsoft.EntityFrameworkCore;
using Server.Common;
using Server.Common.Items;
using Server.Common.Login;
using Server.Database.Server;
using Server.Endpoints.Main.Login;
using Server.Endpoints.Main.Museum;

namespace Server.Endpoints.Main.Lbonus;

internal record Item_
{
    public int UnitId { get; set; }
    public int AddType { get; set; }
    public int Amount { get; set; }
    public bool IsRankMax { get; set; }
    public bool IsSigned { get; set; }
}

internal record LbonusCalendarInfo
{
    public record MonthInfo
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public IEnumerable<DayInfo> Days { get; set; }
    }

    public record DayInfo
    {
        public int Day { get; set; }
        public int DayOfTheWeek { get; set; }
        public bool SpecialDay { get; set; }
        public string SpecialImageAsset { get; set; }
        public bool Received { get; set; }
        public bool AdReceived { get; set; }
        public IEnumerable<Item_> Item { get; set; }
    }

    public string CurrentDate { get; set; } // YYYY.MM.dd
    public MonthInfo CurrentMonth { get; set; }
    public MonthInfo NextMonth { get; set; }
}

internal record TotalLoginInfo
{
    public int LoginCount { get; set; }
    public int RemainingCount { get; set; }
    public IEnumerable<Item_> Reward { get; set; }
}

internal record LbonusResponse
{
    public List<object> Sheets { get; set; }
    public LbonusCalendarInfo CalendarInfo { get; set; }
    public object AdInfo { get; set; }
    public TotalLoginInfo TotalLoginInfo { get; set; }
    public List<object> LicenseLbonusList { get; set; }
    public object ClassSystem { get; set; }
    public List<object> StartDashSheets { get; set; }
    public List<object> EffortPoint { get; set; }
    public List<object> LimitedEffortBox { get; set; }
    public MuseumInfo MuseumInfo { get; set; }
}

[Endpoint("lbonus/execute", xCodeCheck: XCodeCheck.Special)]
internal class LbonusExecuteEndpoint : Action<EmptyObject, LbonusResponse>
{
    public override async Task<LbonusResponse> ExecuteAsync(EmptyObject requestBody)
    {
        var dateNow = DateTimeUtils.GetServerTime();
        var dateTomorrow = DateTime.UtcNow + TimeSpan.FromDays(1);

        var currentMonth = new LbonusCalendarInfo.MonthInfo
        {
            Year = dateNow.Year,
            Month = dateNow.Month,
            Days = Enumerable.Range(1, DateTime.DaysInMonth(dateNow.Year, dateNow.Month)).Select(day =>
                new LbonusCalendarInfo.DayInfo
                {
                    Day = day,
                    DayOfTheWeek = (int)(new DateTime(dateNow.Year, dateNow.Month, day).DayOfWeek),
                    SpecialDay = false,
                    SpecialImageAsset = "",
                    Received = false,
                    AdReceived = false,
                    Item = new List<Item_>
                    {
                        new Item_()
                        {
                            UnitId = 1995,
                            AddType = 1001,
                            Amount = 1
                        }
                    }
                })
        };
        
        var nextMonth = new LbonusCalendarInfo.MonthInfo
        {
            Year = dateNow.Year,
            Month = dateNow.Month + 1,
            Days = Enumerable.Range(1, DateTime.DaysInMonth(dateTomorrow.Year, dateNow.Month + 1)).Select(day =>
                new LbonusCalendarInfo.DayInfo
                {
                    Day = day,
                    DayOfTheWeek = (int)(new DateTime(dateNow.Year, dateNow.Month + 1, day).DayOfWeek),
                    SpecialDay = false,
                    SpecialImageAsset = "",
                    Received = false,
                    AdReceived = false,
                    Item = new List<Item_>
                    {
                        new Item_()
                        {
                            UnitId = 1995,
                            AddType = 1001,
                            Amount = 1
                        }
                    }
                })
        };

        var calendar = new LbonusCalendarInfo
        {
            CurrentDate = dateNow.ToString("yyyy.MM.dd"),
            CurrentMonth = currentMonth,
            NextMonth = nextMonth
        };

        var totalLogin = new TotalLoginInfo
        {
            LoginCount = 1,
            RemainingCount = 999,
            Reward = new List<Item_>
            {
                new Item_
                {
                    UnitId = 1995,
                    AddType = 1001,
                    Amount = 1
                }
            }
        };

        var response = new LbonusResponse
        {
            Sheets = [],
            CalendarInfo = calendar,
            AdInfo = null,
            TotalLoginInfo = totalLogin,
            LicenseLbonusList = [],
            ClassSystem = null,
            StartDashSheets = [],
            EffortPoint = [],
            LimitedEffortBox = [],
            MuseumInfo = new MuseumInfo(new MuseumStats(0, 0, 0), [])
        };

        return response;
    }
}