namespace SunLight.Dtos.Request.Tutorial;

public class TutorialProgressRequest : ClientRequest
{
    public int TutorialState { get; init; }
}