using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.Playlists.CreatePlaylist;

public class CreatePlaylistRequestHandler : IRequestHandler<CreatePlaylistRequest, CreatePlaylistResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public CreatePlaylistRequestHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }
    public async Task<CreatePlaylistResponse> Handle(CreatePlaylistRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.CreatePlaylist(request.UserId, request.Body);

        if(response is null)
        {
            throw new NullReferenceException(nameof(request));
        }

        response.CheckForErrorStatusCode(request);

        return response.Content!;
    }
}
