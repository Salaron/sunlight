namespace Server.Common.Live;

public record LiveInfoWithDeck
{
    public LiveShow LiveInfo { get; set; }
    public LiveShowDeckInfo DeckInfo { get; set; }
}