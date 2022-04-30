using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;
using SpotCli.Application.Playlists.CreatePlaylist;

namespace SpotCli.Cli.Playlists.CreatePlaylist;

public class CreatePlaylistBeforeAddingTracksRequestHandler : IRequestHandler<CreatePlaylistBeforeAddingTracksRequest, CreatePlaylistResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public CreatePlaylistBeforeAddingTracksRequestHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }
    public async Task<CreatePlaylistResponse> Handle(CreatePlaylistBeforeAddingTracksRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.CreatePlaylist(request.UserId, request.Body); // todo issue with mediatr handling inherited handler method, manual implementation for now

        if (response is null)
        {
            throw new NullReferenceException(nameof(request));
        }

        response.CheckForErrorStatusCode(request);

        return response.Content!;
    } 
}
