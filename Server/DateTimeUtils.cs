namespace SunLight;

public static class DateTimeUtils
{
    public static long CurrentUnixTimeStamp()
    {
        return DateTimeOffset.Now.ToUnixTimeSeconds();
    }

    public static DateTime GetServerTime()
    {
        var japaneseTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
        var japaneseTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, japaneseTimeZone);
        return japaneseTime;
    }

    public static DateTime ToServerTime(this DateTime dateTime)
    {
        var japaneseTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
        var japaneseTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, japaneseTimeZone);
        return japaneseTime;
    }
}