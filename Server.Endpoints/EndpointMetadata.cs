using Server.Common;

namespace Server.Endpoints;

// used in generated code
internal class EndpointMetadata(
    string path,
    bool usedInApi,
    bool ignoreVersion,
    XCodeCheck xCodeCheck,
    bool requireAuthorization,
    bool directResponse)
{
    public string Path => path;
    public bool UsedInApi => usedInApi;
    public XCodeCheck XCodeCheck => xCodeCheck;
    public bool IgnoreVersion => ignoreVersion;
    public bool RequireAuthorization => requireAuthorization;
    public bool DirectResponse => directResponse;
}