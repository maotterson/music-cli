using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.CurrentTrack.PausePlayback;

public class PausePlaybackRequestHandler : IRequestHandler<PausePlaybackRequest, PausePlaybackResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public PausePlaybackRequestHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<PausePlaybackResponse> Handle(PausePlaybackRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.PausePlayback(request.Query);
        if (response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return new PausePlaybackResponse();
    }
}
