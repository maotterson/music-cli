using Refit;

namespace SpotCli.Application.Playlists.CreatePlaylist;

public record CreatePlaylistRequestBody
{
    [AliasAs("name")]
    public string? Name { get; set; }

}
