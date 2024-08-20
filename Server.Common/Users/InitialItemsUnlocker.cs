using Server.Common.Items;
using Server.Database.Game;

namespace Server.Common.Users;

internal class InitialItemsUnlocker(LiveContext liveContext, ItemManager itemManager) : IInitialItemsUnlocker
{
    public async Task UnlockAsync(int userId)
    {
        await itemManager.AddAsync(userId, Item.Award(1));
        await itemManager.AddAsync(userId, Item.Award(23));
        await itemManager.AddAsync(userId, Item.Background(1));

        var normalLivesToUnlock = liveContext.NormalLiveM.Where(live => live.DefaultUnlockedFlag == 1);
        foreach (var normalLive in normalLivesToUnlock)
            await itemManager.AddAsync(userId, Item.Live(normalLive.LiveDifficultyId));
    }
}