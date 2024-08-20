namespace Server.Common.Users;

public interface IUserService
{
    Task<UserInfo> CreateAsync(string login, string password);

    Task<UserInfo> GetAsync(int userId);

    Task<IReadOnlyList<UserNextLevelInfo>> AddExp(int userId, int amount);
}