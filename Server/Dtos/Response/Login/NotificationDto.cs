namespace SunLight.Dtos.Response.Login;

[Serializable]
public class NotificationDto
{
    public bool Push { get; set; }
    public bool Lp { get; set; }
    public bool UpdateInfo { get; set; }
    public bool Campaign { get; set; }
    public bool Live { get; set; }
    public bool Lbonus { get; set; }
    public bool Event { get; set; }
    public bool Secretbox { get; set; }
    public bool Birthday { get; set; }
}