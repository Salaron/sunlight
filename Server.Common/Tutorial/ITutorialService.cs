using Server.Database.Enums;

namespace Server.Common.Tutorial;

public interface ITutorialService
{
    Task ProcessStateAsync(int userId, TutorialState nextState);
    Task SkipAsync(int userId);
}