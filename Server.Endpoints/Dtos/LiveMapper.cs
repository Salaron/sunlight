using Riok.Mapperly.Abstractions;
using Server.Common.Live;
using Server.Endpoints.Handlers.Live;

namespace Server.Endpoints.Dtos;

[Mapper]
internal partial class LiveMapper
{
    public partial LiveStatusDto LiveStatusInfoToDto(LiveStatusInfo liveStatusInfo);
}
