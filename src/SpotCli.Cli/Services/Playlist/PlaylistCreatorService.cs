namespace SpotCli.Cli.Services.Playlist;

public class PlaylistCreatorService
{
    private IList<string> _trackUriList = new List<string>();
    private string? _playlistName;
    private int numberOfTracks = 0;

    public string? PlaylistId { get; set; }

    public void SetName(string _playlistName)
    {
        this._playlistName = _playlistName;
    }
    public bool HasSearchedForAllTracks()
    {
        return _trackUriList.Count >= numberOfTracks;
    }
    public void AddTrackUri(string uri)
    {
        _trackUriList.Add(uri);
    }

    public void SetPlaylistSize(int size)
    {
        numberOfTracks = size;
    }

    public string[] UriArray()
    {
        return _trackUriList.ToArray();
    }
}
