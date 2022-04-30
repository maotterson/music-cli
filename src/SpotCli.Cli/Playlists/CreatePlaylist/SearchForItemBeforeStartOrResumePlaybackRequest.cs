using SpotCli.Application.Playlists.CreatePlaylist;

namespace SpotCli.Cli.Playlists.CreatePlaylist;

public class CreatePlaylistBeforeAddingTracksRequest : CreatePlaylistRequest, IRequestBeforeAddingTracks
{
    public CreatePlaylistBeforeAddingTracksRequest(CreatePlaylistRequest original) : base(original.UserId, original.Body)
    {
    }
}
