namespace SpotCli.Cli.Search.SearchForItem;

public class TrackNotFoundException : Exception
{
    public TrackNotFoundException() : base("Search query unsuccessful, no track found.")
    {
    }
}
