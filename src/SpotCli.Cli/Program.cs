using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.Api;
using IdentityModel.AspNetCore;
using IdentityModel.Client;
using SpotCli.Cli.OAuth;

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

services.AddSingleton<ISaveTokenService, SaveTokenService>();
var client = services.BuildServiceProvider()
    .GetRequiredService<ISpotifyApi>();

// testing seeing a response
var refreshRequest = new GetNewAccessTokenRequest(configuration.RefreshToken);
var refreshHeader = new Base64ClientSecretAuthHeader(configuration.ClientSecret, configuration.ClientId);
var response = await client.GetNewAccessToken(refreshHeader.Get(), refreshRequest);
Console.WriteLine(response);

// testing saving
var saver = services.BuildServiceProvider()
    .GetRequiredService<ISaveTokenService>();
var test = saver.Save("test");