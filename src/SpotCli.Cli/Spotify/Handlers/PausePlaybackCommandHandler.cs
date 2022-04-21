using MediatR;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify.Commands;
using SpotCli.Cli.Spotify.Responses;

namespace SpotCli.Cli.Spotify.Handlers;

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

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return new PausePlaybackResponse();
    }
}
