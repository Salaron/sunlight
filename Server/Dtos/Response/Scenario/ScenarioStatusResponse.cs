namespace SunLight.Dtos.Response.Scenario;

[Serializable]
public class ScenarioStatusResponse
{
    public IEnumerable<ScenarioStatusItem> ScenarioStatusList { get; set; }
}