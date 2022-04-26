using MediatR;
using SpotCli.Application.Apis;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.CurrentTrack.StartOrResumePlayback;

public class StartOrResumePlaybackRequestHandler : IRequestHandler<StartOrResumePlaybackRequest, StartOrResumePlaybackResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public StartOrResumePlaybackRequestHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<StartOrResumePlaybackResponse> Handle(StartOrResumePlaybackRequest request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.StartOrResumePlayback(request.Query, request.Body);
        if (response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return new StartOrResumePlaybackResponse();
    }
}
