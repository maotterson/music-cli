using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.CurrentTrack.PausePlayback;

public class PausePlaybackCommandHandler : IRequestHandler<PausePlaybackRequest, PausePlaybackResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public PausePlaybackCommandHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<PausePlaybackResponse> Handle(PausePlaybackRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.PausePlayback(request);
        if (response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return new PausePlaybackResponse();
    }
}
