namespace Server.Common.Config;

public class ServerConfig
{
    public string ServerVersion { get; init; }
    public bool CheckXMessageCode { get; init; }
    public string ApplicationKey { get; init; }
    public string Xorpad { get; init; }
    public string RsaPrivateKey { get; init; }
    public ReleaseInfo[] ReleaseInfo { get; init; }
    
    // TODO
    public string ClientVersion { get; init; }
    public bool Maintenance { get; init; }
    
    public DownloadConfig Download { get; init; }
}