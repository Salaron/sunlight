namespace Server.Common.Live;

public interface ILiveStatusProvider
{
    Task<IEnumerable<LiveStatusInfo>> GetNormalLiveStatusAsync(int userId);
    Task<IEnumerable<LiveStatusInfo>> GetSpecialLiveStatusAsync(int userId);
}