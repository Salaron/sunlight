namespace SunLight.Dtos.Response.Subscenario;

[Serializable]
public class SubscenarioStatusResponse
{
    public IEnumerable<SubscenarioStatusItem> SubscenarioStatusList { get; set; }
    public IEnumerable<int> UnlockedSubscenarioIds { get; set; }
}