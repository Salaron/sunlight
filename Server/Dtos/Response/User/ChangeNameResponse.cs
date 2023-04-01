namespace SunLight.Dtos.Response.User;

[Serializable]
public class ChangeNameResponse : BaseResponse
{
    public string BeforeName { get; set; }
    public string AfterName { get; set; }
}