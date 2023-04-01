using System.Web;

namespace SunLight.Authorization;

public class AuthorizeHeader
{
    public string ConsumerKey = "lovelive_test";
    public string Version = "1.1";
    public uint Nonce = 1;
    public uint RequestTimestamp = 1234;
    public uint TimeStamp = 12345;
    public Guid Token;

    public static AuthorizeHeader FromString(string authorizeHeader)
    {
        var instance = new AuthorizeHeader();
        var values = HttpUtility.ParseQueryString(authorizeHeader);

        instance.ConsumerKey = values.Get("consumerKey");
        instance.Version = values.Get("version");
        instance.Nonce = Convert.ToUInt32(values.Get("nonce"));
        instance.TimeStamp = Convert.ToUInt32(values.Get("timeStamp"));
        instance.Token = Guid.Parse(values.Get("token") ?? Guid.Empty.ToString());

        return instance;
    }

    public override string ToString()
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        queryString.Add("consumerKey", ConsumerKey);
        queryString.Add("version", Version);
        queryString.Add("nonce", Nonce.ToString());
        queryString.Add("requestTimestamp", RequestTimestamp.ToString());
        queryString.Add("timeStamp", TimeStamp.ToString());

        return queryString.ToString();
    }
}