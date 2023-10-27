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

    public async Task<User> CreateUserAsync(string loginKey, string password)
    {
        var newUser = new User
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

    public async Task<User> GetUserAsync(int userId)
    {
        var userInfo = await _dbContext.Users
            .Include(user => user.PartnerUnit)
            .FirstAsync(user => user.UserId == userId);

        return userInfo;
    }

    public async Task UpdateUserAsync(User user)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();
    }
}