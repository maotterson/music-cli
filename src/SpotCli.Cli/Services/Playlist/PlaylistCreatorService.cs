namespace SpotCli.Cli.Services.Playlist;

public class PlaylistCreatorService
{
    private IList<ParsedTrack>? _tracklist;
    private string? _playlistName;
    private string? _playlistId;

    public void SetTracklist(IList<ParsedTrack> tracklist)
    {
        _tracklist = tracklist;
    }

    public void SetName(string _playlistName)
    {
        this._playlistName = _playlistName;
    }

    public void SetId(string _playlistName)
    {
        this._playlistName = _playlistName;
    }

}
