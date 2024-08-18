using System.Globalization;
using System.Web;

namespace Server.Common;

public class AuthorizeHeader
{
    private const string DefaultConsumerKey = "lovelive_test";
    private const string DefaultVersion = "1.1";

    public static AuthorizeHeader FromString(string authorizeHeader)
    {
        var instance = new AuthorizeHeader();
        var values = HttpUtility.ParseQueryString(authorizeHeader);

        instance.ConsumerKey = values.Get("consumerKey") ?? DefaultConsumerKey;
        instance.Version = values.Get("version") ?? DefaultVersion;
        instance.Nonce = Convert.ToUInt32(values.Get("nonce"));
        instance.TimeStamp = DateTimeOffset.FromUnixTimeSeconds(Convert.ToUInt32(values.Get("timeStamp"))).UtcDateTime;
        instance.Token = values.Get("token") ?? string.Empty;

        return instance;
    }

    public string ConsumerKey { get; set; }
    public string Version { get; set; }
    public uint Nonce { get; set; }
    public DateTime TimeStamp { get; set; }
    public DateTime RequestTimestamp { get; set; }
    public string Token { get; set; }

    public override string ToString()
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        queryString.Add("consumerKey", ConsumerKey);
        queryString.Add("version", Version);
        queryString.Add("nonce", Nonce.ToString());
        queryString.Add("requestTimestamp", RequestTimestamp.ToString(CultureInfo.InvariantCulture));
        queryString.Add("timeStamp", TimeStamp.ToString(CultureInfo.InvariantCulture));

        return queryString.ToString();
    }
}