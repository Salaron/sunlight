namespace SunLight.Dtos.Response.Background;

[Serializable]
public class BackgroundInfo
{
    public int BackgroundId { get; set; }
    public bool IsSet { get; set; }
    public DateTime InsertDate { get; set; }
}