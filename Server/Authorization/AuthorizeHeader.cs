using System.Web;

namespace SunLight.Authorization;

public class AuthorizeHeader
{
    public string ConsumerKey = "lovelive_test";
    public string Version = "1.1";
    public uint Nonce = 1;
    public uint RequestTimestamp = 1234;
    public uint TimeStamp = 12345;


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