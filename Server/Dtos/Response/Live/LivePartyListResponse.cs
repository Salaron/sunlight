namespace SunLight.Dtos.Response.Live;

[Serializable]
public class LivePartyListResponse
{
    public object LiveInfo { get; set; } // not used?
    public bool HasSlideNotes { get; set; }
    public IEnumerable<BasicUserInfo> PartyList { get; set; }
    public int TrainingEnergy { get; set; }
    public int TrainingEnergyMax { get; set; }
}