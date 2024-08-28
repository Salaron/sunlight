namespace Server.Common.Config;

public record DownloadConfigSection
{
    public string? NppsDownloadApiUrl { get; init; }
    public string? NppsDownloadApiKey { get; init; }
}