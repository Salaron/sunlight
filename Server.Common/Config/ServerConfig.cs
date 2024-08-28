namespace Server.Common.Config;

public record ServerConfig
{
    public required string ServerVersion { get; init; }
    public required string ClientAppVersion { get; init; }
    public bool CheckXMessageCode { get; init; }
    public required string ApplicationKey { get; init; }
    public required string Xorpad { get; init; }
    public required string RsaPrivateKey { get; init; }
    public required List<ReleaseInfo> ReleaseInfo { get; init; } = [];
    public required MaintenanceConfigSection Maintenance { get; init; }
    public required DownloadConfigSection Download { get; init; }
    public required LoginBonusConfigSection LoginBonus { get; init; }
}