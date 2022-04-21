using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.OAuth;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Spotify;

namespace SpotCli.Cli.Application;

public class ConsoleApplication : IConsoleApplication
{
    private readonly ISpotifyWebApi _spotifyApi;
    private readonly ISpotifyOAuthApi _spotifyOAuthApi;
    private readonly ISaveTokenService _saveTokenService;
    private readonly IConsoleCommandFactory _consoleRequestFactory;
    private readonly ISpotifyApiConfiguration _spotifyApiConfiguration;

    public ConsoleApplication(
        ISpotifyWebApi spotifyApi,
        ISpotifyOAuthApi spotifyOAuthApi,
        ISaveTokenService saveTokenService,
        IConsoleCommandFactory consoleRequestFactory,
        ISpotifyApiConfiguration spotifyApiConfiguration)
    {
        _spotifyApi = spotifyApi;
        _spotifyOAuthApi = spotifyOAuthApi;
        _saveTokenService = saveTokenService;
        _consoleRequestFactory = consoleRequestFactory;
        _spotifyApiConfiguration = spotifyApiConfiguration;
    }

    public async Task RunAsync(string[] args)
    {
        var requestObject = _consoleRequestFactory.GetRequestObject(args);
        var response = _requestMediator.Send(requestObject);

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
            var refreshRequest = new GetNewAccessTokenCommand(_spotifyApiConfiguration.RefreshToken);
            var refreshHeader = new Base64ClientSecretAuthHeader(_spotifyApiConfiguration.ClientSecret, _spotifyApiConfiguration.ClientId).Get();
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
