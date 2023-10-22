using Microsoft.EntityFrameworkCore;
using SunLight.Infrastructure.Database.Server;

namespace SunLight.Modules.UserModule;

internal class UserService : IUserService
{
    private readonly ServerDbContext _dbContext;

    public UserService(ServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Infrastructure.Database.Server.User> GetUserInfoAsync(int userId)
    {
        var userInfo = await _dbContext.Users
            .Include(user => user.PartnerUnit)
            .FirstAsync(user => user.UserId == userId);

        return userInfo;
    }

    public async Task ChangeNameAsync(int userId, string newName)
    {
        var userInfo = await _dbContext.Users.FirstAsync(user => user.UserId == userId);

        userInfo.Name = newName;
        _dbContext.Update(userInfo);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateTutorialStateAsync(int userId, int state)
    {
        var userInfo = await _dbContext.Users.FirstAsync(user => user.UserId == userId);
        userInfo.TutorialState = state;
        _dbContext.Update(userInfo);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Infrastructure.Database.Server.User> CreateUserAsync(string loginKey, string password)
    {
        var newUser = new Infrastructure.Database.Server.User
        {
            Name = "New Comer",
            Level = 1,
            LoginKey = loginKey,
            LoginPasswd = password,
            SettingAwardId = 1,
            SettingBackgroundId = 1
        };

        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();

        return newUser;
    }

    public async Task SetPartnerUnitAsync(int userId, int unitOwningUserId)
    {
        var user = await _dbContext.Users.FirstAsync(u => u.UserId == userId);
        user.PartnerUnitId = unitOwningUserId;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SetMainDeckAsync(int userId, int unitDeckId)
    {
        var user = await _dbContext.Users.FirstAsync(u => u.UserId == userId);
        user.MainUnitDeckId = unitDeckId;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
}