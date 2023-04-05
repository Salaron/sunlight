namespace SunLight.Dtos.Request.User;

[Serializable]
public class ChangeNameRequest : ClientRequest
{
    public string Name { get; init; }
}