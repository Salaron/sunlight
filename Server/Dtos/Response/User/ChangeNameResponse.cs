namespace SunLight.Dtos.Response.User;

[Serializable]
public class ChangeNameResponse
{
    public string BeforeName { get; set; }
    public string AfterName { get; set; }
}