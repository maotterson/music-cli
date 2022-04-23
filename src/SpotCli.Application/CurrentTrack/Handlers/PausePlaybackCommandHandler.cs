using MediatR;
using SpotCli.Application.Api;
using SpotCli.Application.CurrentTrack.Commands;
using SpotCli.Application.CurrentTrack.Responses;
using SpotCli.Application.Exceptions;

namespace SpotCli.Application.CurrentTrack.Handlers;

public class PausePlaybackCommandHandler : IRequestHandler<PausePlaybackCommand, PausePlaybackResponse>
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public PausePlaybackCommandHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }

    public async Task<PausePlaybackResponse> Handle(PausePlaybackCommand request, CancellationToken cancellationToken)
    {
        var response = await _spotifyWebApi.PausePlayback();
        if (response is null || response.Content is null)
        {
            throw new NullReferenceException();
        }

        response.CheckForErrorStatusCode(request);

        return new PausePlaybackResponse();
    }
}
