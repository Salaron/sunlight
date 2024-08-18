using Server.Common;
using Server.Common.Download;

namespace Server.Endpoints.Main.Download;

[Endpoint("download/event")]
internal class DownloadEvent: Action<EmptyObject, IEnumerable<DownloadPackageInfo>>
{
    public override Task<IEnumerable<DownloadPackageInfo>> ExecuteAsync(EmptyObject requestBody)
    {
        return Task.FromResult(Enumerable.Empty<DownloadPackageInfo>());
    }
}