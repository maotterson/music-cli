using SpotCli.Cli.Configuration;
using SpotCli.Cli.OAuth;
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
    private readonly ISaveTokenService _saveTokenService;
    private readonly ISpotifyApiConfiguration _configuration;

    public ConsoleApplication(ISpotifyOAuthApi spotifyOAuthApi, 
        ISpotifyApi spotifyApi, 
        ISpotifyApiConfiguration configuration,
        ISaveTokenService saveTokenService)
    {
        _spotifyOAuthApi = spotifyOAuthApi;
        _spotifyApi = spotifyApi;
        _configuration = configuration;
        _saveTokenService = saveTokenService;
    }

    public async Task RunAsync(string[] args)
    {
        if (args[0] == "playing")
        {
            var response = await _spotifyApi.GetCurrentlyPlaying();
        }
        else if(args[0] == "refresh")
        {
            var refreshRequest = new GetNewAccessTokenRequest(_configuration.RefreshToken);
            var refreshHeader = new Base64ClientSecretAuthHeader(_configuration.ClientSecret, _configuration.ClientId).Get();
            var response = await _spotifyOAuthApi.GetNewAccessToken(refreshHeader, refreshRequest);
            Console.WriteLine(response.AccessToken);

            var savedMessage = _saveTokenService.Save(response.AccessToken!);
            Console.WriteLine(savedMessage);
        }
    }
}
