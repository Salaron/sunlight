namespace Server.Common.Download;

public static class PlatformHelper
{
    public static Platform GetPlatformId(string os) => os switch
    {
        "Android" => Platform.Android,
        "iOS" => Platform.iOS,
        _ => throw new ArgumentOutOfRangeException(nameof(os), os, null)
    };
}