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

    public async Task ChangeNameAsync(uint userId, string newName)
    {
        var userInfo = await _dbContext.Users.FirstAsync(user => user.UserId == userId);

        userInfo.Name = newName;
        _dbContext.Update(userInfo);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateTutorialStateAsync(uint userId, int state)
    {
        var userInfo = await _dbContext.Users.FirstAsync(user => user.UserId == userId);

        userInfo.TutorialState = state;
        _dbContext.Update(userInfo);
        await _dbContext.SaveChangesAsync();
    }
}