namespace SunLight.Dtos.Request.User;

[Serializable]
public class ChangeNameRequest : BaseRequest
{
    public string Name { get; init; }
}