namespace SunLight.Dtos.Response.MultiUnit;

[Serializable]
public class MultiUnitScenarioItem
{
    public int MultiUnitId { get; set; }
    public int Status { get; set; }
    public string MultiUnitScenarioBtnAsset { get; set; }
    public DateTime OpenDate { get; set; }
    public IEnumerable<MultiUnitScenarioChapter> ChapterList { get; set; }
}