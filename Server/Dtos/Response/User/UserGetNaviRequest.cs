namespace SunLight.Dtos.Response;

[Serializable]
public class UserGetNaviRequest
{
    public record UserNavi
    {
        public int UserId { get; set; }
        public int UnitOwningUserId { get; set; }
    }
    
    public UserNavi User { get; set; }
}