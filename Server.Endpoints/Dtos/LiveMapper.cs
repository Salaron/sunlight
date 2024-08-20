using Riok.Mapperly.Abstractions;
using Server.Common.Live;
using Server.Endpoints.Main.Live;

namespace Server.Endpoints.Dtos;

[Mapper]
internal partial class LiveMapper
{
    public partial LiveStatusDto LiveStatusInfoToDto(LiveStatusInfo liveStatusInfo);
}