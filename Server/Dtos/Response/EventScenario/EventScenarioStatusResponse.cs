namespace SunLight.Dtos.Response.EventScenario;

[Serializable]
public class EventScenarioStatusResponse
{
    public IEnumerable<object> EventScenarioList { get; set; }
}