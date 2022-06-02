using Refit;
using SpotCli.Application.Dto;

namespace SpotCli.Application.Playlists.CreatePlaylist;

public class CreatePlaylistResponse
{
    public override string ToString()
    {
        if (Id is null) throw new NullReferenceException(nameof(CreatePlaylistResponse));
        return $"Playlist \"{Name}\" created (Id: {Id}.";
    }
    [AliasAs("id")]
    public string? Id { get; set; }
    [AliasAs("name")]
    public string? Name { get; set; }
}
