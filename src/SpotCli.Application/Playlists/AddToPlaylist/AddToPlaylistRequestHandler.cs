using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.Playlists.AddToPlaylist;

public class AddToPlaylistRequestHandler : IRequestHandler<AddToPlaylistRequest, AddToPlaylistResponse>
{
    private readonly ISpotifyWebApi _api;

    public AddToPlaylistRequestHandler(ISpotifyWebApi api)
    {
        _api = api;
    }

    public async Task<AddToPlaylistResponse> Handle(AddToPlaylistRequest request, CancellationToken cancellationToken)
    {
        var response = await _api.AddToPlaylist(request.PlaylistId, request.Body);

        if (response is null)
        {
            throw new NullReferenceException(nameof(request));
        }

        response.CheckForErrorStatusCode(request);

        return response.Content!;
    }
}
