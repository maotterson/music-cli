using Refit;

namespace SpotCli.Application.Playlists.AddToPlaylist;

public class AddToPlaylistRequestBody
{
    [AliasAs("uris")]
    public string[]? Uris { get; set; }
    [AliasAs("position")]
    public int? Position { get; set; }
}
