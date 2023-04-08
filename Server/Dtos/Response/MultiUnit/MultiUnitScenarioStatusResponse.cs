namespace SunLight.Dtos.Response.MultiUnit;

[Serializable]
public class MultiUnitScenarioStatusResponse
{
    public IEnumerable<MultiUnitScenarioItem> MultiUnitScenarioStatusList { get; set; }
}