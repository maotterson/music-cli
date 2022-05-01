using Refit;

namespace SpotCli.Application.Playlists.AddToPlaylist;

public class AddToPlaylistResponse
{
    public override string ToString()
    {
        return "Item added to playlist.";
    }
    [AliasAs("snapshot_id")]
    public string? SnapshotId { get; set; }
}
