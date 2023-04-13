using System.ComponentModel.DataAnnotations;

namespace SunLight.Dtos.Request.Live;

[Serializable]
public class PartyListRequest : ClientRequest
{
    public bool IsTraining { get; init; }

    [Range(minimum: 1, maximum: 4)]
    public int LpFactor { get; init; }

    public string LiveDifficultyId { get; init; }
}