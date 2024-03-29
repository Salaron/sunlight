﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;
using SunLight.Dtos.Response.Lbonus;
using SunLight.Dtos.Response.Museum;
using SunLight.Infrastructure.Authorization;

namespace SunLight.Modules.Lbonus;

[Authorize]
[ApiController]
[XMessageCodeCheck(specialApi: true)]
[Route("main.php/lbonus")]
public class LbonusController : LlsifController
{
    [HttpPost("execute")]
    [Produces(typeof(ServerResponse<LbonusResponse>))]
    public async Task<IActionResult> Execute([FromBody] ClientRequest requestData)
    {
        var dateNow = DateTimeUtils.GetServerTime();
        var dateTomorrow = DateTime.Now + TimeSpan.FromDays(1);

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
                    Item = new List<Dtos.Response.Lbonus.Item>
                    {
                        new Dtos.Response.Lbonus.Item
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
                    Item = new List<Dtos.Response.Lbonus.Item>
                    {
                        new Dtos.Response.Lbonus.Item
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
            Reward = new List<Dtos.Response.Lbonus.Item>
            {
                new Dtos.Response.Lbonus.Item
                {
                    UnitId = 1995,
                    AddType = 1001,
                    Amount = 1
                }
            }
        };

        var response = new LbonusResponse
        {
            Sheets = Enumerable.Empty<object>(),
            CalendarInfo = calendar,
            AdInfo = null,
            TotalLoginInfo = totalLogin,
            LicenseLbonusList = Enumerable.Empty<object>(),
            ClassSystem = null,
            StartDashSheets = Enumerable.Empty<object>(),
            EffortPoint = Enumerable.Empty<object>(),
            LimitedEffortBox = Enumerable.Empty<object>(),
            MuseumInfo = new MuseumInfoResponse.MuseumInfoParams()
            {
                Parameter = new MuseumInfoStats(),
                ContentsIdList = Enumerable.Empty<int>()
            }
        };

        return SendResponse(response);
    }
}