using SunLight.Dtos.Response;

namespace SunLight.Infrastructure.Configuration;

public class ServerConfig
{
    public string ServerVersion { get; init; }
    public bool XMessageCodeVerificationEnabled { get; init; }
    public string RsaPrivateKey { get; init; }
    public ReleaseInfo[] ReleaseInfoKeys { get; init; }
}