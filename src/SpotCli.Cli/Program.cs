using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.Api;
using IdentityModel.AspNetCore;
using IdentityModel.Client;

var services = new ServiceCollection();
var configuration = new SpotifyApiConfiguration(
        new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("secrets.json")
            .AddJsonFile("token.json")
            .Build());

var authHeader = $"Bearer {configuration.BearerToken}";
services.AddRefitClient<ISpotifyApi>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri(configuration.BaseAddress);
        client.DefaultRequestHeaders.Add("Authorization", authHeader);
    });

var client = services.BuildServiceProvider()
    .GetRequiredService<ISpotifyApi>();

var response = await client.GetCurrentlyPlaying();
Console.WriteLine(response);

