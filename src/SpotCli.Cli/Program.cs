using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using SpotCli.Application.Apis;
using SpotCli.Application.Interfaces;
using SpotCli.Cli.App;
using SpotCli.Cli.Configuration;
using SpotCli.Cli.Factories;
using SpotCli.Cli.Options.CurrentTrack.GetCurrentlyPlaying;
using SpotCli.Cli.Options.CurrentTrack.PausePlayback;
using SpotCli.Cli.Options.CurrentTrack.StartOrResumePlayback;
using SpotCli.Cli.Options.Devices.GetAvailableDevices;
using SpotCli.Cli.Options.Interfaces;
using SpotCli.Cli.Options.OAuth.GetNewAccessToken;
using SpotCli.Cli.Options.Search;
using SpotCli.Cli.Services;
using System.Reflection;

var appDataDirectory = GetAppDataDirectoryFromSettings();
var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile(appDataDirectory + "secrets.json")
    .AddJsonFile(appDataDirectory + "token.json")
    .AddJsonFile(appDataDirectory + "devices.json")
    .Build();
var configuration = new SpotifyApiConfiguration(configurationBuilder);

var services = new ServiceCollection();
services.AddRefitApis(configuration);
services.AddSingletonServices(configuration);
services.AddOptionsMappers();
services.AddHandlers();

var app = services.BuildServiceProvider()
    .GetRequiredService<IConsoleApplication>();
await app.RunAsync(args);

string GetAppDataDirectoryFromSettings()
{
    return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["AppDataDirectory"] ?? "/AppData";
}

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

        services.AddSingleton<IRequestQueue, RequestQueue>();
        services.AddSingleton<ISearchQueryBus, SearchQueryBus>();
        services.AddSingleton<ISaveTokenService, SaveTokenService>();
        services.AddSingleton<ISaveDevicesService, SaveDevicesService>();
        services.AddSingleton<IConsoleApplication, ConsoleApplication>();
        services.AddSingleton<ISpotifyApiConfiguration, SpotifyApiConfiguration>(_ =>
        {
            return new(configuration.Configuration);
        });
        services.AddSingleton<ICommandLineOptionsResolver, CommandLineOptionsMapper>();
    }
    public static void AddHandlers(this IServiceCollection services)
    {
        var applicationAssembly = Assembly.GetAssembly(typeof(ISpotifyWebApi))!;
        var cliAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(applicationAssembly, cliAssembly);
    }

    public static void AddOptionsMappers(this IServiceCollection services)
    {
        services.AddTransient<PausePlaybackOptionsMapper>();
        services.AddTransient<GetNewAccessTokenOptionsMapper>();
        services.AddTransient<GetAvailableDevicesOptionsMapper>();
        services.AddTransient<GetCurrentlyPlayingOptionsMapper>();
        services.AddTransient<StartOrResumePlaybackOptionsMapper>();
        services.AddTransient<SearchForItemOptionsMapper>();
    }
}
