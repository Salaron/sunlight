namespace SunLight.Dtos.Response.Unit;

[Serializable]
public class AccessoryAllResponse
{
    public IEnumerable<object> AccessoryList { get; set; }
    public IEnumerable<object> WearingInfo { get; set; }
    public bool EspecialCreateFlag { get; set; }
}