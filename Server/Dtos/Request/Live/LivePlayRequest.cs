using System.ComponentModel.DataAnnotations;

namespace SunLight.Dtos.Request.Live;

[Serializable]
public class LivePlayRequest : ClientRequest
{
    public int PartyUserId { get; set; }
    public bool IsTraining { get; set; }
    public int UnitDeckId { get; set; }
    public string LiveDifficultyId { get; set; }

    [Range(1, 4)]
    public int LpFactor { get; set; }
}