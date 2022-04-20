using Refit;
using SpotCli.Cli.Spotify.OAuth;
using SpotCli.Cli.Spotify.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Api;

public interface ISpotifyWebApi
{
    [Get("/me/player/currently-playing")]
    Task<IApiResponse<GetCurrentlyPlayingResponse>> GetCurrentlyPlaying();

    
}
