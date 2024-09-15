using Server.Database.Server;

namespace Server.Common.Items;

public interface IRewardBox
{
    Task<int> GetTotalAsync(int userId);
    Task<IReadOnlyList<RewardBoxItem>> GetAsync(int userId, RewardBoxFilter filter);
    Task AddAsync(int userId, GameItem item, string message, DateTime? expireDate = null, bool autoOpen = false);
    Task<RewardItem> OpenAsync(int userId, int rewardBoxItemId);
}