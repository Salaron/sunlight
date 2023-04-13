using SunLight.Dtos.Response.Unit;
using SunLight.Dtos.Response.User;

namespace SunLight.Dtos.Response.Live;

[Serializable]
public class LivePartyListResponse
{
    [Serializable]
    public record PartyListItem
    {
        public UserInfoStripped UserInfo { get; set; }
        public UnitInfoStripped CenterUnitInfo { get; set; }
        public int SettingAwardId { get; set; }
        public int AvailableSocialPoint { get; set; }
        public int FriendStatus { get; set; }
    }
    
    public object LiveInfo { get; set; } // not used?
    public bool HasSlideNotes { get; set; }
    public IEnumerable<PartyListItem> PartyList { get; set; }
    public int TrainingEnergy { get; set; }
    public int TrainingEnergyMax { get; set; }
}