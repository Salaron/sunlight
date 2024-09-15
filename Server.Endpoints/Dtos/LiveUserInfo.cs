namespace Server.Endpoints.Dtos;

public record LiveUserInfo
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
}