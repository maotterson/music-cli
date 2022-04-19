using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Cli.Application;

public class ConsoleApplication : IConsoleApplication
{
    private readonly ISpotifyOAuthApi _spotifyOAuthApi;
    private readonly ISpotifyApi _spotifyApi;
    private readonly ISpotifyApiConfiguration _configuration;

    public ConsoleApplication(ISpotifyOAuthApi spotifyOAuthApi, ISpotifyApi spotifyApi, ISpotifyApiConfiguration configuration)
    {
        _spotifyOAuthApi = spotifyOAuthApi;
        _spotifyApi = spotifyApi;
        _configuration = configuration;
    }

    public async Task RunAsync(string[] args)
    {
        
    }
}
