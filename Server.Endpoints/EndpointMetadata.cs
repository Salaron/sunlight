using Server.Common;

namespace Server.Endpoints;

// used in generated code
internal class EndpointMetadata(string path, bool usedInApi, bool ignoreVersion, XCodeCheck xCodeCheck)
{
    public string Path => path;
    public bool UsedInApi => usedInApi;
    public XCodeCheck XCodeCheck => xCodeCheck;
    public bool IgnoreVersion => ignoreVersion;
}
