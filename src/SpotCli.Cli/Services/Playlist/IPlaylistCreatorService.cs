namespace SpotCli.Cli.Services.Playlist;

public interface IPlaylistCreatorService
{
    public void SetTracklist(IList<ParsedTrack> tracklist);
    public void SetName(string name);
    public void SetId(string id);
}
