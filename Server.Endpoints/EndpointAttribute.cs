using Server.Common;

namespace Server.Endpoints;

internal class EndpointAttribute : Attribute
{
    public EndpointAttribute(string path,
        bool usedInApi = false,
        bool ignoreVersion = false,
        XCodeCheck xCodeCheck = XCodeCheck.Enabled)
    {
    }
}