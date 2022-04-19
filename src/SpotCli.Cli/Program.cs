using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.OAuth;
using SpotCli.Cli.Application;

var services = new ServiceCollection();
var configuration = new SpotifyApiConfiguration(
        new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("secrets.json")
            .AddJsonFile("token.json")
            .Build());
services.AddSingleton<ISpotifyApiConfiguration, SpotifyApiConfiguration>(_ =>
    {
        return configuration;
    });

services.AddRefitClient<ISpotifyApi>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri(configuration.BaseAddress);
        client.DefaultRequestHeaders.Add("Authorization", configuration.BearerTokenHeader);
    });
services.AddRefitClient<ISpotifyOAuthApi>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri(configuration.OAuthBaseAddress);
    });
services.AddSingleton<ISaveTokenService, SaveTokenService>();
services.AddSingleton<IConsoleApplication, ConsoleApplication>();
var app = services.BuildServiceProvider()
    .GetRequiredService<IConsoleApplication>();

await app.RunAsync(args);


/*
var client = services.BuildServiceProvider()
    .GetRequiredService<ISpotifyApi>();

var oauth = services.BuildServiceProvider()
    .GetRequiredService<ISpotifyOAuthApi>();

// testing seeing a response
var refreshRequest = new GetNewAccessTokenRequest(configuration.RefreshToken);
var refreshHeader = new Base64ClientSecretAuthHeader(configuration.ClientSecret, configuration.ClientId);
var response = await oauth.GetNewAccessToken(refreshHeader.Get(), refreshRequest);
Console.WriteLine(response);

// testing saving
var saver = services.BuildServiceProvider()
    .GetRequiredService<ISaveTokenService>();
var test = saver.Save(response.AccessToken!);
*/