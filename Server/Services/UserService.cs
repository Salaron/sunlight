using Microsoft.EntityFrameworkCore;
using SunLight.Database.Server;

namespace SunLight.Services;

internal class UserService : IUserService
{
    private readonly ServerDbContext _dbContext;

    public UserService(ServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserInfoAsync(uint userId)
    {
        var userInfo = await _dbContext.Users.FirstAsync(user => user.UserId == userId);

        return userInfo;
    }
}