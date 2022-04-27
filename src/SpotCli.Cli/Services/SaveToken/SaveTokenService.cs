using SpotCli.Application.Interfaces;

namespace SpotCli.Cli.Services;

public class SaveTokenService : ISaveTokenService
{
    private readonly ISpotifyApiConfiguration _configuration;
    public SaveTokenService(ISpotifyApiConfiguration apiConfiguration)
    {
        _configuration = apiConfiguration;
    }
    public string Save(string token)
    {
        var appDataDirectory = _configuration.AppDataDirectory;
        using (StreamWriter sw = new StreamWriter(File.Create(appDataDirectory + "token.json")))
        {
            var tokenJson = "{\"BearerToken\":\"" + token + "\"}";
            sw.WriteLine(tokenJson);
        }
        return $"New token saved.";
    }
}
