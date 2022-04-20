using CommandLine;
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
    private readonly ISpotifyApi _spotifyApi;
    private readonly ISpotifyOAuthApi _spotifyOAuthApi;
    private readonly ISaveTokenService _saveTokenService;
    private readonly ISpotifyApiConfiguration _configuration;

    public ConsoleApplication(
        ISpotifyApi spotifyApi,
        ISpotifyOAuthApi spotifyOAuthApi, 
        ISaveTokenService saveTokenService,
        ISpotifyApiConfiguration configuration)
    {
        _spotifyApi = spotifyApi;
        _configuration = configuration;
        _spotifyOAuthApi = spotifyOAuthApi;
        _saveTokenService = saveTokenService;
    }

    public async Task RunAsync(string[] args)
    {
        var command = _commandProvider.GetCommand(args);
        var response = command.ExecuteAsync();

        if (args[0] == "playing")
        {
            var response = await _spotifyApi.GetCurrentlyPlaying();
            
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("error."); //todo
                return;
            }
            var content = response.Content;

            Console.WriteLine(content.Item.Artists[0].Name + " - " + content.Item.Name);
        }
        else if(args[0] == "refresh")
        {
            var refreshRequest = new GetNewAccessTokenRequest(_configuration.RefreshToken);
            var refreshHeader = new Base64ClientSecretAuthHeader(_configuration.ClientSecret, _configuration.ClientId).Get();
            var response = await _spotifyOAuthApi.GetNewAccessToken(refreshHeader, refreshRequest);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("error."); //todo
                return;
            }

            var token = response.Content.AccessToken!;
            Console.WriteLine(token);

            var savedMessage = _saveTokenService.Save(token);
            Console.WriteLine(savedMessage);
        }
    }
}
