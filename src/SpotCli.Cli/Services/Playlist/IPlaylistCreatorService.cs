namespace SpotCli.Cli.Services.Playlist;

public interface IPlaylistCreatorService
{
    public void SetPlaylistSize(int size);
    public void AddTrackUri(string uri);
    public void SetName(string name);
    public bool HasSearchedForAllTracks();
    public string[] UriArray();
    public string? PlaylistId { get; set; }
}