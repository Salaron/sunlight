using Server.Common;

namespace Server.Endpoints;

internal class EndpointAttribute : Attribute
{
    public EndpointAttribute(string path,
        bool usedInApi = false,
        bool ignoreVersion = false,
        bool requireAuthorization = true,
        bool directResponse = false,
        XCodeCheck xCodeCheck = XCodeCheck.Enabled)
    {
    }
}