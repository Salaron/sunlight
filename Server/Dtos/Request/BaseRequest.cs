namespace SunLight.Dtos;

public class BaseRequest
{
    public string Module { get; set; }
    public string Action { get; set; }
    public long TimeStamp { get; set; }
    public GameMode Mgd { get; set; }
    public string CommandNum { get; set; } // loginKey.timeStamp.nonce
}

public enum GameMode
{
    Muse = 1,
    Aqours = 2
}