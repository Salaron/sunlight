namespace SunLight.Dtos.Request;

[Serializable]
public class ClientRequest
{
    public string Module { get; init; }
    public string Action { get; init; }
    public long TimeStamp { get; init; }
    public GameMode Mgd { get; init; }
    public string CommandNum { get; init; } // loginKey.timeStamp.nonce
}

public enum GameMode
{
    Muse = 1,
    Aqours = 2
}