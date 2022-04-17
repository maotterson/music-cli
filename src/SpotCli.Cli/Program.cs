using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.Api;

var services = new ServiceCollection();
var configuration = new SpotifyApiConfiguration(
        new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("secrets.json")
            .Build());

services.AddRefitClient<ISpotifyApi>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri(configuration.BaseAddress);
    });

var client = services.BuildServiceProvider()
    .GetRequiredService<ISpotifyApi>();

var response = await client.GetTokenAsync();

public static class ProgramExtensions
{
    public static void AddConfiguration(this ServiceCollection services)
    {
        
    }
}
