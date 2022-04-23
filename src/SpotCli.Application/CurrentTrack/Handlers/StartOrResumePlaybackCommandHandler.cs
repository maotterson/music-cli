using MediatR;
using SpotCli.Application.Api;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.CurrentTrack.Handlers;

public class StartOrResumePlaybackCommandHandler : IRequestHandler<StartOrResumePlaybackCommand, StartOrResumePlaybackResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public StartOrResumePlaybackCommandHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<StartOrResumePlaybackResponse> Handle(StartOrResumePlaybackCommand request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.StartOrResumePlayback();
        if (response is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return new StartOrResumePlaybackResponse();
    }
}
