using Server.Common.Items;
using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Common.Users;

internal class UserService(ServerContext serverContext, IUnlockedItemsProvider itemsProvider) : IUserService
{
    public async Task<UserInfo> CreateAsync(string login, string password)
    {
        var user = new User
        {
            LoginKey = login,
            LoginPasswd = password,
            UnitMax = 320,
            WaitingUnitMax = 300,
            EnergyFullTime = DateTime.UtcNow
        };
        user.NextExp = GetNextExp(user.Level);
        user.EnergyMax = GetMaxEnergy(user.Level);
        user.TrainingEnergyMax = GetMaxTrainingEnergy(user.Level);
        user.FriendMax = GetMaxFriends(user.Level);
        serverContext.Users.Add(user);
        await serverContext.SaveChangesAsync();

        return ConvertToUserInfo(user);
    }

    public async Task<UserInfo> GetAsync(int userId)
    {
        var user = await serverContext.Users.FindAsync(userId);
        if (user == null)
            throw new UserNotFoundException();

        return ConvertToUserInfo(user);
    }

    public async Task<IReadOnlyList<UserNextLevelInfo>> AddExp(int userId, int amount)
    {
        var user = await serverContext.Users.FindAsync(userId);
        if (user == null)
            throw new UserNotFoundException();

        var levelInfo = new List<UserNextLevelInfo>();
        user.Exp += amount;

        while (user.Exp >= user.NextExp)
        {
            user.PreviousExp += GetNextExp(user.Level);
            user.Level += 1;
            user.NextExp += GetNextExp(user.Level);
            user.EnergyMax = GetMaxEnergy(user.Level);
            levelInfo.Add(new UserNextLevelInfo(user.Level, user.NextExp));
        }

        if (levelInfo.Any())
        {
            user.FriendMax = GetMaxFriends(user.Level);
            user.TrainingEnergy = GetMaxTrainingEnergy(user.Level);
        }
        
        serverContext.Users.Update(user);
        await serverContext.SaveChangesAsync();

        return levelInfo;
    }

    public async Task SetAwardAsync(int userId, int awardId)
    {
        var user = await serverContext.Users.FindAsync(userId);
        if (user == null)
            throw new UserNotFoundException();

        var isUnlocked = await itemsProvider.IsItemUnlockedAsync(userId, AddType.Award, awardId);
        if (!isUnlocked)
            throw new Exception(); // TODO
        
        user.SettingAwardId = awardId;
        serverContext.Users.Update(user);
        await serverContext.SaveChangesAsync();
    }

    public async Task SetBackgroundAsync(int userId, int backgroundId)
    {
        var user = await serverContext.Users.FindAsync(userId);
        if (user == null)
            throw new UserNotFoundException();

        var isUnlocked = await itemsProvider.IsItemUnlockedAsync(userId, AddType.Background, backgroundId);
        if (!isUnlocked)
            throw new Exception(); // TODO
        
        user.SettingBackgroundId = backgroundId;
        serverContext.Users.Update(user);
        await serverContext.SaveChangesAsync();
    }

    private UserInfo ConvertToUserInfo(User user)
    {
        return new UserInfo
        {
            UserId = user.UserId,
            Name = user.Name,
            Level = user.Level,
            PreviousExp = user.PreviousExp,
            Exp = user.Exp,
            NextExp = user.NextExp,
            GameCoin = user.GameCoin,
            SnsCoin = user.FreeSnsCoin + user.PaidSnsCoin,
            FreeSnsCoin = user.FreeSnsCoin,
            PaidSnsCoin = user.PaidSnsCoin,
            SocialPoint = user.SocialPoint,
            UnitMax = user.UnitMax,
            WaitingUnitMax = user.WaitingUnitMax,
            EnergyMax = user.EnergyMax,
            EnergyFullTime = user.EnergyFullTime,
            LicenseLiveEnergyRecoverlyTime = 0,
            EnergyFullNeedTime = 0,
            OverMaxEnergy = user.OverMaxEnergy,
            TrainingEnergy = user.TrainingEnergy,
            TrainingEnergyMax = user.TrainingEnergyMax,
            FriendMax = user.FriendMax,
            InviteCode = user.InviteCode,
            TutorialState = user.TutorialState,
            LpRecoveryItem = [],
            Birthday = user.Birthday,
            SettingAwardId = user.SettingAwardId,
            SettingBackgroundId = user.SettingBackgroundId
        };
    }

    // the following formulas are taken from NPPS4 by AuahDark
    private int GetNextExp(int level)
    {
        var exp = 0d;
        if (level <= 1)
            exp = 11d;
        else if (level < 34)
            exp = Math.Round(GetNextExp(level - 1) + 34.45 * level / 33d, MidpointRounding.AwayFromZero);
        else
            exp = Math.Round(34.45d * level - 551, MidpointRounding.AwayFromZero);

        if (level < 100)
            return (int)Math.Round(exp / 2d, MidpointRounding.AwayFromZero);

        return (int)exp;
    }

    private int GetMaxEnergy(int level)
    {
        var a = Math.Min(300, level) / 2 + 25;
        var b = Math.Max(level - 300, 0) / 3;
        return a + b;
    }

    private int GetMaxFriends(int level)
    {
        var a = 10 + Math.Min(50, level) / 5;
        var b = Math.Max(level - 50, 0) / 10;
        return a + b;
    }

    private int GetMaxTrainingEnergy(int level)
    {
        var a = 3 + Math.Min(200, level) / 50;
        var b = Math.Max(level - 200, 0) / 100;
        return a + b;
    }
}