namespace SunLight;

public static class DateTimeUtils
{
    public static long CurrentUnixTimeStamp()
    {
        return DateTimeOffset.Now.ToUnixTimeSeconds();
    }
}