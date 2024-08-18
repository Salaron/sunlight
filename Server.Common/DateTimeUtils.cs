namespace Server.Common;

public static class DateTimeUtils
{
    public static long CurrentUnixTimeStamp()
    {
        return DateTimeOffset.Now.ToUnixTimeSeconds();
    }

    public static DateTime GetServerTime()
    {
        return DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(9)).DateTime;
    }
}