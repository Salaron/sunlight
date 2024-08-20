namespace Server.Common.Users;

public interface IInitialItemsUnlocker
{
    Task UnlockAsync(int userId);
}