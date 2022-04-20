using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Spotify.Api;
using SpotCli.Cli.Application;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SpotCli.Cli.Spotify.OAuth;
using SpotCli.Cli.Spotify;

var services = new ServiceCollection();
var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("secrets.json")
    .AddJsonFile("token.json")
    .Build();
var configuration = new SpotifyApiConfiguration(configurationBuilder);

services.AddRefitApis(configuration);
services.AddSingletonServices(configuration);

var app = services.BuildServiceProvider()
    .GetRequiredService<IConsoleApplication>();
await app.RunAsync(args);

public static partial class Helpers
{
    public static void AddRefitApis(this IServiceCollection services, ISpotifyApiConfiguration configuration)
    {
        services.AddRefitClient<ISpotifyWebApi>(
            new RefitSettings(
                new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    })))
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri(configuration.BaseAddress);
            client.DefaultRequestHeaders.Add("Authorization", configuration.BearerTokenHeader);
        });
        services.AddRefitClient<ISpotifyOAuthApi>(
            new RefitSettings(
                new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    })))
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri(configuration.OAuthBaseAddress);
        });
    }
    public static void AddSingletonServices(this IServiceCollection services, ISpotifyApiConfiguration configuration)
    {
        services.AddSingleton<ISaveTokenService, SaveTokenService>();
        services.AddSingleton<IConsoleApplication, ConsoleApplication>();
        services.AddSingleton<IConsoleRequestFactory, ConsoleRequestFactory>();
        services.AddSingleton<ISpotifyApiConfiguration, SpotifyApiConfiguration>(_ =>
        {
            return new(configuration.Configuration);
        });
    }
}
