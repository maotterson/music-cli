using Refit;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Handlers;

public class GetCurrentlyPlayingQueryHandler
{
    private readonly ISpotifyWebApi _spotifyWebApi;
    public GetCurrentlyPlayingQueryHandler(ISpotifyWebApi spotifyWebApi)
    {
        _spotifyWebApi = spotifyWebApi;
    }
    public async Task<IApiResponse> ExecuteAsync(GetCurrentlyPlayingQuery query)
    {
        return await _spotifyWebApi.GetCurrentlyPlaying();
    }
}
