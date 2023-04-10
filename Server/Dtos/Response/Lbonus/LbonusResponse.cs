using SunLight.Dtos.Response.Class;
using SunLight.Dtos.Response.Museum;

namespace SunLight.Dtos.Response.Lbonus;

[Serializable]
public class LbonusResponse
{
    public IEnumerable<object> Sheets { get; set; }
    public LbonusCalendarInfo CalendarInfo { get; set; }
    public object AdInfo { get; set; }
    public TotalLoginInfo TotalLoginInfo { get; set; }
    public IEnumerable<object> LicenseLbonusList { get; set; }
    public ClassSystemResponse ClassSystem { get; set; }
    public IEnumerable<object> StartDashSheets { get; set; }
    public IEnumerable<object> EffortPoint { get; set; }
    public IEnumerable<object> LimitedEffortBox { get; set; }
    public MuseumInfoResponse MuseumInfo { get; set; }
}