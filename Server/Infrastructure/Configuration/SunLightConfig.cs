namespace SunLight.Infrastructure.Configuration;

public class SunLightConfig
{
    public ServerConfig Server { get; set; }
    public DownloadConfig Download { get; set; }
    public AwardConfig Award { get; set; }
    public BackgroundConfig Background { get; set; }
    public LiveConfig Live { get; set; }
    public UnitConfig Unit { get; set; }
}