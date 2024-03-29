﻿using SunLight.Infrastructure.Database.Server;

namespace SunLight.Modules.UserModule;

public interface IUserService
{
    Task<User> CreateUserAsync(string login, string password);

    Task<User> GetUserInfoAsync(int userId);

    Task ChangeNameAsync(int userId, string newName);

    Task UpdateTutorialStateAsync(int userId, int state);

    Task SetPartnerUnitAsync(int userId, int unitOwningUserId);

    Task SetMainDeckAsync(int userId, int unitDeckId);
}