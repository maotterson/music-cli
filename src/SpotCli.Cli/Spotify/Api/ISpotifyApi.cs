using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Api;

public interface ISpotifyApi
{
    [Get("/me/player/currently-playing")]
    Task<string> GetCurrentlyPlaying();

    [Post("/api/token")]
    Task<string> GetNewAccessToken();
}
