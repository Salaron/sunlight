namespace SunLight.Dtos.Response.Tos;

[Serializable]
public class TosCheckResponse
{
    public uint TosId { get; set; }
    public uint TosType { get; set; }
    public bool IsAgreed { get; set; }
}