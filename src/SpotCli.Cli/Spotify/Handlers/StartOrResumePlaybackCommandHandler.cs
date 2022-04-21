﻿using MediatR;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify.Commands;
using SpotCli.Cli.Spotify.Responses;

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

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return new StartOrResumePlaybackResponse();
    }
}
