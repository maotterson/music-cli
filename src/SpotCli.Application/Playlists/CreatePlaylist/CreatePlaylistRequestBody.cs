using Refit;

namespace SpotCli.Application.Playlists.CreatePlaylist;

public record CreatePlaylistRequestBody
{
    [AliasAs("name")]
    public string? Name { get; set; }
    [AliasAs("public")]
    public bool? IsPublic { get; set; }
    [AliasAs("collaborative")]
    public bool? IsCollaborative { get; set; }
    [AliasAs("description")]
    public string? Description { get; set; }

}
