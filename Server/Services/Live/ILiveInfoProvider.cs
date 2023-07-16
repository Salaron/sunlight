namespace SunLight.Services.Live;

public interface ILiveInfoProvider
{
    Task<LiveDifficultyInfo> GetLiveDifficultyInfoAsync(int liveDifficultyId);
}