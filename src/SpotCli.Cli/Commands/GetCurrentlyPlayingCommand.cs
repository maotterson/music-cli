using Refit;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Commands;

public class GetCurrentlyPlayingCommand : IConsoleCommand
{
    private readonly ISpotifyApi _spotifyApi;

    public GetCurrentlyPlayingCommand(ISpotifyApi spotifyApi)
    {
        _spotifyApi = spotifyApi;
    }

    public async Task<IApiResponse> ExecuteAsync()
    {
        return await _spotifyApi.GetCurrentlyPlaying();
    }
}
