namespace SunLight.Dtos.Response.User;

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