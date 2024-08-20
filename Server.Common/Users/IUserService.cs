namespace Server.Common.Users;

public interface IUserService
{
    Task<UserInfo> CreateAsync(string login, string password);

    Task<UserInfo> GetAsync(int userId);

    Task<IReadOnlyList<UserNextLevelInfo>> AddExp(int userId, int amount);

    Task SetAwardAsync(int userId, int awardId);

    Task SetBackgroundAsync(int userId, int backgroundId);
}