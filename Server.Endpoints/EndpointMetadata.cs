using Server.Common;

namespace Server.Endpoints;

// used in generated code
internal record EndpointMetadata(
    string Path,
    bool UsedInApi,
    bool IgnoreVersion,
    XCodeCheck XCodeCheck,
    bool RequireAuthorization);