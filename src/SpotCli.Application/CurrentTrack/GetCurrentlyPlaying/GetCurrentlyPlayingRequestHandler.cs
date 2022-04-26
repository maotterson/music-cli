using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.CurrentTrack.GetCurrentlyPlaying;

public class GetCurrentlyPlayingRequestHandler : IRequestHandler<GetCurrentlyPlayingRequest, GetCurrentlyPlayingResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public GetCurrentlyPlayingRequestHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<GetCurrentlyPlayingResponse> Handle(GetCurrentlyPlayingRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.GetCurrentlyPlaying(request.Query);
        if (response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return response.Content!;
    }
}
