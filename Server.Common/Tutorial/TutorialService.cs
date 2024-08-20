using Server.Common.Items;
using Server.Common.Users;
using Server.Database.Enums;
using Server.Database.Server;

namespace Server.Common.Tutorial;

internal class TutorialService(
    ServerContext serverContext,
    IUserService userService,
    ItemManager itemManager,
    IInitialItemsUnlocker initialItemsUnlocker) : ITutorialService
{
    public async Task ProcessStateAsync(int userId, TutorialState nextState)
    {
        var user = await serverContext.Users.FindAsync(userId);
        if (user.TutorialState == TutorialState.End)
            throw new TutorialInvalidStateException();

        if (user.TutorialState == TutorialState.Start && nextState == TutorialState.ChooseCenterUnit)
            user.TutorialState = nextState;
        else if (user.TutorialState == TutorialState.ChooseCenterUnit && nextState == TutorialState.Live)
            user.TutorialState = nextState;
        else if (user.TutorialState == TutorialState.Live && nextState == TutorialState.Top)
        {
            await itemManager.AddAsync(userId, Item.GameCoin(36400));
            await itemManager.AddAsync(userId, Item.SocialPoint(5));
            await itemManager.AddAsync(userId, Item.PlayerExp(11));
            user.TutorialState = nextState;
        }
        else if (user.TutorialState == TutorialState.Top && nextState == TutorialState.End)
        {
            await initialItemsUnlocker.UnlockAsync(userId);
            await userService.SetAwardAsync(userId, 1);
            await userService.SetBackgroundAsync(userId, 1);

            user.TutorialState = nextState;
        }
        else
            throw new TutorialInvalidStateException();

        serverContext.Update(user);
        await serverContext.SaveChangesAsync();
    }

    public async Task SkipAsync(int userId)
    {
        var user = await serverContext.Users.FindAsync(userId);
        if (user.TutorialState == TutorialState.End)
            throw new TutorialInvalidStateException();

        if (user.TutorialState < TutorialState.ChooseCenterUnit)
            await ProcessStateAsync(userId, TutorialState.ChooseCenterUnit);
        if (user.TutorialState < TutorialState.Live)
            await ProcessStateAsync(userId, TutorialState.Live);

        if (user.TutorialState < TutorialState.Top)
            await ProcessStateAsync(userId, TutorialState.Top);

        await ProcessStateAsync(userId, TutorialState.End);
    }
}