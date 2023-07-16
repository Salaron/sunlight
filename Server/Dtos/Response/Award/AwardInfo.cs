namespace SunLight.Dtos.Response.Award;

[Serializable]
public class AwardInfo
{
    public int AwardId { get; set; }
    public bool IsSet { get; set; }
    public DateTime InsertDate { get; set; }
}