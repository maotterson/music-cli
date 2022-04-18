using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Spotify.Api;

public interface ISpotifyApi
{
    [Get("/albums/4aawyAB9vmqN3uQ7FjRGTy")]
    Task<string> GetTokenAsync();
}
