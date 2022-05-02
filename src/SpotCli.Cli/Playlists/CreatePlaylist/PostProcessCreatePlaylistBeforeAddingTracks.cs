using MediatR.Pipeline;
using SpotCli.Application.Playlists.CreatePlaylist;
using SpotCli.Cli.Services.Playlist;

namespace SpotCli.Cli.Playlists.CreatePlaylist;

public class PostProcessCreatePlaylistBeforeAddingTracks : IRequestPostProcessor<CreatePlaylistBeforeAddingTracksRequest, CreatePlaylistResponse>
{
    private readonly IPlaylistCreatorService _playlistCreatorService;
    public PostProcessCreatePlaylistBeforeAddingTracks(IPlaylistCreatorService playlistCreatorService)
    {
        _playlistCreatorService = playlistCreatorService;
    }

    public Task Process(CreatePlaylistBeforeAddingTracksRequest request, CreatePlaylistResponse response, CancellationToken cancellationToken)
    {
        if(response.Id is null)
        {
            throw new NullReferenceException(nameof(response));
        }
        _playlistCreatorService.PlaylistId = response.Id;

        return Task.CompletedTask;
    }
}
