using MediatR;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify.Commands;
using SpotCli.Cli.Spotify.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Handlers;

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
        return new StartOrResumePlaybackResponse();
    }
}
